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
            OutputManager.getInstance().Render_Static(
                this.graphics.getCurrentGraphic(ref this.entityRef).texture,
                this.entityRef.location, 
                Color.White);
        }
    }
}
