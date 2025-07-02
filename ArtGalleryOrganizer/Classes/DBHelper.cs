using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGalleryOrganizer.Classes
{
    public class DBHelper
    {
      
            private static string connStr = "Server=.;Database=ArtGalleryDB;Integrated Security=True;";

            public static DataTable GetData(string query)
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand(query, conn))
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }

            public static int Execute(string query, params SqlParameter[] parameters)
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }

