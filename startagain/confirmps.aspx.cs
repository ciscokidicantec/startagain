using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data.MySqlClient;
using System.IO;


//using System.Configuration;

//using MySql.Data.MySqlClient;

using System.Data.SqlClient;

using startagain;


namespace startagain
{
    public partial class confirmps : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            MySqlConnection transferconn;

            DateTime Startdate = DateTime.Now;

            //string transfer = "";

            string cs = @"server=localhost;database=Postcodetransfer;userid=root;password=Coreldraw1$";
            transferconn = null;
            MySqlCommand cmd;
            Response.BufferOutput = false;

            try
            {
                transferconn = new MySqlConnection(cs);
                transferconn.Open();

                string creatdb = "CREATE DATABASE IF NOT EXISTS `Postcodetransfer`;";
                cmd = new MySqlCommand(creatdb, transferconn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                transferconn.Close();
                transferconn.Dispose();

                string tabledroptext = "DROP TABLE IF EXISTS `postcodetransfer`.`testpostcodetransfer`";
                transferconn = new MySqlConnection(cs);
                cmd = new MySqlCommand(tabledroptext,transferconn);
                transferconn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                transferconn.Close();
                transferconn.Dispose();

                string cretble = "CREATE TABLE `postcodetransfer`.`testpostcodetransfer` (" +
                "PostCode nvarchar(20) NOT NULL," +
                "`In_Use` bit," +
                "`Latitude` decimal(12,9)," +
                "`Longitude` decimal(13,9)," +
                "`Easting` int," +
                "`Northing` int," +
                "`Grid_Ref` text," +
                "`County` text," +
                "`District` text," +
                "`Ward` text," +
                "`District_Code` text," +
                "`Ward_Code` text," +
                "`Country` text," +
                "`County_Code` text," +
                "`Constituency` text," +
                "`Introduced` datetime," +
                "`Dateterminated` datetime," + //changed from Terminated
                "`Parish` text," +
                "`National_Park` text," +
                "`Population` int," +
                "`Households` int," +
                "`Built_Up_Area` text," +
                "`Built_Up_Sub_Division` text," +
                "`Lower_Layer_Super_Output_Area` text," +
                "`Rural_Urban` text," +
                "`Region` text," +
                "`Altitude` int," +
                "`London_Zone` int," +
                "`LSOA_Code` text," +
                "`Local_Authority` text," +
                "`MSOA_Code` text," +
                "`Middle_Layer_Super_Output_Area` text," +
                "`Parish_Code` text," +
                "`Census_Output_Area` text," +
                "`Constituency_Code` text," +
                "`Index_Of_Multiple_Deprivation` int," +
                "`Quality` int," +
                "`User_Type` int," +
                "`Last_Updated` datetime," +
                "`Nearest_Station` text," +
                "`Distance_To_Station` decimal(12,9)," +
                "`Postcode_Area` text," +
                "`Postcode_District` text," +
                "`Police_Force` text," +
                "`Water_Company` text," +
                "`Plus_Code` text," +
                "PRIMARY KEY(`PostCode`)" +
                ");";

                transferconn = new MySqlConnection(cs);
                cmd = new MySqlCommand(cretble, transferconn);
                transferconn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                transferconn.Close();
                transferconn.Dispose();

                // cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Mercedes',57127)";

                //read seq svr
                string CmdString = "INSERT INTO `testpostcodetransfer` (" +
                 "Postcode" +                                        //        00  ([Postcode]
                 ",In_Use" +                                          //        01  ,[In Use]
                 ",Latitude" +                                        //        02  ,[Latitude]
                 ",Longitude" +                                //        03  ,[Longitude]
                 ",Easting" +                                  //        04  ,[Easting]
                 ",Northing" +                                 //        05  ,[Northing]
                 ",Grid_Ref" +                               //        06  ,[Grid Ref]
                 ",County" +                                   //        07  ,[County]
                 ",District" +                                 //        08  ,[District]
                 ",Ward" +                                     //        09  ,[Ward]
                 ",District_Code" +                          //        10  ,[District Code]
                 ",Ward_Code" +                              //        11  ,[Ward Code]
                 ",Country" +                                  //        12  ,[Country]
                 ",County_Code" +                            //        13  ,[County Code]
                 ",Constituency" +                             //        14  ,[Constituency]
                 ",Introduced" +                               //        15  ,[Introduced]
                 ",Dateterminated" +                             //        16  ,[Terminated]
                 ",Parish" +                                   //        17  ,[Parish]
                 ",National_Park" +                          //        18  ,[National Park]
                 ",Population" +                               //        19  ,[Population]
                 ",Households" +                               //        20  ,[Households]
                 ",Built_Up_Area" +                          //        21  ,[Built up area]
                 ",Built_Up_Sub_Division" +                //        22  ,[Built up sub - division]
                 ",Lower_Layer_Super_Output_Area" +          //        23  ,[Lower layer super output area]
                 ",Rural_Urban" +                            //        24  ,[Rural/Urban]
                 ",Region" +                                   //        25  ,[Region]
                 ",Altitude" +                                 //        26  ,[Altitude]
                 ",London_Zone" +                            //        27  ,[London zone]
                 ",LSOA_Code" +                              //        28  ,[LSOA Code]
                 ",Local_Authority" +                        //        29  ,[Local authority]
                 ",MSOA_Code" +                              //        30  ,[MSOA Code]
                 ",Middle_Layer_Super_Output_Area" +         //        31  ,[Middle layer super output area]
                 ",Parish_Code" +                            //        32  ,[Parish Code]
                 ",Census_Output_Area" +                     //        33  ,[Census output area]
                 ",Constituency_Code" +                      //        34  ,[Constituency Code]
                 ",Index_Of_Multiple_Deprivation" +          //        35  ,[Index of Multiple Deprivation]
                 ",Quality" +                                  //        36  ,[Quality]
                 ",User_Type" +                              //        37  ,[User Type]
                 ",Last_Updated" +                           //        38  ,[Last updated]
                 ",Nearest_Station" +                        //        39  ,[Nearest station]
                 ",Distance_To_Station" +                    //        40  ,[Distance to station]
                 ",Postcode_Area" +                          //        41  ,[Postcode Area]
                 ",Postcode_District" +                      //        42  ,[Postcode District]
                 ",Police_Force" +                           //        43  ,[Police force]
                 ",Water_Company" +                          //        44  ,[Water Company]
                 ",Plus_Code)" +
                 " VALUES(@Postcode" +
                 ",@In_Use" +
                 ",@Latitude" +
                 ",@Longitude" +
                 ",@Easting" +
                 ",@Northing" +
                 ",@Grid_Ref" +
                 ",@County" +
                 ",@District" +
                 ",@Ward" +
                 ",@District_Code" +
                 ",@Ward_Code" +
                 ",@Country" +
                 ",@County_Code" +
                 ",@Constituency" +
                 ",@Introduced" +
                 ",@Dateterminated" +           // Was Terminated
                 ",@Parish" +
                 ",@National_Park" +
                 ",@Population" +
                 ",@Households" +
                 ",@Built_Up_Area" +
                 ",@Built_Up_Sub_Division" +
                 ",@Lower_Layer_Super_Output_Area" +
                 ",@Rural_Urban" +
                 ",@Region" +
                 ",@Altitude" +
                 ",@London_Zone" +
                 ",@LSOA_Code" +
                 ",@Local_Authority" +
                 ",@MSOA_Code" +
                 ",@Middle_Layer_Super_Output_Area" +
                 ",@Parish_Code" +
                 ",@Census_Output_Area" +
                 ",@Constituency_Code" +
                 ",@Index_Of_Multiple_Deprivation" +
                 ",@Quality" +
                 ",@User_Type" +
                 ",@Last_Updated" +
                 ",@Nearest_Station" +
                 ",@Distance_To_Station" +
                 ",@Postcode_Area" +
                 ",@Postcode_District" +
                 ",@Police_Force" +
                 ",@Water_Company" +
                 ",@Plus_Code)";

                cmd = new MySqlCommand(CmdString, transferconn);
                cmd.Parameters.Add("@Postcode", MySqlDbType.VarChar, 20);
                cmd.Parameters.Add("@In_Use", MySqlDbType.Bit);
                cmd.Parameters.Add("@Latitude", MySqlDbType.Decimal);
                cmd.Parameters.Add("@Longitude", MySqlDbType.Decimal);
                cmd.Parameters.Add("@Easting", MySqlDbType.Int32);
                cmd.Parameters.Add("@Northing", MySqlDbType.Int32);
                cmd.Parameters.Add("@Grid_Ref", MySqlDbType.Text);
                cmd.Parameters.Add("@County", MySqlDbType.Text);
                cmd.Parameters.Add("@District", MySqlDbType.Text);
                cmd.Parameters.Add("@Ward", MySqlDbType.Text);
                cmd.Parameters.Add("@District_Code", MySqlDbType.Text);
                cmd.Parameters.Add("@Ward_Code", MySqlDbType.Text);
                cmd.Parameters.Add("@Country", MySqlDbType.Text);
                cmd.Parameters.Add("@County_Code", MySqlDbType.Text);
                cmd.Parameters.Add("@Constituency", MySqlDbType.Text);
                cmd.Parameters.Add("@Introduced", MySqlDbType.DateTime);
                cmd.Parameters.Add("@Dateterminated", MySqlDbType.DateTime);        // Was Terminated
                cmd.Parameters.Add("@Parish", MySqlDbType.Text);
                cmd.Parameters.Add("@National_Park", MySqlDbType.Text);
                cmd.Parameters.Add("@Population", MySqlDbType.Int32);
                cmd.Parameters.Add("@Households", MySqlDbType.Int32);
                cmd.Parameters.Add("@Built_Up_Area", MySqlDbType.Text);
                cmd.Parameters.Add("@Built_Up_Sub_Division", MySqlDbType.Text);
                cmd.Parameters.Add("@Lower_Layer_Super_Output_Area", MySqlDbType.Text);
                cmd.Parameters.Add("@Rural_Urban", MySqlDbType.Text);
                cmd.Parameters.Add("@Region", MySqlDbType.Text);
                cmd.Parameters.Add("@Altitude", MySqlDbType.Int32);
                cmd.Parameters.Add("@London_Zone", MySqlDbType.Int32);
                cmd.Parameters.Add("@LSOA_Code", MySqlDbType.Text);
                cmd.Parameters.Add("@Local_Authority", MySqlDbType.Text);
                cmd.Parameters.Add("@MSOA_Code", MySqlDbType.Text);
                cmd.Parameters.Add("@Middle_Layer_Super_Output_Area", MySqlDbType.Text);
                cmd.Parameters.Add("@Parish_Code", MySqlDbType.Text);
                cmd.Parameters.Add("@Census_Output_Area", MySqlDbType.Text);
                cmd.Parameters.Add("@Constituency_Code", MySqlDbType.Text);
                cmd.Parameters.Add("@Index_Of_Multiple_Deprivation", MySqlDbType.Int32);
                cmd.Parameters.Add("@Quality", MySqlDbType.Int32);
                cmd.Parameters.Add("@User_Type", MySqlDbType.Int32);
                cmd.Parameters.Add("@Last_Updated", MySqlDbType.DateTime);
                cmd.Parameters.Add("@Nearest_Station", MySqlDbType.Text);
                cmd.Parameters.Add("@Distance_To_Station", MySqlDbType.Decimal);
                cmd.Parameters.Add("@Postcode_Area", MySqlDbType.Text);
                cmd.Parameters.Add("@Postcode_District", MySqlDbType.Text);
                cmd.Parameters.Add("@Police_Force", MySqlDbType.Text);
                cmd.Parameters.Add("@Water_Company", MySqlDbType.Text);
                cmd.Parameters.Add("@Plus_Code", MySqlDbType.Text);

                transferconn.Open();
                int rowseffected;

                DateTime currentdt = DateTime.Now;

                //Obtain a connection then Open Seq Server and create a new reader object.  

                SqlConnection conn = new SqlConnection("Data source=.\\SQLEXPRESS19; Database=FullPostcodes;" +
                                    "AttachDbFilename=C:\\Program Files\\Microsoft SQL Server\\MSSQL15.SQLEXPRESS19\\MSSQL\\DATA\\FullPostcodes.mdf;" +
                                    "Integrated Security = True;");

                SqlCommand inscommand = new SqlCommand();
                inscommand.Connection = conn;
                inscommand.CommandText = "SELECT TOP(1000) * FROM TotalPostcodes;";
                //inscommand.CommandText = "SELECT * FROM TotalPostcodes;";

                conn.Open();

                SqlDataReader reader = inscommand.ExecuteReader();
                long linenumber = 0;

                while (reader.Read())
                {
                    cmd.Parameters["@Postcode"].Value = reader["Postcode"];
                    cmd.Parameters["@In_Use"].Value = reader["In_Use"];
                    //cmd.Parameters["@In_Use"].Value = (reader["In_Use"] == "Yes") ? true : false;
                    cmd.Parameters["@Latitude"].Value = reader["Latitude"];
                    //cmd.Parameters["@Latitude"].Value = (reader["Latitude"] == "") ? Decimal.Parse("0.0", System.Globalization.NumberStyles.Any)
                    //                                                        : Decimal.Parse(fields[2], System.Globalization.NumberStyles.Any);
                    cmd.Parameters["@Longitude"].Value = reader["Longitude"];
                    //cmd.Parameters["@Longitude"].Value = (fields[3] == "") ? Decimal.Parse("0.0", System.Globalization.NumberStyles.Any)
                    //                                                        : Decimal.Parse(fields[3], System.Globalization.NumberStyles.Any);
                    cmd.Parameters["@Easting"].Value = reader["Easting"];
                    //cmd.Parameters["@Easting"].Value = reader["Easting"];
                    cmd.Parameters["@Northing"].Value = reader["Northing"];
                    //cmd.Parameters["@Northing"].Value = (fields[5] == "") ? 0 : int.Parse(fields[5]);
                    cmd.Parameters["@Grid_Ref"].Value = reader["Grid_Ref"];
                    cmd.Parameters["@County"].Value =  reader["County"];
                    cmd.Parameters["@District"].Value = reader["District"];
                    cmd.Parameters["@Ward"].Value = reader["Ward"];
                    cmd.Parameters["@District_Code"].Value = reader["Ward"];
                    cmd.Parameters["@Ward_Code"].Value = reader["Ward_Code"];
                    cmd.Parameters["@Country"].Value = reader["Country"];
                    cmd.Parameters["@County_Code"].Value = reader["County_Code"];
                    cmd.Parameters["@Constituency"].Value = reader["Constituency"];
                    cmd.Parameters["@Introduced"].Value = reader["Introduced"];
                    cmd.Parameters["@Dateterminated"].Value = reader["Terminated"];
                    //cmd.Parameters["@Dateterminated"].Value = (reader["Terminated"] == "") ? currentdt : reader["Terminated"];
                    cmd.Parameters["@Parish"].Value = reader["Parish"];
                    cmd.Parameters["@National_Park"].Value = reader["National_Park"];
                    cmd.Parameters["@Population"].Value = reader["Population"];
                    //cmd.Parameters["@Population"].Value = (fields[19] == "") ? 0 : int.Parse(fields[19]);
                    cmd.Parameters["@Households"].Value = reader["Households"];
                    //cmd.Parameters["@Households"].Value = (fields[20] == "") ? 0 : int.Parse(fields[20]);
                    cmd.Parameters["@Built_Up_Area"].Value = reader["Built_Up_Area"];
                    cmd.Parameters["@Built_Up_Sub_Division"].Value = reader["Built_Up_Sub_Division"];
                    cmd.Parameters["@Lower_Layer_Super_Output_Area"].Value = reader["Lower_Layer_Super_Output_Area"];
                    cmd.Parameters["@Rural_Urban"].Value = reader["Rural_Urban"];
                    cmd.Parameters["@Region"].Value = reader["Region"];
                    cmd.Parameters["@Altitude"].Value = reader["Altitude"];
                    //cmd.Parameters["@Altitude"].Value = (fields[26] == "") ? 0 : int.Parse(fields[26]);
                    cmd.Parameters["@London_Zone"].Value = reader["London_Zone"];
                    //cmd.Parameters["@London_Zone"].Value = (fields[27] == "") ? 0 : int.Parse(fields[27]);
                    cmd.Parameters["@LSOA_Code"].Value = reader["LSOA_Code"];
                    cmd.Parameters["@Local_Authority"].Value = reader["Local_Authority"];
                    cmd.Parameters["@MSOA_Code"].Value = reader["MSOA_Code"];
                    cmd.Parameters["@Middle_Layer_Super_Output_Area"].Value = reader["Middle_Layer_Super_Output_Area"];
                    cmd.Parameters["@Parish_Code"].Value = reader["Parish_Code"];
                    cmd.Parameters["@Census_Output_Area"].Value = reader["Census_Output_Area"];
                    cmd.Parameters["@Constituency_Code"].Value = reader["Constituency_Code"];
                    cmd.Parameters["@Index_Of_Multiple_Deprivation"].Value = reader["Index_Of_Multiple_Deprivation"];
                    //cmd.Parameters["@Index_Of_Multiple_Deprivation"].Value = (fields[35] == "") ? 0 : int.Parse(fields[35]);
                    cmd.Parameters["@Quality"].Value = reader["Quality"];
                    //cmd.Parameters["@Quality"].Value = (fields[36] == "") ? 0 : int.Parse(fields[36]);
                    cmd.Parameters["@User_Type"].Value = reader["User_Type"];
                    //cmd.Parameters["@User_Type"].Value = (fields[37] == "") ? 0 : int.Parse(fields[37]);
                    cmd.Parameters["@Last_Updated"].Value = reader["Last_Updated"];
                    //cmd.Parameters["@Last_Updated"].Value = (fields[38] == "") ? currentdt : DateTime.Parse(fields[38]);
                    cmd.Parameters["@Nearest_Station"].Value = reader["Nearest_Station"];
                    cmd.Parameters["@Distance_To_Station"].Value = reader["Distance_To_Station"];
                    //cmd.Parameters["@Distance_To_Station"].Value = (fields[40] == "") ? Decimal.Parse("0.0", System.Globalization.NumberStyles.Any)
                    //                                                                    : Decimal.Parse(fields[40], System.Globalization.NumberStyles.Any);
                    cmd.Parameters["@Postcode_Area"].Value = reader["Postcode_Area"];
                    cmd.Parameters["@Postcode_District"].Value = reader["Postcode_District"];
                    cmd.Parameters["@Police_Force"].Value = reader["Police_Force"];
                    cmd.Parameters["@Water_Company"].Value = reader["Water_Company"];
                    cmd.Parameters["@Plus_Code"].Value = reader["Plus_Code"];

                    rowseffected = cmd.ExecuteNonQuery();
                    linenumber++;

                    Response.Write("<br/>Line Count = " + string.Format("{0,-12}", linenumber) +
                        "      Post Code Value = " + (string)reader["Postcode"] +
                        "   Latitude = " + reader["Latitude"] +
                        "   Latitude = " + reader["Longitude"] +
                        "   Dateterminated = " + reader["Terminated"]
                        );
                    Response.Flush();
                }
            }
            catch (MySqlException ex)

            {
                string emessage = ex.Message;

            }
            finally
            {
                DateTime Completiontime = DateTime.Now;
                TimeSpan ts = Completiontime - Startdate;
                Response.Write("<br/>Time Taken = " + ts);
                Response.Write("<br/>Transfering Data From Sequel Server To MySql Completed");
                Response.Flush();
                transferconn.Close();
                transferconn.Dispose();
                if (transferconn != null)
                {
                    transferconn.Close();
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Check mysql database against original .csv file make sure they are all there.

            int counter = 0;
            string line;
            string filelinetext = "";

            // Read sample data from CSV file

            Usecsv mycsvreader = new Usecsv();
            //mycsvreader.ReadMyCSV("C:\\Users\\Owner\\Downloads\\postcodes\\postcodes.csv", false,false, false);
            //mycsvreader.ReadMyCSV("C:\\Users\\Owner\\Downloads\\postcodes\\part2.csv", false,false, false);


            mycsvreader.ReadMyCSV("C:\\Users\\Owner\\Downloads\\postcodes\\totalpostcodes\\postcodes.csv", true, true, false);

         mycsvreader = null;
                       
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
                    if (linenumber >= 10)
                    {
                        break;
                    }
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