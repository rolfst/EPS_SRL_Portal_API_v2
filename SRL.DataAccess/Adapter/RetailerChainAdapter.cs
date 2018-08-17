using SRL.Data_Access.Entity;
using SRL.Models.RetailerChain;
using System.Collections.Generic;

namespace SRL.Data_Access.Adapter
{
    /// <summary>
    /// Adapter class to convert Retailer chain model object
    /// </summary>
    public static class RetailerChainAdapter
    {
        internal static RetailerChain ConvertRetailerChainResult(this API_LIST_RETAILERS_Result result)
        {
            if (result is null)
                return new RetailerChain();
            else
                return new RetailerChain()
                {
                    RetailerChainId = result.RETAILER_CHAIN_ID,
                    RetailerChainName = result.RETAILER_CHAIN
                };
        }

        internal static List<RetailerChain> ToEntityRetailerChainList(this List<API_LIST_RETAILERS_Result> retailerChainList)
        {
            List<RetailerChain> retailerChains = new List<RetailerChain>();
            if (retailerChainList != null)
            {
                retailerChainList.ForEach(r => retailerChains.Add(r.ConvertRetailerChainResult()));
            }
            return retailerChains;

        }

    }
}
