using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using EpicRPG.Util;
using EpicRPG.Managers;

namespace EpicRPG.Entities
{
    public class BaseEntity
    {
        private int keyId;

        public State.EntityState currentState = State.EntityState.IDLE;
        public State.DirectionState orientation = State.DirectionState.SOUTH;

        public State.LocationType locationType = State.LocationType.PIXEL;

        protected Vector2 _location;
        public Vector2 location{
            get{return this._location;}
            
            set{
                if (WorldManager.getInstance().requestMove(this.keyId, this._location, value))
                    this._location = value;
            }
        }

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

        public virtual string Describe(){
            return "?";
        }
    }
}
