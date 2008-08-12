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
            IN_PLAY_NORMAL,
            IN_PLAY_BATTLE,
            PAUSE,
        }
    }
}
