using SRL.Data_Access.Adapter;
using SRL.Data_Access.Repository;
using SRL.Models.SSCC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SRL.Models.Constants;
using SRL_Portal_API.Common;

namespace SRL_Portal_API.Controllers
{
    /// <summary>
    /// Controller for all SSCC related actions
    /// </summary>
    public class SSCCController : ApiController
    {
        private readonly SSCCListRepository _ssccListRepository = new SSCCListRepository();
        private readonly SSCCOrderDetailsRepository _ssccOrderDetailsRepository = new SSCCOrderDetailsRepository();
        private readonly SSCCLoadCarrierRepository _ssccLoadCarrierRepository = new SSCCLoadCarrierRepository();
        private readonly SSCCPalletCountingRepository _ssccPalletCountingRepository = new SSCCPalletCountingRepository();
        private readonly SSCCImagesRepository _ssccImagesRepository = new SSCCImagesRepository();
        private readonly SSCCDeviationDetailsRepository _ssccDeviationDetailsRepository = new SSCCDeviationDetailsRepository();

        // Parameters default values for dev purposes
        /// <summary>
        /// Get the list of SSCC's, based on the given parameters
        /// </summary>
        /// <returns></returns>
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.Customer })]
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
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.Customer })]
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
        [CustomAuthorizationFilter(new string[] { UserRoles.CustomerServiceAgent, UserRoles.Customer })]
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

            return _ssccListRepository.GetSSCCList(request).Select(x => x.SSCC).Distinct().ToList();
        }
    }
}
