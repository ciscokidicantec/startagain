using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace startagain
{
    public class Paramsinsert
    {

        public void CreateMySqlCommand(MySqlConnection myConnection, string mySelectQuery,MySqlParameter[] myParamArray)
        {
            string outmess = "";

            MySqlCommand myCommand = new MySqlCommand(mySelectQuery, myConnection);
            myCommand.CommandText = "SELECT id, name FROM mytable WHERE age=@age";
            myCommand.Parameters.Add(myParamArray);
            for (int j = 0; j < myParamArray.Length; j++)
            {
                myCommand.Parameters.Add(myParamArray[j]);
            }
            string myMessage = "";
            for (int i = 0; i < myCommand.Parameters.Count; i++)
            {
                myMessage += myCommand.Parameters[i].ToString() + "\n";
            }
            outmess = myMessage;
        }


    }
}