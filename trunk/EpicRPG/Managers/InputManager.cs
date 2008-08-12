using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using Microsoft.Xna.Framework.Input;

namespace EpicRPG.Managers
{
    public class InputManager : Singleton<InputManager>
    {
        private KeyboardState keyStateCurrent,
                              keyStatePrev;
    }
}
