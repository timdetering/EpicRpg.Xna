using System;
using System.Collections.Generic;
using System.Text;

namespace EpicRPG.Entities.Items
{
    public class Weapon : Item
    {
        public long damage;

        public Weapon() : base(){

        }

        public long getDamage(){
            return this.damage;
        }

        public void setDamage(long d){
            this.damage = d;
        }
    }
}
