using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using EpicRPG.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EpicRPG.Managers
{
    public class CampaignManager : Singleton<CampaignManager>
    {
        public GameEntity newHero;

        public State.CutScene currentScene;
        public int sceneIndex = 0;

        public void setCurrentScene(State.CutScene type){
            this.currentScene = type;
            this.sceneIndex = 0;
        }

        public void Update(GameTime gameTime){
            switch(this.currentScene){
                case State.CutScene.TEXT:
                    //if(InputManager.getInstance().keyPressed(Keys.Space)){
                    if(InputManager.getInstance().MOVE_RIGHT){
                        EpicRPG.getInstance().CurrentState = State.GameState.IN_PLAY;
                    }
                    break;

                default: 
                    break;
            }
        }

        public void Draw(){
            //:temporary
            string renderString = "Hero Name: " + newHero.name;
            OutputManager.getInstance().Render_String(renderString, new Vector2(50, 50), Color.Blue);
            //
            switch (this.currentScene){
                case State.CutScene.TEXT:
                    //TODO: WRITE SCENE DATA...
                    break;

                default:
                    break;
            }
        }

        public void initializeNewGame(string heroName/*TODO: PARAMS*/){
            //TODO: BUILD HERO
            this.newHero = new GameEntity();
            this.newHero.name = heroName;

            //TODO: w/e else

            this.BeginNewGame();
        }

        public void BeginNewGame(){
            EpicRPG.getInstance().CurrentState = State.GameState.CUTSCENE;
            this.setCurrentScene(State.CutScene.TEXT);
        }
    }
}
