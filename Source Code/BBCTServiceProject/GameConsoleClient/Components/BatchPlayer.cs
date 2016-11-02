using GameConsoleClient.Cores;
using GameConsoleClient.Helpers.FEnum;
using GameConsoleClient.Models;
using System.Collections.Generic;

namespace GameConsoleClient.Components
{
    public class BatchPlayer : IGameComponent
    {
        private Tracker tracker;
        public Player[] players;
        public List<Account> listAccount;

        //public BatchPlayer(Tracker Tracker, int amount, int actionCategory)
        //{
        //    this.Tracker = Tracker;

        //    players = new Player[amount];

        //    for (int i = 0; i < players.Length; i++)
        //    {
        //        int category = actionCategory;
        //        if (category == (int)CommonEnum.Category.Random)
        //        {
        //            category = Common.RandomCategory();
        //        }
        //        players[i] = new Player(Program.CountPeer, Tracker, category);
        //        players[i].Start();
        //        Tracker.AddPlayer(players[i]);
        //        Program.CountPeer++;
        //    }
        //}

        public BatchPlayer(Tracker tracker, int amount, List<Account> listAccount, int actionCategory)
        {
            this.tracker = tracker;

            players = new Player[amount];

            this.listAccount = listAccount;

            for (int i = 0; i < players.Length; i++)
            {
                int category = actionCategory;
                if (category == (int)CommonEnum.Action.Random)
                {
                    category = (int)GameConsoleClient.Helpers.Common.Common.RandomCategory();
                }
                Account account = GetOrCreateAccount(i);
                players[i] = new Player(Program.CountPeer, tracker, account, category);
                players[i].Start();
                tracker.AddPlayer(players[i]);
                Program.CountPeer++;
                //System.Threading.Thread.Sleep(1000);
            }
        }

        public void RestartPlayer()
        {
            foreach (var player in players)
            {
                player.ActionCategory = (int)CommonEnum.Action.None;
                //playerPeer.isCalledNonLoopAction = false;
            }
        }

        public void StartActionPlayer(int actionCategory)
        {
            foreach (var player in players)
            {
                int category = actionCategory;
                if (category == (int)CommonEnum.Action.Random)
                {
                    category = (int)GameConsoleClient.Helpers.Common.Common.RandomCategory();
                }
                player.ActionCategory = actionCategory;
            }
        }

        private Account GetOrCreateAccount(int index)
        {
            if (listAccount.Count > index)
            {
                return listAccount[index];
            }
            else
            {
                Account newAccount = GameConsoleClient.Helpers.Common.Common.CreateNewAccount();
                Program.AddNewAccount(newAccount);
                return newAccount;
            }
        }

        public void Start()
        {

        }

        public void Update()
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].Update();
            }
        }
    }
}
