using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Graphics;

namespace EpicRPG.Entities
{
    public class WorldEntity : BaseEntity
    {

        public string name;
        public GameTexture texture;
        public bool passable;

        public WorldEntity(){

        }

        public WorldEntity(string name, bool passable, GameTexture texture){
            this.name = name;
            this.passable = passable;
            this.texture = texture;
        }

        public override string Describe()
        {
            return this.name;
        }
    }
}
