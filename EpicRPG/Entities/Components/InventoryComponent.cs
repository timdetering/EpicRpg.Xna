using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using EpicRPG.Entities.Items;

namespace EpicRPG.Entities.Components
{
    public class InventoryComponent : BaseComponent
    {
        public int maxCapacity = 0;
        public List<Item> inventory;

        public InventoryComponent(BaseEntity e) : base(e){
            this.type = State.ComponentType.INVENTORY;
        }

        public override BaseComponent setAttributes(List<KeyValuePair<string, string>> attributes)
        {

            foreach(KeyValuePair<string,string> pair in attributes){
                switch (pair.Key.ToUpper()){
                    case "MAX":
                    case "MAXCAPACITY":
                    case "CAPACITY": this.maxCapacity = int.Parse(pair.Value); break;
                }
            }

            this.inventory = new List<Item>(maxCapacity);

            return base.setAttributes(attributes);
        }

        public bool addItem(Item newItem){
            if(this.inventory.Count < this.inventory.Capacity){
                this.inventory.Add(newItem);
                return true;
            }

            return false;
        }
    }
}
