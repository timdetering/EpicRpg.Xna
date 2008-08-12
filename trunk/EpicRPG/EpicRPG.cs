using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using EpicRPG.Managers;
using EpicRPG.Util;

namespace EpicRPG
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class EpicRPG : Microsoft.Xna.Framework.Game
    {

        private State.GameState gameState;

        public EpicRPG()
        {
            GraphicsManager.getInstance().initializeGraphics(this);
            Content.RootDirectory = "Content";

            this.gameState = State.GameState.INITIALIZING;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            GraphicsManager.getInstance().initializeSpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            switch(this.gameState){
                
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

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsManager.getInstance().Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}