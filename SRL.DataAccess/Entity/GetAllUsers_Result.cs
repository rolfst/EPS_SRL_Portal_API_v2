//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SRL.Data_Access.Entity
{
    using System;
    
    public partial class GetAllUsers_Result
    {
        public bool Admin { get; set; }
        public int Assigned { get; set; }
        public bool IsInternal { get; set; }
        public int HasTemplate { get; set; }
        public string RetailerChainCode { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public Nullable<int> RolePriority { get; set; }
        public bool Active { get; set; }
    }
}
