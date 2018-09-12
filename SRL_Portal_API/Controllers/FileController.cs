using System.Web.Http;
using SRL.Models.Constants;
using SRL_Portal_API.Common;

namespace SRL_Portal_API.Controllers
{
    [RoutePrefix("api")]
    public class FileController : BaseController
    {
        [HttpPost]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.Customer, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public string DownloadFile([FromBody] string path)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, "file\\download"));
            return path;
        }
    }
}