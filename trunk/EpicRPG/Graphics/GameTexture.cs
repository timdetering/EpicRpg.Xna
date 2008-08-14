using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using EpicRPG.Managers;
using System.IO;

namespace EpicRPG.Graphics
{
    /// <summary>
    /// Represents a single texture file (static or animated sprite-batch).
    /// If the texture is a batch, frame width(/height) must be specified.
    /// </summary>
    public class GameTexture
    {
        public Texture2D texture;
        public int frameWidth = 0;
        public int frameHeight = 0;

        public GameTexture(Texture2D tex)
        {
            this.texture = tex;
        }

        public GameTexture(string textureName)
        {
            this.loadTexture(textureName);
            //TODO: Throw error if texture is null; image specified DNE
        }

        public GameTexture(string textureName, int frameWidth, int frameHeight)
            : this(textureName)
        {
            this.frameWidth = (frameWidth == 0 ? texture.Width : frameWidth);
            this.frameHeight = (frameHeight == 0 ? texture.Height : frameHeight);
        }

        private void loadTexture(string name){
            try{
                this.texture = FileManager.getInstance().loadTexture2DFromFile(name);
            }
            catch(FileNotFoundException fnf){
                Console.WriteLine("File Not Found: '" + name + "'");
            }
        }
    }
}
