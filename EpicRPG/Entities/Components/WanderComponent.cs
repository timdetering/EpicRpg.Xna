using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using Microsoft.Xna.Framework;

namespace EpicRPG.Entities.Components
{
    class WanderComponent : BaseComponent
    {
        public int move;

        public WanderComponent(BaseEntity e) : base(e){
            this.type = State.ComponentType.WONDER;
        }

        public override BaseComponent setAttributes(List<KeyValuePair<string, string>> attributes)
        {
            foreach (KeyValuePair<string, string> pair in attributes)
            {
                switch (pair.Key.ToUpper())
                {
                    case "MOVE": this.move = int.Parse(pair.Value); break;
                    default: break;
                }
            }
            return base.setAttributes(attributes);
        }

        public override void Update(GameTime gameTime)
        {
            this.Wander();
            base.Update(gameTime);
        }

        //makes the entity move around
        //needs work
        public void Wander()
        {
            if(this.entityRef.location.X < 100 || this.entityRef.location.X >= 300)
            {
                this.entityRef.location = new Vector2(this.entityRef.location.X - move, this.entityRef.location.Y);
            }

            if(this.entityRef.location.X >= 100 && this.entityRef.location.X < 300)
            {
                this.entityRef.location = new Vector2(this.entityRef.location.X + move, this.entityRef.location.Y);
            }
        }

    }    
}

