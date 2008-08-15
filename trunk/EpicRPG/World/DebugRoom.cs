using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Entities;
using EpicRPG.Managers;
using EpicRPG.Util;

namespace EpicRPG.World
{
    public class DebugRoom : BaseMap
    {
        public DebugRoom() : base(){
            this.initialize(40, 40);
            WorldEntity grass = WorldManager.getInstance().getWorldEntityByName("grass");
            int grassId = -1;
            if (grass != null)
                grassId = grass.getKeyId();

            for(int x = 0; x < this.terrainGrid.GetUpperBound(0); x++){
                for(int y = 0; y < this.terrainGrid.GetUpperBound(1); y++){
                    this.terrainGrid[x, y] = grassId;
                    this.occupancyGrid[x, y] = grass.passable ? State.Occupancy.UNOCCUPIED : State.Occupancy.OCCUPIED;
                }
            }
        }
    }
}
