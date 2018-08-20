using SRL.Data_Access.Entity;
using SRL.Models.SSCC;
using System.Collections.Generic;
using System.Linq;

namespace SRL.Data_Access.Repository
{
    public class SSCCListRepository
    {
        //to get search result
        public IEnumerable<API_SSCC_OVERVIEW_Result> GetSSCCList(SSCCListRequest request)
        {
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
            //Check if logged in user is external
            UserRespository userRespository = new UserRespository();
            if (userRespository.IsExternalUser(userEmail))
            {
                //Fetch actors assigned to the user
                List<int?> actorIdList = userRespository.GetActorIdList(userEmail);
                request.ActorOriginId = string.Join(",", actorIdList.Select(n => n.Value).ToArray());
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
                        .ToList<API_SSCC_OVERVIEW_Result>();
               

                    return result;
                }
            }
    }
}
