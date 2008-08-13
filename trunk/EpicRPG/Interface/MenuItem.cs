using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using EpicRPG.Managers;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EpicRPG.Interface
{
    /// <summary>
    /// MenuItem selection will change state, so this should be simple
    /// </summary>
    public class MenuItem
    {
        public string text;
        public State.MenuState target;
        public bool disabled = false;

        public MenuItem(){}

        public MenuItem(string text, State.MenuState target, bool disabled) : this(text, target){
            this.disabled = disabled;
        }

        public MenuItem(string text, State.MenuState target){
            this.text = text;
            this.target = target;

            if (this.target == State.MenuState.NULL)
                this.disabled = true;
        }

        public virtual void Update(){

        }

        public virtual void Select(){
            if(!this.disabled)
                MenuManager.getInstance().menuState = this.target;
        }

        public virtual void Deselect(){

        }

        public virtual void listenForInput(bool l){
            //virtual function for input menu item
        }

        public virtual void Draw(Vector2 location, Color color){
            OutputManager.getInstance().Render_String(this.text, location, (this.disabled ? Color.Gray : color));
        }

        public virtual void input(string text){

        }
    }
}
