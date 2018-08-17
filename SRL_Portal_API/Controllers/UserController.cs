using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SRL.Data_Access;
using SRL.Models;
using SRL_Portal_API.Common;
using SRL.Models.Constants;
using SRL.Data_Access.Repository;

namespace SRL_Portal_API.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "http://localhost:9005", headers: "*", methods: "*")]
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

        [Route("users")]
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // [CustomAuthorizationFilter(new string[] { UserRoles.SRLModuleAdministrator, UserRoles.SuperUser, UserRoles.UltraUser})]
        public List<User> GetUsers(UserListRequest userListRequest)
        {
            if (userListRequest == null)
                userListRequest = new UserListRequest();

            if (userListRequest.ViewingUserEmail == null)
                userListRequest.ViewingUserEmail = RequestContext.Principal.Identity.Name;
            UserRespository userRespository = new UserRespository();
            try
            {
                return userRespository.GetUsersList(userListRequest);
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(response);
            }
        }


        [Route("screens")]
        [HttpGet]
        [Authorize]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<Screen> GetScreens()
        {
            string  userEmail = RequestContext.Principal.Identity.Name;

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