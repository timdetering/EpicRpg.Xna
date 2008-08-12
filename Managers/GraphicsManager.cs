using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EpicRPG.Util;

namespace EpicRPG.Managers
{
    public class GraphicsManager : Singleton<GraphicsManager>
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public void initializeGraphics(EpicRPG mainApp){
            this.graphics = new GraphicsDeviceManager(mainApp);
        }

        public void initializeSpriteBatch(GraphicsDevice device){
            this.spriteBatch = new SpriteBatch(device);
        }

        public void Draw(GameTime gameTime){
            this.graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}
