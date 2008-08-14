using System;
using System.Collections.Generic;
using System.Text;

using EpicRPG.Util;
using Microsoft.Xna.Framework;
using EpicRPG.Entities;

namespace EpicRPG.Managers
{
    public class WorldManager : Singleton<WorldManager>
    {
        public List<WorldEntity> worldEntities;
    }
}