using System;
using System.Collections.Generic;
using System.Text;

namespace EpicRPG.Entities.Abilities
{
    public class HealSelfAbility : BaseHealAbility
    {
        public override void CastOnSelf()
        {
            //TODO: GET PARENT ENTITY
            this.heal(null);
        }
    }
}
