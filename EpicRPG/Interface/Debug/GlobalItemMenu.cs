using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Entities.Configuration;
using EpicRPG.Managers;

namespace EpicRPG.Interface.Debug
{
    public class GlobalItemMenu : Menu
    {
        public GlobalItemMenu(string text){
            this.title = text;
            List<ItemConfiguration> allItems = ItemManager.getInstance().itemList;
            this.menuItems = new List<MenuItem>();
            foreach(ItemConfiguration ic in allItems){
                this.menuItems.Add(new AddItemMenuItem(ic));
            }

            this.menuItems.Add(new MenuItem("Back", global::EpicRPG.Util.State.MenuState.EPIC_MENU));

            this.highlightedItem = 0;
        }
    }
}
