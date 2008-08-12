using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;

namespace EpicRPG.Entities.Components
{
    public class InventoryComponent : BaseComponent
    {
        public int maxCapacity = 0;

        public InventoryComponent(BaseEntity e) : base(e){
            this.type = State.ComponentType.INVENTORY;
        }

        public override BaseComponent setAttributes(List<KeyValuePair<string, string>> attributes)
        {
            return base.setAttributes(attributes);

            foreach(KeyValuePair<string,string> pair in attributes){
                switch (pair.Key.ToUpper()){
                    case "MAX":
                    case "MAXCAPACITY":
                    case "CAPACITY": this.maxCapacity = int.Parse(pair.Value); break;
                }
            }
        }
    }
}
