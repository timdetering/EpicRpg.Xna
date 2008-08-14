using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using EpicRPG.Entities;
using Microsoft.Xna.Framework;
using EpicRPG.Entities.Components;

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
            if(InputManager.getInstance().MOVE_DOWN){
                this.party.move(State.DirectionState.SOUTH);
            }
            else if (InputManager.getInstance().MOVE_UP){
                this.party.move(State.DirectionState.NORTH);
            }
            if (InputManager.getInstance().MOVE_LEFT){
                this.party.move(State.DirectionState.WEST);
            }
            else if (InputManager.getInstance().MOVE_RIGHT){
                this.party.move(State.DirectionState.EAST);
            }

            //Listen for other input
            if(InputManager.getInstance().ACTION){
                InputManager.getInstance().ACTION = false;
                MessageManager.getInstance().DisplayMessage("Oh no!  The floor is black!", "What am I going to do?");
            }
        }
    }
}
