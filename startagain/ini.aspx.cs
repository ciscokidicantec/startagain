using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;



namespace startagain
{
    public partial class ini : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            MySql.Data.MySqlClient.MySqlCommand cmd;

            try
            {

                string CmdString = "INSERT INTO estateporrtal.images(" +
                    "imageindex," +
                    "image," +
                    "myguid," +
                    "originalfilename," +
                    "imagesizeKbytes," +
                    "savedondiskfilename," +
                    "inserteddate) " +
                    "VALUES(" +
                    "@imageindex," +
                    "@image," +
                    "@myguid," +
                    "@originalfilename," +
                    "@imagesizeKbytes," +
                    "@savedondiskfilename," +
                    "@inserteddate)";


                cmd = new MySqlCommand(CmdString, myConnection);
                cmd.Connection = myConnection;

                byte[] imagebytes = new byte[1];
                imagebytes[0] = 3;



                cmd = new MySqlCommand(CmdString, myConnection);
                cmd.Parameters.Add("@imageindex", MySqlDbType.VarChar,36);
                cmd.Parameters.Add("@image", MySqlDbType.LongBlob);
                cmd.Parameters.Add("@myguid", MySqlDbType.VarChar, 36);
                cmd.Parameters.Add("@originalfilename", MySqlDbType.VarChar, 36);
                cmd.Parameters.Add("@imagesizeKbytes", MySqlDbType.Int32);
                cmd.Parameters.Add("@savedondiskfilename", MySqlDbType.VarChar, 255);
                cmd.Parameters.Add("@inserteddate", MySqlDbType.DateTime);

                cmd.Parameters["@imageindex"].Value = Guid.NewGuid();
                cmd.Parameters["@image"].Value = imagebytes;
                cmd.Parameters["@myguid"].Value = Guid.NewGuid();
                cmd.Parameters["@originalfilename"].Value = Guid.NewGuid();
                cmd.Parameters["@imagesizeKbytes"].Value = 34567;
                cmd.Parameters["@savedondiskfilename"].Value = "abc";
                cmd.Parameters["@inserteddate"].Value = DateTime.Now;

                myConnection.Open();

                int RowsAffected = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write("Error Message = " + ex.Message);
            }
            myConnection.Close();
            myConnection.Dispose();
        }
    }
}
