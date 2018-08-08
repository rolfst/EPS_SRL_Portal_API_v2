using SRL.Data_Access.Entity;
using SRL.Models;
using System.Collections.Generic;
using System.Linq;

namespace SRL.Data_Access.Repository
{
    class LoadCarrierRepository
    {
        public List<LoadCarrier> GetCarriersList(LoadCarrier userFilter)
        {
            List<LoadCarrier> loadcarriers = new List<LoadCarrier>();
            if (userFilter != null)
            {
                using (var ctx = new SRLManagementEntities())
                {
                    loadcarriers = (ctx.GetAllUsers(userFilter.ViewingUserEmail, 
                                                    userFilter.FirstName, 
                                                    userFilter.LastName, 
                                                    userFilter.Email, 
                                                    userFilter.IsAssigned, 
                                                    userFilter.IsActive, 
                                                    userFilter.HasTemplate, 
                                                    userFilter.IsAdmin, 
                                                    userFilter.RetailerChainCode, 
                                                    userFilter.IsInternal ).ToList<Data_Access.Entity.GetAllUsers_Result>()).ToEntityUserList();
                };
            }
            return loadcarriers;
        }
    }
}
