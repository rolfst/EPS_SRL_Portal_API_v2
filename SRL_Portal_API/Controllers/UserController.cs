﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SRL.Data_Access;
using SRL.Models;
using SRL_Portal_API.Common;

namespace SRL_Portal_API.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [Route("roles/{userEmail}/")]
        [HttpGet]
        public List<Role> GetRoles(string userEmail)
        {
            if (!string.IsNullOrEmpty(userEmail))
            {
                if (ValidateUserEmail(userEmail))
                {
                    UserRespository userRepository = new UserRespository();
                    return userRepository.GetUserRoles(userEmail);
                }
                return new List<Role>();
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("No email passed"),
                    ReasonPhrase = "User email address not provided"
                };
                throw new HttpResponseException(response);
            }
        }

        [Route("screens/{userEmail}/")]
        [HttpGet]
        public List<Screen> GetScreens(string userEmail)
        {
            if (!string.IsNullOrEmpty(userEmail))
            {
                if (ValidateUserEmail(userEmail))
                {
                    UserRespository userRepository = new UserRespository();
                    return userRepository.GetUserScreens(userEmail);
                }

                return new List<Screen>();
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("No email passed"),
                    ReasonPhrase = "User email address not provided"
                };
                throw new HttpResponseException(response);
            }
        }


        private bool ValidateUserEmail(string userEmail)
        {
            RegexUtilities util = new RegexUtilities();
            if (util.IsValidEmail(userEmail))
                return true;
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Invalid email passed"),
                    ReasonPhrase = "Invalid user email address provided"
                };
                throw new HttpResponseException(response);
            }

        }



    }
}