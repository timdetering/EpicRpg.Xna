using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using Microsoft.Xna.Framework;
using EpicRPG.Interface;
using EpicRPG.Entities.Configuration;
using EpicRPG.Interface.Debug;

namespace EpicRPG.Managers
{
    public class MenuManager : Singleton<MenuManager>
    {
        private State.MenuState _menuState;

        public State.MenuState menuState{
            get{return this._menuState;}
            set{if(value != State.MenuState.NULL) this._menuState = value;}
        }

        public Menu currentCharacterMenu{
            set { this.characterMenu = value; }
        }

        private bool refreshMenu = false;

        private Menu currentMenu,
                     mainMenu,
                     newGameMenu,
                     epicMenu,
                     inventoryMenu,
                     partyMenu,
                     characterMenu,
                     battleMenu,
                     allItemsMenu;

        public void initializeMenuManager(){
            this.mainMenu = new Menu("Eternal Progression into Chaos",
                new MenuItem("New Game", State.MenuState.NEW_GAME),
                new MenuItem("Load Game", State.MenuState.NULL),
                new MenuItem("Credits", State.MenuState.NULL),
                new MenuItem("Exit", State.MenuState.EXIT_GAME));

            this.newGameMenu = new Menu("Create Your Hero",
                new MenuItemWithInput("Name"),
                new MenuItem("Begin Epic RPG", State.MenuState.START_NEW_GAME),
                new MenuItem("Cancel", State.MenuState.MAIN_MENU));

            this.epicMenu = new Menu("EPIC Menu",
                new MenuItem("DEBUG: Items", State.MenuState.DEBUG_ALL_ITEMS),
                //new MenuItem("Inventory", State.MenuState.EPIC_MENU_INVENTORY),
                //new MenuItem("Abilities", State.MenuState.NULL),
                new MenuItem("Party", State.MenuState.EPIC_MENU_PARTY),
                new MenuItem("Save Game", State.MenuState.NULL),
                new MenuItem("Back", State.MenuState.NONE),
                new MenuItem("Quit", State.MenuState.EXIT_GAME));

            this.battleMenu = new Menu("Pick Action",
                new MenuItem("Attack", State.MenuState.NONE),
                new MenuItem("Magic", State.MenuState.NONE),
                new MenuItem("Item", State.MenuState.NONE),
                new MenuItem("Run", State.MenuState.NONE));

            this.inventoryMenu = new InventoryMenu(null);

            this.partyMenu = new PartyMenu();

            this.allItemsMenu = new GlobalItemMenu("All Items");
        }

        public void Update(GameTime gameTime){
            switch(this.menuState){
                case State.MenuState.CREDITS:
                    break;

                case State.MenuState.EXIT_GAME:
                    EpicRPG.getInstance().Exit();
                    break;

                case State.MenuState.LOAD_GAME:
                    break;

                case State.MenuState.MAIN_MENU:
                    this.setCurrentMenu(ref this.mainMenu);
                    break;

                case State.MenuState.NEW_GAME:
                    this.setCurrentMenu(ref this.newGameMenu);
                    break;

                case State.MenuState.EPIC_MENU:
                    this.setCurrentMenu(ref this.epicMenu);
                    break;

                case State.MenuState.EPIC_MENU_INVENTORY:
                    this.setCurrentMenu(ref this.inventoryMenu);
                    break;

                case State.MenuState.EPIC_MENU_PARTY:
                    if(this.refreshMenu){
                        this.refreshMenu = false;
                        this.partyMenu.refreshMenu();
                    }
                    this.setCurrentMenu(ref this.partyMenu);
                    break;

                case State.MenuState.EPIC_MENU_CHARACTER:
                    this.setCurrentMenu(ref this.characterMenu);
                    break;

                case State.MenuState.EPIC_MENU_CHARACTER_INVENTORY:
                    if(this.refreshMenu){
                        this.refreshMenu = false;
                        ((InventoryMenu)this.inventoryMenu).refreshMenu(((CharacterMenu)this.characterMenu).character);
                    }
                    this.setCurrentMenu(ref this.inventoryMenu);
                    break;

                case State.MenuState.START_NEW_GAME:
                    CampaignManager.getInstance().initializeNewGame(this.newGameMenu.getInputValueWithName("Name"));
                    break;

                case State.MenuState.SAVE_GAME:
                    break;

                case State.MenuState.NONE:
                    EpicRPG.getInstance().CurrentState = State.GameState.IN_PLAY_NORMAL;
                    break;

                //DEBUGS
                case State.MenuState.DEBUG_ADD_ITEM:
                    goto case State.MenuState.NONE;

                case State.MenuState.DEBUG_ALL_ITEMS:
                    this.setCurrentMenu(ref this.allItemsMenu);
                    break;

                default: break;
            }

            this.currentMenu.Update(gameTime);
        }

        public void DrawCurrentMenu(){
            this.currentMenu.Draw();
        }

        private void setCurrentMenu(ref Menu menu){
            if(this.currentMenu != menu){
                this.refreshMenu = true;
                this.currentMenu = menu;
            }
        }
    }
}
