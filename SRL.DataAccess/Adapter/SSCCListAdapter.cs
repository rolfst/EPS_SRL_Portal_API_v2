using SRL.Data_Access.Entity;
using SRL.Models.SSCC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRL.Data_Access.Adapter
{
    public static class SSCCListAdapter
    {
        public static List<SSCCListModel> ConvertSsccList(IEnumerable<API_SSCC_OVERVIEW_Result> input)
        {
            DateTime now = DateTime.Now;
            var slmList = new List<SSCCListModel>();

            //Fetch list of all actors in order to populate the actor names
            Dictionary<int, string> actorsList = GetAllActors();

            Parallel.ForEach(input, (item) =>
            {
                SSCCListModel slm = new SSCCListModel();
                slm.OrderDate = item.FIRST_SSCC_USAGE;
                slm.SSCC = item.SSCC;
                slm.ActorFrom = actorsList.ContainsKey(item.ACTOR_ORIGIN_ID) ? actorsList[item.ACTOR_ORIGIN_ID] : string.Empty;
                slm.ActorTo = item.ACTOR_ID.HasValue && actorsList.ContainsKey(item.ACTOR_ID.Value) ? actorsList[item.ACTOR_ID.Value] : string.Empty;

                switch (item.SSCC_STATUS)
                {
                    case 1:
                        slm.SsccStatus = "New";
                        break;
                    case 2:
                        slm.SsccStatus = "Processed";
                        break;
                    case 3:
                        slm.SsccStatus = "Validated";
                        break;
                    default:
                        slm.SsccStatus = "New";
                        break;
                }

                if (item.VALIDATION_DEADLINE.HasValue)
                {
                    slm.ValidationDeadline = Math.Round((item.VALIDATION_DEADLINE.Value - now).TotalHours, 0);
                }

                slm.SlaOK = item.SLA_VALUE == item.SLA_MIN_VALUE;
                slm.CountingOK = item.SHOP_COUNT == item.CI_COUNT;
                slm.CIDate = item.CI_DATETIME;
                slm.IsValidated = item.VALIDATED;
                slm.ValidationStatus = SetValidationStatus(item.VALIDATED, item.VALIDATION_DEADLINE);
                slmList.Add(slm);

            });

            return slmList;
        }

        private static string GetActorName(int actorId)
        {
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                string actorName = (from a in dbEntity.ACTOR_REFERENCE
                                    where a.ACTOR_ID == actorId
                                    select a.ACTOR_LABEL).SingleOrDefault();

                return actorName;
            }

        }

        private static Dictionary<int, string> GetAllActors()
        {
            Dictionary<int, string> actorsList = new Dictionary<int, string>();
            using (var dbEntity = new BACKUP_SRL_20180613Entities())
            {
                foreach (var actor in dbEntity.ACTOR_REFERENCE)
                {
                    actorsList.Add(actor.ACTOR_ID, actor.ACTOR_LABEL);
                }
            }
            return actorsList;
        }

        private static string SetValidationStatus(bool isValidated, DateTime? valDeadline)
        {
            if (isValidated)
            {
                return "Passed";
            }

            return valDeadline.HasValue && valDeadline < DateTime.Now ? "Exceeded" : "Open";
        }
    }
}
