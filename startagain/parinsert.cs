﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace startagain
{
    public static class SqlCommandExt
    {

        //MySql.Data.MySqlClient.SqlParameter SqlParameter[] AddArrayParameters<T>;

        /// <summary>
        /// This will add an array of parameters to a SqlCommand. This is used for an IN statement.
        /// Use the returned value for the IN part of your SQL call. (i.e. SELECT * FROM table WHERE field IN ({paramNameRoot}))
        /// </summary>
        /// <param name="cmd">The SqlCommand object to add parameters to.</param>
        /// <param name="paramNameRoot">What the parameter should be named followed by a unique value for each value. This value surrounded by {} in the CommandText will be replaced.</param>
        /// <param name="values">The array of strings that need to be added as parameters.</param>
        /// <param name="dbType">One of the System.Data.SqlDbType values. If null, determines type based on T.</param>
        /// <param name="size">The maximum size, in bytes, of the data within the column. The default value is inferred from the parameter value.</param>
        public static MySqlParameter[] AddArrayParameters<T>(this MySql.Data.MySqlClient.MySqlCommand cmd, string paramNameRoot, IEnumerable<T> values, MySqlDbType? dbType = null, int? size = null)
        {
            /* An array cannot be simply added as a parameter to a SqlCommand so we need to loop through things and add it manually. 
             * Each item in the array will end up being it's own SqlParameter so the return value for this must be used as part of the
             * IN statement in the CommandText.
             */
            var parameters = new List<MySqlParameter>();
            var parameterNames = new List<string>();
            var paramNbr = 1;
            foreach (var value in values)
            {
                var paramName = string.Format("@{0}{1}", paramNameRoot, paramNbr++);
                parameterNames.Add(paramName);
                MySqlParameter p = new MySqlParameter(paramName, value);
                if (dbType.HasValue)
                    p.MySqlDbType = dbType.Value;
                if (size.HasValue)
                    p.Size = size.Value;
                cmd.Parameters.Add(p);
                parameters.Add(p);
            }

            cmd.CommandText = cmd.CommandText.Replace("{" + paramNameRoot + "}", string.Join(",", parameterNames));

            return parameters.ToArray();
        }

    }
//var cmd = new MySqlCommand("SELECT * FROM TableA WHERE Age IN ({Age})");
//cmd.AddArrayParameters("Age", new int[] { 1, 2, 3 });
}