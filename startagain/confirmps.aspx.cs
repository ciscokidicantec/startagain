using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data.MySqlClient;
using System.IO;
using System.Configuration;


namespace startagain
{
    public partial class confirmps : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            //Read serial post code file

            int counter = 0;
            string line;
            int posofcomma;
            string filelinetext = "";

            MySqlConnection connpostcode;
            string DummyErrorMessage;

            //MyDbConnections getaninsertconnection = new MyDbConnections();
            //connpostcode = getaninsertconnection.MyConnection();

            string connStr = ConfigurationManager.ConnectionStrings["estateporrtalConnectionString"].ConnectionString;
            MySqlConnection myConnection = new MySqlConnection(connStr);

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Owner\Downloads\postcodes\postcodes.csv");

            MySqlCommand mypostcodecmd;
            MySqlDataReader rdrpostcode;
            int recordcounter = 0;

            try
            {
                while ((line = file.ReadLine()) != null)
                {
                    counter++;
                    recordcounter = 0;
                    if (counter == 1) continue;
                    filelinetext = line.Substring(0, line.IndexOf(','));
                    string commandstring = "SELECT Postcode FROM estateporrtal.justheadercsv WHERE Postcode = '" + filelinetext + "'";
                    mypostcodecmd = new MySqlCommand(commandstring, myConnection);
                    myConnection.Open();
                    rdrpostcode = mypostcodecmd.ExecuteReader();
                    while (rdrpostcode.Read())
                    {
                        recordcounter++;
                        if (recordcounter != 1)
                        {
                            continue;
                        }
                    }
                    mypostcodecmd.Dispose();
                    myConnection.Close();
                }
                myConnection.Dispose();
                file.Close();
            }
            catch (Exception postcodeex)
            {
                DummyErrorMessage = postcodeex.Message;
            }
        }
    }
}