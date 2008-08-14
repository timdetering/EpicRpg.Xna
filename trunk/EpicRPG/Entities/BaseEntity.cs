using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using EpicRPG.Util;

namespace EpicRPG.Entities
{
    public class BaseEntity
    {
        private int keyId;

        public State.EntityState currentState = State.EntityState.IDLE;
        public State.DirectionState orientation = State.DirectionState.SOUTH;

        public State.LocationType locationType = State.LocationType.PIXEL;
        public Vector2 location;

        public BaseEntity(){
        
        }

        public int getKeyId(){
            return keyId;
        }

        public void setKeyId(int k){
            this.keyId = k;
        }

        public virtual void Update(GameTime gameTime){

        }

        public virtual void Draw(){

        }
    }
}
