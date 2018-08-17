using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SRL.Data_Access.Entity;
using SRL.Models.ActorMasterData;
using SRL.Data_Access.Repository;
using System.Web.Http.Cors;
using SRL.Models;

namespace SRL_Portal_API.Controllers
{
    [EnableCors(origins: "http://localhost:9005", headers: "*", methods: "*")]
    public class ActorController : ApiController
    {
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public IList<API_LIST_ACTORS_TRANSACTION_Result> Index()
        {
            BACKUP_SRL_20180613Entities dbEntities = new BACKUP_SRL_20180613Entities();

            var result = dbEntities.API_LIST_ACTORS_TRANSACTION(-1)
                .ToList<API_LIST_ACTORS_TRANSACTION_Result>();

            return result;
        }

        [HttpPost]
        [Route("ActorMasterList")]
        public List<ActorMasterListResponse> GetActorMasterLists(ActorMasterListRequest request)
        {
            ActorRepository actorRepository = new ActorRepository();
            return actorRepository.GetActorMasterDataList(request);
        }

        [HttpGet]
        [Route("ActorsList")]
        public List<Actor> GetActorsList()
        {
            ActorRepository actorRepository = new ActorRepository();
          return actorRepository.GetActorsList(RequestContext.Principal.Identity.Name);
            
        }
    }
}