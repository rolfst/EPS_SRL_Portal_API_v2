using System.Web.Http;

namespace SRL_Portal_API.Controllers
{
    public class BaseController : ApiController
    {
        protected readonly log4net.ILog log = log4net.LogManager.GetLogger("EuropoolSystemPortal");
    }
}