using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data.MySqlClient;
using System.IO;
//using System.Configuration;

using startagain;


namespace startagain
{
    public partial class confirmps : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Check mysql database against original .csv file make sure they are all there.

            int counter = 0;
            string line;
            string filelinetext = "";

            // Read sample data from CSV file

            Usecsv mycsvreader = new Usecsv();
            mycsvreader.ReadMyCSV("C:\\Users\\Owner\\Downloads\\postcodes\\dummypostcodes.csv", true);

            MySqlConnection connpostcode;
            //string DummyErrorMessage;

            MyDbConnections getaninsertconnection = new MyDbConnections();
            connpostcode = getaninsertconnection.MyConnection();

            //not supported in mysql "MultipleActiveResultSets = true;"

            //The connection is done in a seperate class as shown above.
            //string connStr = ConfigurationManager.ConnectionStrings["estateporrtalConnectionString"].ConnectionString;
            //MySqlConnection myConnection = new MySqlConnection(connStr);

            MySqlCommand mypostcodecmd;
            MySqlDataReader rdrpostcode;
            int recordcounter;
            long linenumber = 0;

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
//                    mypostcodecmd.Connection = myConnection;
                    mypostcodecmd.Connection = connpostcode;

                    mypostcodecmd.CommandText = commandstring;

                    connpostcode.Open();
                    //myConnection.Open();
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

                    connpostcode.Close();
                    //myConnection.Close();
                    mypostcodecmd.Dispose();
                }
                connpostcode.Dispose();
                //myConnection.Dispose();

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
                connpostcode.Dispose();
                //myConnection.Dispose();
            }
        }
    }
}