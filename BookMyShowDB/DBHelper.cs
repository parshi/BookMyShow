using BookMyShow.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookMyShow.DAL
{
    public class DBHelper
    {        
        string connectionString = string.Empty;
        public DBHelper()
        {
            connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\BookMyShow.mdf;Integrated Security=True";
        }
        internal DataTable ExecuteDataTable(SqlCommand sqlCommand)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    sqlCommand.Connection = connection;
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                    {
                        DataTable dTable = new DataTable();
                        dataAdapter.SelectCommand = sqlCommand;
                        dataAdapter.Fill(dTable);
                        return dTable;
                    }
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }

    }
}