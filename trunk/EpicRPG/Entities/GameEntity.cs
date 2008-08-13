using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Entities.Components;
using Microsoft.Xna.Framework;

namespace EpicRPG.Entities
{
    public class GameEntity : BaseEntity
    {
        public string name;
        private string className;
        private List<BaseComponent> components;
        private Vector2 location;
        private Attribute
            health,
            mana;
        private int strength;

        public GameEntity(){
            this.name = "";
            this.strength = 0;
            this.components = new List<BaseComponent>();
        }
        
        public GameEntity(string className, string name, int health, int mana, int strength){
            this.className = className;
            this.name = name;
            this.health = new Attribute(health, health);
            this.mana = new Attribute(mana, mana);
            this.strength = strength;
            this.components = new List<BaseComponent>();
        }

        public void addComponent(BaseComponent bc){
            this.components.Add(bc);
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

        
    }
}
