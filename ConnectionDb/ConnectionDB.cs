using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Practica_new.ConnectionDb
{
    public class ConnectionDB
    {
        private string _connectionString;
        public ConnectionDB()
        {
            _connectionString = @"Data Source=205NEW-9\SQLEXPRESS;Initial Catalog=WSR123;Integrated Security=True;Encrypt=False";
        }
        public ConnectionDB(string conn)
        {
            if (conn != null)
            {
                _connectionString = conn;
            }
        }
        public void SqlCommand(string sqlcommand)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlcommand, conn);
                cmd.ExecuteNonQuery();
            }
        }
        public void SqlSelecct(string sqlcommand, out DataTable table)
        {
            table = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlcommand, _connectionString))
            {
                adapter.Fill(table);
            }
        }
    }
}
