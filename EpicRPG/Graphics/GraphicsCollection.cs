using System;
using System.Text;
using EpicRPG.Util;
using System.Collections;
using System.Collections.Generic;
using EpicRPG.Entities;

namespace EpicRPG.Graphics
{
    public class GraphicsCollection
    {
        public int keyId = -1;
        public string name;

        protected List<KeyValuePair<State.EntityState, GraphicsSet>> graphics;

        public GraphicsCollection(int id, string name){
            this.keyId = id;
            this.name = name;
            this.graphics = new List<KeyValuePair<State.EntityState, GraphicsSet>>();
        }

        public virtual GameTexture getCurrentGraphic(ref BaseEntity e){
            return this.getGraphicsByState(e.currentState).getCurrentGraphic(ref e.orientation);
        }

        public virtual bool contains(State.EntityState state){
            foreach (KeyValuePair<State.EntityState, GraphicsSet> pair in this.graphics){
                if (pair.Key == state)
                    return true;
            }

            return false;
        }

        public virtual GraphicsSet getGraphicsByState(State.EntityState state){
            foreach(KeyValuePair<State.EntityState, GraphicsSet> pair in this.graphics){
                if (pair.Key == state)
                    return pair.Value;
            }

            return null;
        }

        public virtual void addGraphics(State.EntityState state, GraphicsSet set){
            if (!this.contains(state))
                this.graphics.Add(new KeyValuePair<State.EntityState, GraphicsSet>(state, set));
        }
    }
}
