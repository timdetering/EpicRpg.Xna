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

        public void move(bool n, bool s, bool e, bool w){
            ((MovementComponent)this.party[0].getComponent(State.ComponentType.MOVEMENT)).move(n,s,e,w);
        }
    }
}
