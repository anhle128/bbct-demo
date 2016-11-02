using System;

namespace GameServer.MMO.Concepts
{
    /// <summary>
    /// Quản lý tất cả các world trong game
    /// </summary>
    public class WorldCache : IDisposable
    {
        #region Properties
        public static readonly WorldCache Instance = new WorldCache();
        private readonly ObjectCache<World> worlds;

        #endregion

        #region Constructor
        public WorldCache()
        {
            worlds = new ObjectCache<World>();
        }
        #endregion

        #region Methods
        public bool TryCreate(string name, int width,
            int height, float sizeRegion, Vector2D bottomLeft, out World world)
        {
            world = new World(name, width, height, sizeRegion, bottomLeft);
            return worlds.AddItem(name, world);
        }

        public bool TryGet(string name, out World world)
        {
            return worlds.TryGetItem(name, out world);
        }

        #endregion

        #region Implements
        public void Dispose()
        {
            worlds.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
