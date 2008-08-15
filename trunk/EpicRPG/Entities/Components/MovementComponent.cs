using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using Microsoft.Xna.Framework;

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

        public void move(bool n, bool s, bool e, bool w)
        {
            if (!(n || s || e || w))
                return;

            if (n) this.moveNorth();

            if (e) this.moveEast();

            if (s) this.moveSouth();

            if (w) this.moveWest();


            if (n && e) this.entityRef.orientation = State.DirectionState.NORTH_EAST;
            
            else if (n && w) this.entityRef.orientation = State.DirectionState.NORTH_WEST;
            
            else if (s && e) this.entityRef.orientation = State.DirectionState.SOUTH_EAST;
            
            else if (s && w) this.entityRef.orientation = State.DirectionState.SOUTH_WEST;
            
        }

        public void moveNorth(){
            this.entityRef.location = 
                new Vector2(this.entityRef.location.X, this.entityRef.location.Y - this.speed);
            this.entityRef.orientation = State.DirectionState.NORTH;
        }
        public void moveEast(){
            this.entityRef.location =
                new Vector2(this.entityRef.location.X + this.speed, this.entityRef.location.Y);
            this.entityRef.orientation = State.DirectionState.EAST;
        }
        public void moveSouth(){
            this.entityRef.location =
                new Vector2(this.entityRef.location.X, this.entityRef.location.Y + this.speed);
            this.entityRef.orientation = State.DirectionState.SOUTH;
        }
        public void moveWest(){
            this.entityRef.location =
                new Vector2(this.entityRef.location.X - this.speed, this.entityRef.location.Y);
            this.entityRef.orientation = State.DirectionState.WEST;
        }
    }
}
