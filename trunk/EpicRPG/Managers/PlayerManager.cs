using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using EpicRPG.Entities;
using Microsoft.Xna.Framework;
using EpicRPG.Entities.Components;
using EpicRPG.Entities.Items;

namespace EpicRPG.Managers
{
    public class PlayerManager : Singleton<PlayerManager>{
        public Party party;

        public void initializePlayerManager(GameEntity hero){
            this.party = new Party(hero);
        }

        public void Update(GameTime gameTime){
            //This will control the player's characters.

            //Listen for movement commands
            this.party.move(
                InputManager.getInstance().MOVE_UP,
                InputManager.getInstance().MOVE_DOWN,
                InputManager.getInstance().MOVE_RIGHT,
                InputManager.getInstance().MOVE_LEFT
            );

            //Listen for other input
            if(InputManager.getInstance().ACTION){
                //TEMP:
                InputManager.getInstance().ACTION = false;

                MessageManager.getInstance().DisplayMessage("You see " + this.party.party[0].whatIsInFrontOfMe());
            }
        }
    }
}
