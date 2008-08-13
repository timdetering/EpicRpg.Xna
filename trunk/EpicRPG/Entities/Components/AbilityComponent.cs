using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using EpicRPG.Entities.Abilities;

namespace EpicRPG.Entities.Components
{
    /// <summary>
    /// Component that allows its parent to contain and use abilities.
    /// </summary>
    public class AbilityComponent : BaseComponent
    {
        public List<BaseAbility> abilities;

        public AbilityComponent(BaseEntity e) : base(e){
            this.type = State.ComponentType.ABILITY;
        }

        public override BaseComponent setAttributes(List<KeyValuePair<string, string>> attributes)
        {
            for (int i = 0; i < attributes.Count; i++)
            {
                switch (attributes[i].Key)
                {
                    //TODO: DEFINE ABILITY ATTRIBUTES
                    default: break;
                }
            }

            return base.setAttributes(attributes);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
