using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Entities;

using EpicRPG.Util;
using EpicRPG.Entities.Configuration;
using Microsoft.Xna.Framework;

namespace EpicRPG.Managers
{
    public class EntityManager : Singleton<EntityManager>
    {
        private List<BaseEntity> entityBank;

        public void initializeEntityManager(){
            this.entityBank = new List<BaseEntity>();
        }

        public BaseEntity createNewEntity(int configId){
            return this.assignKeyId(ObjectFactory.getInstance().createNewEntity(configId));
        }

        public BaseEntity createNewEntity(string className){
            return this.assignKeyId(ObjectFactory.getInstance().createNewEntity(className));
        }

        private BaseEntity assignKeyId(BaseEntity e){
            e.setKeyId(this.entityBank.Count);
            this.entityBank.Insert(e.getKeyId(), e);
            return e;
        }

        public void Update(GameTime gameTime){
            //TODO: Update applicable entities; not all will need to update!
            foreach(BaseEntity e in entityBank){
                /*TODO: only update: 
                 *  - entites on-screen
                 *  - player-controlled entities
                 *  - ????
                 */ 
                e.Update(gameTime);
            }
        }

        public BaseEntity getEntityByKeyId(int key){
            return this.entityBank[key];
        }

        public void RenderEntities(){
            //TODO: update params so we can render
            //TODO: Render applicable entities.

            //TEMPORARY:
            foreach(BaseEntity e in this.entityBank){
                e.Draw();
            }
        }

    }

    class ObjectFactory : Singleton<ObjectFactory>
    {
        private List<EntityConfiguration> entityConfigurationBank;

        public List<EntityConfiguration> Entities{
            get{return this.entityConfigurationBank;}
            set{
                this.entityConfigurationBank = value;

                for(int i = 0; i < this.entityConfigurationBank.Count; i++){
                    BaseEntity e = this.createNewEntity(i);
                }
            }
        }

        public BaseEntity createNewEntity(string className){
            foreach(EntityConfiguration c in this.entityConfigurationBank){
                if (c.className == className)
                    return this.createNewEntity(c.classID);
            }

            return null;
        }

        public BaseEntity createNewEntity(int configId){
            EntityConfiguration config = null;
            if (this.entityConfigurationBank != null && this.entityConfigurationBank.Capacity >= configId){
                config = this.entityConfigurationBank[configId];
            }

            if(config == null)
                return null;

            return config.buildEntity();
        }
    }
}
