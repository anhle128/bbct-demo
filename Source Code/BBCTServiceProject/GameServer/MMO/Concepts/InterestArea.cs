using GameServer.Common.Enum;
using GameServer.Common.SerializeData.EventData;
using GameServer.MMO.Concepts.Messages;
using GameServer.MMO.Concepts.Messages.Core;
using System;
using System.Collections.Generic;

namespace GameServer.MMO.Concepts
{
    /// <summary>
    /// Quản lý việc quan sát của một Item
    /// Chịu trách nhiệm gửi về tất cả các event về trạng thái của các Item trong vùng quan sát được
    /// </summary>
    public class InterestArea : IDisposable
    {
        #region Properties
        public readonly Item owner;
        public readonly int distance;

        /// <summary>
        /// Danh sách các item mà interest area này đang theo dõi
        /// </summary>
        public readonly Dictionary<string, Item> interestItems;

        /// <summary>
        /// Danh sách các region mà interest area này đang quan sát được
        /// </summary>
        private List<Region> regions;

        #endregion

        #region Constructor

        public InterestArea(Item owner, int distance)
        {
            this.owner = owner;
            this.distance = distance;
            regions = new List<Region>();
            interestItems = new Dictionary<string, Item>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Cập nhật tất cả trạng thái mỗi khi Item thay đổi vị trí
        /// </summary>
        public void Update()
        {
            List<Region> newRegions = owner.currentWorld.GetInterestRegion(owner.position, distance);

            foreach (Region re in regions)
            {
                if (!newRegions.Contains(re))
                {
                    re.Unsubscribe(owner);

                    foreach (Item it in re.items.Values)
                    {
                        if (it != owner)
                        {
                            UnsubscriptionInterestMessage imsg = new UnsubscriptionInterestMessage();
                            imsg.SetSource(it);
                            owner.OnRecieveInterestArea(imsg, 1);
                        }
                    }
                }
            }

            foreach (Region re in newRegions)
            {
                if (!regions.Contains(re))
                {
                    re.Subscribe(owner);

                    foreach (Item it in re.items.Values)
                    {
                        if (it != owner)
                        {
                            SubscriptionInterestMessage imsg = new SubscriptionInterestMessage(it.position);
                            imsg.SetSource(it);
                            owner.OnRecieveInterestArea(imsg, 1);
                        }
                    }
                }
            }

            regions = newRegions;

            int[] interestCol = new int[regions.Count];
            int[] interestRow = new int[regions.Count];
            for (int i = 0; i < regions.Count; i++)
            {
                interestCol[i] = regions[i].col;
                interestRow[i] = regions[i].row;
            }
            UpdateInterestAreaEventData evData = new UpdateInterestAreaEventData()
            {
                interestCol = interestCol,
                interestRow = interestRow
            };
            owner.owner.SendEvent((byte)EventCode.UpdateInterestArea, evData.Serialize());
        }

        public void Exit()
        {
            foreach (Region re in regions)
            {
                re.Unsubscribe(owner);
            }
        }

        /// <summary>
        /// Được gọi mỗi khi nhận được message từ các region đang theo dõi gửi về
        /// </summary>
        /// <param name="msg"></param>
        public void OnRecieveRegionChannel(RegionMessage msg)
        {
            if (msg.source != owner)
            {
                switch (msg.type)
                {
                    case RegionMessage.Type.Enter:
                        EnterRegionMessage enMsg = (EnterRegionMessage)msg;
                        if (enMsg.oldRegion == null)
                        {
                            SubscriptionInterestMessage imsg = new SubscriptionInterestMessage(enMsg.position);
                            imsg.SetSource(msg.source);
                            owner.OnRecieveInterestArea(imsg, (byte)3);
                        }
                        else
                        {
                            if (regions.Contains(enMsg.oldRegion))
                            {
                                // Không cần send msg vì trường hợp này sau vì client đang theo dõi cả region mới và cũ của item này
                                // Nên sau khi nhận được Message Enter sẽ nhận được message exit. Nên không cần xử lý ở đây tránh trùng lặp
                            }
                            else
                            {
                                SubscriptionInterestMessage imsg = new SubscriptionInterestMessage(enMsg.position);
                                imsg.SetSource(msg.source);
                                owner.OnRecieveInterestArea(imsg, 4);
                            }
                        }
                        break;
                    case RegionMessage.Type.Move:
                        MoveRegionMessage mMsg = (MoveRegionMessage)msg;
                        MoveInterestMessage iMovemsg = new MoveInterestMessage(mMsg.position);
                        iMovemsg.SetSource(msg.source);
                        owner.OnRecieveInterestArea(iMovemsg, 5);
                        break;
                    case RegionMessage.Type.Exit:
                        ExitRegionMessage eMsg = (ExitRegionMessage)msg;
                        if (eMsg.newRegion == null)
                        {
                            UnsubscriptionInterestMessage imsg = new UnsubscriptionInterestMessage();
                            imsg.SetSource(msg.source);
                            owner.OnRecieveInterestArea(imsg, 6);
                        }
                        else
                        {
                            if (regions.Contains(eMsg.newRegion))
                            {
                                MoveInterestMessage imsg = new MoveInterestMessage(eMsg.position);
                                imsg.SetSource(msg.source);
                                owner.OnRecieveInterestArea(imsg, 7);
                            }
                            else
                            {
                                UnsubscriptionInterestMessage imsg = new UnsubscriptionInterestMessage();
                                imsg.SetSource(msg.source);
                                owner.OnRecieveInterestArea(imsg, 8);
                            }
                        }
                        break;
                    case RegionMessage.Type.ChangeAvatar:
                        ChangeAvatarRegionMessage caMsg = (ChangeAvatarRegionMessage)msg;
                        ChangeAvatarInterestMessage iCaMsg = new ChangeAvatarInterestMessage(caMsg.avatar);
                        iCaMsg.SetSource(msg.source);
                        owner.OnRecieveInterestArea(iCaMsg, 9);
                        break;
                }
            }
        }

        #endregion

        #region Implement
        public void Dispose()
        {
            interestItems.Clear();
            regions.Clear();
            regions = null;
        }
        #endregion

        public List<Region> GetInterestRegion()
        {
            return regions;
        }
    }
}
