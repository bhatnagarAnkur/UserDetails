using Repositories;
using Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserModels;

namespace UserAPI.Controllers
{
    public class UserController : ApiController
    {
        public HttpResponseMessage GetUsers()
        {
            UserRepository userRepository = new UserRepository();
            var userDetailsList = userRepository.GetUsers();
            if (userDetailsList != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, userDetailsList);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Unable to fetch User Details");
            }
        }

        [HttpPost]
        public HttpResponseMessage Add(UserDetails userDetails)
        {
            if (userDetails != null)
            {
                UserRepository userRepository = new UserRepository();
                UserDetail userDetail = new UserDetail
                {
                    ID = userDetails.ID,
                    Forename = userDetails.Forename,
                    Surname = userDetails.Surname,
                    Date_of_Birth = userDetails.Date_of_Birth,
                    Gender = userDetails.Gender,
                    Home_Number = userDetails.Home_Number,
                    Work_Number = userDetails.Work_Number,
                    Mobile_Number = userDetails.Mobile_Number
                };

                bool flag = userRepository.Add(userDetail);
                if (flag)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, flag);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Unable to create User");
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please Provide User Details");
            }
        }
    }
}
