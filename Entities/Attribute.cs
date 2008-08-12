using System;
using System.Collections.Generic;
using System.Text;

namespace EpicRPG.Entities
{
    public class Attribute
    {
        public int value, maxValue;

        public Attribute(int maxValue){
            this.value = this.maxValue = maxValue;
        }

        public Attribute(int val, int maxVal){
            this.value = val;
            this.maxValue = maxVal;
        }
    }
}
