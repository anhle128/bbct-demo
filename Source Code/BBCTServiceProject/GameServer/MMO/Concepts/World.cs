using ExitGames.Concurrency.Fibers;
using System;
using System.Collections.Generic;

namespace GameServer.MMO.Concepts
{
    public class World : IDisposable
    {
        #region Properties
        public readonly string name;
        public readonly float sizeRegion;
        public readonly int width;
        public readonly int height;
        public readonly Vector2D bottomLeft;
        public readonly Region[,] regions;

        public readonly PoolFiber fiber;
        #endregion

        #region Constructor
        public World(string name, int width,
            int height, float sizeRegion, Vector2D bottomLeft)
        {
            this.name = name;
            this.sizeRegion = sizeRegion;
            this.bottomLeft = bottomLeft;
            this.width = width;
            this.height = height;

            regions = new Region[width, height];
            for (int c = 0; c < width; c++)
            {
                for (int r = 0; r < height; r++)
                {
                    regions[c, r] = new Region(c, r);
                }
            }
            fiber = new PoolFiber();
            fiber.Start();
        }
        #endregion

        #region Implements
        public void Dispose()
        {
            for (int c = 0; c < width; c++)
            {
                for (int r = 0; r < width; r++)
                {
                    regions[c, r].Dispose();
                }
            }
            fiber.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Methods
        public Region GetRegion(Vector2D position)
        {
            if (position.x < bottomLeft.x || position.x > bottomLeft.x + (width * sizeRegion))
            {
                //Common.CommonLog.Instance.PrintLog("Try get region out of range (X) . Position : (" + position.x + "," + position.y + ")");
                return null;
            }
            if (position.y < bottomLeft.y || position.y > bottomLeft.y + (height * sizeRegion))
            {
                //Common.CommonLog.Instance.PrintLog("Try get region out of range (Y) . Position : (" + position.x + "," + position.y + ")");
                return null;
            }

            float defX = (position.x - bottomLeft.x);
            int col = (int)(defX / sizeRegion);
            /*
            if (defX % sizeRegion > 0)
            {
                col++;
            }*/
            if (col >= width || col < 0)
            {
                //Common.CommonLog.Instance.PrintLog("Try get region out of range . Index : "+index+" - Position : ("+position.x+","+position.y+")");
                return null;
            }

            float defY = (position.y - bottomLeft.y);
            int row = (int)(defY / sizeRegion);
            /*
            if (defY % sizeRegion > 0)
            {
                row++;
            }*/
            if (row >= height || row < 0)
            {
                //Common.CommonLog.Instance.PrintLog("Try get region out of range . Index : "+index+" - Position : ("+position.x+","+position.y+")");
                return null;
            }

            return regions[col, row];
        }

        public List<Region> GetInterestRegion(Vector2D position, int interestDistance)
        {
            List<Region> result = new List<Region>();
            Region original = GetRegion(position);
            if (original != null)
            {
                result.Add(original);
                for (int col = original.col - interestDistance; col <= original.col + interestDistance; col++)
                {
                    for (int row = original.row - interestDistance; row <= original.row + interestDistance; row++)
                    {
                        if (col >= 0 && col < width && row >= 0 && row < height)
                        {
                            if (regions[col, row] != original)
                            {
                                result.Add(regions[col, row]);
                            }
                            
                        }
                    }
                }
            }
            return result;
        }
        #endregion
    }
}
