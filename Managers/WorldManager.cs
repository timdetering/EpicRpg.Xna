using System;
using System.Collections.Generic;
using System.Text;

using EpicRPG.Util;

namespace EpicRPG.Managers
{
    public class WorldManager : Singleton<WorldManager>
    {
        public enum Occupancy{
            OCCUPIED, UNOCCUPIED
        }

        private byte[,] occupancyGrid;
        private long[,] entityGrid;
        private long[,] terrainGrid;
    }
}
