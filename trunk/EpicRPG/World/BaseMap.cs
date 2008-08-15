using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using Microsoft.Xna.Framework;
using EpicRPG.Managers;
using Microsoft.Xna.Framework.Graphics;

namespace EpicRPG.World
{
    public class BaseMap
    {
        protected State.Occupancy[,] occupancyGrid;
        protected int[,] entityGrid;
        protected int[,] terrainGrid;

        protected int gridWidth, gridHeight;
        public int CELL_WIDTH, CELL_HEIGHT;

        public virtual void initialize(int cellWidth, int cellHeight){
            this.gridWidth = cellWidth;
            this.gridHeight = cellHeight;
            this.occupancyGrid = new State.Occupancy[cellWidth, cellHeight];
            this.entityGrid = new int[cellWidth, cellHeight];
            this.terrainGrid = new int[cellWidth, cellHeight];
        }

        public virtual void initialize(int pixWidth, int pixHeight, int cellWidth, int cellHeight){

        }

        public virtual void Update(GameTime gameTime){
            //do we need this one?
        }

        public virtual void Draw(){
            Vector2 loc = new Vector2(0,0);
            foreach(int id in this.terrainGrid){
                OutputManager.getInstance().Render_Static(
                    WorldManager.getInstance().getWorldEntityById(id).texture.texture,
                    loc,
                    Color.White
                );
            }
        }
    }
}
