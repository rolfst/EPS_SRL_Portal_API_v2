using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SRL.Models;
using SRL_Portal_API.Common;
using SRL.Models.Constants;
using SRL.Data_Access.Repository;

namespace SRL_Portal_API.Controllers
{
    [RoutePrefix("api")]
    public class UserController : BaseController
    {
        [Route("roles/{userEmail}/")]
        [HttpGet]
        [Authorize]
        public List<Role> GetRoles(string userEmail)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, "roles"));
            if (!string.IsNullOrEmpty(userEmail))
            {
                if (ValidateUserEmail(userEmail))
                {
                    UserRepository userRepository = new UserRepository();
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

        [Route("user/me")]
        [HttpGet]
        [Authorize]
        public UserProfile GetCurrentUserDetail()
        {
            UserRepository userRepository = new UserRepository();
            return userRepository.GetUserProfile(RequestContext.Principal.Identity.Name);
        }

        [Route("users")]
        [HttpPost]
        [CustomAuthorizationFilter(new string[] { UserRoles.SRLModuleAdministrator, UserRoles.SuperUser, UserRoles.UltraUser })]
        public List<User> GetUsers(UserListRequest userListRequest)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, "User\\users"));
            if (userListRequest == null)
                userListRequest = new UserListRequest();

            if (userListRequest.ViewingUserEmail == null)
                userListRequest.ViewingUserEmail = RequestContext.Principal.Identity.Name;
            UserRepository userRepository = new UserRepository();
            try
            {
                return userRepository.GetUsersList(userListRequest);
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
        public List<Screen> GetScreens()
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, "User\\Screens"));
            string userEmail = RequestContext.Principal.Identity.Name;

            if (!string.IsNullOrEmpty(userEmail))
            {
                if (ValidateUserEmail(userEmail))
                {
                    UserRepository userRepository = new UserRepository();
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

        [Route("IsUserExternal")]
        [HttpGet]
        [Authorize]
        public bool CheckIfExternalUser()
        {
            return new UserRepository().IsExternalUser(RequestContext.Principal.Identity.Name);
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