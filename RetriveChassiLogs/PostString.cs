using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetriveChassiLogs
{
    class PostString
    {
        private static string logString = "https://vida-prod.volvocars.biz/VidaAPI-0.1/rest/chassis/ops/v1/create/";
        private List<string> _postString = new List<string>();

        public List<string> addToPostString(string[] VIN, string[] DeviceID)
        {
            _postString.Clear();
            if (VIN.Length == DeviceID.Length)
            {
                for (int i = 0; i < VIN.Length; i++)
                {
                    if (DeviceID[i] != "" || VIN[i] != "")
                    {
                        _postString.Add(logString + DeviceID[i] + "/" + VIN[i]);                        
                    }
                }
            }
            else
            {
                MessageBox.Show("Number of VIN and DeviceID does not match!");
            }
            return _postString;
        }
    }
}
