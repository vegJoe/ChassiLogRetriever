using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Windows.Forms;

namespace RetriveChassiLogs
{
    class SaveToExcel
    {
        List<InsertValues> insertValues = new List<InsertValues>();
        public void writeToExcel(bool writeToExcelCheck)
        {
            try
            {
                if (writeToExcelCheck)
                {
                    string sql = null;
                    OleDbConnection oleDbcon;
                    OleDbCommand oleDbCmd = new OleDbCommand();
                    oleDbcon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\GOTSNM5104.got.volvocars.net\9413-APP-NASVIDACHASSISPROD\PROD\Loggbok.xlsx;Extended Properties=""Excel 12.0 Xml; HDR=YES""");
                    oleDbcon.Open();
                    oleDbCmd.Connection = oleDbcon;
                    foreach (InsertValues insertString in insertValues)
                    {
                        try
                        {
                            sql = $"INSERT INTO [Förfrågade loggar$] ([Felkod], [Device-id], [VIN], [Date requested], [Comments])" +
                                $" values ('{insertString.felkod}', '{insertString.deviceID}', '{insertString.VIN}', '{insertString.Date}', '{insertString.Comments}')";
                            oleDbCmd.CommandText = sql;
                            oleDbCmd.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Could not insert into excel.\n Error: " + e.ToString());
                            throw;
                        }
                    }
                    oleDbcon.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not open excel workbook.\n Error: " + e.ToString());
                throw;
            }
            insertValues.Clear();
        }

        public void insertToExcelString(string deviceID, string VIN, string errorCode, string description)
        {
            InsertValues insertString = new InsertValues();
            insertString.VIN = VIN;
            insertString.deviceID = deviceID;
            insertString.Date = DateTime.Today.ToString();
            insertString.felkod = errorCode;
            insertString.Comments = description;

            insertValues.Add(insertString);
        }

        public class InsertValues
        {
            public string felkod;
            public string deviceID;
            public string VIN;
            public string Date;
            public string Comments;
        }
    }
}
