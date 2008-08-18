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
            int num = RNG.EnemyPos();
            if(num == 0)
            {
            }
            if(num == 1)
                this.entityRef.location = new Vector2(this.entityRef.location.X + move, this.entityRef.location.Y);
            if(num == 2)
                this.entityRef.location = new Vector2(this.entityRef.location.X - move, this.entityRef.location.Y);
            if(num == 3)
                this.entityRef.location = new Vector2(this.entityRef.location.X, this.entityRef.location.Y + move);
            if(num == 4)
                this.entityRef.location = new Vector2(this.entityRef.location.X, this.entityRef.location.Y - move);
            if(num == 5)
                this.entityRef.location = new Vector2(this.entityRef.location.X + move, this.entityRef.location.Y + move);
            if(num == 6)
                this.entityRef.location = new Vector2(this.entityRef.location.X - move, this.entityRef.location.Y - move);
            if(num == 7)
                this.entityRef.location = new Vector2(this.entityRef.location.X + move, this.entityRef.location.Y - move);
            if(num == 8)
                this.entityRef.location = new Vector2(this.entityRef.location.X - move, this.entityRef.location.Y + move);
        }

    }    
}

