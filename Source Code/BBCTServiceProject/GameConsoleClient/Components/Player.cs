using DynamicDBModel;
using ExitGames.Client.Photon;
using GameConsoleClient.Action;
using GameConsoleClient.Configs;
using GameConsoleClient.Cores;
using GameConsoleClient.Helpers.Common;
using GameConsoleClient.Helpers.FEnum;
using GameConsoleClient.Models;
using GameConsoleClient.OperationHandler;
using GameConsoleClient.Webservice;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using System;
using System.Collections.Generic;

namespace GameConsoleClient.Components
{
    public class Player : IGameComponent
    {
        public int id;
        public const float DistanceX = 300f;
        public PlayerPeer PlayerPeer;
        public PhotonPeer Peer;
        public int ActionCategory { get; set; }

        private bool _isCalledNonLoopAction = false;

        public string Token;

        public Account Account;

        int level;

        public Entity DynamicData;

        public enum State
        {
            Wait,
            Connected,
            Loging,
            Logined,
            InWorld,
            Disconnect,
            LoginService
        };

        private bool isCalledAction = false;

        public State state = State.Wait;

        private DateTime tmpTracker;
        public DateTime tmpTime = DateTime.Now;
        public DateTime tmpTimeAvata = DateTime.Now;

        private DateTime timeTrackFPS;

        public Tracker Tracker;

        public float X;
        public float Y;

        private Dictionary<OperationCode, IOperationHandleable> _dictOperationFactory;
        private Dictionary<CommonEnum.Action, AbsAction> _dictActionFactory;

        public Player(int id, Tracker tracker, int actionCategory)
        {
            this.id = id;
            this.Tracker = tracker;
            this.ActionCategory = actionCategory;
            //_account = account;
        }

        public Player(int id, Tracker tracker, Models.Account account, int category)
        {
            this.id = id;
            this.Tracker = tracker;
            this.ActionCategory = category;
            this.Account = account;

            CreateOperationFactory();
        }


        public void CreateOperationFactory()
        {
            _dictActionFactory = new Dictionary<CommonEnum.Action, AbsAction>()
            {
                { CommonEnum.Action.AttackMap, new ActionAttackMap(this)}
            };

            _dictOperationFactory = new Dictionary<OperationCode, IOperationHandleable>()
            {
                {OperationCode.CreateAccount, new CreateAccountHandler(this,OperationCode.CreateAccount)}, 
                {OperationCode.SignIn, new SignInHandler(this,OperationCode.SignIn)},
                {OperationCode.EnterWorld, new EnterWorldHandler(this,OperationCode.EnterWorld)},
                {OperationCode.MoveTo, new MoveHandler(this,OperationCode.MoveTo)},
                {OperationCode.StartAttackStage, new StartAttackStageHandler(this,OperationCode.StartAttackStage,_dictActionFactory[CommonEnum.Action.AttackMap])},
                {OperationCode.EndAttackStage, new EndAttackStage(this,OperationCode.EndAttackStage,_dictActionFactory[CommonEnum.Action.AttackMap])}
            };
        }

        public void Start()
        {
            PlayerPeer = new PlayerPeer(id);

            PlayerPeer.OperationResponse += OperationResponse;
            PlayerPeer.StatusChanged += OnStatusChanged;
            PlayerPeer.EventResponse += OnEventResponse;

            state = State.Wait;

            CreatePeerConnectToPhoton();

            SignInService();
        }

        private void CreatePeerConnectToPhoton()
        {
            Console.WriteLine("Call CreatePeerConnectToPhoton");
            Peer = new PhotonPeer(PlayerPeer, ConnectionProtocol.Udp);
            bool isConnected = Peer.Connect(Program.UrlPhoton + ":5055", Program.AppName);
            Peer.Service();
        }

        const double delayBetweenAction = 2;
        const double delayBetweenChangeAvata = 5;
        private int p;
        private Tracker tracker1;

        public void Update()
        {
            if (Peer != null)
            {
                Peer.Service();
            }
            if (state != State.Disconnect && state != State.LoginService)
            {
                if (timeTrackFPS == null)
                {
                    timeTrackFPS = DateTime.Now;
                }
                else
                {
                    if ((DateTime.Now - timeTrackFPS).TotalMilliseconds >= 1000f / Config.OUT_FPS)
                    {
                        Tracker.Plus(Tracker.Param.OutFPS);
                    }
                    timeTrackFPS = DateTime.Now;
                }

                if (Peer.PeerState == PeerStateValue.Connected && state == State.Connected)
                {
                    DoOperationRequest(OperationCode.SignIn, null);
                }
                else if (state == State.InWorld && ActionCategory != (int)CommonEnum.Action.None)
                {
                    if (ActionCategory != (short)CommonEnum.Action.Move)
                    {
                        if (!isCalledAction)
                        {
                            StartNewAction();
                            isCalledAction = true;
                        }
                    }
                    if ((DateTime.Now - tmpTime).TotalSeconds > delayBetweenAction)
                    {
                        LoopActionGame((CommonEnum.Action)ActionCategory);
                        tmpTime = DateTime.Now;
                    }
                    if ((DateTime.Now - tmpTimeAvata).TotalSeconds >= delayBetweenChangeAvata)
                    {
                        tmpTimeAvata = DateTime.Now;
                    }
                }
            }
        }

        public void LoopActionGame(CommonEnum.Action category)
        {
            switch (category)
            {
                case CommonEnum.Action.Move:
                    DoOperationRequest(OperationCode.MoveTo, null);
                    break;
            }
        }


        public void NonLoopActionGame(int actionCategory)
        {

        }

        public void StartNewAction()
        {

            if (ActionCategory == (short)CommonEnum.Action.Random)
            {
                CommonEnum.Action category = GameConsoleClient.Helpers.Common.Common.RandomCategory();
                _dictActionFactory[category].DoAction();
            }
            else
            {
                _dictActionFactory[(CommonEnum.Action)ActionCategory].DoAction();
            }
        }

        public void OperationResponse(OperationResponse operationResponse)
        {
            Tracker.Plus(Tracker.Param.AmountResponse);
            //Console.WriteLine("------------------ OperationResponse {0} ----------------------", (OperationCode)operationResponse.OperationCode);
            _dictOperationFactory[(OperationCode)operationResponse.OperationCode].OnResponse(operationResponse);
        }

        public void DoOperationRequest(OperationCode code, Dictionary<byte, object> dataRequest)
        {
            _dictOperationFactory[code].OnRequest(dataRequest);
            Tracker.Plus(Tracker.Param.AmountRequest);
        }


        public void OnEventResponse(EventData eventData)
        {
            Tracker.Plus(Tracker.Param.AmountResponse);
            TimeSpan ts = (DateTime.Now - tmpTracker);
            if (ts.TotalMilliseconds >= Config.OUT_EVENT_RADAR_TIME)
            {
                Tracker.Plus(Tracker.Param.OutTimeRadar);
            }
            tmpTracker = DateTime.Now;
            Tracker.Plus(Tracker.Param.AmountEventRadar);
        }

        public void OnStatusChanged(PlayerPeer.State state)
        {
            Console.WriteLine("------------------ OnStatusChanged ----------------------");
            Console.WriteLine(string.Format("playerPeer {0} OnStatusChanged {1} ", id, state.ToString()));
            if (this.state != State.Disconnect)
            {
                if (state == PlayerPeer.State.Connected && this.state == State.Wait)
                {
                    this.state = State.Connected;
                }
                else if (state == PlayerPeer.State.Disconnect)
                {
                    this.state = State.Disconnect;
                }
            }
        }

        public string GetUsername()
        {
            return Account.Username.Replace("-", "");
        }

        #region Sign In
        public void SignInPhoton()
        {
            state = State.Loging;

            SignInRequestData signinRequest = new SignInRequestData();
            signinRequest.token = Account.Token;


            Peer.OpCustom((byte)OperationCode.SignIn, signinRequest.Serialize(), true);
            Tracker.Plus(Tracker.Param.AmountRequest);
        }

        public void SignInService()
        {
            state = State.Loging;
            Dictionary<string, string> dictRequest = new Dictionary<string, string>();
            dictRequest.Add("username", Account.Username);
            dictRequest.Add("password", Account.Password);

            string responseSignIn = DRestClient.Instance.SignIn(dictRequest);
            CommonEnum.STATUS status = GameConsoleClient.Helpers.Common.Common.GetStatusResponse(responseSignIn);
            if (status == CommonEnum.STATUS.SUCCESS)
            {
                Account.Token = GameConsoleClient.Helpers.Common.Common.GetTokenResponse(responseSignIn);
                state = State.Connected;
            }
            else if (status == CommonEnum.STATUS.USER_DOES_NOT_EXSIT)
            {
                // Create account
                SignUpServer();
            }
        }
        #endregion

        #region Sign Up
        private void SignUpServer()
        {
            Dictionary<string, string> dictRequest = new Dictionary<string, string>();
            dictRequest.Add("username", Account.Username);
            dictRequest.Add("password", Account.Password);
            string responseSignIn = DRestClient.Instance.SignUp(dictRequest);
            CommonEnum.STATUS status = GameConsoleClient.Helpers.Common.Common.GetStatusResponse(responseSignIn);
            if (status == CommonEnum.STATUS.SUCCESS)
            {
                Account.Token = GameConsoleClient.Helpers.Common.Common.GetTokenResponse(responseSignIn);
                state = State.Connected;
            }
        }
        #endregion


    }
}
