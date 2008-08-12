using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;

namespace EpicRPG.Entities.Components
{
    public class RenderComponent : BaseComponent
    {
        public RenderComponent(BaseEntity e) : base(e){
            this.type = State.ComponentType.RENDER;
        }

        public override BaseComponent setAttributes(List<KeyValuePair<string, string>> attributes)
        {
            return base.setAttributes(attributes);
        }
    }
}
