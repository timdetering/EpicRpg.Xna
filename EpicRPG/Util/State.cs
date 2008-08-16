using System;
using System.Collections.Generic;
using System.Text;

namespace EpicRPG.Util
{
    public static class State
    {
        public static State.EntityState getEntityStateByName(string name){
            switch(name.ToUpper()){
                case "IDLE": return State.EntityState.IDLE;
                case "MOVING": return EntityState.MOVING;
                default: return EntityState.IDLE;
            }
        }

        public enum GameState{
            INITIALIZING,
            MENU,
            IN_PLAY,        //in case we need a generic playstate
            IN_PLAY_NORMAL,
            IN_PLAY_BATTLE,
            MESSAGE,
            CUTSCENE,
            PAUSE,
        }

        public enum ComponentType{
            ABILITY,
            AUDIO,
            INVENTORY,
            MOVEMENT,
            RENDER,
            WONDER,
        }

        public enum MenuState{
            MAIN_MENU,
            EPIC_MENU,
            EPIC_MENU_INVENTORY,
            EPIC_MENU_PARTY,
            EPIC_MENU_CHARACTER,
            EPIC_MENU_CHARACTER_INVENTORY,
            NEW_GAME,
            START_NEW_GAME,
            LOAD_GAME,
            SAVE_GAME,
            CREDITS,
            EXIT_GAME,
            NONE,
            NULL,
            DEBUG_ALL_ITEMS,
            DEBUG_ADD_ITEM,
        }

        public enum EntityState{
            IDLE,
            MOVING,
        }

        public enum TerrainType{
            GRASS,
            SHORT_GRASS,
            TALL_GRASS,
            DIRT,
            TREE,
            //TODO: subclass stuff
            ROAD,
            WATER,
            SHORE,
            WALL,
            FLOOR,
        }

        public enum DirectionState{
            NORTH,
            NORTH_EAST,
            EAST,
            SOUTH_EAST,
            SOUTH,
            SOUTH_WEST,
            WEST,
            NORTH_WEST,
        }

        public enum CutScene{
            TEXT
        }

        public enum Occupancy{
            OCCUPIED, UNOCCUPIED
        }

        public enum LocationType{
            PIXEL,
            CELL
        }

        public enum PartyMember{
            ONE,
            TWO,
            THREE,
            FOUR,
        }
    }
}
