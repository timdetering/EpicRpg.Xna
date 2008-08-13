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

        public BaseEntity createNewEntity(int configId){
            return this.assignKeyId(ObjectFactory.getInstance().createNewEntity(configId));
        }

        private BaseEntity assignKeyId(BaseEntity e){
            e.setKeyId(this.entityBank.Count);
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
