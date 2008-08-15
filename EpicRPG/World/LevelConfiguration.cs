using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Managers;

namespace EpicRPG.World
{
    public class LevelConfiguration
    {
        public string levelName;
        public string levelDefinitionFile;
        public int levelNumber;

        public LevelConfiguration(string name, string file, int num){
            this.levelName = name;
            this.levelDefinitionFile = file;
            this.levelNumber = num;
        }

        public void buildMap(){
            FileManager.getInstance().ReadConfigurationFile(
                ConfigurationManager.getInstance().formatConfigurationFile(this.levelDefinitionFile)
            );
        }
    }
}
