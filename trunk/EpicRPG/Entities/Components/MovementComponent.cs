using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;

namespace EpicRPG.Entities.Components
{
    public class MovementComponent : BaseComponent
    {
        public int speed = 2;

        public MovementComponent(BaseEntity e) : base(e){
            this.type = State.ComponentType.MOVEMENT;
        }

        public override BaseComponent setAttributes(List<KeyValuePair<string, string>> attributes)
        {
            foreach(KeyValuePair<string,string> pair in attributes){
                switch(pair.Key.ToUpper()){
                    case "SPEED": this.speed = int.Parse(pair.Value); break;
                    default: break;
                }
            }

            return base.setAttributes(attributes);
        }

        public void moveNorth(){
            this.entityRef.location.Y -= this.speed;
        }
        public void moveEast(){
            this.entityRef.location.X += this.speed;
        }
        public void moveSouth(){
            this.entityRef.location.Y += this.speed;
        }
        public void moveWest(){
            this.entityRef.location.X -= this.speed;
        }
    }
}
