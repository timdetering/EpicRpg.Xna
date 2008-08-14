using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
