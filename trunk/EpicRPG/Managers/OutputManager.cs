using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EpicRPG.Util;

namespace EpicRPG.Managers
{
    public class OutputManager : Singleton<OutputManager>
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public void initializeGraphics(EpicRPG mainApp){
            this.graphics = new GraphicsDeviceManager(mainApp);
        }

        public void initializeSpriteBatch(GraphicsDevice device){
            this.spriteBatch = new SpriteBatch(device);
        }

        public void Draw(GameTime gameTime, State.GameState currentState){
            this.graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            
            switch (currentState){
                case State.GameState.INITIALIZING:
                    break;

                case State.GameState.MAIN_MENU:
                    break;

                case State.GameState.IN_PLAY_BATTLE:
                    break;

                case State.GameState.IN_PLAY_NORMAL:
                    break;

                case State.GameState.PAUSE:
                    break;
            }
        }

        public void Render_String(/*TODO: PARAMS!*/){

        }

        public void Render_Static(/*TODO: PARAMS!*/){

        }

        public void Render_Animated(/*TODO: PARAMS!*/){

        }
    }
}
