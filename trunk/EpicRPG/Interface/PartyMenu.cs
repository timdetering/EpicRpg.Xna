using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Managers;
using EpicRPG.Entities;
using EpicRPG.Util;

namespace EpicRPG.Interface
{
    public class PartyMenu : Menu
    {
        private Party party;

        public PartyMenu() : base("Party"){
            this.initialize();
        }

        private void initialize(){
            this.party = PlayerManager.getInstance().party;
        }

        public override void refreshMenu(){
            if (this.party == null) this.initialize();
            this.menuItems = new List<MenuItem>();
            foreach(GameEntity e in this.party.party){
                this.menuItems.Add(new PartyMenuItem(e));
            }
            this.menuItems.Add(new MenuItem("Back", State.MenuState.EPIC_MENU));

            this.highlightedItem = 0;
        }
    }
}
