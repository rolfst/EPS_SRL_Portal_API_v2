using SRL_Portal_API.Models;
using SRL_Portal_API.ViewModels;
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
    public class SSCCController : ApiController
    {
        BACKUP_SRL_20180613Entities dbEntities = new BACKUP_SRL_20180613Entities();
        DateTime now = DateTime.Now;


        // Parameters default values for dev purposes
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public IList<SSCCListViewModel> Index(
            string actorId = null,
            string actorOriginId = null,
            bool ssccStatusNew = false,
            bool ssccStatusProcessed = false,
            bool ssccStatusValidated = false,
            DateTime? ssccDateFrom = null,
            DateTime? ssccDateTo = null,
            DateTime? ciDateFrom = null,
            DateTime? ciDateTo = null,
            bool validationOpen = false,
            bool validationExceeded = false,
            bool validationPassed = false,
            string ssccNr = null,
            decimal? orderNr = 0,
            bool countingOK = false,
            bool countingNOK = false,
            bool slaOK = false,
            bool slaNOK = false,
            int? retailerChainId = -1
        )
        {
            // Filterfunctionality checkboxgroups: Select none = See all
            if (!ssccStatusNew && !ssccStatusProcessed && !ssccStatusValidated )
            {
                ssccStatusNew = true; ssccStatusProcessed = true; ssccStatusValidated = true;
            }
            if (!validationOpen && !validationExceeded && !validationPassed)
            {
                validationOpen = true; validationExceeded = true; validationPassed = true;
            }
            if (!countingOK && !countingNOK)
            {
                countingOK = true; countingNOK = true;
            }
            if (!slaOK && !slaNOK)
            {
                slaOK = true; slaNOK = true;
            }


            // call stored procedure with the given parameters to retrieve the list
            dbEntities.Configuration.ProxyCreationEnabled = false;
            var SSCCList = dbEntities.API_SSCC_OVERVIEW(actorId, actorOriginId, 
                ssccStatusNew, ssccStatusProcessed, ssccStatusValidated, ssccDateFrom, ssccDateTo,
                ciDateFrom, ciDateTo, validationOpen, validationExceeded, validationPassed, ssccNr, 
                orderNr, countingOK, countingNOK, slaOK, slaNOK, retailerChainId)
                .Take(1000) 
                .ToList<API_SSCC_OVERVIEW_Result>();

            var result = ConvertSSCCList(SSCCList);
            return result;
        }

        /// <summary>
        /// Convert the raw data from the database into the form as expected by the front-end
        /// </summary>
        /// <param name="input">The raw data as retrieved list of SSCC's</param>
        /// <returns>A list of SSCCListViewModels based on the input</returns>
        private List<SSCCListViewModel> ConvertSSCCList(List<API_SSCC_OVERVIEW_Result> input)
        {
            var VMList = new List<SSCCListViewModel>();
            foreach (var item in input)
            {
                SSCCListViewModel vm = new SSCCListViewModel();
                vm.OrderDate = item.FIRST_SSCC_USAGE;
                vm.SSCC = item.SSCC;
                vm.ActorFrom = GetActorName(item.ACTOR_ORIGIN_ID);
                vm.ActorTo = item.ACTOR_ID.HasValue ? GetActorName(item.ACTOR_ID.Value) : "";
                switch (item.SSCC_STATUS)
                {
                    case 1:
                        vm.SsccStatus = "New";
                        break;
                    case 2:
                        vm.SsccStatus = "Processed";
                        break;
                    case 3:
                        vm.SsccStatus = "Validated";
                        break;
                    default:
                        vm.SsccStatus = "New";
                        break;
                }
                if (item.VALIDATION_DEADLINE.HasValue)
                {
                    vm.ValidationDeadline = Math.Round((item.VALIDATION_DEADLINE.Value - now).TotalHours, 0);
                }
                vm.SlaOK = item.SLA_VALUE == item.SLA_MIN_VALUE;
                vm.CountingOK = item.SHOP_COUNT == item.CI_COUNT;
                vm.CIDate = item.CI_DATETIME;
                vm.IsValidated = item.VALIDATED;
                vm.ValidationStatus = SetValidationStatus(item.VALIDATED, item.VALIDATION_DEADLINE);
                VMList.Add(vm);
            }

            return VMList;
        }

        private string GetActorName(int actorId)
        {
            string actorName = (from a in dbEntities.ACTOR_REFERENCE
                                where a.ACTOR_ID == actorId
                                select a.ACTOR_LABEL).SingleOrDefault();

            return actorName;
        }

        private string SetValidationStatus(bool IsValidated, DateTime? valDeadline)
        {
            if (IsValidated)
                return "Passed";
            else if (valDeadline.HasValue && valDeadline < DateTime.Now)
                return "Exceeded";
            else
                return "Open";
        }
    }
}