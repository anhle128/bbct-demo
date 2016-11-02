using GameServer.MMO.Concepts.Messages;
using GameServer.MMO.Concepts.Messages.Core;
using System;
using System.Collections.Generic;

namespace GameServer.MMO.Concepts
{
    /// <summary>
    /// Là một region nhỏ nằm trong world
    /// </summary>
    public class Region : IDisposable
    {
        #region Properties
        public readonly int col;
        public readonly int row;

        /// <summary>
        /// Danh sách các exchange_items đang trong region
        /// </summary>
        public readonly Dictionary<string, Item> items;

        /// <summary>
        /// Danh sách các item đang lắng nghe region này
        /// </summary>
        public readonly Dictionary<string, Item> itemsSubscription;
        #endregion

        #region Constructor

        public Region(int col, int row)
        {
            this.col = col;
            this.row = row;
            items = new Dictionary<string, Item>();
            itemsSubscription = new Dictionary<string, Item>();
        }

        #endregion

        #region Methods
        public void Enter(Item item)
        {
            if (!items.ContainsKey(item.id))
            {
                items.Add(item.id, item);
                EnterRegionMessage msg = new EnterRegionMessage(item.position, item.currentRegion);
                msg.SetSource(item);
                Publish(msg);
            }
            else
            {
                //Common.CommonLog.Instance.PrintLog("Lỗi : " + item.id + " enter vào region " + col + "-" + row + " bị lỗi");
            }
        }

        public void Exit(Item item, Region newRegion)
        {
            if (items.ContainsKey(item.id))
            {
                items.Remove(item.id);
                ExitRegionMessage msg = new ExitRegionMessage(item.position, newRegion);
                msg.SetSource(item);
                Publish(msg);
            }
            else
            {
                //Common.CommonLog.Instance.PrintLog("Lỗi : " + item.id + " exit region " + col + "-" + row + " bị lỗi");
            }
        }

        public void MoveIn(Item item)
        {
            MoveRegionMessage msg = new MoveRegionMessage(item.position);
            msg.SetSource(item);
            Publish(msg);
        }

        public void Unsubscribe(Item it)
        {
            if (itemsSubscription.ContainsKey(it.id))
            {
                itemsSubscription.Remove(it.id);
            }
            else
            {
                //Common.CommonLog.Instance.PrintLog("Lỗi : " + it.id + " không thể unsubcribe region " + col + "-" + row);
            }
        }

        public void Subscribe(Item it)
        {
            if (!itemsSubscription.ContainsKey(it.id))
            {
                itemsSubscription.Add(it.id, it);
            }
            else
            {
                //Common.CommonLog.Instance.PrintLog("Lỗi : " + it.id + " không thể subcribe region " + col + "-" + row);
            }
        }

        /// <summary>
        /// Gửi message đến tất cả item đang lắng nghe region này
        /// </summary>
        /// <param name="msg">Message kiểu RegionMessage</param>
        public void Publish(RegionMessage msg)
        {
            foreach (Item it in itemsSubscription.Values)
            {
                it.interestArea.OnRecieveRegionChannel(msg);
            }
        }
        #endregion

        #region Implements
        public void Dispose()
        {
            items.Clear();
            itemsSubscription.Clear();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
