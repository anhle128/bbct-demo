using ExitGames.Threading;
using System;
using System.Collections.Generic;
using System.Threading;

namespace GameServer.MMO.Concepts
{
    /// <summary>
    /// Là một collection Key(String) có lock để an toàn khi sử dụng trong Concurentcy
    /// </summary>
    /// <typeparam name="T">Kiểu Value</typeparam>
    public class ObjectCache<T> : IDisposable
    {
        #region Properties

        /// <summary>
        /// Danh sách exchange_items
        /// </summary>
        public readonly Dictionary<string, T> items;

        /// <summary>
        ///   The reader writer lock.
        /// </summary>
        public readonly ReaderWriterLockSlim readerWriterLock;
        #endregion

        #region Constructors and Destructors
        public ObjectCache()
        {
            this.items = new Dictionary<string, T>();
            this.readerWriterLock = new ReaderWriterLockSlim();
        }

        /// <summary>
        ///   Finalizes an instance of the <see cref = "ItemCache.ItemCacheL2" /> class.
        /// </summary>
        ~ObjectCache()
        {
            this.DisposeReaderWriterLock();
        }
        #endregion

        #region Methods
        public bool AddItem(string id, T item)
        {
            using (WriteLock.TryEnter(this.readerWriterLock, Settings.Instance.MaxLockWaitTimeMilliseconds))
            {
                if (this.items.ContainsKey(id))
                {
                    return false;
                }

                this.items.Add(id, item);
                return true;
            }
        }

        public bool RemoveItem(string id)
        {
            using (WriteLock.TryEnter(this.readerWriterLock, Settings.Instance.MaxLockWaitTimeMilliseconds))
            {
                return this.items.Remove(id);
            }
        }

        public bool TryGetItem(string id, out T item)
        {
            using (ReadLock.TryEnter(this.readerWriterLock, Settings.Instance.MaxLockWaitTimeMilliseconds))
            {
                return this.items.TryGetValue(id, out item);
            }
        }

        public void Clear()
        {
            using (WriteLock.TryEnter(this.readerWriterLock, Settings.Instance.MaxLockWaitTimeMilliseconds))
            {
                this.items.Clear();
            }
        }

        public int Count()
        {
            using (ReadLock.TryEnter(this.readerWriterLock, Settings.Instance.MaxLockWaitTimeMilliseconds))
            {
                return this.items.Count;
            }
        }

        /// <summary>
        ///   The dispose reader writer lock.
        /// </summary>
        private void DisposeReaderWriterLock()
        {
            this.readerWriterLock.Dispose();
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
