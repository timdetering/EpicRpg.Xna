using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Entities.Abilities;

namespace EpicRPG.Entities.Items
{
    public class Item : BaseEntity
    {
        public long value;
        public string name,
                      description;
        
        //TODO: multiple abilities?
        public BaseAbility ability;

        public Item(){

        }

        public void UseMe(){
            //ability.cast?
        }

        public override string Describe()
        {
            return this.name;
        }
    }
}
