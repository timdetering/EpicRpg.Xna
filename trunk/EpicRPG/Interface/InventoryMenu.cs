using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Entities;
using EpicRPG.Entities.Items;
using EpicRPG.Util;
using EpicRPG.Entities.Components;

namespace EpicRPG.Interface
{
    public class InventoryMenu : Menu
    {
        public GameEntity entity;
        public InventoryMenu(GameEntity e){
            this.entity = e;
            this.title = this.entity.name + "'s Inventory";
            List<Item> items = ((InventoryComponent) this.entity.getComponent(State.ComponentType.INVENTORY)).inventory;
            this.menuItems = new List<MenuItem>();
            foreach(Item i in items){
                this.menuItems.Add(new ItemMenuItem(i));
            }
            this.menuItems.Add(new MenuItem("Back", State.MenuState.EPIC_MENU_CHARACTER));
            this.highlightedItem = 0;
        }
    }
}
