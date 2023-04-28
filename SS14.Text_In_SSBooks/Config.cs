using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SS14.Text_In_SSBooks
{
    public class Config
    {
        private readonly string pathConfig = "config.json";

        private readonly string defaultPathTxt = "Text";

        private readonly string defaultPathYML = "Resources\\Prototypes\\Entities\\Objects\\Misc\\";

        private readonly string defaultPathFTL = "Resources\\Locale\\en-US\\paper\\";

        public Config()
        {
            if (File.Exists(pathConfig))
            {
                ReadConfig();
            }
            else
            {
                WriteDefaultConfig();
            }
        }

        private string pathTxt;

        public string PathTxt
        {
            get 
            { 
                return pathTxt; 
            }
        }
        private string pathYML;

        public string PathYML
        {
            get
            {
                return pathYML;
            }
        }
        private string pathFTL;

        public string PathFTL
        {
            get
            {
                return pathFTL;
            }
        }
        
        public bool CreateDictionary()
        {
            if (!File.Exists(pathTxt))
            {
                Directory.CreateDirectory(pathTxt);
            }
            if (!File.Exists(pathYML))
            {
                Directory.CreateDirectory(pathYML);
            }
            if (!File.Exists(pathFTL))
            {
                Directory.CreateDirectory(pathFTL);
            }
            return true;
        }
        private async Task<bool> ReadConfig()
        {
            Dictionary<string, string> settingRead = new Dictionary<string, string>();

            using (FileStream fs = new FileStream(pathConfig, FileMode.Open))
            {
                settingRead = JsonSerializer.Deserialize<Dictionary<string, string>>(fs);
            }

            pathTxt = settingRead["pathTxt"];
            pathYML = settingRead["pathYML"];
            pathFTL = settingRead["pathFTL"];

            return true;
        }
        private async Task<bool> WriteDefaultConfig()
        {
            Dictionary<string, string> settingWrite = new Dictionary<string, string>();

            settingWrite.Add("pathTxt", defaultPathTxt);
            settingWrite.Add("pathYML", defaultPathYML);
            settingWrite.Add("pathFTL", defaultPathFTL);


            using (FileStream fs = new FileStream(pathConfig, FileMode.Create))
            {
                await JsonSerializer.SerializeAsync<Dictionary<string, string>>(fs, settingWrite);
            }

            pathTxt = defaultPathTxt;
            pathYML = defaultPathYML;
            pathFTL = defaultPathFTL;

            return true;
        }
    }
}
