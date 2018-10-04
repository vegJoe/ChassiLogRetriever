using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Threading;

namespace RetriveChassiLogs
{
    public partial class Form1 : Form
    {     
        List<SaveToExcel.InsertValues> insertValues = new List<SaveToExcel.InsertValues>();
        PostString postStrings = new PostString();
        SaveToExcel saveToExcel = new SaveToExcel();
        private List<string> postString = new List<string>();
        private string cookieString;
        private string user;
        private string password;
        private string deviceID;
        private string computerName;
        private bool writeToExcelCheck = true;
        
        public Form1()
        {
            InitializeComponent();
            checkIfConfigExists();
        }

        private void checkIfConfigExists()
        {            
            ReadInConfig config = new ReadInConfig();
            if (!config.runConfig())
            {
                MessageBox.Show("Config file is not setup. DeviceID is mandatory to fill in, rest is optional.");
                sendButton.Enabled = false;
            }
            else
                getSettingsFromConfig(config);
        }

        private void getSettingsFromConfig(ReadInConfig config)
        {
            config.readConfig(ref deviceID, ref user, ref password, ref writeToExcelCheck, ref computerName);
            if(deviceID.Length < 15)
            {
                MessageBox.Show("Config file does not containe DeviceID. DeviceID and ComputerName is mandatory to fill in.");
                sendButton.Enabled = false;
            }
            else if(computerName.Length < 5)
            {
                MessageBox.Show("Config file does not contain ComputerName. DeviceID and ComputerName is mandatory to fill in.");
                sendButton.Enabled = false;
            }
            writeToExcelChkBox.Checked = writeToExcelCheck;
            userID.Text = user;
            passwordTxtBox.Text = password;
        }

        public void vinTxtBox_TextChanged(object sender, EventArgs e)
        {
        }

        public void deviceIDTxtBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            JSonCreater jSonFormatCookie = new JSonCreater();
            cookieString = jSonFormatCookie.formatCookie(cookie.Text);
            user = userID.Text;
            password = passwordTxtBox.Text;
            postString = postStrings.addToPostString(VIN.Lines, DeviceID.Lines);
            jsonCreate(postString, user, cookieString);
            saveToExcel.writeToExcel(writeToExcelCheck);    
        }

        private void userIDTxtBox_TextChanged(object sender, EventArgs e)
        {            
        }

        private void cookie_TextChanged(object sender, EventArgs e)
        {
        }

        public void addToListView(string postString, int statusCode)
        {
            ListViewItem post = new ListViewItem(postString);
            post.SubItems.Add(statusCode.ToString());
            listView1.Items.Add(post);

            Thread writeToListViewThread = new Thread(() => displayRespons(statusCode.ToString(), post));
            writeToListViewThread.Start();
        }

        public void addToExcelString(int vehicleNumber)
        {
            saveToExcel.insertToExcelString(DeviceID.Lines[vehicleNumber], VIN.Lines[vehicleNumber], errorcodeTxtBox.Text, descriptionTxtBox.Text);
        }

        private void displayRespons(string statusCode, ListViewItem listViewItem)
        {
            if (statusCode == "200")
            {
                listViewItem.BackColor = Color.Green;                
            }
            else
            {
                listViewItem.BackColor = Color.Red;
            }
        }

        private void jsonCreate(List<string> post, string user, string cookieString)
        {
            JSonCreater jSonPost = new JSonCreater();
            int statusCode = 0;
            int vehicleNumber = 0;
            foreach(string postString in post)
            {
                jSonPost.createJson(postString, user, cookieString, ref statusCode, ref vehicleNumber);

                addToListView(postString, statusCode);
                if (statusCode == 200)
                {
                    addToExcelString(vehicleNumber);
                }
            }           
        }

        private void responseListView_SelectedIndexChanged(object sender, EventArgs e)
        {            
        }

        private void descriptionTxtBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void errorcodeTxtBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void writeToExcelChkBox_CheckedChanged(object sender, EventArgs e)
        {
            writeToExcelCheck = writeToExcelChkBox.Checked;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            user = userID.Text;
            password = passwordTxtBox.Text;
            GetCookie getCookie = new GetCookie(user, password, deviceID, computerName);

            if(getCookie.ltpaToken2 != null)
            {
                cookie.Text = getCookie.ltpaToken2;
            }
        }

        private void passwordTxtBox_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
