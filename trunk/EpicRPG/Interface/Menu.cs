using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using EpicRPG.Managers;
using Microsoft.Xna.Framework.Graphics;

namespace EpicRPG.Interface
{
    public class Menu
    {
        public string title;
        public List<MenuItem> menuItems;
        public int highlightedItem = -1;
        public Vector2 location;
        public int itemSpacer = 15;

        public Menu(){}

        public Menu(string title, params MenuItem[] items){
            this.menuItems = new List<MenuItem>(items.Length);
            this.title = title;
            this.location = new Vector2(10, 10);

            for(int i = 0; i < items.Length; i++){
                this.menuItems.Add(items[i]);
            }

            if (this.menuItems.Count > 0){
                for(int i = 0; i < this.menuItems.Count; i++){
                    if (!this.menuItems[i].disabled){
                        this.highlightedItem = i;
                        break;
                    }
                }
            }
        }

        public void Draw()
        {
            OutputManager.getInstance().Render_String(this.title, this.location, Color.BlueViolet);

            Vector2 nextLocation;

            for(int i = 0; i < this.menuItems.Count; i++){
                nextLocation = new Vector2(this.location.X, this.location.Y + this.itemSpacer*(2*(i + 1)));
                MenuItem item = this.menuItems[i];
                item.Draw(nextLocation, (i == this.highlightedItem ? Color.White : Color.Blue));
            }
        }

        public void Update(GameTime gameTime)
        {
            if (InputManager.getInstance().MOVE_DOWN)
                this.incrementHighlightedItem();

            else if (InputManager.getInstance().MOVE_UP)
                this.decrementHighlightedItem();

            else if (InputManager.getInstance().MOVE_RIGHT)
                this.menuItems[this.highlightedItem].Select();

            //set item to listen for input, if applicable
            if(this.menuItems[this.highlightedItem] is MenuItemWithInput){
                this.menuItems[this.highlightedItem].listenForInput(true);
            }

            this.menuItems[this.highlightedItem].Update();
        }

        public string getInputValueWithName(string inputName){
            foreach(MenuItemWithInput item in this.menuItems){
                if (item.text == inputName)
                    return item.inputValue;
            }

            return "";
        }

        private void incrementHighlightedItem(){
            do{
                if (this.highlightedItem < this.menuItems.Count - 1){
                    this.menuItems[this.highlightedItem].Deselect();
                    this.highlightedItem++;
                }
                else{
                    this.highlightedItem = 0;
                }
            } while (this.menuItems[this.highlightedItem].disabled);
        }

        private void decrementHighlightedItem(){
            do{
                if (this.highlightedItem > 0){
                    this.menuItems[this.highlightedItem].Deselect();
                    this.highlightedItem--;
                }
                else{
                    this.highlightedItem = this.menuItems.Count - 1;
                }
            } while (this.menuItems[this.highlightedItem].disabled);
        }

        public virtual void refreshMenu(){

        }
    }
}
