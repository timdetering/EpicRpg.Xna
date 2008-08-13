using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using EpicRPG.Managers;

namespace EpicRPG.Interface
{
    class MenuItemWithInput : MenuItem
    {
        public string inputValue;
        public bool listeningForInput = false;

        public MenuItemWithInput(string text, State.MenuState target):this(text){

        }

        public MenuItemWithInput(string text){
            this.target = State.MenuState.NULL;
            this.text = text;
            this.inputValue = "";
        }

        public override void Deselect(){
            this.inputValue = InputManager.getInstance().getInputString();
            this.listenForInput(false);
        }

        public override void Update(){
            
        }

        public override void listenForInput(bool l){
            //if we're starting, we need to set our current data
            if (!this.listeningForInput && l)
                InputManager.getInstance().setInputString(this.inputValue);

            //if we're stopping, we need to store the data
            //else if(this.listeningForInput && !l)
            //    this.inputValue = this.inputValue + InputManager.getInstance().getInputString();

            this.listeningForInput = l;
        }

        public override void Draw(Microsoft.Xna.Framework.Vector2 location, Microsoft.Xna.Framework.Graphics.Color color){
            string displaystr = this.inputValue;
            if (this.listeningForInput)
                displaystr = InputManager.getInstance().getInputString() + "_";
            OutputManager.getInstance().Render_String(this.text + " : " + displaystr, location, color);
        }
    }
}
