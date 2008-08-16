using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Entities;
using EpicRPG.Util;
using EpicRPG.Managers;

namespace EpicRPG.Interface
{
    public class PartyMenuItem : MenuItem
    {
        public CharacterMenu charMenu;

        public PartyMenuItem(GameEntity e) : base(e.name, State.MenuState.EPIC_MENU_CHARACTER){
            this.charMenu = new CharacterMenu(ref e);
        }

        public override void Select(){
            base.Select();
            MenuManager.getInstance().currentCharacterMenu = this.charMenu;
        }
    }
}
