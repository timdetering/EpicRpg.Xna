using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using EpicRPG.Entities.Components;

namespace EpicRPG.Entities
{
    public class Party
    {
        public List<GameEntity> party;

        public Party(){
            this.party = new List<GameEntity>();
        }

        public Party(params GameEntity[] members) : this(){
            foreach (GameEntity newMember in members)
                this.addMember(newMember);
        }

        public void addMember(GameEntity newMember){
            this.party.Add(newMember);
        }

        //TODO: less casting???????
        public void move(State.DirectionState dir){
            switch(dir){
                case State.DirectionState.NORTH:
                    ((MovementComponent)this.party[0].getComponent(State.ComponentType.MOVEMENT)).moveNorth();
                    break;
                case State.DirectionState.EAST:
                    ((MovementComponent)this.party[0].getComponent(State.ComponentType.MOVEMENT)).moveEast();
                    break;
                case State.DirectionState.SOUTH:
                    ((MovementComponent)this.party[0].getComponent(State.ComponentType.MOVEMENT)).moveSouth();
                    break;
                case State.DirectionState.WEST:
                    ((MovementComponent)this.party[0].getComponent(State.ComponentType.MOVEMENT)).moveWest();
                    break;
                default: break;
            }
        }
    }
}
