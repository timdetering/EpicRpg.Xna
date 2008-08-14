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

        SpriteFont arialFont;

        public void initializeGraphics(EpicRPG mainApp){
            this.graphics = new GraphicsDeviceManager(mainApp);
            GraphicsManager.getInstance().initializeGraphicsManager();
        }

        public void initializeSpriteBatch(GraphicsDevice device){
            this.spriteBatch = new SpriteBatch(device);
        }

        //TODO: Expand to allow multiple fonts
        public void setFonts(params SpriteFont[] fonts){
            if (fonts.Length > 0)
                this.arialFont = fonts[0];
        }

        public void Draw(GameTime gameTime, State.GameState currentState){
            //draw background...
            this.graphics.GraphicsDevice.Clear(Color.Black);

            this.spriteBatch.Begin();
            EntityManager.getInstance().RenderEntities();
            switch (currentState){
                case State.GameState.INITIALIZING:
                    break;

                case State.GameState.MAIN_MENU:
                    MenuManager.getInstance().DrawCurrentMenu();
                    break;

                case State.GameState.CUTSCENE:
                    CampaignManager.getInstance().Draw();
                    break;

                case State.GameState.IN_PLAY_BATTLE:
                    break;

                case State.GameState.IN_PLAY_NORMAL:
                    break;

                case State.GameState.PAUSE:
                    break;
            }

            this.spriteBatch.End();
        }

        public void Render_String(string text, Vector2 position, Color color){
            this.spriteBatch.DrawString(this.arialFont, text, position, color);
        }

        public void Render_Static(Texture2D texture, Vector2 onScreenLoc, Color colorMask){
            spriteBatch.Draw(texture,
                new Rectangle((int)onScreenLoc.X - (texture.Width / 2),
                    (int)(onScreenLoc.Y - (texture.Height * 0.80)),
                    texture.Width, 
                    texture.Height),
                colorMask);
        }

        public void Render_Animated(/*TODO: PARAMS!*/){

        }

        public GraphicsDevice getGraphicsDevice(){
            return this.spriteBatch.GraphicsDevice;
        }
    }

}
