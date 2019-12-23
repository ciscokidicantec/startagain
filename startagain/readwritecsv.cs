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
                    //SqlConnection conn = new SqlConnection("Data source=.\\SQLEXPRESS; Database=FullPostcodes;" +
                    //"AttachDbFilename=|DataDirectory|\\FullPostcodes.mdf;Integrated Security = True");
                    //SqlCommand cmd = new SqlCommand("create table <Table Name>(empno int,empname varchar(50),salary money);", conn);

                    string dropcommand = "DROP TABLE IF EXISTS Customer;";

                    SqlCommand dropcmd = new SqlCommand(dropcommand, conn);
                    conn.Open();
                    dropcmd.ExecuteNonQuery();
                    dropcmd.Dispose();
                    conn.Close();

                    SqlCommand cmd = new SqlCommand("CREATE TABLE Customer(empno int" +
                        ",empname varchar(50)" +
                        ",salary money);"
                        , conn);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Table Created Successfully...");
                    conn.Close();
                    conn.Dispose();
                }
                catch (Exception e)
                {
                    string errormess = e.Message;
                 }                       

            //string[] mycolumns = csvParser.ReadLine();

            while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                    string Name = fields[0];
                    string Address = fields[1];
                }
            }

        }
    }
}


