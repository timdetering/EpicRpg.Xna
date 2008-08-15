using System;
using System.Collections.Generic;
using System.Text;

using EpicRPG.Util;
using Microsoft.Xna.Framework;
using EpicRPG.Entities;
using EpicRPG.World;

namespace EpicRPG.Managers
{
    public class WorldManager : Singleton<WorldManager>
    {
        private List<WorldEntity> worldEntities;
        public BaseMap currentMap;

        public void setWorldEntities(List<WorldEntity> wentities){
            this.worldEntities = new List<WorldEntity>();
            WorldEntity we;
            for(int i = 0; i < wentities.Count; i++){
                we = wentities[i];
                we.setKeyId(i);
                this.worldEntities.Insert(i, we);
                wentities[i] = null;
            }
        }

        public WorldEntity getWorldEntityById(int id){
            if (id >= 0 && id < this.worldEntities.Count)
                return this.worldEntities[id];

            return null;
        }

        public WorldEntity getWorldEntityByName(string name){
            foreach(WorldEntity we in this.worldEntities){
                if (we.name == name)
                    return we;
            }

            return null;
        }

        public string describeEntityAtPixel(float x, float y){
            return this.describeEntityAtPixel((int)x, (int)y);
        }

        public string describeEntityAtPixel(int x, int y){
            this.currentMap.translate(x, y, out x, out y);
            return this.describeEntityInCell(x, y);
        }

        public string describeEntityInCell(float x, float y){
            return this.describeEntityInCell((int)x, (int)y);
        }

        public string describeEntityInCell(int x, int y){
            if(this.currentMap.withinBoundaries(x, y)){
                if (this.currentMap.entityGrid[x, y] != -1){
                    return EntityManager.getInstance().getEntityByKeyId(this.currentMap.entityGrid[x, y]).Describe();
                }
                else if (this.currentMap.terrainGrid[x, y] != -1){
                    return this.getWorldEntityById(this.currentMap.terrainGrid[x, y]).Describe();
                }
            }

            return "Absolutely Nothing";
        }

        public bool requestMove(int entityId, Vector2 curLoc, Vector2 requestedLocation){
            return this.currentMap.requestMove(entityId, curLoc, requestedLocation);
        }

        public Vector2 translate(Vector2 point, bool isPixel){
            return this.currentMap.translate(point, isPixel);
        }

        public bool isPassable(Vector2 point, bool isPixel){
            return this.currentMap.isPassable(point, isPixel);
        }

        public void Update(GameTime gameTime){

        }

        public void Draw(){
            if(currentMap != null)
                this.currentMap.Draw();
        }
    }
}