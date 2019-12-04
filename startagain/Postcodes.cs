using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace startagain
{
    public class Postcodes
    {
        public int Postcodeindex { get; set; }
        public string Postcode { get; set; }
        public string Nameofplace { get; set; }

        public string current_postCode;


        public List<Postcodes> GetAPostCode()
        {

            //int latestpostcode;
            MySqlConnection connpostcode;
            //List<Postcodes> allpscodes;
            string DummyErrorMessage;

            List<Postcodes> postcodelist = new List<Postcodes>();
            Postcodes postcodeinstance = new Postcodes();

            MyDbConnections getaninsertconnection = new MyDbConnections();
            connpostcode = getaninsertconnection.MyConnection();

            try
            {
                string commandstring = "SELECT * FROM postcodes WHERE TRIM(POSTCODE) = 'SN'";
                //string commandstring = "SELECT * FROM postcodes WHERE TRIM(POSTCODE) = 'BN' OR TRIM(POSTCODE) = 'BD' OR TRIM(POSTCODE) = 'CB'";

                MySqlCommand mypostcodecmd = new MySqlCommand(commandstring, connpostcode);
                mypostcodecmd.CommandType = System.Data.CommandType.Text;

                connpostcode.Open();
                //  string areapostcode;
                MySqlDataReader rdrpostcode = mypostcodecmd.ExecuteReader();
                while (rdrpostcode.Read())
                {
                    postcodelist.Add(new Postcodes
                    {
                        Postcodeindex = (int)rdrpostcode["indexpostcode"],
                        Postcode = (string)rdrpostcode["postcode"],
                        Nameofplace = (string)rdrpostcode["codeareadescription"]
                    });
                }

                connpostcode.Close();
                connpostcode.Dispose();
            }
            catch (Exception postcodeex)
            {
                DummyErrorMessage = postcodeex.Message;
            }



            return postcodelist;
        }
    }
}
