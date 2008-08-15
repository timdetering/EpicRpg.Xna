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

        public void initializeWorldManager(){
            this.currentMap = new DebugRoom();
        }

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

        public void Update(GameTime gameTime){

        }

        public void Draw(){
            this.currentMap.Draw();
        }
    }
}