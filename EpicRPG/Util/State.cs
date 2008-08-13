using System;
using System.Collections.Generic;
using System.Text;

namespace EpicRPG.Util
{
    public static class State
    {
        public enum GameState{
            INITIALIZING,
            MAIN_MENU,
            IN_PLAY,        //in case we need a generic playstate
            IN_PLAY_NORMAL,
            IN_PLAY_BATTLE,
            CUTSCENE,
            PAUSE,
        }

        public enum ComponentType{
            ABILITY,
            AUDIO,
            INVENTORY,
            MOVEMENT,
            RENDER,
        }

        public enum MenuState{
            MAIN_MENU,
            NEW_GAME,
            START_NEW_GAME,
            LOAD_GAME,
            SAVE_GAME,
            CREDITS,
            EXIT_GAME,
            NULL
        }

        public enum CutScene{
            TEXT
        }

        public enum Occupancy{
            OCCUPIED, UNOCCUPIED
        }
    }
}
