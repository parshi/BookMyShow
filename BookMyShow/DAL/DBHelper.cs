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
            connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\LAB\BookMyShow\BookMyShow\App_Data\BookMyShow.mdf;Integrated Security=True";
        }
        internal void AddMovie(Movie movie)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.AddMovie", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = movie.Name;
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal void GetMovies(Movie movie)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.GetMovie", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = movie.Name;
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }
        private DataTable ExecuteDataTable(SqlCommand sqlCommand)
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

        internal void AddScreen(Screen screen)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.AddScreen", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = screen.Name;
                    command.Parameters.Add("@Location", SqlDbType.VarChar).Value = screen.Location;
                    command.Parameters.Add("@Capacity", SqlDbType.Int).Value = screen.Capacity;
                    command.Parameters.Add("@City", SqlDbType.Int).Value = screen.City;
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal DataTable GetMoviesByCity(string city)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.GetMoviesByCity", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@City", SqlDbType.VarChar).Value = city;
                    DataTable dt = ExecuteDataTable(command);
                    return dt;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal DataTable GetMoviesDetailsByName(string movieName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.GetMoviesDetailsByMovieName", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@movieName", SqlDbType.VarChar).Value = movieName;
                    DataTable dt = ExecuteDataTable(command);
                    return dt;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal void AddUser(Register details)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.AddUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = details.Name;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = details.Email;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = details.Password;
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal DataTable ValidateUser(Login loginDetails)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.ValidateLoginDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Email", SqlDbType.VarChar).Value = loginDetails.Email;
                    command.Parameters.Add("@Password", SqlDbType.VarChar).Value = loginDetails.Password;
                    DataTable dt = ExecuteDataTable(command);
                    return dt;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal DataTable CheckAvalibility(CheckAvalibilityRequest request)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.CheckAvalibility", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@MovieName", SqlDbType.VarChar).Value = request.MovieName;
                    command.Parameters.Add("@Cinema", SqlDbType.VarChar).Value = request.Cinema;
                    command.Parameters.Add("@Location", SqlDbType.VarChar).Value = request.Location;
                    command.Parameters.Add("@City", SqlDbType.VarChar).Value = request.City;
                    command.Parameters.Add("@ShowTime", SqlDbType.NVarChar).Value = request.ShowTime;
                    DataTable dt = ExecuteDataTable(command);
                    return dt;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal void BookTicket(BookingRequest request)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.BookTicket", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@SeatType", SqlDbType.VarChar).Value = request.Class;
                    command.Parameters.Add("@NumOfTickets", SqlDbType.Int).Value = request.NumberOfTickets;
                    command.Parameters.Add("@Cinema", SqlDbType.VarChar).Value = request.Cinema;
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}