using System;
using System.Collections.Generic;
using System.Text;

namespace EpicRPG.Entities.Abilities
{
    public class BaseHealAbility : BaseAbility
    {
        public int power = 0;

        public BaseHealAbility(){

        }

        protected virtual void heal(GameEntity target){
            //TODO: RANDOMIZE
            target.heal(this.power);
        }
    }
}
