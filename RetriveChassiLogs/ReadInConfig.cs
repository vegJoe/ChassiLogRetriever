using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace RetriveChassiLogs
{
    class ReadInConfig
    {
        private bool configExists;
        private string currentDirectory;
        public bool runConfig()
        {
            configExists = checkIfConfigExist();
            
            return configExists;
        }

        public void readConfig(ref string deviceID, ref string user, ref string password, ref bool writeToExcel, ref string computerName)
        {
            string[] configSettings = File.ReadAllLines(currentDirectory + @"\config.txt");

            deviceID = configSettings[0].Substring(configSettings[0].LastIndexOf(':') + 1);
            computerName = configSettings[1].Substring(configSettings[1].LastIndexOf(':') + 1);
            user = configSettings[2].Substring(configSettings[2].LastIndexOf(':') + 1);
            password = configSettings[3].Substring(configSettings[3].LastIndexOf(':') + 1);

            deviceID = deviceID.TrimStart(' '); deviceID = deviceID.TrimEnd(' ');
            computerName = computerName.TrimStart(' '); computerName = computerName.TrimEnd(' ');
            user = user.TrimStart(' '); user = user.TrimEnd(' ');
            password = password.TrimStart(' '); password = password.TrimEnd(' ');
            
            if (configSettings[4].Contains("no") || configSettings[4].Contains("No") || configSettings[4].Contains("NO"))
            {
                writeToExcel = false;
            }
        }
        private bool checkIfConfigExist()
        {
            currentDirectory = Directory.GetCurrentDirectory();
            bool configExist = false;

            if (!File.Exists(currentDirectory + @"\config.txt"))
            {
                string[] configSetup = { "DeviceID:", "ComputerName:", "UserID:", "Password:", "Write to Excel default on: Yes" };
                File.WriteAllLines(currentDirectory + @"\config.txt", configSetup);
            }
            else
                configExist = true;

            return configExist;
        }
    }
}
