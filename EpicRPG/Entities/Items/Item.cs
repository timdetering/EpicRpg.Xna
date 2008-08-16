using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Entities.Abilities;
using EpicRPG.Managers;

namespace EpicRPG.Entities.Items
{
    public class Item : BaseEntity
    {
        public long value;
        public string name,
                      description;
        public bool constant = false;
        //public GameEntity entityRef;
        
        //TODO: multiple abilities?
        public BaseAbility ability;

        public Item(){

        }

        public void UseMe(GameEntity e){
            //TODO: & display info
        }

        public override string Describe()
        {
            return this.name;
        }
    }
}
