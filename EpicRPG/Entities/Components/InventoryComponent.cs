using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;

namespace EpicRPG.Entities.Components
{
    public class InventoryComponent : BaseComponent
    {
        public InventoryComponent(BaseEntity e) : base(e){
            this.type = State.ComponentType.INVENTORY;
        }
    }
}
