using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Entities.Configuration;
using EpicRPG.Util;
using EpicRPG.Managers;

namespace EpicRPG.Interface.Debug
{
    public class AddItemMenuItem : MenuItem
    {
        public ItemConfiguration myItem;

        public AddItemMenuItem(ItemConfiguration item) : base(item.name, State.MenuState.DEBUG_ADD_ITEM){
            this.myItem = item;
        }

        public override void Select()
        {
            MessageManager.getInstance().DisplayMessage(PlayerManager.getInstance().party.party[0].getItem(myItem.buildItem()));
        }
    }
}