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
    using System.Collections.Generic;
    
    public partial class ACTOR_REFERENCE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACTOR_REFERENCE()
        {
            this.ACTOR_LABEL_DETAILS = new HashSet<ACTOR_LABEL_DETAILS>();
            this.LOAD_UNIT_SLA = new HashSet<LOAD_UNIT_SLA>();
            this.SSCC_ORDER = new HashSet<SSCC_ORDER>();
            this.SSCC_ORDER1 = new HashSet<SSCC_ORDER>();
            this.TRANSACTION = new HashSet<TRANSACTION>();
        }
    
        public int ACTOR_ID { get; set; }
        public decimal ACTOR_CODE { get; set; }
        public int ACTOR_TYPE_ID { get; set; }
        public string ACT_SEARCH_NAME { get; set; }
        public string ACTOR_LABEL { get; set; }
        public Nullable<decimal> ACTOR_SORT { get; set; }
        public string ACT_OFFICIAL_NAME_LINE1 { get; set; }
        public string ACT_OFFICIAL_NAME_LINE2 { get; set; }
        public string ACT_NAME_LINE1 { get; set; }
        public string ACT_NAME_LINE2 { get; set; }
        public Nullable<int> ACTOR_STOCK_GROUP_ID { get; set; }
        public Nullable<decimal> ACTOR_OWNER_ID { get; set; }
        public string ACTOR_OWNER_CODE { get; set; }
        public Nullable<decimal> ACTOR_OWNER_SORT { get; set; }
        public Nullable<decimal> ACTOR_CONTACT_SM1_ID { get; set; }
        public Nullable<decimal> ACTOR_CONTACT_SM2_ID { get; set; }
        public string ACTOR_CONTACT_SM1 { get; set; }
        public string ACTOR_CONTACT_SM2 { get; set; }
        public string GOODS_ADDRESS_LINE1 { get; set; }
        public string GOODS_ADDRESS_LINE2 { get; set; }
        public string GOODS_HOUSE_NB { get; set; }
        public string GOODS_POSTAL_CODE { get; set; }
        public string GOODS_DOMICILE { get; set; }
        public Nullable<decimal> GOODS_COUNTRY_ID { get; set; }
        public string GOODS_COUNTRY_CODE { get; set; }
        public string GOODS_COUNTRY { get; set; }
        public Nullable<decimal> GOODS_POST_REGION_ID { get; set; }
        public Nullable<decimal> ROLE_TYPE_ID { get; set; }
        public string ROLE_TYPE { get; set; }
        public Nullable<decimal> PRODUCT_GROUP_ID { get; set; }
        public string PRODUCT_GROUP { get; set; }
        public string DEBITOR_NB { get; set; }
        public string ATRADIUS_NUMBER { get; set; }
        public Nullable<decimal> CREDIT_LIMIT { get; set; }
        public string DEPOT_TYPE { get; set; }
        public string DEPOT_SUBTYPE { get; set; }
        public Nullable<decimal> DEPOT_ACTOR_ID { get; set; }
        public string LOC_CODE { get; set; }
        public string LOC_TYPE { get; set; }
        public Nullable<decimal> LOC_COST_CENTER { get; set; }
        public Nullable<System.DateTime> UDATE_DATE { get; set; }
        public string DWH_INSERT_USER { get; set; }
        public Nullable<System.DateTime> DWH_INSERT_DATE { get; set; }
        public string DWH_UPDATE_USER { get; set; }
        public Nullable<System.DateTime> DWH_UPDATE_DATE { get; set; }
        public Nullable<decimal> LOG_PLANNING_GROUP_ID { get; set; }
        public Nullable<decimal> CCO_OWNER_ID { get; set; }
        public string CCO_CODE { get; set; }
        public string CCO_NAME { get; set; }
        public Nullable<int> RETAILER_CHAIN_ID { get; set; }
        public Nullable<decimal> RETAILER_LOCATION_ID { get; set; }
        public string RETAILER_LOCATION { get; set; }
        public Nullable<decimal> ACT_STOCK_CALCULATION { get; set; }
        public Nullable<decimal> ACTOR_ID_DEFAULT_DEPOT { get; set; }
        public string ACT_EAN_CODE { get; set; }
        public Nullable<decimal> BLACK_USE_ID { get; set; }
        public string BLACK_USE { get; set; }
        public string BLACK_USE_GREEN { get; set; }
        public Nullable<decimal> ACT_STOCK_RETAILER { get; set; }
        public int REPORTING_ACTOR_TYPE_ID { get; set; }
        public Nullable<int> DEFAULT_LANGUAGE_CODE_ID { get; set; }
        public string DEFAULT_LANGUAGE_CODE { get; set; }
        public int CUSTOMER_SPECIFIC_NR_OF_MONTHS { get; set; }
        public Nullable<decimal> ACTOR_GLN { get; set; }
        public string ACTOR_EMAIL { get; set; }
        public string ACTOR_EMAIL_TEXT { get; set; }
        public string ACTOR_CC_EMAIL { get; set; }
        public string ACTOR_BCC_EMAIL { get; set; }
        public string ACTOR_FAX { get; set; }
        public string ACTOR_IP_ADRESS { get; set; }
        public Nullable<int> DUMMY_ACTOR_REFERENCE_ID { get; set; }
        public string TRESHOLD { get; set; }
        public string LABEL_TYPE { get; set; }
        public string INSERT_USER { get; set; }
        public Nullable<System.DateTime> INSERT_DATE { get; set; }
        public string UPDATE_USER { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public Nullable<int> QTY_MISSING { get; set; }
        public Nullable<int> QTY_EMERGENCY { get; set; }
        public byte[] HASH_SHA256 { get; set; }
        public Nullable<decimal> NOVEXX_CLIENT_CODE { get; set; }
        public string EXTERNAL_ACTOR_REF { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACTOR_LABEL_DETAILS> ACTOR_LABEL_DETAILS { get; set; }
        public virtual ACTOR_TYPE ACTOR_TYPE { get; set; }
        public virtual REPORTING_ACTOR_TYPE REPORTING_ACTOR_TYPE { get; set; }
        public virtual RETAILER_CHAIN RETAILER_CHAIN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOAD_UNIT_SLA> LOAD_UNIT_SLA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SSCC_ORDER> SSCC_ORDER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SSCC_ORDER> SSCC_ORDER1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRANSACTION> TRANSACTION { get; set; }
    }
}
