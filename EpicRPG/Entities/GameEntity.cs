using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Entities.Components;
using Microsoft.Xna.Framework;
using EpicRPG.Util;
using EpicRPG.Managers;
using EpicRPG.Entities.Items;

namespace EpicRPG.Entities
{
    public class GameEntity : BaseEntity
    {
        public string name;
        private string className;
        private List<BaseComponent> components;
        private Attribute
            health,
            mana;
        private int strength;
        private bool isEnemy;

        public GameEntity(){
            this.name = "";
            this.strength = 0;
            this.components = new List<BaseComponent>();
        }
        
        public GameEntity(string className, string name, int health, int mana, int strength, bool isEnemy){
            this.className = className;
            this.name = name;
            this.health = new Attribute(health, health);
            this.mana = new Attribute(mana, mana);
            this.strength = strength;
            this.components = new List<BaseComponent>();
            this.isEnemy = isEnemy;
        }

        public override void Draw()
        {
            ((RenderComponent)this.getComponent(State.ComponentType.RENDER)).Render(0, 0);
        }

        public void addComponent(BaseComponent bc){
            this.components.Add(bc);
        }

        public BaseComponent getComponent(State.ComponentType type){
            foreach(BaseComponent c in this.components){
                if (c.type == type)
                    return c;
            }

            return null;
        }

        public string whatIsInFrontOfMe(){
            switch(this.orientation){
                case State.DirectionState.NORTH:
                    return WorldManager.getInstance().describeEntityAtPixel(
                        this.location.X, this.location.Y - WorldManager.getInstance().currentMap.CELL_HEIGHT
                    );
                case State.DirectionState.SOUTH:
                    return WorldManager.getInstance().describeEntityAtPixel(
                        this.location.X, this.location.Y + WorldManager.getInstance().currentMap.CELL_HEIGHT
                    );
                case State.DirectionState.EAST:
                    return WorldManager.getInstance().describeEntityAtPixel(
                        this.location.X + WorldManager.getInstance().currentMap.CELL_WIDTH, this.location.Y
                    );
                case State.DirectionState.WEST:
                    return WorldManager.getInstance().describeEntityAtPixel(
                        this.location.X - WorldManager.getInstance().currentMap.CELL_WIDTH, this.location.Y
                    );
                default: return "What's that?";
            }
        }

        public override string Describe()
        {
            if (this.name != null)
                return this.name;

            return this.className;
        }

        public void useItem(Item newItem){
            MessageManager.getInstance().DisplayMessage(this.name + " uses " + newItem.name);
            newItem.UseMe(this);

            if(!newItem.constant){
                this.removeItem(ref newItem);
            }
        }

        public void removeItem(ref Item newItem){
            ((InventoryComponent)this.getComponent(State.ComponentType.INVENTORY)).inventory.Remove(newItem);
        }

        public string getItem(Item newItem){
            BaseComponent invc = this.getComponent(State.ComponentType.INVENTORY);
            if (invc != null)
                if (((InventoryComponent)(invc)).addItem(newItem))
                    return this.Describe() + " receives " + newItem.Describe();

            return this.Describe() + " cannot carry any more items.";
        }

        public void heal(int value){
            this.health.value += value;
        }

        public int getHealth(){
            return this.health.value;
        }

        public int getMaxHealth(){
            return this.health.maxValue;
        }

        public int getMana()
        {
            return this.mana.value;
        }

        public int getMaxMana()
        {
            return this.mana.maxValue;
        }

        public int getStrength()
        {
            return this.strength;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (BaseComponent c in this.components)
            {
                c.Update(gameTime);
            }
        }
    }
}
