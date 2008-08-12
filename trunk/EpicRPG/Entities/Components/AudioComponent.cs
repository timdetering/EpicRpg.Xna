using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;

namespace EpicRPG.Entities.Components
{
    public class AudioComponent : BaseComponent
    {
        public AudioComponent(BaseEntity e) : base(e){
            this.type = State.ComponentType.AUDIO;
        }
    }
}
