using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace EpicRPG.Managers
{
    public class InputManager : Singleton<InputManager>
    {
        private KeyboardState keyStateCurrent,
                              keyStatePrev;

        //TODO: do we need mouse input, or are we limiting to keyboard?

        private bool enterStringMode = false;
        private string enteredString = "";

        public bool MOVE_UP = false,
                    MOVE_LEFT = false,
                    MOVE_DOWN = false,
                    MOVE_RIGHT = false,
                    EPIC_MENU = false,
                    ACTION = false;

        public void Update(GameTime gameTime)
        {
            //set current states
            keyStateCurrent = Keyboard.GetState();

            if (enterStringMode)
            {
                this.processTextInput();
                //Console.WriteLine(this.enteredString);
            }

            //interface

            //only update these things if game is in play
            if (EpicRPG.getInstance().CurrentState == State.GameState.IN_PLAY ||
                EpicRPG.getInstance().CurrentState == State.GameState.MESSAGE){
                this.Update_PlayState(gameTime);
            }
            else if(EpicRPG.getInstance().CurrentState == State.GameState.MENU){
                this.Update_MenuState(gameTime);
            }

            //save states for previous
            keyStatePrev = keyStateCurrent;
        }

        private void Update_PlayState(GameTime gameTime)
        {
            #region KEYBOARD COMMANDS

            this.clearBools();

            if (keyStateCurrent.IsKeyDown(Keys.W) || keyStateCurrent.IsKeyDown(Keys.Up)){
                MOVE_UP = true;
            }
            else if (keyStateCurrent.IsKeyDown(Keys.S) || keyStateCurrent.IsKeyDown(Keys.Down)){
                MOVE_DOWN = true;
            }

            if (keyStateCurrent.IsKeyDown(Keys.A) || keyStateCurrent.IsKeyDown(Keys.Left)){
                MOVE_LEFT = true;
            }
            else if (keyStateCurrent.IsKeyDown(Keys.D) || keyStateCurrent.IsKeyDown(Keys.Right)){
                MOVE_RIGHT = true;
            }

            if(this.keyPressed(Keys.Escape)){
                EpicRPG.getInstance().CurrentState = State.GameState.MENU;
                MenuManager.getInstance().menuState = State.MenuState.EPIC_MENU;
            }

            if(this.keyPressed(Keys.Space)){
                ACTION = true;
            }
            
            #endregion

        }

        private void Update_MenuState(GameTime gameTime)
        {

            #region KEYBOARD COMMANDS

            this.clearBools();

            if(this.keyPressed(Keys.Up))
            {
                MOVE_UP = true;
            }
            else if (this.keyPressed(Keys.Down))
            {
                MOVE_DOWN = true;
            }

            if (this.keyPressed(Keys.Left))
            {
                MOVE_LEFT = true;
            }
            else if (this.keyPressed(Keys.Right) || this.keyPressed(Keys.Enter))
            {
                MOVE_RIGHT = true;
            }

            #endregion

        }

        public bool anyKeysPressed(params Keys[] keys){
            foreach(Keys k in keys){
                if (this.keyPressed(k))
                    return true;
            }

            return false;
        }

        public bool keyPressed(Keys key)
        {
            return (keyStateCurrent.IsKeyDown(key) && keyStatePrev.IsKeyUp(key));
        }

        public bool shifting()
        {
            return (keyStateCurrent.IsKeyDown(Keys.LeftShift) || keyStateCurrent.IsKeyDown(Keys.RightShift));
        }

        public bool alting()
        {
            return (keyStateCurrent.IsKeyDown(Keys.LeftAlt) || keyStateCurrent.IsKeyDown(Keys.RightAlt));
        }

        public bool ctrling()
        {
            return (keyStateCurrent.IsKeyDown(Keys.LeftControl) || keyStateCurrent.IsKeyDown(Keys.RightControl));
        }

        private void clearBools()
        {
            this.MOVE_DOWN = false;
            this.MOVE_LEFT = false;
            this.MOVE_RIGHT = false;
            this.MOVE_UP = false;
            this.ACTION = false;
        }

        public string getInputString(){
            //string tmp = this.enteredString;
            //this.enteredString = "";
            //return tmp;
            return this.enteredString;
        }

        public  void setInputString(string i){
            this.enterStringMode = true;
            this.enteredString = i;
        }

        //TODO: this function isn't *that* great...redo?
        private void processTextInput()
        {
            Keys[] keys = keyStateCurrent.GetPressedKeys();
            for (int i = 0; i < keys.Length; i++)
            {
                if (this.keyPressed(keys[i]))
                {
                    switch (keys[i])
                    {
                        case Keys.Back:
                            if (this.enteredString.Length > 0)
                                this.enteredString = this.enteredString.Remove(enteredString.Length - 1);
                            break;

                        #region PUNCTUATION KEYS
                        case Keys.Space:
                            this.enteredString += " ";
                            break;

                        case Keys.Multiply:
                            this.enteredString += "*";
                            break;

                        case Keys.Decimal:
                        case Keys.OemPeriod:
                            this.enteredString += ".";
                            break;

                        case Keys.OemComma:
                            this.enteredString += ",";
                            break;

                        case Keys.Divide:
                            this.enteredString += "/";
                            break;

                        case Keys.OemBackslash:
                            this.enteredString += "\\";
                            break;

                        case Keys.OemMinus:
                        case Keys.Subtract:
                            this.enteredString += "-";
                            break;

                        case Keys.OemOpenBrackets:
                            this.enteredString += "[";
                            break;

                        case Keys.OemCloseBrackets:
                            this.enteredString += "]";
                            break;

                        case Keys.OemPipe:
                            this.enteredString += "|";
                            break;

                        case Keys.OemQuestion:
                            this.enteredString += "?";
                            break;

                        case Keys.OemQuotes:
                            this.enteredString += "\"";
                            break;

                        case Keys.OemSemicolon:
                            this.enteredString += ";";
                            break;

                        case Keys.OemTilde:
                            this.enteredString += "~";
                            break;
                        #endregion

                        #region NUMBER KEYS
                        case Keys.D0:
                        case Keys.NumPad0:
                            this.enteredString += "0";
                            break;

                        case Keys.D1:
                        case Keys.NumPad1:
                            this.enteredString += "1";
                            break;

                        case Keys.D2:
                        case Keys.NumPad2:
                            this.enteredString += "2";
                            break;

                        case Keys.D3:
                        case Keys.NumPad3:
                            this.enteredString += "3";
                            break;

                        case Keys.D4:
                        case Keys.NumPad4:
                            this.enteredString += "4";
                            break;

                        case Keys.D5:
                        case Keys.NumPad5:
                            this.enteredString += "5";
                            break;

                        case Keys.D6:
                        case Keys.NumPad6:
                            this.enteredString += "6";
                            break;

                        case Keys.D7:
                        case Keys.NumPad7:
                            this.enteredString += "7";
                            break;

                        case Keys.D8:
                        case Keys.NumPad8:
                            this.enteredString += "8";
                            break;

                        case Keys.D9:
                        case Keys.NumPad9:
                            this.enteredString += "9";
                            break;
                        #endregion

                        #region ALPHA KEYS
                        case Keys.A:
                        case Keys.B:
                        case Keys.C:
                        case Keys.D:
                        case Keys.E:
                        case Keys.F:
                        case Keys.G:
                        case Keys.H:
                        case Keys.I:
                        case Keys.J:
                        case Keys.K:
                        case Keys.L:
                        case Keys.M:
                        case Keys.N:
                        case Keys.O:
                        case Keys.P:
                        case Keys.Q:
                        case Keys.R:
                        case Keys.S:
                        case Keys.T:
                        case Keys.U:
                        case Keys.V:
                        case Keys.W:
                        case Keys.X:
                        case Keys.Y:
                        case Keys.Z:
                            this.enteredString += (this.shifting() ? keys[i].ToString().ToUpper() : keys[i].ToString().ToLower());
                            break;
                        #endregion

                        //DEBUGGING
                        default:
                            //this.enteredString += keys[i].ToString();
                            break;
                    }
                }
            }
        }
    }
}
