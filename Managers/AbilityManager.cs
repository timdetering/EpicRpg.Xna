using System;
using System.Collections.Generic;
using System.Text;

using EpicRPG.Util;
using EpicRPG.Entities.Abilities;

namespace EpicRPG.Managers
{
    public class AbilityManager : Singleton<AbilityManager>
    {
        private List<BaseAbility> abilityBank;
    }
}
