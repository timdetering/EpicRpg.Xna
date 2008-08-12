using System;
using System.Collections.Generic;
using System.Text;

using EpicRPG.Util;
using Microsoft.Xna.Framework;

namespace EpicRPG.Managers
{
    public class WorldManager : Singleton<WorldManager>
    {
        private State.Occupancy[,] occupancyGrid;
        private int[,] entityGrid;
        private int[,] terrainGrid;
    }
}
