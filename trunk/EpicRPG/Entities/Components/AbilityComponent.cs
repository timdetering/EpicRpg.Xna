using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;

namespace EpicRPG.Entities.Components
{
    public class AbilityComponent : BaseComponent
    {

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
