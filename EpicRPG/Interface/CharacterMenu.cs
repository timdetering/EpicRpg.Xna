using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Entities;
using EpicRPG.Util;

namespace EpicRPG.Interface
{
    public class CharacterMenu : Menu
    {
        public GameEntity character;

        public CharacterMenu(ref GameEntity e) : 
            base(e.name, 
                new MenuItem("Inventory", State.MenuState.EPIC_MENU_CHARACTER_INVENTORY),
                new MenuItem("Abilities", State.MenuState.NULL),
                new MenuItem("Back", State.MenuState.EPIC_MENU_PARTY)
            )
        {
            this.character = e;
        }
    }
}
