using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EpicRPG.Managers
{
    public class MessageManager : Singleton<MessageManager>
    {
        private List<string> messageQueue;

        public void DisplayMessage(params string[] messages){
            messageQueue = new List<string>(messages);
            EpicRPG.getInstance().CurrentState = State.GameState.MESSAGE;
        }

        public void Update(GameTime gameTime){
            //listen for advancement
            if (InputManager.getInstance().ACTION)
                this.messageQueue.RemoveAt(0);

            if (this.messageQueue.Count == 0){
                EpicRPG.getInstance().CurrentState = State.GameState.IN_PLAY_NORMAL;
            }

        }

        public void Draw(){
            if (this.messageQueue.Count > 0)
                OutputManager.getInstance().Render_String(this.messageQueue[0], new Vector2(10, 10), Color.Blue);
        }
    }
}
