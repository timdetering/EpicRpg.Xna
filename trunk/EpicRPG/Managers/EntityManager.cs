using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Entities;

using EpicRPG.Util;
using EpicRPG.Entities.Configuration;

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
