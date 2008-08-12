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

        public BaseEntity createNewEntity(int configId){

            return null;
        }
    }
}
