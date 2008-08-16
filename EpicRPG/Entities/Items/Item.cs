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
        public GameEntity entityRef;
        
        //TODO: multiple abilities?
        public BaseAbility ability;

        public Item(){

        }

        public void UseMe(){
            //ability.cast?
            MessageManager.getInstance().DisplayMessage(this.entityRef.name + " uses " + this.name);
        }

        public override string Describe()
        {
            return this.name;
        }
    }
}
