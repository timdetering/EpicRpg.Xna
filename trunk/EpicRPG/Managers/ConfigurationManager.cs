using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;

namespace EpicRPG.Managers
{
    public class ConfigurationManager : Singleton<ConfigurationManager>
    {

        #region SETTING FLAGS
        public bool AUDIO_ENABLED = true;
        public bool PLAY_BG_MUSIC = true;
        #endregion

        private string configRoot = "Configuration";
        private string configScheme = "EpicRPG";

        public string contentRoot = "Content";

        public List<string> configurationFiles;

        public void setConfigurationSetting(string setting, string value)
        {
            switch (setting.ToUpper())
            {

                case "CONFIGROOT":
                case "CONFIGURATIONROOT":
                    if (this.configurationFiles == null)
                        this.configRoot = value;
                    else
                        Console.WriteLine("Cannot modify configuration root location after files have been added");
                    break;

                case "CONFIGSCHEME":
                case "CONFIGURATIONSCHEME":
                    if (this.configurationFiles == null)
                        this.configScheme = value;
                    else
                        Console.WriteLine("Cannot modify configuration scheme location after files have been added");
                    break;

                case "CONTENTROOT":
                    this.contentRoot = value;
                    break;

                case "CONFIGURATIONFILE":
                    if (this.configurationFiles == null) this.configurationFiles = new List<string>();
                    this.configurationFiles.Add(this.configRoot + "/" + this.configScheme + "/" + value);
                    break;

                case "AUDIOENABLED":
                    this.AUDIO_ENABLED = bool.Parse(value);
                    break;

                case "PLAYBACKGROUNDMUSIC":
                    this.PLAY_BG_MUSIC = bool.Parse(value);
                    break;

                case "DRAWENTITYGRID":
                case "SHOWENTITYGRID":
                    break;

                case "DRAWOCCUPANCYGRID":
                case "SHOWOCCUPANCYGRID":
                    break;
            }
        }

    }
}
