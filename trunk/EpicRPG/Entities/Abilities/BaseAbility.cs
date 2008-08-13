using System;
using System.Collections.Generic;
using System.Text;

namespace EpicRPG.Entities.Abilities
{
    /// <summary>
    /// Parent class for any kind of ability, whether is is a spell, feat, etc.
    /// Must be sub-classed to add new abilities
    /// </summary>
    public class BaseAbility
    {
        public int keyId;
        public string name;
        public string description;

        /// <summary>
        /// Casts the ability, performing whatever action is to be performed
        /// </summary>
        public virtual void CastOnSelf(){
            //TODO: DISPLAY FAIL ERROR
        }

        /// <summary>
        /// Casts the ability, performing whatever action is to be performed
        /// </summary>
        public virtual void CastOnTarget(BaseEntity target){
            //TODO: DISPLAY FAIL ERROR
        }
    }
}
