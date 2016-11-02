using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExitGames.Threading;
using GameServer.Common;

namespace GameServer.MMO
{
    public class ListCache<T> : IDisposable
    {
        #region Properties

        /// <summary>
        /// Danh sách Items
        /// </summary>
        public readonly List<T> Items;

        /// <summary>
        ///   The reader writer lock.
        /// </summary>
        private readonly ReaderWriterLockSlim _readerWriterLock;
        #endregion

        #region Constructors and Destructors
        public ListCache()
        {
            this.Items = new List<T>();
            this._readerWriterLock = new ReaderWriterLockSlim();
        }

        /// <summary>
        ///   Finalizes an instance of the <see cref = "ItemCache.ItemCacheL2" /> class.
        /// </summary>
        ~ListCache()
        {
            this.DisposeReaderWriterLock();
        }

        /// <summary>
        ///   The dispose reader writer lock.
        /// </summary>
        private void DisposeReaderWriterLock()
        {
            this._readerWriterLock.Dispose();
        }
        #endregion

        #region Methods
        public bool AddItem(T item)
        {
            using (WriteLock.TryEnter(this._readerWriterLock, Settings.Instance.MaxLockWaitTimeMilliseconds))
            {
                Items.Add(item);
                return true;
            }
        }

        public void RemoveItem(int index)
        {
            using (WriteLock.TryEnter(this._readerWriterLock, Settings.Instance.MaxLockWaitTimeMilliseconds))
            {
                CommonLog.Instance.PrintLog(""+Items.Count);
                this.Items.RemoveAt(index);
            }
        }

        public void RemoveItemLast()
        {
            using (WriteLock.TryEnter(this._readerWriterLock, Settings.Instance.MaxLockWaitTimeMilliseconds))
            {
                this.Items.RemoveAt(Items.Count - 1);
            }
        }

        public T TryGetItem(int index)
        {
            using (ReadLock.TryEnter(this._readerWriterLock, Settings.Instance.MaxLockWaitTimeMilliseconds))
            {
                return this.Items[index];
            }
        }

        public void Clear()
        {
            using (WriteLock.TryEnter(this._readerWriterLock, Settings.Instance.MaxLockWaitTimeMilliseconds))
            {
                this.Items.Clear();
            }
        }

        public int Count()
        {
            using (ReadLock.TryEnter(this._readerWriterLock, Settings.Instance.MaxLockWaitTimeMilliseconds))
            {
                return Items.Count;
            }
        }

        #endregion

        #region Implements
        public void Dispose()
        {
            this.DisposeReaderWriterLock();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
