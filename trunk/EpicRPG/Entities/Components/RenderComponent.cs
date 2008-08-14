using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using EpicRPG.Managers;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using EpicRPG.Graphics;

namespace EpicRPG.Entities.Components
{
    public class RenderComponent : BaseComponent
    {
        public GraphicsCollection graphics;

        public int currentFrameX = 0,
                   currentFrameY = 0;

        public RenderComponent(BaseEntity e) : base(e){
            this.type = State.ComponentType.RENDER;
        }

        public override BaseComponent setAttributes(List<KeyValuePair<string, string>> attributes)
        {
            foreach(KeyValuePair<string,string> pair in attributes){
                switch(pair.Key.ToUpper()){
                    case "GRAPHICS":
                    case "GRAPHICSCOLLECTION":
                        this.graphics = GraphicsManager.getInstance().getGraphicsByName(pair.Value);
                        break;
                }
            }

            return base.setAttributes(attributes);
        }

        public void Render(int frameTimer, int FRAME_LENGTH){
            //TODO: STATE-DETERMINED GRAPHICS

            //First, get graphic to draw:
            GameTexture tex = this.graphics.getCurrentGraphic(ref  this.entityRef);

            //determine to draw static or animated
            if(tex.frameWidth == 0){
                OutputManager.getInstance().Render_Static(
                    tex.texture,
                    this.entityRef.location, 
                    Color.White);
            }
            else{
                OutputManager.getInstance().Render_Animated(
                    tex,
                    this.entityRef.location,
                    Color.White,
                    this.currentFrameX,
                    this.currentFrameY
                );

                if (OutputManager.getInstance().gotoNextFrame())
                {
                    if (this.currentFrameX < tex.texture.Width - tex.frameWidth)
                    {
                        this.currentFrameX += tex.frameWidth;
                    }
                    else
                    {
                        this.currentFrameX = 0;
                    }
                }
            }
        }
    }
}
