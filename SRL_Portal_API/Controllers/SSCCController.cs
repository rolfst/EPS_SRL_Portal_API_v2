using SRL.Data_Access.Adapter;
using SRL.Data_Access.Repository;
using SRL.Models.SSCC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace SRL_Portal_API.Controllers
{
    /// <summary>
    /// Controller for all SSCC related actions
    /// </summary>
    public class SSCCController : ApiController
    {
        private readonly SSCCListRepository _sSCCListRepository = new SSCCListRepository();
        private readonly SSCCOrderDetailsRepository _sSCCOrderDetailsRepository = new SSCCOrderDetailsRepository();
        private readonly SSCCLoadCarrierRepository _sSCCLoadCarrierRepository = new SSCCLoadCarrierRepository();
        private readonly SSCCPalletCountingRepository _sSCCPalletCountingRepository = new SSCCPalletCountingRepository();
        private readonly SSCCImagesRepository _sSCCImagesRepository = new SSCCImagesRepository();
        private readonly SSCCDeviationDetailsRepository _sSCCDeviationDetailsRepository = new SSCCDeviationDetailsRepository();

        // Parameters default values for dev purposes
        /// <summary>
        /// Get the list of SSCC's, based on the given parameters
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
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

            return SSCCListAdapter.ConvertSsccList(_sSCCListRepository.GetSSCCList(request));
        }

        /// <summary>
        /// This function gets all the data needed to display it on the SSCC Detail Page
        /// The data is retrieved in 5 'blocks', and send to the adapter to put it all together
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public SSCCDetailsModel GetSSCCDetails(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(id, "Request is not valid.");
            }

            var orderDetails = _sSCCOrderDetailsRepository.GetSSCCOrderDetails(id);
            var loadCarrierDetailsList = _sSCCLoadCarrierRepository.GetSSCCLoadCarrier(id);
            var palletCountingList = _sSCCPalletCountingRepository.GetSSCCPalletCounting(id);
            var imageList = _sSCCImagesRepository.GetSSCCImages(id);
            var deviationDetailsList = _sSCCDeviationDetailsRepository.GetSSCCDeviationDetails(id);

            return SSCCDetailAdapter.ConvertSSCCDetails(orderDetails, loadCarrierDetailsList, palletCountingList, imageList, deviationDetailsList);
        }

        [System.Web.Http.HttpGet]
        public IList<string> GetSSCCNumbers()
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
            };

            return _sSCCListRepository.GetSSCCList(request).Select(x => x.SSCC).Distinct().ToList();
        }
    }
}
