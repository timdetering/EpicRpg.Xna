using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace EpicRPG.Entities.Configuration
{
    public class EntityConfiguration
    {
        public int keyId = -1;

        public int classID;
        public string className;
        public string entityName;

        public int health = 100,
                   mana = 0,
                   strength = 1;

        //TODO: REMOVE SIZE?
        public Vector2 size = new Vector2(1, 1);
        public List<ComponentConfiguration> components = new List<ComponentConfiguration>();

        public EntityConfiguration(int id, string className, params string[] args){
            this.classID = id;
            this.className = className;

            //set all other properties that are given
            for(int i = 0; (i + 1) < args.Length; i += 2){
                switch(args[i].ToUpper()){
                    case "NAME":     entityName      = args[i + 1];              break;
                    case "HEALTH":   health          = int.Parse(args[i + 1]);   break;
                    case "MANA":     mana            = int.Parse(args[i + 1]);   break;
                    case "STRENGTH": health          = int.Parse(args[i + 1]);   break;
                    case "WIDTH":    size.X          = float.Parse(args[i + 1]); break;
                    case "HEIGHT":   size.Y          = float.Parse(args[i + 1]); break;
                    default: break;
                }
            }
        }

        public void addComponentConfiguration(string componentType, params string[] args){
            ComponentConfiguration cc = new ComponentConfiguration(componentType);

            for (int i = 0; (i + 1) < args.Length; i += 2){
                cc.addAttribute(new KeyValuePair<string, string>(args[i], args[i + 1]));
            }

            this.components.Add(cc);
        }

        public GameEntity buildEntity(){
            GameEntity e = new GameEntity(this.className, this.entityName, this.health, this.mana, this.strength);
            
            this.components.ForEach(delegate(ComponentConfiguration cc)
            {
                cc.addToEntity(e);
            });

            return e;
        }
    }
}
