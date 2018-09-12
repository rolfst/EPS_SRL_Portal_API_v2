using System.Web.Http;

namespace SRL_Portal_API.Controllers
{
    [RoutePrefix("api")]
    public class FileController : BaseController
    {
        [HttpPost]
        public string DownloadFile([FromBody] string path)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, "file\\download"));
            return path;
        }
    }
}