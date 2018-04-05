using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UredjajFinder
{
   public class DAUredjaji
    {
        public static string GetID(string id)
        {
            SqlConnection cn = new SqlConnection(Properties.Settings.Default.DbConn);

            if (cn.State == System.Data.ConnectionState.Closed)
                cn.Open();



            string query = @"select * from Uredjaji
            where ID = @ID ";
            SqlCommand com = new SqlCommand(query, cn);

            com.Parameters.AddWithValue("@ID", id);

            object o=com.ExecuteScalar();

            if (o == null || o == DBNull.Value)
                return string.Empty;
            else
                return o.ToString();
        }
    }
}
