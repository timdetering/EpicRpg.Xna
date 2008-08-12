using System;
using System.Collections.Generic;
using System.Text;

namespace EpicRPG.Entities.Items
{
    public class Armor : Item
    {
        public long armorRating;

        public Armor() : base(){

        }

        public long getArmorRating(){
            return this.armorRating;
        }

        public void setArmorRating(long r){
            this.armorRating = r;
        }
    }
}
