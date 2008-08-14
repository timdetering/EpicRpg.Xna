using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;

namespace EpicRPG.World
{
    public class BaseMap
    {
        private State.Occupancy[,] occupancyGrid;
        private int[,] entityGrid;
        private int[,] terrainGrid;

        public virtual void initialize(int width, int height){
            this.occupancyGrid = new State.Occupancy[width, height];
            this.entityGrid = new int[width, height];
            this.terrainGrid = new int[width, height];
        }
    }
}
