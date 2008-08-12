using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Entities.Components;

namespace EpicRPG.Entities.Configuration
{
    public class ComponentConfiguration
    {
        public string type;
        public List<KeyValuePair<string, string>> attributes = new List<KeyValuePair<string, string>>();

        public ComponentConfiguration(string type)
        {
            this.type = type;
        }

        public void addAttribute(KeyValuePair<string, string> att)
        {
            if (!attributes.Contains(att))
                attributes.Add(att);
        }

        public bool addToEntity(GameEntity e)
        {
            BaseComponent bc;
            
            switch (this.type)
            {
                case "InventoryComponent": bc = new InventoryComponent(e); break;
                case "AbilityComponent": bc = new AbilityComponent(e); break;
                case "AudioComponent": bc = new AudioComponent(e); break;
                case "MovementComponent": bc = new MovementComponent(e); break;
                case "RenderComponent": bc = new RenderComponent(e); break;
                default: return false;
            }

            e.addComponent(bc.setAttributes(attributes));
            return true;
        }
    }
}
