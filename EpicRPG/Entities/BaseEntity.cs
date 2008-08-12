using System;
using System.Collections.Generic;
using System.Text;

namespace EpicRPG.Entities
{
    public class BaseEntity
    {
        private int keyId;

        public BaseEntity(){
        
        }

        public int getKeyId(){
            return keyId;
        }

        public void setKeyId(int k){
            this.keyId = k;
        }
    }
}
