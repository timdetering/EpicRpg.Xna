using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using EpicRPG.Entities;
using Microsoft.Xna.Framework;

namespace EpicRPG.Managers
{
    public class PlayerManager : Singleton<PlayerManager>
    {

        public Party party;

        public void initializePlayerManager(GameEntity hero){
            this.party = new Party(hero);
        }

        public void Update(GameTime gameTime){
            //This will control the player's characters.
        }
    }
}
