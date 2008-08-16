using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Entities.Items;
using EpicRPG.Util;

namespace EpicRPG.Interface
{
    public class ItemMenuItem : MenuItem
    {
        public Item item;
        public ItemMenuItem(Item item) : base(item.name, State.MenuState.NONE){
            this.item = item;
        }

        public override void Select(){
            base.Select();

            //TODO: this needs some work...
            item.UseMe();
        }
    }
}
