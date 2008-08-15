using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using EpicRPG.Entities.Items;
using EpicRPG.Entities.Configuration;

namespace EpicRPG.Managers
{
    public class ItemManager : Singleton<ItemManager>
    {
        public List<ItemConfiguration> itemList;

        public Item getItem(int itemId){
            if (this.itemList != null && itemId >= 0 && itemId < this.itemList.Count)
                return this.itemList[itemId].buildItem();

            return null;
        }

        public Item getItem(string name){
            foreach(ItemConfiguration ic in this.itemList){
                if (ic.name == name)
                    return ic.buildItem();
            }

            return null;
        }
    }
}
