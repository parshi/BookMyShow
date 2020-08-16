using BookMyShow.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookMyShow.DAL
{
    public class DALLayer : IDALLayer
    {
        string connectionString = string.Empty;

        public DALLayer()
        {
            connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\BookMyShow.mdf;Integrated Security=True";
        }
        void IDALLayer.AddMovie(Movie movie)
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

        void IDALLayer.GetMovies(Movie movie)
        {
            throw new NotImplementedException();
        }

        DataTable IDALLayer.GetMoviesByCity(string city)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.GetMoviesByCity", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@City", SqlDbType.VarChar).Value = city;
                    DataTable dt = new DBHelper().ExecuteDataTable(command);
                    return dt;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        DataTable IDALLayer.GetMoviesDetailsByName(string movieName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.GetMoviesDetailsByMovieName", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@movieName", SqlDbType.VarChar).Value = movieName;
                    DataTable dt = new DBHelper().ExecuteDataTable(command);
                    return dt;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        void IDALLayer.AddScreen(Screen screen)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.AddScreen", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = screen.Name;
                    command.Parameters.Add("@Location", SqlDbType.VarChar).Value = screen.Location;
                    command.Parameters.Add("@City", SqlDbType.VarChar).Value = screen.City;
                    command.Parameters.Add("@Capacity", SqlDbType.Int).Value = screen.Capacity;
                    command.Parameters.Add("@SliverClass", SqlDbType.Int).Value = screen.SliverClass;
                    command.Parameters.Add("@GoldClass", SqlDbType.Int).Value = screen.GoldClass;
                    command.Parameters.Add("@PlatinumClass", SqlDbType.Int).Value = screen.Platinum;
                    command.Parameters.Add("@VIP", SqlDbType.Int).Value = screen.VIP;
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        void IDALLayer.AddUser(Register details)
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

        DataTable IDALLayer.ValidateUser(Login loginDetails)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.ValidateLoginDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Email", SqlDbType.VarChar).Value = loginDetails.Email;
                    command.Parameters.Add("@Password", SqlDbType.VarChar).Value = loginDetails.Password;
                    DataTable dt = new DBHelper().ExecuteDataTable(command);
                    return dt;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        DataTable IDALLayer.CheckAvalibility(CheckAvalibilityRequest request)
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
                    command.Parameters.Add("@Date", SqlDbType.NVarChar).Value = request.Date;
                    command.Parameters.Add("@ShowTime", SqlDbType.NVarChar).Value = request.ShowTime;
                    DataTable dt = new DBHelper().ExecuteDataTable(command);
                    return dt;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        void IDALLayer.BookTicket(BookingRequest request)
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
                    command.Parameters.Add("@MovieName", SqlDbType.VarChar).Value = request.MovieName;
                    command.Parameters.Add("@ShowDate", SqlDbType.NVarChar).Value = request.BookingDate;
                    command.Parameters.Add("@ShowTime", SqlDbType.NVarChar).Value = request.ShowTime;
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        void IDALLayer.AddMovieToCinema(ScreeingRequest request)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.AddMovieToCinema", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Cinema", SqlDbType.VarChar).Value = request.Cinema;
                    command.Parameters.Add("@Movie", SqlDbType.VarChar).Value = request.Movie;
                    command.Parameters.Add("@ShowDate", SqlDbType.NVarChar).Value = request.ShowDate;
                    command.Parameters.Add("@ShowTime", SqlDbType.NVarChar).Value = request.ShowTime;
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