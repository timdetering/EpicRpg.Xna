using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using Microsoft.Xna.Framework;
using EpicRPG.Managers;
using Microsoft.Xna.Framework.Graphics;
using EpicRPG.Entities;

namespace EpicRPG.World
{
    public class BaseMap
    {
        public State.Occupancy[,] occupancyGrid;
        public int[,] entityGrid;
        public int[,] terrainGrid;

        public int gridWidth, gridHeight;
        public int CELL_WIDTH = 32, CELL_HEIGHT = 32;

        public virtual void initialize(int cellWidth, int cellHeight){
            this.gridWidth = cellWidth;
            this.gridHeight = cellHeight;
            this.occupancyGrid = new State.Occupancy[cellWidth, cellHeight];
            this.entityGrid = new int[cellWidth, cellHeight];
            this.terrainGrid = new int[cellWidth, cellHeight];

            for(int x = 0; x < cellWidth; x++){
                for(int y = 0; y < cellHeight; y++){
                    this.occupancyGrid[x, y] = State.Occupancy.OCCUPIED;
                    this.entityGrid[x, y] = -1;
                    this.terrainGrid[x, y] = -1;
                }
            }
        }

        public virtual void initialize(int pixWidth, int pixHeight, int cellWidth, int cellHeight)
        {

        }

        public bool withinBoundaries(float x, float y){
            return this.withinBoundaries((int)x, (int)y);
        }

        public bool withinBoundaries(int x, int y){
            return !(x < 0 || y < 0 || x >= this.gridWidth || y >= this.gridHeight);
        }

        public virtual void setCell(int x, int y, WorldEntity we){
            if(this.withinBoundaries(x, y)){
                if(we != null){
                    this.terrainGrid[x, y] = we.getKeyId();
                    this.occupancyGrid[x, y] = we.passable ? State.Occupancy.UNOCCUPIED : State.Occupancy.OCCUPIED;
                }
                else{
                    this.terrainGrid[x, y] = -1;
                    this.occupancyGrid[x, y] = State.Occupancy.OCCUPIED;
                }
            }
        }

        public virtual void Update(GameTime gameTime){
            //do we need this one?
        }

        public virtual void Draw(){
            Vector2 loc = new Vector2(0,0);
            bool mask = ConfigurationManager.getInstance().drawOccupancyGrid;
            WorldEntity we;

            for (int x = 0; x < this.terrainGrid.GetUpperBound(0); x++){
                for (int y = 0; y < this.terrainGrid.GetUpperBound(1); y++){
                    loc.X = x * this.CELL_WIDTH;
                    loc.Y = y * this.CELL_HEIGHT;

                    we = WorldManager.getInstance().getWorldEntityById(this.terrainGrid[x,y]);

                    if(we != null){
                        OutputManager.getInstance().Render_Static(
                            we.texture.texture,
                            loc,
                            (mask && this.occupancyGrid[x,y] == State.Occupancy.OCCUPIED ? Color.Black : Color.White)
                        );
                    }
                }
            }
        }

        public bool requestMove(int entityId, Vector2 curLoc, Vector2 requestedLocation){
            curLoc = this.translate(curLoc, true);
            requestedLocation = this.translate(requestedLocation, true);

            if( curLoc.Equals(requestedLocation) || this.isPassable(requestedLocation, false)){

                this.entityGrid[(int)curLoc.X, (int)curLoc.Y] = -1;
                this.entityGrid[(int)requestedLocation.X, (int)requestedLocation.Y] = entityId;

                this.occupancyGrid[(int)curLoc.X, (int)curLoc.Y] = State.Occupancy.UNOCCUPIED;
                this.occupancyGrid[(int)requestedLocation.X, (int)requestedLocation.Y] = State.Occupancy.OCCUPIED;

                return true;
            }

            return false;
        }

        public void translate(int inx, int iny, out int x, out int y){
            x = inx / this.CELL_WIDTH;
            y = iny / this.CELL_HEIGHT;
        }
        
        public Vector2 translate(Vector2 point, bool isPixel){
            if (isPixel){
                point = new Vector2(
                    (int)(point.X / this.CELL_WIDTH),
                    (int)(point.Y / this.CELL_HEIGHT)
                );
            }
            else{
                point = new Vector2(
                    point.X * this.CELL_WIDTH,
                    point.Y * this.CELL_HEIGHT
                );
            }

            return point;
        }

        public bool isPassable(Vector2 point, bool isPixel){
            if (isPixel){
                point = this.translate(point, isPixel);
            }

            if (!this.withinBoundaries(point.X, point.Y))
                return false;

            return this.occupancyGrid[(int)point.X, (int)point.Y] == State.Occupancy.UNOCCUPIED;
        }
    }
}
