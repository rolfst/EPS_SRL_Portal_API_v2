using SRL.Data_Access.Adapter;
using SRL.Data_Access.Entity;
using SRL.Models.SSCC;
using System.Collections.Generic;
using System.Linq;

namespace SRL.Data_Access.Repository
{
    public class SSCCListRepository
    {
        //to get search result
        public IEnumerable<API_SSCC_OVERVIEW_Result> GetSSCCList(SSCCListRequest request, string userEmail)
        {
            if (string.IsNullOrEmpty(request.ActorID) && string.IsNullOrEmpty(request.ActorOriginId))
            {
                UserRepository userRepository = new UserRepository();
                //Fetch actors assigned to the user
                List<int> actorIdList = userRepository.GetActorIdList(userEmail);
                request.ActorOriginId = string.Join(",", actorIdList.Select(n => n).ToArray());
            }

            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                List<API_SSCC_OVERVIEW_Result> result = dbEntity.API_SSCC_OVERVIEW(
                    request.ActorID,
                    request.ActorOriginId,
                    request.SsccStatusNew,
                    request.SsccStatusProcessed,
                    request.SsccStatusValidated,
                    request.SsccDateFrom,
                    request.SsccDateTo,
                    request.CiDateFrom,
                    request.CiDateTo,
                    request.ValidationOpen,
                    request.ValidationExceeded,
                    request.ValidationPassed,
                    request.SsccNr,
                    request.OrderNr,
                    request.CountingOK,
                    request.CountingNOK,
                    request.SlaOK,
                    request.SlaNOK,
                    request.RetailerChainId)
                    .Take(1000)
                    .ToList<API_SSCC_OVERVIEW_Result>();

                return result;
            }
        }

        /// <summary>
        /// To fetch SSCC numbers for the SSCC number filter parameter
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IEnumerable<API_SSCC_OVERVIEW_Result> GetSSCCNumberList(SSCCListRequest request, string userEmail)
        {
            
            UserRepository userRepository = new UserRepository();
            //Fetch actors assigned to the user
            List<int> actorIdList = userRepository.GetActorIdList(userEmail);
            request.ActorOriginId = string.Join(",", actorIdList.Select(n => n).ToArray());

            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                List<API_SSCC_OVERVIEW_Result> result = dbEntity.API_SSCC_OVERVIEW(
                    request.ActorID,
                    request.ActorOriginId,
                    request.SsccStatusNew,
                    request.SsccStatusProcessed,
                    request.SsccStatusValidated,
                    request.SsccDateFrom,
                    request.SsccDateTo,
                    request.CiDateFrom,
                    request.CiDateTo,
                    request.ValidationOpen,
                    request.ValidationExceeded,
                    request.ValidationPassed,
                    request.SsccNr,
                    request.OrderNr,
                    request.CountingOK,
                    request.CountingNOK,
                    request.SlaOK,
                    request.SlaNOK,
                    request.RetailerChainId)
                    .ToList<API_SSCC_OVERVIEW_Result>();


                return result;
            }
        }

        public int GetApprovedSSCCsCount(string userEmail,int retailerChainId)
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
            //Return count of validated SSCCs
            return GetSSCCNumberList(request, userEmail).Where(s=>s.SSCC_STATUS ==3).Count();
        }

        /// <summary>
        /// Validate multiple SSCC 
        /// </summary>
        /// <param name="SSCCs">SSCC list</param>
        /// <param name="currentUserEmail">logged in user email</param>
        /// <returns>Non validated SSCC list</returns>
        public List<string> ValidateMultipleSSCC(List<string> SSCCs, string currentUserEmail)
        {

            List<string> failedSSCCs = new List<string>();
            if (SSCCs.Any())
            {
                using (var dbEntity = new BACKUP_SRL_20180613Entities())
                {
                    failedSSCCs = dbEntity.API_VALIDATE_MULTIPLE_SSCC(string.Join(",", SSCCs), currentUserEmail).ToList().ConvertNonValidatedSSCC();
                }
            }
            return failedSSCCs;
        }
    }
}
