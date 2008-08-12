using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;

namespace EpicRPG.Entities.Components
{
    public class MovementComponent : BaseComponent
    {
        public MovementComponent(BaseEntity e) : base(e){
            this.type = State.ComponentType.MOVEMENT;
        }
    }
}