using System.Collections.Generic;
using SRL.Data_Access.Entity;
using SRL.Models.ActorMasterData;
using SRL.Data_Access.Adapter;

namespace SRL.Data_Access.Repository
{
    public class ActorRepository
    {
        public IEnumerable<API_LIST_ACTORS_TRANSACTION_Result> GetActorList(int retailerChainId)
        {
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                IEnumerable<API_LIST_ACTORS_TRANSACTION_Result> result = dbEntity.API_LIST_ACTORS_TRANSACTION(retailerChainId);
                return result;
            }
        }

        public List<ActorMasterListResponse> GetActorMasterDataList(ActorMasterListRequest request)
        {
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                dbEntity.Configuration.ProxyCreationEnabled = false;
                IEnumerable<API_LIST_ACTOR_MASTERDATA_Result> result = dbEntity.API_LIST_ACTOR_MASTERDATA(request.ActorName, request.ActorCode, request.RetailerChainId, request.Location);
                return result.ConvertActorMasterList();
            }
        }
    }
}
