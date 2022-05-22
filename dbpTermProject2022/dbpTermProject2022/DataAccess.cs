using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbpTermProject2022
{
    class DataAccess
    {

        static private string connString =
            System.Configuration.ConfigurationManager
                    .ConnectionStrings["DbpTermProject2022"].ConnectionString;


        static public DataTable GetData(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);

            DataTable dt = new DataTable();

            using (conn)
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }
            return dt;
        }

        static public object ExecuteScaler(string sql)
        {
            object retValue = null;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                retValue = cmd.ExecuteScalar();
            }

            return retValue;
        }
    }
}
