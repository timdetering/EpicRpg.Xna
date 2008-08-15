using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using EpicRPG.World;

namespace EpicRPG.Managers
{
    public class LevelManager : Singleton<LevelManager>
    {
        private List<LevelConfiguration> _levelConfigurations;

        private LevelConfiguration currentLevel;
        private int currentLevelIndex = -1;

        public List<LevelConfiguration> levelConfigurations{
            get{return this._levelConfigurations;}
            set{
                if(value != null){
                    this._levelConfigurations = value;
                    this._levelConfigurations.Sort(delegate(LevelConfiguration l1, LevelConfiguration l2) { return l1.levelNumber.CompareTo(l2.levelNumber); });
                }
            }
        }

        public bool loadLevel(int levelNum){
            int i = 0;
            foreach (LevelConfiguration l in this._levelConfigurations){
                if (l.levelNumber == levelNum){
                    this.currentLevel = l;
                    this.currentLevelIndex = i;
                    l.buildMap();
                    return true;
                }
                i++;
            }

            return false;
        }

        public bool loadLevelById(int id){
            if (this._levelConfigurations != null && id < this._levelConfigurations.Count){
                this.currentLevelIndex = id;
                this.currentLevel = this._levelConfigurations[id];
                this.currentLevel.buildMap();
                return true;
            }
            return false;
        }

        public void loadNextLevel(){
            int nextLevel = this.currentLevelIndex + 1;

            if(!this.loadLevelById(nextLevel)){
                //TODO: ERROR!!!
            }
            //level is loaded
        }
    }
}
