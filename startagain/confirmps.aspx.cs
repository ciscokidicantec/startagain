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
            MySqlCommand mypostcodecmd;
            MySqlDataReader rdrpostcode;
            int recordcounter = 0;
            //int linenumber = 0;
            long linenumber = 0;
            string columnvalue;

            try
            {
                Response.BufferOutput = false;
                StreamReader file = new StreamReader(@"C:\Users\Owner\Downloads\postcodes\postcodes.csv");
                while ((line = file.ReadLine()) != null)
                {
                    if (linenumber >= 10) break;
                    counter++;
                    recordcounter = 0;
                    if (counter == 1) continue;
                    linenumber++;
                    filelinetext = line.Substring(0, line.IndexOf(','));
                    //mypostcodecmd = new MySqlCommand(commandstring, myConnection);
                    mypostcodecmd = new MySqlCommand();
                    string commandstring = "SELECT CAST(Postcode AS CHAR(36)) AS Postcode1 " +
                                            "FROM estateporrtal.justheadercsv " +
                                            "WHERE CAST(Postcode AS CHAR(36)) = '" + filelinetext + "'";
                    mypostcodecmd.Connection = myConnection;
                    mypostcodecmd.CommandText = commandstring;
                    myConnection.Open();
                    rdrpostcode = mypostcodecmd.ExecuteReader();
                    while (rdrpostcode.Read())
                    {
                        recordcounter++;
                        //columnvalue = (string)rdrpostcode["Postcode1"];
                        //string.Format("{0:n0}", linenumber);
                        Response.Write("<br/>Line Count = " + string.Format("{0,-12}", linenumber) + "      Post Code Value = " + (string)rdrpostcode["Postcode1"]);
                        Response.Flush();
                        if (recordcounter != 1) continue;
                    }
                    myConnection.Close();
                    mypostcodecmd.Dispose();
                }
                myConnection.Dispose();
                file.Close();
                file.Dispose();
            }
            catch (Exception postcodeex)
            {
                //DummyErrorMessage = postcodeex.Message;
                Response.Write("<br/>Error Message = " + postcodeex.Message);
                Response.Flush();

            }
            finally
            {
                myConnection.Dispose();
                //file.Close();
            }
        }
    }
}