﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SRL.Data_Access.Entity;
using SRL.Models.ActorMasterData;
using SRL.Data_Access.Repository;
using SRL.Models;
using SRL_Portal_API.Common;
using SRL.Models.Constants;
using SRL.Models.Exceptions;
using System.Net;
using Newtonsoft.Json;
using SRL_Portal_API.Resources;

namespace SRL_Portal_API.Controllers
{
    [RoutePrefix("api")]
    public class ActorController : BaseController
    {
        [AcceptVerbs("GET")]
        [HttpGet]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator, UserRoles.Customer })]
        public IList<API_LIST_ACTORS_TRANSACTION_Result> Index()
        {
            // Todo: Get current User.
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, "Actor\\GetAll"));
            BACKUP_SRL_20180613Entities dbEntities = new BACKUP_SRL_20180613Entities();

            var result = dbEntities.API_LIST_ACTORS_TRANSACTION(-1)
                .ToList<API_LIST_ACTORS_TRANSACTION_Result>();

            return result;
        }

        [HttpPost]
        [Route("ActorMasterList")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public List<ActorMasterListResponse> GetActorMasterLists(ActorMasterListRequest request)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, "Actor\\GetActorMasterList"));
            ActorRepository actorRepository = new ActorRepository();
            return actorRepository.GetActorMasterDataList(request);
        }

        [HttpGet]
        [Route("ActorsList")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator, UserRoles.Customer })]
        public List<Actor> GetActorsList()
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, "Actor\\Actorslist"));
            ActorRepository actorRepository = new ActorRepository();
            return actorRepository.GetActorsList(RequestContext.Principal.Identity.Name);

        }

        [HttpGet]
        [Route("ActorMasterDetail")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public ActorDetailResponse GetActorMasterDetail(int actorId)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, "Actor\\ActorMasterDetail"));
            ActorRepository actorRepository = new ActorRepository();
            return actorRepository.GetActorDetail(actorId);
        }

        [HttpGet]
        [Route("LabelTypesForActor")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public Dictionary<string, string> GetLabelTypesForActor()
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, "Actor\\LabelTypesForActor"));
            ActorRepository actorRepository = new ActorRepository();
            return actorRepository.GetLabelTypes();
        }

        [HttpPost]
        [Route("SaveActor")]
        [CustomAuthorizationFilter(new string[] { UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public bool SaveActorDetail(AddActorDetailRequest request)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, "Actor\\SaveActor"));
            ActorRepository actorRepository = new ActorRepository();
            return actorRepository.SaveActorMaster(request);

        }

        [HttpPost]
        [Route("DeleteSLAForActor")]
        [CustomAuthorizationFilter(new string[] { UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public bool DeleteSLAForActor(int SLAId)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, "Actor\\DeleteSLAForActor"));
            ActorRepository actorRepository = new ActorRepository();
            if (actorRepository.DeleteSLA(SLAId) > 0)
                return true;
            else
                throw HttpMessageExceptionBuilder.Build(HttpStatusCode.InternalServerError, HttpMessageType.Error, JsonConvert.SerializeObject(string.Empty), Messages.DeleteSLAForActor, Messages.DeleteSLAForActorHeader);
        }
    }
}