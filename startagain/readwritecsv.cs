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

namespace startagain
{
    public class Usecsv
    {
        public void ReadMyCSV(string filename, bool Skipheader)
        {
            
            string path = filename;
            //var path = @"C:\Person.csv"; // Habeeb, "Dubai Media City, Dubai"

            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                if (Skipheader)
                {
                    string[] mycolumns = csvParser.ReadFields();
                    //return  mycolumns;
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

                    //String str;
                    //SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

                    //str = "CREATE DATABASE MyDatabase ON PRIMARY " +
                    //    "(NAME = MyDatabase_Data, " +
                    //    "FILENAME = 'C:\\MyDatabaseData.mdf', " +
                    //    "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                    //    "LOG ON (NAME = MyDatabase_Log, " +
                    //    "FILENAME = 'C:\\MyDatabaseLog.ldf', " +
                    //    "SIZE = 1MB, " +
                    //    "MAXSIZE = 5MB, " +
                    //    "FILEGROWTH = 10%)";

                    //SqlCommand myCommand = new SqlCommand(str, myConn);

//pppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp

                    string dropcommand = "DROP TABLE IF EXISTS TotalPostCodes;";

                    //MessageBox.Show("DataBase is Created Successfully");
                    //if (myConn.State == ConnectionState.Open)
                    //{
                    //    myConn.Close();
                    //}

                    SqlCommand dropcmd = new SqlCommand(dropcommand, conn);
                    conn.Open();
                    dropcmd.ExecuteNonQuery();
                    dropcmd.Dispose();
                    conn.Close();

                SqlCommand cmd = new SqlCommand("CREATE TABLE TotalPostcodes(" +
                        "Postcode nvarchar(20) NOT NULL PRIMARY KEY" +
                        ",In_Use bit" +
                        ",Latitude decimal(10,8)" +
                        ",Longitude decimal(10,8)" +
                        ",Easting int" +
                        ",Northing int" +
                        ",Grid_Ref text" +
                        ",County text" +
                        ",District text)"
                        //",Ward text" +
                        //",[District Code] text" +
                        //",[Ward Code] text" +
                        //",Country text" +
                        //",[County Code] text" +
                        //",Constituency text" +
                        //",Introduced text" +
                        //",[Terminated] text" +
                        //",Parish text" +
                        //",[National Park] text" +
                        //",Population text" +
                        //",Households text" +
                        //",[Built up area] text" +
                        //",[Built up sub - division] text" +
                        //",[Lower layer super output area] text" +
                        //",[Rural/Urban] text" +
                        //",Region text" +
                        //",Altitude text" +
                        //",[London zone] text" +
                        //",[LSOA Code] text" +
                        //",[Local authority] text" +
                        //",[MSOA Code] text" +
                        //",[Middle layer super output area] text" +
                        //",[Parish Code] text" +
                        //",[Census output area] text" +
                        //",[Constituency Code] text" +
                        //",[Index of Multiple Deprivation] text" +
                        //",Quality text" +
                        //",[User Type] text" +
                        //",[Last updated] text" +
                        //",[Nearest station] text" +
                        //",[Distance to station] text" +
                        //",[Postcode Area] text" +
                        //",[Postcode District] text" +
                        //",[Police force] text" +
                        //",[Water Company] text" +
                        //",[Plus Code] text);" + 
                        ,conn);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    cmd.Dispose();
                    conn.Close();

                    //string stmt = "INSERT INTO dbo.Test(id, name) VALUES(@ID, @Name)";
                    //SqlBulkCopy

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
                     ",District)" +                                 //        08  ,[District]
                                                                  //",Ward text" +                                     //        09  ,[Ward]
                                                                  //",[District Code] text" +                          //        10  ,[District Code]
                                                                  //",[Ward Code] text" +                              //        11  ,[Ward Code]
                                                                  //",Country text" +                                  //        12  ,[Country]
                                                                  //",[County Code] text" +                            //        13  ,[County Code]
                                                                  //",Constituency text" +                             //        14  ,[Constituency]
                                                                  //",Introduced text" +                               //        15  ,[Introduced]
                                                                  //",[Terminated] text" +                             //        16  ,[Terminated]
                                                                  //",Parish text" +                                   //        17  ,[Parish]
                                                                  //",[National Park] text" +                          //        18  ,[National Park]
                                                                  //",Population text" +                               //        19  ,[Population]
                                                                  //",Households text" +                               //        20  ,[Households]
                                                                  //",[Built up area] text" +                          //        21  ,[Built up area]
                                                                  //",[Built up sub - division] text" +                //        22  ,[Built up sub - division]
                                                                  //",[Lower layer super output area] text" +          //        23  ,[Lower layer super output area]
                                                                  //",[Rural/Urban] text" +                            //        24  ,[Rural/Urban]
                                                                  //",Region text" +                                   //        25  ,[Region]
                                                                  //",Altitude text" +                                 //        26  ,[Altitude]
                                                                  //",[London zone] text" +                            //        27  ,[London zone]
                                                                  //",[LSOA Code] text" +                              //        28  ,[LSOA Code]
                                                                  //",[Local authority] text" +                        //        29  ,[Local authority]
                                                                  //",[MSOA Code] text" +                              //        30  ,[MSOA Code]
                                                                  //",[Middle layer super output area] text" +         //        31  ,[Middle layer super output area]
                                                                  //",[Parish Code] text" +                            //        32  ,[Parish Code]
                                                                  //",[Census output area] text" +                     //        33  ,[Census output area]
                                                                  //",[Constituency Code] text" +                      //        34  ,[Constituency Code]
                                                                  //",[Index of Multiple Deprivation] text" +          //        35  ,[Index of Multiple Deprivation]
                                                                  //",Quality text" +                                  //        36  ,[Quality]
                                                                  //",[User Type] text" +                              //        37  ,[User Type]
                                                                  //",[Last updated] text" +                           //        38  ,[Last updated]
                                                                  //",[Nearest station] text" +                        //        39  ,[Nearest station]
                                                                  //",[Distance to station] text" +                    //        40  ,[Distance to station]
                                                                  //",[Postcode Area] text" +                          //        41  ,[Postcode Area]
                                                                  //",[Postcode District] text" +                      //        42  ,[Postcode District]
                                                                  //",[Police force] text" +                           //        43  ,[Police force]
                                                                  //",[Water Company] text" +                          //        44  ,[Water Company]
                                                                  //",[Plus Code] text)";                              //        45  ,[Plus Code])
                     " VALUES(@Postcode" +
                     ",@In_Use" +
                     ",@Latitude" +
                     ",@Longitude" +
                     ",@Easting" +
                     ",@Northing" +
                     ",@Grid_Ref" +
                     ",@County" +
                     ",@District)";

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
                    //cmd.Parameters.Add("@Ward", SqlDbType.Text);
                    //cmd.Parameters.Add("@[District Code]", SqlDbType.Text);
                    //cmd.Parameters.Add("@[Ward Code]", SqlDbType.Text);
                    //cmd.Parameters.Add("@Country", SqlDbType.Text);
                    //cmd.Parameters.Add("@[County Code]", SqlDbType.Text);
                    //cmd.Parameters.Add("@Constituency", SqlDbType.Text);
                    //cmd.Parameters.Add("@Introduced", SqlDbType.Text);
                    //cmd.Parameters.Add("@[Terminated]", SqlDbType.Text);
                    //cmd.Parameters.Add("@Parish", SqlDbType.Text);
                    //cmd.Parameters.Add("@[National Park]", SqlDbType.Text);
                    //cmd.Parameters.Add("@Population", SqlDbType.Text);
                    //cmd.Parameters.Add("@Households", SqlDbType.Text);
                    //cmd.Parameters.Add("@[Built up area]", SqlDbType.Text);
                    //cmd.Parameters.Add("@[Built up sub - division]", SqlDbType.Text);
                    //cmd.Parameters.Add("@[Lower layer super output area]", SqlDbType.Text);
                    //cmd.Parameters.Add("@[Rural/Urban]", SqlDbType.Text);
                    //cmd.Parameters.Add("@Region", SqlDbType.Text);
                    //cmd.Parameters.Add("@Altitude", SqlDbType.Text);
                    //cmd.Parameters.Add("@[London zone]", SqlDbType.Text);
                    //cmd.Parameters.Add("@[LSOA Code]", SqlDbType.Text);
                    //cmd.Parameters.Add("@[Local authority]", SqlDbType.Text);
                    //cmd.Parameters.Add("@[MSOA Code]", SqlDbType.Text);
                    //cmd.Parameters.Add("@[Middle layer super output area]", SqlDbType.Text);
                    //cmd.Parameters.Add("@[Parish Code]", SqlDbType.Text);
                    //cmd.Parameters.Add("@[Census output area]", SqlDbType.Text);
                    //cmd.Parameters.Add("@[User Type]", SqlDbType.Text);
                    //cmd.Parameters.Add("@[Last updated]", SqlDbType.Text);
                    //cmd.Parameters.Add("@[Nearest station]", SqlDbType.Text);
                    //cmd.Parameters.Add("@[Distance to station]", SqlDbType.Text);
                    //cmd.Parameters.Add("@[Postcode Area]", SqlDbType.Text);
                    //cmd.Parameters.Add("@[Postcode District]", SqlDbType.Text);
                    //cmd.Parameters.Add("@[Police force]", SqlDbType.Text);
                    //cmd.Parameters.Add("@[Water Company]", SqlDbType.Text);
                    //cmd.Parameters.Add("@[Plus Code]", SqlDbType.Text);

                    conn.Open();
                    string[] fields = new string[46];
                    int rowseffected;

                    //dbCommand.CommandText = "INSERT INTO People (name, isStudent) VALUES(@name, @isStudent)";
                    //dbCommand.Parameters.AddWithValue("@name", people1.name);
                    //dbCommand.Parameters.AddWithValue("@isStudent", people1.isStudent);
                    //dbCommand.ExecuteNonQuery();

                    while (!csvParser.EndOfData)
                    {
                        // Read current line fields, pointer moves to the next line.
                        fields = csvParser.ReadFields();
                        cmd.Parameters["@Postcode"].Value = fields[0];
                        cmd.Parameters["@In_Use"].Value = (fields[1] == "Yes") ? true : false;
                        cmd.Parameters["@Latitude"].Value = fields[2];
                        cmd.Parameters["@Longitude"].Value = fields[3];
                        cmd.Parameters["@Easting"].Value = (fields[4] == "") ? 0 : int.Parse(fields[4]);
                        cmd.Parameters["@Northing"].Value = (fields[5] == "") ? 0 : int.Parse(fields[5]);
                        cmd.Parameters["@Grid_Ref"].Value = fields[6];
                        cmd.Parameters["@County"].Value = fields[7];
                        cmd.Parameters["@District"].Value = fields[8];
                        //cmd.Parameters["@Ward"].Value = fields[9];
                        //cmd.Parameters["@[District Code"].Value = fields[10];
                        //cmd.Parameters["@[Ward Code"].Value = fields[11];
                        //cmd.Parameters["@Country"].Value = fields[12];
                        //cmd.Parameters["@[County Code"].Value = fields[13];
                        //cmd.Parameters["@Constituency text"].Value = fields[14];
                        //cmd.Parameters["@Introduced text"].Value = fields[15];
                        //cmd.Parameters["@[Terminated"].Value = fields[16];
                        //cmd.Parameters["@Parish text"].Value = fields[17];
                        //cmd.Parameters["@[National Park"].Value = fields[18];
                        //cmd.Parameters["@Population text"].Value = fields[19];
                        //cmd.Parameters["@Households text"].Value = fields[20];
                        //cmd.Parameters["@[Built up area"].Value = fields[21];
                        //cmd.Parameters["@[Built up sub - division"].Value = fields[22];
                        //cmd.Parameters["@[Lower layer super output area"].Value = fields[23];
                        //cmd.Parameters["@[Rural/Urban"].Value = fields[24];
                        //cmd.Parameters["@[Region"].Value = fields[25];
                        //cmd.Parameters["@[Altitude"].Value = fields[26];
                        //cmd.Parameters["@[London zone"].Value = fields[27];
                        //cmd.Parameters["@[LSOA Code"].Value = fields[28];
                        //cmd.Parameters["@[Local authority"].Value = fields[29];
                        //cmd.Parameters["@[MSOA Code"].Value = fields[30];
                        //cmd.Parameters["@[Middle layer super output area"].Value = fields[31];
                        //cmd.Parameters["@[Parish Code"].Value = fields[32];
                        //cmd.Parameters["@[Census output area"].Value = fields[33];
                        //cmd.Parameters["@[User Type"].Value = fields[34];
                        //cmd.Parameters["@[Last updated"].Value = fields[35];
                        //cmd.Parameters["@[Nearest station"].Value = fields[36];
                        //cmd.Parameters["@[Distance to station"].Value = fields[37];
                        //cmd.Parameters["@[Postcode Area"].Value = fields[38];
                        //cmd.Parameters["@[Postcode District"].Value = fields[39];
                        //cmd.Parameters["@[Police force"].Value = fields[40];
                        //cmd.Parameters["@[Water Company"].Value = fields[41];
                        //cmd.Parameters["@[Plus Code"].Value = fields[42];
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

            //while (!csvParser.EndOfData)
            //    {
                    // Read current line fields, pointer moves to the next line.
            //        string[] fields = csvParser.ReadFields();
            //        string Name = fields[0];
            //        string Address = fields[1];
            //    }
            }

        }
    }
}


