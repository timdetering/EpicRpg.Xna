using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Entities.Items;

namespace EpicRPG.Entities.Configuration
{
    public class ItemConfiguration
    {
        public int classId;
        public string name,
                      description;
        public long value;
        //TODO: ABILITIES

        public ItemConfiguration(int id, string name, long value, params string[] args){
            this.classId = id;
            this.name = name;
            this.value = value;

            //set all other properties that are given
            for(int i = 0; (i + 1) < args.Length; i += 2){
                switch(args[i].ToUpper()){
                    case "DESCRIPTION": description = args[i + 1];              break;
                    default: break;
                }
            }
        }

        public Item buildItem(){
            Item item = new Item();
            item.name = name;
            item.description = description;
            item.value = value;
            return item;
        }
    }
}
