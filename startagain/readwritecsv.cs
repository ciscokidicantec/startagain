using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

//Need to add a reference from Project/Add Reference Menu in Visual Studio

using Microsoft.VisualBasic.FileIO;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Input;
using System.Globalization;

namespace startagain
{
    public class Usecsv
    {
        public void ReadMyCSV(string filename, bool Skipheader,bool Deletetable,bool deletedatabase)
        {
            
            string path = filename;
            SqlCommand cmd;

            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                if (Skipheader)
                {
                    string[] mycolumns = csvParser.ReadFields();
                }

                try
                {

                    //< add name = "AutoRepairSqlProvider" connectionString =
                    //       "Data Source=.\SQLEXPRESS; Initial Catalog=MyDatabase; AttachDbFilename=|DataDirectory|\AutoRepairDatabase.mdf;
                    //     Integrated Security = True; User Instance = True"/

                    //SqlConnection conn = new SqlConnection("Data source=.\\SQLEXPRESS; Database=FullPostcodes;AttachDbFilename=|DataDirectory|\\FullPostcodes.mdf;Integrated Security = True");

                    SqlConnection conn = new SqlConnection("Data source=.\\SQLEXPRESS19; Database=FullPostcodes;" +
                    "AttachDbFilename=C:\\Program Files\\Microsoft SQL Server\\MSSQL15.SQLEXPRESS19\\MSSQL\\DATA\\FullPostcodes.mdf;" +
                    "Integrated Security = True;");
                    //;User Instance=True

                    //SqlConnection conn = new SqlConnection("Data source=.\\SQLEXPRESS19;" +
                    //"AttachDbFilename=|DataDirectory|\\FullPostcodes.mdf;Integrated Security = True");

                    //ppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp
                  
                    
                    if (deletedatabase)
                    {
                        try
                        {

                            String str;
                            SqlConnection myConn = new SqlConnection("Server=localhost;Data source=.\\SQLEXPRESS19;Integrated security=SSPI");
                            SqlCommand dropdatabasecmd;
                            string dropdatabasecommand;

                            dropdatabasecommand = "DROP DATABASE IF EXISTS EstateProperty;";
                                dropdatabasecmd = new SqlCommand(dropdatabasecommand, myConn);
                                myConn.Open();
                                dropdatabasecmd.ExecuteNonQuery();
                                dropdatabasecmd.Dispose();
                                myConn.Close();

                            str = "CREATE DATABASE EstateProperty ON PRIMARY " +
                                   "(NAME = EstateProperty, " +
                                   "FILENAME = 'C:\\Program Files\\Microsoft SQL Server\\MSSQL15.SQLEXPRESS19\\MSSQL\\DATA\\EstateProperty.mdf'," +
                                   "SIZE = 5000MB, MAXSIZE = UNLIMITED, FILEGROWTH = 25%)";

                            //"LOG ON (NAME = C:\\Program Files\\Microsoft SQL Server\\MSSQL15.SQLEXPRESS19\\MSSQL\\DATA\\EstateProperty_Log, " +
                            //"FILENAME = 'C:\\Program Files\\Microsoft SQL Server\\MSSQL15.SQLEXPRESS19\\MSSQL\\DATAEstateProperty_Log.ldf', " +
                            //"SIZE = 1000MB, " +
                            //"MAXSIZE = 4000MB, " +
                            //"FILEGROWTH = 50%)";

                            SqlCommand myCommand = new SqlCommand(str, myConn);
                            myConn.Open();
                            myCommand.ExecuteNonQuery();
                            myCommand.Dispose();
                            if (myConn.State == ConnectionState.Open)
                            {
                                myConn.Close();
                            }
                        }
                        catch (Exception e)
                        {
                            string mysqlerror = e.Message;
                        }
                    }
                    //return;

                    //pppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp

                    if (Deletetable)
                    {
                        SqlCommand dropcmd;
                        string dropcommand;

                        dropcommand = "DROP TABLE IF EXISTS TotalPostCodes;";
                        dropcmd = new SqlCommand(dropcommand, conn);
                        conn.Open();
                        dropcmd.ExecuteNonQuery();
                        dropcmd.Dispose();
                        conn.Close();

                        cmd = new SqlCommand("CREATE TABLE TotalPostcodes(" +
                        "Postcode nvarchar(20) NOT NULL PRIMARY KEY" +
                        ",In_Use bit" +
                        ",Latitude decimal(12,9)" +
                        ",Longitude decimal(12,9)" +
                        ",Easting int" +
                        ",Northing int" +
                        ",Grid_Ref text" +
                        ",County text" +
                        ",District text" +
                        ",Ward text" +
                        ",District_Code text" +
                        ",Ward_Code text" +
                        ",Country text" +
                        ",County_Code text" +
                        ",Constituency text" +
                        ",Introduced datetime" +
                        ",Terminated datetime" +
                        ",Parish text" +
                        ",National_Park text" +
                        ",Population int" +
                        ",Households int" +
                        ",Built_Up_Area text" +
                        ",Built_Up_Sub_Division text" +
                        ",Lower_Layer_Super_Output_Area text" +
                        ",Rural_Urban text" +
                        ",Region text" +
                        ",Altitude int" +
                        ",London_Zone int" +
                        ",LSOA_Code text" +
                        ",Local_Authority text" +
                        ",MSOA_Code text" +
                        ",Middle_Layer_Super_Output_Area text" +
                        ",Parish_Code text" +
                        ",Census_Output_Area text" +
                        ",Constituency_Code text" +
                        ",Index_Of_Multiple_Deprivation int" +
                        ",Quality int" +
                        ",User_Type int" +
                        ",Last_Updated datetime" +
                        ",Nearest_Station text" +
                        ",Distance_To_Station decimal(12,9)" +
                        ",Postcode_Area text" +
                        ",Postcode_District text" +
                        ",Police_Force text" +
                        ",Water_Company text" +
                        ",Plus_Code text);"
                        , conn);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Clone();
                        cmd.Dispose();
                        conn.Close();
                    }

                    //Insert csv rows
                    string CmdString = "INSERT INTO dbo.TotalPostcodes(" +
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
                     ",Terminated" +                             //        16  ,[Terminated]
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
                     ",@Terminated" +
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

                    cmd = new SqlCommand(CmdString, conn);
                    cmd.Parameters.Add("@Postcode", SqlDbType.NVarChar,20);
                    cmd.Parameters.Add("@In_Use", SqlDbType.Bit);
                    cmd.Parameters.Add("@Latitude", SqlDbType.Decimal);
                    cmd.Parameters.Add("@Longitude", SqlDbType.Decimal);
                    cmd.Parameters.Add("@Easting", SqlDbType.Int);
                    cmd.Parameters.Add("@Northing", SqlDbType.Int);
                    cmd.Parameters.Add("@Grid_Ref", SqlDbType.Text);
                    cmd.Parameters.Add("@County", SqlDbType.Text);
                    cmd.Parameters.Add("@District", SqlDbType.Text);
                    cmd.Parameters.Add("@Ward", SqlDbType.Text);
                    cmd.Parameters.Add("@District_Code", SqlDbType.Text);
                    cmd.Parameters.Add("@Ward_Code", SqlDbType.Text);
                    cmd.Parameters.Add("@Country", SqlDbType.Text);
                    cmd.Parameters.Add("@County_Code", SqlDbType.Text);
                    cmd.Parameters.Add("@Constituency", SqlDbType.Text);
                    cmd.Parameters.Add("@Introduced", SqlDbType.DateTime);
                    cmd.Parameters.Add("@Terminated", SqlDbType.DateTime);
                    cmd.Parameters.Add("@Parish", SqlDbType.Text);
                    cmd.Parameters.Add("@National_Park", SqlDbType.Text);
                    cmd.Parameters.Add("@Population", SqlDbType.Int);
                    cmd.Parameters.Add("@Households", SqlDbType.Int);
                    cmd.Parameters.Add("@Built_Up_Area", SqlDbType.Text);
                    cmd.Parameters.Add("@Built_Up_Sub_Division", SqlDbType.Text);
                    cmd.Parameters.Add("@Lower_Layer_Super_Output_Area", SqlDbType.Text);
                    cmd.Parameters.Add("@Rural_Urban", SqlDbType.Text);
                    cmd.Parameters.Add("@Region", SqlDbType.Text);
                    cmd.Parameters.Add("@Altitude", SqlDbType.Int);
                    cmd.Parameters.Add("@London_Zone", SqlDbType.Int);
                    cmd.Parameters.Add("@LSOA_Code", SqlDbType.Text);
                    cmd.Parameters.Add("@Local_Authority", SqlDbType.Text);
                    cmd.Parameters.Add("@MSOA_Code", SqlDbType.Text);
                    cmd.Parameters.Add("@Middle_Layer_Super_Output_Area", SqlDbType.Text);
                    cmd.Parameters.Add("@Parish_Code", SqlDbType.Text);
                    cmd.Parameters.Add("@Census_Output_Area", SqlDbType.Text);
                    cmd.Parameters.Add("@Constituency_Code", SqlDbType.Text);
                    cmd.Parameters.Add("@Index_Of_Multiple_Deprivation", SqlDbType.Int);
                    cmd.Parameters.Add("@Quality", SqlDbType.Int);
                    cmd.Parameters.Add("@User_Type", SqlDbType.Int);
                    cmd.Parameters.Add("@Last_Updated", SqlDbType.DateTime);
                    cmd.Parameters.Add("@Nearest_Station", SqlDbType.Text);
                    cmd.Parameters.Add("@Distance_To_Station", SqlDbType.Decimal);
                    cmd.Parameters.Add("@Postcode_Area", SqlDbType.Text);
                    cmd.Parameters.Add("@Postcode_District", SqlDbType.Text);
                    cmd.Parameters.Add("@Police_Force", SqlDbType.Text);
                    cmd.Parameters.Add("@Water_Company", SqlDbType.Text);
                    cmd.Parameters.Add("@Plus_Code", SqlDbType.Text);

                    conn.Open();
                    string[] fields = new string[46];
                    int rowseffected;

                    DateTime currentdt = DateTime.Now;

                    while (!csvParser.EndOfData)
                    {
                        // Read current line fields, pointer moves to the next line.
                        fields = csvParser.ReadFields();
                        cmd.Parameters["@Postcode"].Value = fields[0];
                       // if(fields[0] == "BN10 8LA")
                       // {
                       //     string errorofps = fields[0];
                       // }

                        //System.Globalization.NumberStyles.Any

                        cmd.Parameters["@In_Use"].Value = (fields[1] == "Yes") ? true : false;
                        cmd.Parameters["@Latitude"].Value = (fields[2] == "") ? Decimal.Parse("0.0", System.Globalization.NumberStyles.Any) 
                                                                                : Decimal.Parse(fields[2],System.Globalization.NumberStyles.Any);
                        cmd.Parameters["@Longitude"].Value = (fields[3] == "") ? Decimal.Parse("0.0", System.Globalization.NumberStyles.Any)
                                                                                : Decimal.Parse(fields[3],System.Globalization.NumberStyles.Any);
                        cmd.Parameters["@Easting"].Value = (fields[4] == "") ? 0 : int.Parse(fields[4]);
                        cmd.Parameters["@Northing"].Value = (fields[5] == "") ? 0 : int.Parse(fields[5]);
                        cmd.Parameters["@Grid_Ref"].Value = fields[6];
                        cmd.Parameters["@County"].Value = fields[7];
                        cmd.Parameters["@District"].Value = fields[8];
                        cmd.Parameters["@Ward"].Value = fields[9];
                        cmd.Parameters["@District_Code"].Value = fields[10];
                        cmd.Parameters["@Ward_Code"].Value = fields[11];
                        cmd.Parameters["@Country"].Value = fields[12];
                        cmd.Parameters["@County_Code"].Value = fields[13];
                        cmd.Parameters["@Constituency"].Value = fields[14];
                        cmd.Parameters["@Introduced"].Value = (fields[15] == "") ? currentdt : DateTime.Parse(fields[15]);
                        cmd.Parameters["@Terminated"].Value = (fields[16] == "") ? currentdt : DateTime.Parse(fields[16]);
                        cmd.Parameters["@Parish"].Value = fields[17];
                        cmd.Parameters["@National_Park"].Value = fields[18];
                        cmd.Parameters["@Population"].Value = (fields[19] == "") ? 0 : int.Parse(fields[19]);
                        cmd.Parameters["@Households"].Value = (fields[20] == "") ? 0 : int.Parse(fields[20]);
                        cmd.Parameters["@Built_Up_Area"].Value = fields[21];
                        cmd.Parameters["@Built_Up_Sub_Division"].Value = fields[22];
                        cmd.Parameters["@Lower_Layer_Super_Output_Area"].Value = fields[23];
                        cmd.Parameters["@Rural_Urban"].Value = fields[24];
                        cmd.Parameters["@Region"].Value = fields[25];
                        cmd.Parameters["@Altitude"].Value = (fields[26] == "") ? 0 : int.Parse(fields[26]);
                        cmd.Parameters["@London_Zone"].Value = (fields[27] == "") ? 0 : int.Parse(fields[27]);
                        cmd.Parameters["@LSOA_Code"].Value = fields[28];
                        cmd.Parameters["@Local_Authority"].Value = fields[29];
                        cmd.Parameters["@MSOA_Code"].Value = fields[30];
                        cmd.Parameters["@Middle_Layer_Super_Output_Area"].Value = fields[31];
                        cmd.Parameters["@Parish_Code"].Value = fields[32];
                        cmd.Parameters["@Census_Output_Area"].Value = fields[33];
                        cmd.Parameters["@Constituency_Code"].Value = fields[34];
                        cmd.Parameters["@Index_Of_Multiple_Deprivation"].Value = (fields[35] == "") ? 0 : int.Parse(fields[35]);
                        cmd.Parameters["@Quality"].Value = (fields[36] == "") ? 0 : int.Parse(fields[36]);
                        cmd.Parameters["@User_Type"].Value = (fields[37] == "") ? 0 : int.Parse(fields[37]);
                        cmd.Parameters["@Last_Updated"].Value = (fields[38] == "") ? currentdt : DateTime.Parse(fields[38]);
                        cmd.Parameters["@Nearest_Station"].Value = fields[39];
                        cmd.Parameters["@Distance_To_Station"].Value = (fields[40] == "") ? Decimal.Parse("0.0", System.Globalization.NumberStyles.Any)
                                                                                            : Decimal.Parse(fields[40],System.Globalization.NumberStyles.Any);
                        cmd.Parameters["@Postcode_Area"].Value = fields[41];
                        cmd.Parameters["@Postcode_District"].Value = fields[42];
                        cmd.Parameters["@Police_Force"].Value = fields[43];
                        cmd.Parameters["@Water_Company"].Value = fields[44];
                        cmd.Parameters["@Plus_Code"].Value = fields[45];

                        rowseffected = cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                    conn.Dispose();
                }
                catch (Exception e)
                {
                    string errormess02 = e.Message;
                }                       
                    //string[] mycolumns = csvParser.ReadLine();
            }
        }
    }
}


