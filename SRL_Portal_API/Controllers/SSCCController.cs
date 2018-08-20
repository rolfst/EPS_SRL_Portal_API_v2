using SRL.Data_Access.Adapter;
using SRL.Data_Access.Repository;
using SRL.Models.SSCC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SRL.Models.Constants;
using SRL_Portal_API.Common;
using SRL.Data_Access.Common;
using System.Web.Http.Cors;

namespace SRL_Portal_API.Controllers
{
    /// <summary>
    /// Controller for all SSCC related actions
    /// </summary>
    [EnableCors(origins: "http://localhost:9005", headers: "*", methods: "*")]
    public class SSCCController : ApiController
    {
        private readonly SSCCListRepository _ssccListRepository = new SSCCListRepository();
        private readonly SSCCOrderDetailsRepository _ssccOrderDetailsRepository = new SSCCOrderDetailsRepository();
        private readonly SSCCLoadCarrierRepository _ssccLoadCarrierRepository = new SSCCLoadCarrierRepository();
        private readonly SSCCPalletCountingRepository _ssccPalletCountingRepository = new SSCCPalletCountingRepository();
        private readonly SSCCImagesRepository _ssccImagesRepository = new SSCCImagesRepository();
        private readonly SSCCDeviationDetailsRepository _ssccDeviationDetailsRepository = new SSCCDeviationDetailsRepository();

        private const string YES = "YES";

        // Parameters default values for dev purposes
        /// <summary>
        /// Get the list of SSCC's, based on the given parameters
        /// </summary>
        /// <returns></returns>
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.Customer,UserRoles.SuperUser,UserRoles.UltraUser,UserRoles.WebPortalAdministrator })]
        [HttpPost]
        public IList<SSCCListModel> Index(
            [FromBody] SSCCListRequest request
        )
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(SSCCListRequest), "Request is not valid.");
            }

            // Filterfunctionality checkboxgroups: Select none = See all
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

            // Filterfunctionality Dates: If date from is not null and date to is null, get only selected date.
            if (request.SsccDateFrom != null && request.SsccDateTo == null)
            {
                // request.SsccDateFrom = new DateTime(request.SsccDateFrom.Value.Day, request.SsccDateFrom.Value.Month, request.SsccDateFrom.Value.Year);
                request.SsccDateTo = request.SsccDateFrom.Value.AddDays(1);
            }
            if (request.CiDateFrom != null && request.CiDateTo == null)
            {
                request.CiDateTo = request.CiDateFrom.Value.AddDays(1);
            }
            return SSCCListAdapter.ConvertSsccList(_ssccListRepository.GetSSCCList(request));
        }

        /// <summary>
        /// This function gets all the data needed to display it on the SSCC Detail Page
        /// The data is retrieved in 5 'blocks', and send to the adapter to put it all together
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.Customer, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public SSCCDetailsModel GetSsccDetails(string id)
        {
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

        [HttpGet]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.Customer, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public IList<string> GetSsccNumbers(int retailerChainId = -1)
        {
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
                RetailerChainId = retailerChainId
            };

            return _ssccListRepository.GetSSCCNumberList(request).Select(x => x.SSCC).Distinct().ToList();
        }

        [HttpPost]
        [Route("SaveSSCC")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.Customer, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public string SaveSSCCDetail([FromBody] SSCCEditRequest request)
        {
            return SaveSSCCData(request);
        }

        [HttpPost]
        [Route("ValidateSSCC")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.Customer, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public string ValidateSSCC([FromBody] SSCCEditRequest request)
        {
            return ValidateSSCCData(request);
        }

        [HttpPost]
        [Route("SaveValidateSSCC")]
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.Customer, UserRoles.SuperUser, UserRoles.UltraUser, UserRoles.WebPortalAdministrator })]
        public string SaveValidateSSCC([FromBody] SSCCEditRequest request)
        {
            string response = string.Empty;
            response = SaveSSCCData(request);
            if (string.IsNullOrEmpty(response))
                response = ValidateSSCCData(request);
            return response;
        }

        private string SaveSSCCData(SSCCEditRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.SSCC))
                return "No changes provided";
            else
            {
                SSCCOrderDetailsRepository repository = new SSCCOrderDetailsRepository();
                request.UpdateDate = DateTime.Now;
                request.UpdateUser = string.IsNullOrEmpty(request.UpdateUser) ? RequestContext.Principal.Identity.Name : request.UpdateUser;
                request.Time = DateTime.Now.ToString("HH:mm:ss");
                request.LoadMessageStatusId = 0;
                return repository.EditSSCC(request);
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
            return result == 1 ? "Validated" : "Error occured in Validation";
        }


    }
}
