using System;
using System.Collections.Generic;
using System.Text;

namespace EpicRPG.Entities.Items
{
    public class Item : BaseEntity
    {
        private long value;
        private string name;

        public Item(){

        }

        public long getValue(){
            return this.value;
        }

        public void setValue(long v){
            this.value = v;
        }

        public string getName(){
            return this.name;
        }

        public void setName(string n){
            this.name = n;
        }
    }
}
