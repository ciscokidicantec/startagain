using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

using System.Net;
using System.IO;
using System.Drawing;
using System.Configuration;
//using System.Drawing.Imaging;
//using System.Web.UI.WebControls;
//using Image = System.Web.UI.WebControls.Image;
//using System.Drawing.Drawing2;
//using System.Drawing.Image;

using System.Drawing.Drawing2D;
//using System.Json;
using System.Web.Script.Serialization;
//using MySql.Data.MySqlClient;
//using MySql.Data;
//using MySql.Data.MySqlClient;
using MySql.Data;

namespace startagain
{
    public partial class ini : System.Web.UI.Page
    {
        public MySqlParameterCollection Parameters { get; }

        public List<Postcodes> AllPostCodes;
        public string CurrentName;


        protected void Page_Load(object sender, EventArgs e)
        {

            string Nameofplace;

           if (!IsPostBack)
           {
         //     var countryQuery = from c in postcodes
         //     orderby c.codeareadescription
         //     select new { c.indexpostcode, c.codeareadescription };
              DropDownList1.DataValueField = "indexpostcode";
              DropDownList1.DataTextField = "codeareadescription";
        //      DropDownList1.DataSource = countryQuery.ToList();
              DataBind();
           }

            //MySqlParameterCollection pm = new Parameters();

            //MySqlParameter[] myParamArray;
            MySql.Data.MySqlClient.MySqlParameter[] myParamArray = new MySqlParameter[1];
            //myParamArray[0] = "@imageindex",MySqlDbType.VarChar, 255, MySqlDbDirection Direction.Input isNullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value);

            // myParamArray[0] = "@imageindex";
            //, MySqlDbType.VarChar, 36;

            MySqlParameter parameter = new MySqlParameter();
            parameter.ParameterName = "@CategoryName";
            parameter.MySqlDbType = MySqlDbType.Int32;
            //parameter.Direction = MySqlDbDirection.Input;
            parameter.Value = 2345;






            Postcodes Pscodes = new Postcodes();
            AllPostCodes = Pscodes.GetAPostCode();
            CurrentName = "";
            foreach (var currentpostcode in AllPostCodes)
            {
               Nameofplace = currentpostcode.Nameofplace;
               if (Nameofplace == "Swindon") CurrentName = Nameofplace;
            }

            Paramsinsert creparam = new Paramsinsert();

            MyDbConnections myConnection = new MyDbConnections();
            MySqlConnection MyConnection = myConnection.MyConnection();

            string mySelectQuery = "SELECT * FROM images";

          //  creparam.CreateMySqlCommand(MyConnection, mySelectQuery,myParamArray);
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            MySql.Data.MySqlClient.MySqlCommand cmd;
            MySql.Data.MySqlClient.MySqlConnection myconnection;

            String[] arrayurlimage = new String[4];

            WebClient client;

            Scrape Myscraper = new Scrape();
            Myscraper.Getimages();
        



                arrayurlimage[0] = "https://lc.zoocdn.com/32d3e36d37e1b758b4fa096e9078fd3bd1742ade.jpg";
            arrayurlimage[1] = "https://lc.zoocdn.com/c2a8a5af5cec2db187ae1a37d4f8d3965e9d5b87.jpg";
            arrayurlimage[2] = "https://media.rightmove.co.uk/dir/crop/10:9-16:9/78k/77900/73713541/77900_MAR190232_IMG_06_0000_max_476x317.jpg";
            arrayurlimage[3] = "https://pbprodimages.azureedge.net/images/medium/2a00f1ab-a7cb-4315-b247-c3d40636f041.jpg";
            //   arrayurlimage[4] = "https://www.rightmove.co.uk/property-for-sale/fullscreen/image-gallery.html?propertyId=64668300&photoIndex=4#";

            foreach (string imageUrl in arrayurlimage)
            {
                try
                {

                    string CmdString = "INSERT INTO estateporrtal.images(" +
                     "imageindex," +
                     "image," +
                     "myguid," +
                     "originalfilename," +
                     "imagesizeKbytes," +
                     "savedondiskfilename," +
                     "inserteddate," +
                     "postalcodeplace) " +
                     "VALUES(" +
                     "@imageindex," +
                     "@image," +
                     "@myguid," +
                     "@originalfilename," +
                     "@imagesizeKbytes," +
                     "@savedondiskfilename," +
                     "@inserteddate," +
                     "@postalcodeplace)";


                    //cmd.Connection = myConnection;
                    MyDbConnections getaninsertconnection = new MyDbConnections();
                    myconnection = getaninsertconnection.MyConnection();
                    //cmd = new MySqlCommand(CmdString, myconnection);

                    //byte[] imagebytes = new byte[1];
                    //imagebytes[0] = 3;

                    client = new WebClient();


                    byte[] imagebytes = client.DownloadData(imageUrl);
                    int filesizeKbytes = imagebytes.Length;




                    cmd = new MySqlCommand(CmdString, myconnection);
                    cmd.Parameters.Add("@imageindex", MySqlDbType.VarChar, 36);
                    cmd.Parameters.Add("@image", MySqlDbType.LongBlob);
                    cmd.Parameters.Add("@myguid", MySqlDbType.VarChar, 36);
                    cmd.Parameters.Add("@originalfilename", MySqlDbType.VarChar, 36);
                    cmd.Parameters.Add("@imagesizeKbytes", MySqlDbType.Int32);
                    cmd.Parameters.Add("@savedondiskfilename", MySqlDbType.VarChar, 255);
                    cmd.Parameters.Add("@inserteddate", MySqlDbType.DateTime);
                    cmd.Parameters.Add("@postalcodeplace", MySqlDbType.VarChar);

                    cmd.Parameters["@imageindex"].Value = Guid.NewGuid();
                    cmd.Parameters["@image"].Value = imagebytes;
                    cmd.Parameters["@myguid"].Value = Guid.NewGuid();
                    cmd.Parameters["@originalfilename"].Value = Guid.NewGuid();
                    cmd.Parameters["@imagesizeKbytes"].Value = filesizeKbytes;
                    cmd.Parameters["@savedondiskfilename"].Value = imageUrl;
                    cmd.Parameters["@inserteddate"].Value = DateTime.Now;
                    cmd.Parameters["@postalcodeplace"].Value = CurrentName;


                    myconnection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();
                    myconnection.Close();
                    myconnection.Dispose();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    Response.Write("Error Message = " + ex.Message);
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
