using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Graphics;
using EpicRPG.Entities;

namespace EpicRPG.Util
{
    /// <summary>
    /// superclass representing a generic set of grpahics to be used for a section of an entity.
    /// eg. movement left, right, up, down, attacking, etc.
    /// </summary>
    public class GraphicsSet
    {
        //public State.EntityState state = State.EntityState.IDLE;

        public GameTexture north;
        public GameTexture north_east;
        public GameTexture east;
        public GameTexture south_east;
        public GameTexture south;
        public GameTexture south_west;
        public GameTexture west;
        public GameTexture north_west;

        public GraphicsSet(){

        }

        //public GraphicsSet(State.EntityState state){
        //    this.state = state;
        //}

        public virtual void addGraphics(string state, string name, int frameWidth, int frameHeight){

            if(state == null && this.south == null){
                this.south = this.makeGameTexture(name, frameWidth, frameHeight);
                return;
            }

            switch (state.ToUpper())
            {
                case "NORTH": north = this.makeGameTexture(name, frameWidth, frameHeight); break;
                case "NORTHEAST": north_east = this.makeGameTexture(name, frameWidth, frameHeight); break;
                case "EAST": east = this.makeGameTexture(name, frameWidth, frameHeight); break;
                case "SOUTH": south = this.makeGameTexture(name, frameWidth, frameHeight); break;
                case "SOUTHEAST": south_east = this.makeGameTexture(name, frameWidth, frameHeight); break;
                case "SOUTHWEST": south_west = this.makeGameTexture(name, frameWidth, frameHeight); break;
                case "WEST": west = this.makeGameTexture(name, frameWidth, frameHeight); break;
                case "NORTHWEST": north_west = this.makeGameTexture(name, frameWidth, frameHeight); break;
                default: return;
            }
        }

        protected GameTexture makeGameTexture(string name, int fw, int fh)
        {
            return new GameTexture(name, fw, fh);
        }

        public virtual GameTexture getCurrentGraphic(ref State.DirectionState orientation){
            switch(orientation){
                case State.DirectionState.EAST: return this.east;
                case State.DirectionState.NORTH: return this.north;
                case State.DirectionState.NORTH_EAST: return this.north_east;
                case State.DirectionState.NORTH_WEST: return this.north_west;
                case State.DirectionState.SOUTH: return this.south;
                case State.DirectionState.SOUTH_EAST: return this.south_east;
                case State.DirectionState.SOUTH_WEST: return this.south_west;
                case State.DirectionState.WEST: return this.west;
            }

            return null;
        }
    }
}
