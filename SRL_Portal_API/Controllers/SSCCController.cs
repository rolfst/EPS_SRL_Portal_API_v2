using SRL.Data_Access.Adapter;
using SRL.Data_Access.Repository;
using SRL.Models.SSCC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Newtonsoft.Json;
using SRL.Models.Constants;
using SRL_Portal_API.Common;
using SRL.Data_Access.Common;
using SRL.Models.Exceptions;
using SRL_Portal_API.Resources;
using SRL.Models.ActionTile;

namespace SRL_Portal_API.Controllers
{
    /// <summary>
    /// Controller for all SSCC related actions
    /// </summary>
    [RoutePrefix("api")]
    public class SSCCController : BaseController
    {
        private readonly SSCCListRepository _ssccListRepository = new SSCCListRepository();
        private readonly SSCCOrderDetailsRepository _ssccOrderDetailsRepository = new SSCCOrderDetailsRepository();
        private readonly SSCCLoadCarrierRepository _ssccLoadCarrierRepository = new SSCCLoadCarrierRepository();
        private readonly SSCCPalletCountingRepository _ssccPalletCountingRepository = new SSCCPalletCountingRepository();
        private readonly SSCCImagesRepository _ssccImagesRepository = new SSCCImagesRepository();
        private readonly SSCCDeviationDetailsRepository _ssccDeviationDetailsRepository = new SSCCDeviationDetailsRepository();

        private const string YES = "YES";
        private const string VALIDATED = "Validated";

        // Parameters default values for dev purposes
        /// <summary>
        /// Get the list of SSCC's, based on the given parameters
        /// </summary>
        /// <returns></returns>
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.Customer, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        [System.Web.Http.HttpPost]
        public IList<SSCCListModel> Index(
            [FromBody] SSCCListRequest request
        )
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, "sscc\\filter"));
            if (request == null)
            {
                throw new ArgumentNullException(nameof(SSCCListRequest), "Request is not valid.");
            }

            //Block filtering SSCC list based on SSCC status and validation deadline for customer/external user
            UserRepository userRepository = new UserRepository();
            if (userRepository.IsExternalUser(RequestContext.Principal.Identity.Name))
            {
                //For customer show only validated SSCCs
                request.SsccStatusNew = false;
                request.SsccStatusProcessed = false;
                request.SsccStatusValidated = true;

                //For customer do not apply validation deadline filter
                request.ValidationOpen = true;
                request.ValidationExceeded = true;
                request.ValidationPassed = true;
            }
            else
            {
                // Filter functionality checkbox groups: Select none = See all
                if (!request.SsccStatusNew && !request.SsccStatusProcessed && !request.SsccStatusValidated)
                {
                    request.SsccStatusNew = true;
                    request.SsccStatusProcessed = true;
                    request.SsccStatusValidated = true;
                }

                if (!request.ValidationOpen && !request.ValidationExceeded && !request.ValidationPassed)
                {
                    request.ValidationOpen = true;
                    request.ValidationExceeded = true;
                    request.ValidationPassed = true;
                }
            }

            if (!request.CountingOK && !request.CountingNOK)
            {
                request.CountingOK = true;
                request.CountingNOK = true;
            }

            if (!request.SlaOK && !request.SlaNOK)
            {
                request.SlaOK = true;
                request.SlaNOK = true;
            }

            // Filter functionality Dates: If date from is not null and date to is null, get only selected date.
            if (request.SsccDateFrom != null && request.SsccDateTo == null)
            {
                // request.SsccDateFrom = new DateTime(request.SsccDateFrom.Value.Day, request.SsccDateFrom.Value.Month, request.SsccDateFrom.Value.Year);
                request.SsccDateTo = request.SsccDateFrom.Value.AddDays(1);
            }
            if (request.CiDateFrom != null && request.CiDateTo == null)
            {
                request.CiDateTo = request.CiDateFrom.Value.AddDays(1);
            }

            var response = SSCCListAdapter.ConvertSsccList(_ssccListRepository.GetSSCCList(request, RequestContext.Principal.Identity.Name));

            return response;
        }

        [HttpGet]
        [Route("FetchSSCCOrderCounts")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public CheckYourToday FetchSSCCOrderCounts()
        {
            string loggedInUser = RequestContext.Principal.Identity.Name;

            log.Info(string.Format(LogMessages.RequestMethod, loggedInUser, "sscc\\FetchSSCCOrderCounts"));

            SSCCListRequest request = new SSCCListRequest()
            {
                RetailerChainId = -1,
                SsccStatusNew = true,
                SsccStatusProcessed = true,
                SsccStatusValidated = false,
                ValidationOpen = true,
                ValidationExceeded = true,
                ValidationPassed = true,
                SlaOK = true,
                SlaNOK = true,
                CountingOK = true,
                CountingNOK = true,
                OrderNr = null
            };
            return _ssccListRepository.GetSSCCList(request, loggedInUser).ToList().GetCheckYourToday();

        }

        /// <summary>
        /// This function gets all the data needed to display it on the SSCC Detail Page
        /// The data is retrieved in 5 'blocks', and send to the adapter to put it all together
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.Customer, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public SSCCDetailsModel GetSsccDetails(string id)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, "sscc\\details"));
            if (id == null)
            {
                throw new ArgumentNullException(id, "Request is not valid.");
            }

            var orderDetails = _ssccOrderDetailsRepository.GetSSCCOrderDetails(id);
            var loadCarrierDetailsList = _ssccLoadCarrierRepository.GetSSCCLoadCarrier(id);
            var palletCountingList = _ssccPalletCountingRepository.GetSSCCPalletCounting(id);
            var imageList = _ssccImagesRepository.GetSSCCImages(id);
            var deviationDetailsList = _ssccDeviationDetailsRepository.GetSSCCDeviationDetails(id);

            return SSCCDetailAdapter.ConvertSSCCDetails(orderDetails, loadCarrierDetailsList, palletCountingList, imageList, deviationDetailsList);
        }

        [System.Web.Http.HttpGet]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.Customer, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public IList<string> GetSsccNumbers(int retailerChainId = -1)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"sscc\\Get?retailerchainId={retailerChainId}"));
            UserRepository userRepository = new UserRepository();
            var request = new SSCCListRequest
            {
                SsccStatusNew = true,
                SsccStatusProcessed = true,
                SsccStatusValidated = true,
                ValidationOpen = true,
                ValidationExceeded = true,
                ValidationPassed = true,
                CountingOK = true,
                CountingNOK = true,
                SlaOK = true,
                SlaNOK = true,
                RetailerChainId = retailerChainId,
                OrderNr = null
            };
            //For customer show only validated SSCCs
            if (userRepository.IsExternalUser(RequestContext.Principal.Identity.Name))
            {
                request.SsccStatusNew = false;
                request.SsccStatusProcessed = false;
                request.SsccStatusValidated = true;
            }
            return _ssccListRepository.GetSSCCNumberList(request, RequestContext.Principal.Identity.Name).Select(x => x.SSCC).Distinct().ToList();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetApprovedSSCCs")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public int GetApprovedSSCCsCount(int retailerChainId = -1)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, $"sscc\\GetApprovedSSCCs?retailerchainId={retailerChainId}"));
            return _ssccListRepository.GetApprovedSSCCsCount(RequestContext.Principal.Identity.Name, retailerChainId);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("SaveSSCC")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.Customer, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public string SaveSSCCDetail([FromBody] SSCCEditRequest request)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, "sscc\\SaveSSCC"));
            return SaveSSCCData(request);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("ValidateSSCC")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.Customer, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public string ValidateSSCC([FromBody] SSCCEditRequest request)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, "sscc\\ValidateSSCC"));
            return ValidateSSCCData(request);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("ValidateMultipleSSCC")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.Customer, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public List<string> ValidateMultipleSSCCs(MultipleSSCCValidateRequest request)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, "sscc\\ValidateMultipleSSCCs"));
            if (request.SSCCList.Any())
            {
                List<string> nonValidatedSSCCList = new List<string>();
                SSCCListRepository repository = new SSCCListRepository();
                nonValidatedSSCCList = repository.ValidateMultipleSSCC(request.SSCCList, RequestContext.Principal.Identity.Name);

                if (nonValidatedSSCCList.Any())
                {
                    throw HttpMessageExceptionBuilder.Build(HttpStatusCode.Accepted, HttpMessageType.Warn, JsonConvert.SerializeObject(string.Join(",", nonValidatedSSCCList)), Messages.ValidateMultipleSSCC, Messages.ValidateMultipleSSCCHeader);
                }
                return nonValidatedSSCCList;
            }
            return null;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("SaveValidateSSCC")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.Customer, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public string SaveValidateSSCC([FromBody] SSCCEditRequest request)
        {
            log.Info(string.Format(LogMessages.RequestMethod, RequestContext.Principal.Identity.Name, "sscc\\SaveValidateSSCC"));
            string response = string.Empty;
            response = SaveSSCCData(request);
            if (string.IsNullOrEmpty(response))
                response = ValidateSSCCData(request);
            return response;
        }

        [HttpGet]
        [Route("GetStatusForSSCC")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.Customer, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public SSCCStatusResponse GetSSCCStatus(string SSCCNumber)
        {
            SSCCOrderDetailsRepository repository = new SSCCOrderDetailsRepository();
            return repository.GetSSCCStatus(SSCCNumber);

        }

        [HttpGet]
        [Route("GetSSCCPendingChange")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.Customer, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public SSCCPendingChangeResponse GetSSCCPendingChanges(string SSCCNumber)
        {
            SSCCOrderDetailsRepository repository = new SSCCOrderDetailsRepository();
            return repository.GetPendingChangesForSSCC(SSCCNumber);
        }

        private string SaveSSCCData(SSCCEditRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.SSCC))
                return "No changes provided";
            else
            {
                SSCCOrderDetailsRepository repository = new SSCCOrderDetailsRepository();
                string response = string.Empty;
                request.UpdateDate = DateTime.Now;
                request.UpdateUser = string.IsNullOrEmpty(request.UpdateUser) ? RequestContext.Principal.Identity.Name : request.UpdateUser;
                request.Time = DateTime.Now.ToString("HH:mm:ss");
                request.LoadMessageStatusId = 0;
                response = repository.EditSSCC(request);
                if(!string.IsNullOrEmpty(response))
                {
                    throw HttpMessageExceptionBuilder.Build(HttpStatusCode.Accepted, HttpMessageType.Error,response, Messages.SaveSSCC, Messages.SaveSSCCHeader);
                }
                return response;
            }
        }

        private string ValidateSSCCData(SSCCEditRequest request)
        {
            int result = 0;
            if (request != null && !string.IsNullOrEmpty(request.SSCC))
            {
                SSCCEditIntermediate validateSSCC = new SSCCEditIntermediate()
                {
                    SSCC = request.SSCC,
                    UpdateDate = DateTime.Now,
                    UpdateUser = string.IsNullOrEmpty(request.UpdateUser) ? RequestContext.Principal.Identity.Name : request.UpdateUser,
                    Time = DateTime.Now.ToString("HH:mm:ss"),
                    LoadMessageStatusId = 0,
                    Validation = YES
                };
                SSCCOrderDetailsRepository repository = new SSCCOrderDetailsRepository();
                result = repository.SaveSSCC(validateSSCC);
            }
            return result == 1 ? VALIDATED : String.Format("Error occured in Validation of SSCC - {0}", request.SSCC);
        }


    }
}
