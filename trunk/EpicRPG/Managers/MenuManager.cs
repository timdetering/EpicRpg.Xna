using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using Microsoft.Xna.Framework;
using EpicRPG.Interface;
using EpicRPG.Entities.Configuration;

namespace EpicRPG.Managers
{
    public class MenuManager : Singleton<MenuManager>
    {
        public State.MenuState _menuState;

        public State.MenuState menuState{
            get{return this._menuState;}
            set{if(value != State.MenuState.NULL) this._menuState = value;}
        }

        private Menu currentMenu,
                     mainMenu,
                     newGameMenu,
                     loadGameMenu;

        public void initializeMenuManager(){
            //TODO: construct menus
            this.mainMenu = new Menu("Epic RPG",
                new MenuItem("New Game", State.MenuState.NEW_GAME),
                new MenuItem("Load Game", State.MenuState.NULL),
                new MenuItem("Credits", State.MenuState.NULL),
                new MenuItem("Exit", State.MenuState.EXIT_GAME));

            this.newGameMenu = new Menu("Create Your Hero",
                new MenuItemWithInput("Name"),
                new MenuItemWithInput("Quest"),
                new MenuItemWithInput("Favorite Color"),
                new MenuItem("Begin Epic RPG", State.MenuState.START_NEW_GAME),
                new MenuItem("Cancel", State.MenuState.MAIN_MENU));

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

                case State.MenuState.START_NEW_GAME:
                    CampaignManager.getInstance().initializeNewGame(this.newGameMenu.getInputValueWithName("Name"));
                    break;

                case State.MenuState.SAVE_GAME:
                    break;

                default: break;
            }

            this.currentMenu.Update(gameTime);
        }

        public void DrawCurrentMenu(){
            this.currentMenu.Draw();
        }

        private void setCurrentMenu(ref Menu menu){
            this.currentMenu = menu;
        }
    }
}