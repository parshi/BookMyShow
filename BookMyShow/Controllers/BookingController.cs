using BookMyShow.DAL;
using BookMyShow.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookMyShow.Controllers
{
    [RoutePrefix("api/booking")]
    public class BookingController : ApiController
    {
        private IDALLayer _dALLayer;
        public BookingController(IDALLayer dALLayer)
        {
            _dALLayer = dALLayer;
        }

        [HttpPost]
         [Route("checkavalibility")]
         public CheckAvalibilityResponse CheckAvalibility([FromBody]CheckAvalibilityRequest request)
         {
             try
             {
                 if (string.IsNullOrEmpty(request.Cinema) || string.IsNullOrEmpty(request.Location) || string.IsNullOrEmpty(request.MovieName) || string.IsNullOrEmpty(request.ShowTime) || string.IsNullOrEmpty(request.City) || string.IsNullOrEmpty(request.Date))
                 {
                     throw new Exception("MovieName, Cinema,Location,City,Date,Time are mandatory to CheckAvalibility");
                 }
                 DataTable dt = _dALLayer.CheckAvalibility(request);
                 DataRow dr = dt.Rows[0];
                 CheckAvalibilityResponse response = FormCheckAvalibilityResponse(dr);
                 return response;
             }
             catch (Exception)
             {
                 throw;
             }
         }

         private CheckAvalibilityResponse FormCheckAvalibilityResponse(DataRow dr)
         {
            try
            {
                CheckAvalibilityResponse response = new CheckAvalibilityResponse()
                {
                    Avaliable = Convert.ToInt32(dr["TotalSeatsAvaliable"]),
                    SliverClass = Convert.ToInt32(dr["SliverClass"]),
                    GoldClass = Convert.ToInt32(dr["GoldClass"]),
                    PlatinumClass = Convert.ToInt32(dr["Platinum"]),
                    VIP = Convert.ToInt32(dr["VIP"])
                };
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

         [HttpPost]
        [Authorize]
        [Route("confirm")]
         public Response Booking([FromBody]BookingRequest request)
         {
             try
             {
                 if (string.IsNullOrEmpty(request.Cinema) || string.IsNullOrEmpty(request.Location) || string.IsNullOrEmpty(request.MovieName) || string.IsNullOrEmpty(request.ShowTime) || string.IsNullOrEmpty(request.City) || string.IsNullOrEmpty(request.BookingDate))
                 {
                     throw new Exception("MovieName,Cinema,Location,City,Date,Time are mandatory to request");
                 }
                 CheckAvalibilityRequest avalibityRequest = new CheckAvalibilityRequest()
                 {
                     Date=request.BookingDate,
                     ShowTime = request.ShowTime,
                     Cinema = request.Cinema,
                     City = request.City,
                     Location = request.Location,
                     MovieName = request.MovieName
                 };
                 DataTable dt = _dALLayer.CheckAvalibility(avalibityRequest);
                 DataRow dr = dt.Rows[0];
                 CheckAvalibilityResponse avalibilityResponse = FormCheckAvalibilityResponse(dr);
                 if(avalibilityResponse != null)
                 {
                     if(avalibilityResponse.Avaliable !=0 && request.NumberOfTickets <= avalibilityResponse.Avaliable)
                     {
                         if (!Enum.GetNames(typeof(SeatingClass)).Contains(request.Class))
                         {
                              return new Response { Status = "Fail", Message = "Select proper seating class" };
                         }
                         return BookTicket(request, avalibilityResponse);
                     }
                 }
                 return new Response { Status = "Success", Message = "Booking Successfull" };
             }
             catch (Exception)
             {
                 throw;
             }
         }

        private Response BookTicket(BookingRequest request, CheckAvalibilityResponse avalibiltyResponse)
        {
            Response response = new Response();
            switch ((SeatingClass)Enum.Parse(typeof(SeatingClass), request.Class, true))
            {
                case SeatingClass.SliverClass:
                    {
                        response = ValidateAndBookTicket(avalibiltyResponse.SliverClass, request, avalibiltyResponse);
                    }
                    break;
                case SeatingClass.GoldClass:
                    {
                        response = ValidateAndBookTicket(avalibiltyResponse.GoldClass, request, avalibiltyResponse);
                    }
                    break;

                case SeatingClass.PlatinumClass:
                    {
                        response = ValidateAndBookTicket(avalibiltyResponse.PlatinumClass, request, avalibiltyResponse);
                    }
                    break;
                case SeatingClass.VIP:
                    {
                        response = ValidateAndBookTicket(avalibiltyResponse.VIP, request, avalibiltyResponse);
                    }
                    break;
            }
            return response;
        }

         private Response ValidateAndBookTicket(int numOfTickets, BookingRequest request, CheckAvalibilityResponse avalibiltyResponse)
         {
             if (request.NumberOfTickets <= numOfTickets)
             {
                _dALLayer.BookTicket(request);
                 return new Response { Status = "Success", Message = "Booking Successfull" };
             }
             else
                 return new Response { Status = "Fail", Message = "Requested number of tickets are not available" };
         }
    }
}
