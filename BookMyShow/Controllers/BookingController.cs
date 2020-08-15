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
         [HttpPost]
         [Route("CheckAvalibility")]
         public CheckAvalibilityResponse CheckAvalibility([FromBody]CheckAvalibilityRequest request)
         {
             try
             {
                 DBHelper dBHelper = new DBHelper();
                 DataTable dt = dBHelper.CheckAvalibility(request);
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

         [HttpPost]
         [Route("Confirm")]
         public Response Booking([FromBody]BookingRequest request)
         {
             try
             {
                 DBHelper dBHelper = new DBHelper();
                 CheckAvalibilityRequest avalibityRequest = new CheckAvalibilityRequest()
                 {
                     ShowTime = request.ShowTime,
                     Cinema = request.Cinema,
                     City = request.City,
                     Location = request.Location,
                     MovieName = request.MovieName
                 };
                 DataTable dt = dBHelper.CheckAvalibility(avalibityRequest);
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
                 new DBHelper().BookTicket(request);
                 return new Response { Status = "Success", Message = "Booking Successfull" };
             }
             else
                 return new Response { Status = "Fail", Message = "Requested number of tickets are not available" };
         }
    }
}
