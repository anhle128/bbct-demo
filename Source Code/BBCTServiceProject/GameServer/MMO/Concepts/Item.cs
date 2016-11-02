using ExitGames.Concurrency.Fibers;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.EventData;
using GameServer.MMO.Concepts.Messages;
using GameServer.MMO.Concepts.Messages.Core;
using GameServer.Server;
using System;

namespace GameServer.MMO.Concepts
{
    /// <summary>
    /// Đóng vai trò một nhân vật trong một world
    /// </summary>
    public class Item : IDisposable
    {
        #region Properties
        public readonly string id;
        public Vector2D position;
        public readonly InterestArea interestArea;

        public readonly World currentWorld;
        public Region currentRegion;
        public readonly MMOPeer owner;

        /// <summary>
        /// Tham chiếu đến Fiber chung cuả cả world
        /// </summary>
        public readonly PoolFiber fiber;

        #endregion

        #region Constructors and Destructors
        public Item(string id, Vector2D position, World world, MMOPeer owner)
        {
            this.id = id;
            this.owner = owner;
            this.position = position;
            this.currentWorld = world;
            this.fiber = world.fiber;
            interestArea = new InterestArea(this, Settings.Instance.InterestDistance);
        }

        ~Item()
        {
            this.Dispose(false);
        }
        #endregion

        #region Implements
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Methods
        public void Spawn()
        {
            fiber.Enqueue(() => UpdatePosition(this.position));
        }

        public void Move(Vector2D newPosition)
        {
            fiber.Enqueue(() => UpdatePosition(newPosition));
        }

        private void UpdatePosition(Vector2D newPosition)
        {
            owner.Player.cacheData.x = newPosition.x;
            owner.Player.cacheData.y = newPosition.y;
            UpdateRegion(newPosition);
            interestArea.Update();
        }

        public void ExitWorld()
        {
            if (currentRegion != null)
            {
                fiber.Enqueue(() => Exit());
            }
        }

        private void Exit()
        {
            currentRegion.Exit(this, null);
            interestArea.Exit();
        }

        private void UpdateRegion(Vector2D newPosition)
        {
            Region newRegion = this.currentWorld.GetRegion(newPosition);
            if (newRegion == null)
            {
                //Common.CommonLog.Instance.PrintLog("Lỗi : " + id + " đã di chuyển ra ngoài world");
            }
            else
            {
                //Spawn
                if (currentRegion == null)
                {
                    newRegion.Enter(this);
                    currentRegion = newRegion;
                }
                else //Move
                {
                    this.position = newPosition;
                    if (currentRegion == newRegion)
                    {
                        currentRegion.MoveIn(this);
                    }
                    else
                    {
                        currentRegion.Exit(this, newRegion);
                        newRegion.Enter(this);
                        currentRegion = newRegion;
                    }
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                interestArea.Dispose();
                currentRegion = null;
            }
        }

        public void OnRecieveInterestArea(InterestMessage msg, byte code)
        {
            switch (msg.type)
            {
                case InterestMessage.Type.Subscription:
                    SubscriptionInterestMessage sMsg = (SubscriptionInterestMessage)msg;
                    if (interestArea.interestItems.Count < Settings.Instance.maxSubscription &&
                        msg.source.owner != null &&
                        msg.source.owner.Player != null &&
                        msg.source.owner.Player.cacheData != null)
                    {
                        ItemSubscribedEventData sData = new ItemSubscribedEventData();
                        sData.username = msg.source.id;
                        sData.itemType = 1;
                        sData.posX = sMsg.position.x;
                        sData.posY = sMsg.position.y;
                        sData.avatar = msg.source.owner.Player.cacheData.avatar;
                        sData.level = msg.source.owner.Player.cacheData.level;
                        sData.nickname = msg.source.owner.Player.cacheData.nickname;
                        sData.vip = msg.source.owner.Player.cacheData.vip;
                        sData.title = msg.source.owner.Player.cacheData.title;
                        sData.star = msg.source.owner.Player.cacheData.avatar_star;
                        owner.SendEvent((byte)EventCode.ItemSubscribed, sData.Serialize());

                        if (!interestArea.interestItems.ContainsKey(msg.source.id))
                        {
                            interestArea.interestItems.Add(msg.source.id, msg.source);
                        }
                        else
                        {
                            //Common.CommonLog.Instance.PrintLog("Lỗi " + code + " : " + id + " không thể thêm interest item " + msg.source.id);
                        }
                    }
                    break;
                case InterestMessage.Type.Move:
                    MoveInterestMessage mMsg = (MoveInterestMessage)msg;
                    if (interestArea.interestItems.ContainsKey(msg.source.id) && mMsg.position != null)
                    {
                        ItemMoveEventData mData = new ItemMoveEventData()
                        {
                            itemId = msg.source.id,
                            itemType = 1,
                            posX = mMsg.position.x,
                            posY = mMsg.position.y
                        };
                        owner.SendEvent((byte)EventCode.ItemMoved, mData.Serialize());
                    }
                    break;
                case InterestMessage.Type.Unsubscription:
                    if (interestArea.interestItems.ContainsKey(msg.source.id))
                    {
                        ItemUnsubscribedEventData uData = new ItemUnsubscribedEventData()
                        {
                            itemId = msg.source.id,
                            itemType = 1
                        };
                        owner.SendEvent((byte)EventCode.ItemUnsubscribed, uData.Serialize());

                        if (interestArea.interestItems.ContainsKey(msg.source.id))
                        {
                            interestArea.interestItems.Remove(msg.source.id);
                        }
                        else
                        {
                            //Common.CommonLog.Instance.PrintLog("Lỗi " + code + " : " + id + " không thể xóa interest item " + msg.source.id);
                        }
                    }
                    break;
                case InterestMessage.Type.ChangeAvatar:
                    ChangeAvatarInterestMessage caMsg = (ChangeAvatarInterestMessage)msg;
                    if (interestArea.interestItems.ContainsKey(msg.source.id))
                    {
                        ChangeAvatarEventData mData = new ChangeAvatarEventData()
                        {
                            username = msg.source.id,
                            avatar = caMsg.avatar,
                        };
                        owner.SendEvent((byte)EventCode.ChangeAvatar, mData.Serialize());
                    }
                    break;
            }
        }
        #endregion
    }
}
