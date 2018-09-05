﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BACKUP_SRL_20180613Entities : DbContext
    {
        public BACKUP_SRL_20180613Entities()
            : base("name=BACKUP_SRL_20180613Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ACTION> ACTION { get; set; }
        public virtual DbSet<ACTOR_LABEL_DETAILS> ACTOR_LABEL_DETAILS { get; set; }
        public virtual DbSet<ACTOR_REFERENCE> ACTOR_REFERENCE { get; set; }
        public virtual DbSet<ACTOR_TYPE> ACTOR_TYPE { get; set; }
        public virtual DbSet<AUDIT> AUDIT { get; set; }
        public virtual DbSet<CONTENT> CONTENT { get; set; }
        public virtual DbSet<CPF_SOURCE_REFERENCE_SLRS> CPF_SOURCE_REFERENCE_SLRS { get; set; }
        public virtual DbSet<DEPOT_LABEL> DEPOT_LABEL { get; set; }
        public virtual DbSet<DEVIATION_BY_RETAILER> DEVIATION_BY_RETAILER { get; set; }
        public virtual DbSet<ERROR> ERROR { get; set; }
        public virtual DbSet<ERROR_HANDLING> ERROR_HANDLING { get; set; }
        public virtual DbSet<ERROR_HANDLING_ARCHIVE> ERROR_HANDLING_ARCHIVE { get; set; }
        public virtual DbSet<ERROR_TRANSLATION> ERROR_TRANSLATION { get; set; }
        public virtual DbSet<ESOFT_API_RCM500> ESOFT_API_RCM500 { get; set; }
        public virtual DbSet<INPUT_SSCC_MANAGEMENT> INPUT_SSCC_MANAGEMENT { get; set; }
        public virtual DbSet<INTERFACING> INTERFACING { get; set; }
        public virtual DbSet<LATE_TRANSACTIONS> LATE_TRANSACTIONS { get; set; }
        public virtual DbSet<LINK_TRANSACTION_LOAD_UNIT_CONDITION> LINK_TRANSACTION_LOAD_UNIT_CONDITION { get; set; }
        public virtual DbSet<LOAD_CARRIER> LOAD_CARRIER { get; set; }
        public virtual DbSet<LOAD_CARRIER_TRANSLATION> LOAD_CARRIER_TRANSLATION { get; set; }
        public virtual DbSet<LOAD_UNIT> LOAD_UNIT { get; set; }
        public virtual DbSet<LOAD_UNIT_CONDITION> LOAD_UNIT_CONDITION { get; set; }
        public virtual DbSet<LOAD_UNIT_CONDITION_TRANSLATION> LOAD_UNIT_CONDITION_TRANSLATION { get; set; }
        public virtual DbSet<LOAD_UNIT_SLA> LOAD_UNIT_SLA { get; set; }
        public virtual DbSet<LOAD_UNIT_SUB_CONDITION> LOAD_UNIT_SUB_CONDITION { get; set; }
        public virtual DbSet<LOAD_UNIT_TRANSLATION> LOAD_UNIT_TRANSLATION { get; set; }
        public virtual DbSet<PICTURE_EVIDENCE> PICTURE_EVIDENCE { get; set; }
        public virtual DbSet<REF_ORDER> REF_ORDER { get; set; }
        public virtual DbSet<REF_TRANSACTION_TEMP_RECEIPTS> REF_TRANSACTION_TEMP_RECEIPTS { get; set; }
        public virtual DbSet<REPORTING_ACTOR_TYPE> REPORTING_ACTOR_TYPE { get; set; }
        public virtual DbSet<RETAILER_CHAIN> RETAILER_CHAIN { get; set; }
        public virtual DbSet<RT_TYPE> RT_TYPE { get; set; }
        public virtual DbSet<RTI> RTI { get; set; }
        public virtual DbSet<RTI_ACCEPTANCE> RTI_ACCEPTANCE { get; set; }
        public virtual DbSet<RTI_TRANSLATION> RTI_TRANSLATION { get; set; }
        public virtual DbSet<SHIPMENT> SHIPMENT { get; set; }
        public virtual DbSet<SORTING_STATUS> SORTING_STATUS { get; set; }
        public virtual DbSet<SORTING_STATUS_TRANSLATION> SORTING_STATUS_TRANSLATION { get; set; }
        public virtual DbSet<SSCC> SSCC { get; set; }
        public virtual DbSet<SSCC_DEL> SSCC_DEL { get; set; }
        public virtual DbSet<SSCC_MANAGEMENT> SSCC_MANAGEMENT { get; set; }
        public virtual DbSet<SSCC_ORDER> SSCC_ORDER { get; set; }
        public virtual DbSet<SSCC_RTI_DETAILS> SSCC_RTI_DETAILS { get; set; }
        public virtual DbSet<SSCC_RTI_GRAI> SSCC_RTI_GRAI { get; set; }
        public virtual DbSet<STANDARD_DISTRIBUTION> STANDARD_DISTRIBUTION { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TIMEONSITE> TIMEONSITE { get; set; }
        public virtual DbSet<TRANSACTION> TRANSACTION { get; set; }
        public virtual DbSet<TRANSACTION_DEL> TRANSACTION_DEL { get; set; }
        public virtual DbSet<TRANSACTION_SSCC_RTI_DETAILS> TRANSACTION_SSCC_RTI_DETAILS { get; set; }
        public virtual DbSet<TRANSACTION_SSCC_RTI_DETAILS_DEL> TRANSACTION_SSCC_RTI_DETAILS_DEL { get; set; }
        public virtual DbSet<TRANSACTION_SSCC_RTI_DETAILS_QTY_DIF> TRANSACTION_SSCC_RTI_DETAILS_QTY_DIF { get; set; }
        public virtual DbSet<TRANSACTION_SSCC_RTI_GRAI> TRANSACTION_SSCC_RTI_GRAI { get; set; }
        public virtual DbSet<TRANSACTION_SUBTYPES> TRANSACTION_SUBTYPES { get; set; }
        public virtual DbSet<TRANSLATION_DETAILS> TRANSLATION_DETAILS { get; set; }
        public virtual DbSet<XML_EXPORT_MESSAGES> XML_EXPORT_MESSAGES { get; set; }
        public virtual DbSet<Z_CHANGES_TO_DATABASE> Z_CHANGES_TO_DATABASE { get; set; }
        public virtual DbSet<Z_LOAD_MESSAGE_STATUS> Z_LOAD_MESSAGE_STATUS { get; set; }
        public virtual DbSet<Z_SSCC_NUMBERS> Z_SSCC_NUMBERS { get; set; }
        public virtual DbSet<Z_SSCC_ORDER_NUMBER> Z_SSCC_ORDER_NUMBER { get; set; }
        public virtual DbSet<Z_SSCC_ORDER_RETAILER_DETAILS> Z_SSCC_ORDER_RETAILER_DETAILS { get; set; }
        public virtual DbSet<Z_STG_XML_ANOMALIES> Z_STG_XML_ANOMALIES { get; set; }
        public virtual DbSet<Z_STG_XML_CONTENT> Z_STG_XML_CONTENT { get; set; }
        public virtual DbSet<Z_STG_XML_COUNTING> Z_STG_XML_COUNTING { get; set; }
        public virtual DbSet<Z_STG_XML_DATA> Z_STG_XML_DATA { get; set; }
        public virtual DbSet<Z_STG_XML_LOAD> Z_STG_XML_LOAD { get; set; }
        public virtual DbSet<Z_STG_XML_LOAD_CARRIER> Z_STG_XML_LOAD_CARRIER { get; set; }
        public virtual DbSet<Z_STG_XML_ORDER> Z_STG_XML_ORDER { get; set; }
        public virtual DbSet<Z_STG_XML_PICTURES> Z_STG_XML_PICTURES { get; set; }
        public virtual DbSet<Z_STG_XML_SHIPMENT> Z_STG_XML_SHIPMENT { get; set; }
        public virtual DbSet<Z_STG_XML_TIMEONSITE> Z_STG_XML_TIMEONSITE { get; set; }
        public virtual DbSet<Z_STG_XML_TRANSACTION> Z_STG_XML_TRANSACTION { get; set; }
        public virtual DbSet<Z_VALIDATION> Z_VALIDATION { get; set; }
        public virtual DbSet<CPF_410_AGGREGATED_ACTOR_CODE> CPF_410_AGGREGATED_ACTOR_CODE { get; set; }
        public virtual DbSet<CPF_SOURCE_REFERENCE_SLRS_NEW> CPF_SOURCE_REFERENCE_SLRS_NEW { get; set; }
        public virtual DbSet<CPF_SOURCE_REFERENCE_SLRS_RCM410> CPF_SOURCE_REFERENCE_SLRS_RCM410 { get; set; }
        public virtual DbSet<CPF_SOURCE_REFERENCE_SLRS_RCM415> CPF_SOURCE_REFERENCE_SLRS_RCM415 { get; set; }
        public virtual DbSet<PARAMETER_SRLS> PARAMETER_SRLS { get; set; }
        public virtual DbSet<PARAMETER_SRLS_NEW> PARAMETER_SRLS_NEW { get; set; }
        public virtual DbSet<REF_ORDER_UPSERT> REF_ORDER_UPSERT { get; set; }
        public virtual DbSet<RTI_DATASET> RTI_DATASET { get; set; }
        public virtual DbSet<RUNNING_JOB_CHECK> RUNNING_JOB_CHECK { get; set; }
        public virtual DbSet<CPF_SLRS_RCM410_SSCC> CPF_SLRS_RCM410_SSCC { get; set; }
        public virtual DbSet<CPF_SLRS_RCM410_SSCC_OUD> CPF_SLRS_RCM410_SSCC_OUD { get; set; }
        public virtual DbSet<CPF_SLRS_RCM415_SSCC> CPF_SLRS_RCM415_SSCC { get; set; }
        public virtual DbSet<CPF_SLRS_RCM419_SSCC> CPF_SLRS_RCM419_SSCC { get; set; }
        public virtual DbSet<CPF_SLRS_RCM419_SSCC_NEW> CPF_SLRS_RCM419_SSCC_NEW { get; set; }
        public virtual DbSet<EXPORT_MESSAGE_UPDATE_STATUS_2> EXPORT_MESSAGE_UPDATE_STATUS_2 { get; set; }
        public virtual DbSet<EXPORT_MESSAGE_UPDATE_STATUS_2_SUM> EXPORT_MESSAGE_UPDATE_STATUS_2_SUM { get; set; }
        public virtual DbSet<LOAD_UNIT_CONDITION_TRANSLATED> LOAD_UNIT_CONDITION_TRANSLATED { get; set; }
        public virtual DbSet<NOVEXX> NOVEXX { get; set; }
        public virtual DbSet<RCM410_SSCC_VW> RCM410_SSCC_VW { get; set; }
        public virtual DbSet<REF_ARTICLE_PACKING> REF_ARTICLE_PACKING { get; set; }
        public virtual DbSet<REF_CALENDAR_DAY> REF_CALENDAR_DAY { get; set; }
        public virtual DbSet<REF_CALENDAR_MONTH> REF_CALENDAR_MONTH { get; set; }
        public virtual DbSet<REF_CALENDAR_WEEK> REF_CALENDAR_WEEK { get; set; }
        public virtual DbSet<REF_PARAMETER_OUD> REF_PARAMETER_OUD { get; set; }
        public virtual DbSet<RTI_TRANSLATED> RTI_TRANSLATED { get; set; }
        public virtual DbSet<SLA_UNIT_INFO_DETAILS> SLA_UNIT_INFO_DETAILS { get; set; }
        public virtual DbSet<SSCC_ORDER_OVERVIEW> SSCC_ORDER_OVERVIEW { get; set; }
        public virtual DbSet<VW_AUTOMATIC_SLA_MATCH> VW_AUTOMATIC_SLA_MATCH { get; set; }
        public virtual DbSet<VW_CI_WITHOUT_INBOUND> VW_CI_WITHOUT_INBOUND { get; set; }
        public virtual DbSet<vw_DEPOT_LABEL> vw_DEPOT_LABEL { get; set; }
        public virtual DbSet<VW_ERROR_DOUBLE_COUNTING> VW_ERROR_DOUBLE_COUNTING { get; set; }
        public virtual DbSet<VW_INBOUND_WITHOUT_CI> VW_INBOUND_WITHOUT_CI { get; set; }
        public virtual DbSet<VW_MONO_SSCC> VW_MONO_SSCC { get; set; }
        public virtual DbSet<vw_RTG_DATASET> vw_RTG_DATASET { get; set; }
        public virtual DbSet<vw_RTG_DATASET_MT> vw_RTG_DATASET_MT { get; set; }
        public virtual DbSet<vw_RTI_DATASET> vw_RTI_DATASET { get; set; }
        public virtual DbSet<vw_RTI_DATASET_MT> vw_RTI_DATASET_MT { get; set; }
        public virtual DbSet<vw_RTI_DATASET_X> vw_RTI_DATASET_X { get; set; }
        public virtual DbSet<VW_SSCC_CI> VW_SSCC_CI { get; set; }
        public virtual DbSet<VW_SSCC_MULTI_LOAD_CARRIER> VW_SSCC_MULTI_LOAD_CARRIER { get; set; }
        public virtual DbSet<VW_SSCC_VALIDATED> VW_SSCC_VALIDATED { get; set; }
        public virtual DbSet<VW_SSCC_VALIDATED_MT> VW_SSCC_VALIDATED_MT { get; set; }
        public virtual DbSet<Z_RPT_PROCESS_QTY> Z_RPT_PROCESS_QTY { get; set; }
        public virtual DbSet<Z_STG_XML_DV_ANOMALIES> Z_STG_XML_DV_ANOMALIES { get; set; }
        public virtual DbSet<Z_STG_XML_DV_CONTENT> Z_STG_XML_DV_CONTENT { get; set; }
        public virtual DbSet<Z_STG_XML_DV_COUNTING> Z_STG_XML_DV_COUNTING { get; set; }
        public virtual DbSet<Z_STG_XML_DV_LOAD> Z_STG_XML_DV_LOAD { get; set; }
        public virtual DbSet<Z_STG_XML_DV_LOAD_CARRIER> Z_STG_XML_DV_LOAD_CARRIER { get; set; }
        public virtual DbSet<Z_STG_XML_DV_ORDER> Z_STG_XML_DV_ORDER { get; set; }
        public virtual DbSet<Z_STG_XML_DV_PICTURES> Z_STG_XML_DV_PICTURES { get; set; }
        public virtual DbSet<Z_STG_XML_DV_SHIPMENT> Z_STG_XML_DV_SHIPMENT { get; set; }
        public virtual DbSet<Z_STG_XML_DV_TIMEONSITE> Z_STG_XML_DV_TIMEONSITE { get; set; }
        public virtual DbSet<Z_STG_XML_DV_TRANSACTION> Z_STG_XML_DV_TRANSACTION { get; set; }
        public virtual DbSet<temp_TRANSACTION_2018> temp_TRANSACTION_2018 { get; set; }
        public virtual DbSet<temp_TRANSACTION_SSCC_RTI_DETAILS_2018> temp_TRANSACTION_SSCC_RTI_DETAILS_2018 { get; set; }
        public virtual DbSet<temp_Z_STG_XML_DATA_2018> temp_Z_STG_XML_DATA_2018 { get; set; }
    
        [DbFunction("BACKUP_SRL_20180613Entities", "API_FN_SPLIT")]
        public virtual IQueryable<API_FN_SPLIT_Result> API_FN_SPLIT(string tEXT, string dELIMITER)
        {
            var tEXTParameter = tEXT != null ?
                new ObjectParameter("TEXT", tEXT) :
                new ObjectParameter("TEXT", typeof(string));
    
            var dELIMITERParameter = dELIMITER != null ?
                new ObjectParameter("DELIMITER", dELIMITER) :
                new ObjectParameter("DELIMITER", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<API_FN_SPLIT_Result>("[BACKUP_SRL_20180613Entities].[API_FN_SPLIT](@TEXT, @DELIMITER)", tEXTParameter, dELIMITERParameter);
        }
    
        public virtual ObjectResult<API_LIST_ACTORS_TRANSACTION_Result> API_LIST_ACTORS_TRANSACTION(Nullable<int> rETAILER_CHAIN_ID)
        {
            var rETAILER_CHAIN_IDParameter = rETAILER_CHAIN_ID.HasValue ?
                new ObjectParameter("RETAILER_CHAIN_ID", rETAILER_CHAIN_ID) :
                new ObjectParameter("RETAILER_CHAIN_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<API_LIST_ACTORS_TRANSACTION_Result>("API_LIST_ACTORS_TRANSACTION", rETAILER_CHAIN_IDParameter);
        }
    
        public virtual ObjectResult<API_SSCC_OVERVIEW_Result> API_SSCC_OVERVIEW(string aCTOR_ID, string aCTOR_ORIGIN_ID, Nullable<bool> sSCC_STATUS_NEW, Nullable<bool> sSCC_STATUS_PROCESSED, Nullable<bool> sSCC_STATUS_VALIDATED, Nullable<System.DateTime> fIRST_SSCC_USAGE_FROM, Nullable<System.DateTime> fIRST_SSCC_USAGE_TO, Nullable<System.DateTime> cI_DATETIME_FROM, Nullable<System.DateTime> cI_DATETIME_TO, Nullable<bool> vALIDATION_DEADLINE_OPEN, Nullable<bool> vALIDATION_DEADLINE_EXCEEDED, Nullable<bool> vALIDATION_DEADLINE_PASSED, string sSCC, Nullable<decimal> oRDER_NUMBER, Nullable<bool> cOUNTING_OK, Nullable<bool> cOUNTING_NOK, Nullable<bool> sLA_OK, Nullable<bool> sLA_NOK, Nullable<int> rETAILER_CHAIN_ID)
        {
            var aCTOR_IDParameter = aCTOR_ID != null ?
                new ObjectParameter("ACTOR_ID", aCTOR_ID) :
                new ObjectParameter("ACTOR_ID", typeof(string));
    
            var aCTOR_ORIGIN_IDParameter = aCTOR_ORIGIN_ID != null ?
                new ObjectParameter("ACTOR_ORIGIN_ID", aCTOR_ORIGIN_ID) :
                new ObjectParameter("ACTOR_ORIGIN_ID", typeof(string));
    
            var sSCC_STATUS_NEWParameter = sSCC_STATUS_NEW.HasValue ?
                new ObjectParameter("SSCC_STATUS_NEW", sSCC_STATUS_NEW) :
                new ObjectParameter("SSCC_STATUS_NEW", typeof(bool));
    
            var sSCC_STATUS_PROCESSEDParameter = sSCC_STATUS_PROCESSED.HasValue ?
                new ObjectParameter("SSCC_STATUS_PROCESSED", sSCC_STATUS_PROCESSED) :
                new ObjectParameter("SSCC_STATUS_PROCESSED", typeof(bool));
    
            var sSCC_STATUS_VALIDATEDParameter = sSCC_STATUS_VALIDATED.HasValue ?
                new ObjectParameter("SSCC_STATUS_VALIDATED", sSCC_STATUS_VALIDATED) :
                new ObjectParameter("SSCC_STATUS_VALIDATED", typeof(bool));
    
            var fIRST_SSCC_USAGE_FROMParameter = fIRST_SSCC_USAGE_FROM.HasValue ?
                new ObjectParameter("FIRST_SSCC_USAGE_FROM", fIRST_SSCC_USAGE_FROM) :
                new ObjectParameter("FIRST_SSCC_USAGE_FROM", typeof(System.DateTime));
    
            var fIRST_SSCC_USAGE_TOParameter = fIRST_SSCC_USAGE_TO.HasValue ?
                new ObjectParameter("FIRST_SSCC_USAGE_TO", fIRST_SSCC_USAGE_TO) :
                new ObjectParameter("FIRST_SSCC_USAGE_TO", typeof(System.DateTime));
    
            var cI_DATETIME_FROMParameter = cI_DATETIME_FROM.HasValue ?
                new ObjectParameter("CI_DATETIME_FROM", cI_DATETIME_FROM) :
                new ObjectParameter("CI_DATETIME_FROM", typeof(System.DateTime));
    
            var cI_DATETIME_TOParameter = cI_DATETIME_TO.HasValue ?
                new ObjectParameter("CI_DATETIME_TO", cI_DATETIME_TO) :
                new ObjectParameter("CI_DATETIME_TO", typeof(System.DateTime));
    
            var vALIDATION_DEADLINE_OPENParameter = vALIDATION_DEADLINE_OPEN.HasValue ?
                new ObjectParameter("VALIDATION_DEADLINE_OPEN", vALIDATION_DEADLINE_OPEN) :
                new ObjectParameter("VALIDATION_DEADLINE_OPEN", typeof(bool));
    
            var vALIDATION_DEADLINE_EXCEEDEDParameter = vALIDATION_DEADLINE_EXCEEDED.HasValue ?
                new ObjectParameter("VALIDATION_DEADLINE_EXCEEDED", vALIDATION_DEADLINE_EXCEEDED) :
                new ObjectParameter("VALIDATION_DEADLINE_EXCEEDED", typeof(bool));
    
            var vALIDATION_DEADLINE_PASSEDParameter = vALIDATION_DEADLINE_PASSED.HasValue ?
                new ObjectParameter("VALIDATION_DEADLINE_PASSED", vALIDATION_DEADLINE_PASSED) :
                new ObjectParameter("VALIDATION_DEADLINE_PASSED", typeof(bool));
    
            var sSCCParameter = sSCC != null ?
                new ObjectParameter("SSCC", sSCC) :
                new ObjectParameter("SSCC", typeof(string));
    
            var oRDER_NUMBERParameter = oRDER_NUMBER.HasValue ?
                new ObjectParameter("ORDER_NUMBER", oRDER_NUMBER) :
                new ObjectParameter("ORDER_NUMBER", typeof(decimal));
    
            var cOUNTING_OKParameter = cOUNTING_OK.HasValue ?
                new ObjectParameter("COUNTING_OK", cOUNTING_OK) :
                new ObjectParameter("COUNTING_OK", typeof(bool));
    
            var cOUNTING_NOKParameter = cOUNTING_NOK.HasValue ?
                new ObjectParameter("COUNTING_NOK", cOUNTING_NOK) :
                new ObjectParameter("COUNTING_NOK", typeof(bool));
    
            var sLA_OKParameter = sLA_OK.HasValue ?
                new ObjectParameter("SLA_OK", sLA_OK) :
                new ObjectParameter("SLA_OK", typeof(bool));
    
            var sLA_NOKParameter = sLA_NOK.HasValue ?
                new ObjectParameter("SLA_NOK", sLA_NOK) :
                new ObjectParameter("SLA_NOK", typeof(bool));
    
            var rETAILER_CHAIN_IDParameter = rETAILER_CHAIN_ID.HasValue ?
                new ObjectParameter("RETAILER_CHAIN_ID", rETAILER_CHAIN_ID) :
                new ObjectParameter("RETAILER_CHAIN_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<API_SSCC_OVERVIEW_Result>("API_SSCC_OVERVIEW", aCTOR_IDParameter, aCTOR_ORIGIN_IDParameter, sSCC_STATUS_NEWParameter, sSCC_STATUS_PROCESSEDParameter, sSCC_STATUS_VALIDATEDParameter, fIRST_SSCC_USAGE_FROMParameter, fIRST_SSCC_USAGE_TOParameter, cI_DATETIME_FROMParameter, cI_DATETIME_TOParameter, vALIDATION_DEADLINE_OPENParameter, vALIDATION_DEADLINE_EXCEEDEDParameter, vALIDATION_DEADLINE_PASSEDParameter, sSCCParameter, oRDER_NUMBERParameter, cOUNTING_OKParameter, cOUNTING_NOKParameter, sLA_OKParameter, sLA_NOKParameter, rETAILER_CHAIN_IDParameter);
        }
    
        public virtual ObjectResult<ORDER_LIST_Result> API_ORDER_LIST(string oRD_ORDER_NUMBER, Nullable<int> rETAILER_CHAIN_ID, Nullable<System.DateTime> oRDER_DATE_FROM, Nullable<System.DateTime> oRDER_DATE_TO, Nullable<bool> oRDER_NEW, Nullable<bool> oRDER_OPEN, Nullable<bool> oRDER_VALIDATED, string oRDER_ID, Nullable<System.DateTime> cI_DATE_FROM, Nullable<System.DateTime> cI_DATE_TO, Nullable<System.DateTime> vALIDATION_DEADLINE, string uSER, string aCTOR_ID_FROM, string aCTOR_ID_TO, string oRDER_NUMBER, Nullable<bool> sHOP_COUNT_OK, Nullable<bool> sHOP_COUNT_NOK, Nullable<bool> vALIDATION_DEADLINE_OPEN, Nullable<bool> vALIDATION_DEADLINE_EXCEEDED, Nullable<bool> vALIDATION_DEADLINE_PASSED, string aCTOR_ID)
        {
            var oRD_ORDER_NUMBERParameter = oRD_ORDER_NUMBER != null ?
                new ObjectParameter("ORD_ORDER_NUMBER", oRD_ORDER_NUMBER) :
                new ObjectParameter("ORD_ORDER_NUMBER", typeof(string));
    
            var rETAILER_CHAIN_IDParameter = rETAILER_CHAIN_ID.HasValue ?
                new ObjectParameter("RETAILER_CHAIN_ID", rETAILER_CHAIN_ID) :
                new ObjectParameter("RETAILER_CHAIN_ID", typeof(int));
    
            var oRDER_DATE_FROMParameter = oRDER_DATE_FROM.HasValue ?
                new ObjectParameter("ORDER_DATE_FROM", oRDER_DATE_FROM) :
                new ObjectParameter("ORDER_DATE_FROM", typeof(System.DateTime));
    
            var oRDER_DATE_TOParameter = oRDER_DATE_TO.HasValue ?
                new ObjectParameter("ORDER_DATE_TO", oRDER_DATE_TO) :
                new ObjectParameter("ORDER_DATE_TO", typeof(System.DateTime));
    
            var oRDER_NEWParameter = oRDER_NEW.HasValue ?
                new ObjectParameter("ORDER_NEW", oRDER_NEW) :
                new ObjectParameter("ORDER_NEW", typeof(bool));
    
            var oRDER_OPENParameter = oRDER_OPEN.HasValue ?
                new ObjectParameter("ORDER_OPEN", oRDER_OPEN) :
                new ObjectParameter("ORDER_OPEN", typeof(bool));
    
            var oRDER_VALIDATEDParameter = oRDER_VALIDATED.HasValue ?
                new ObjectParameter("ORDER_VALIDATED", oRDER_VALIDATED) :
                new ObjectParameter("ORDER_VALIDATED", typeof(bool));
    
            var oRDER_IDParameter = oRDER_ID != null ?
                new ObjectParameter("ORDER_ID", oRDER_ID) :
                new ObjectParameter("ORDER_ID", typeof(string));
    
            var cI_DATE_FROMParameter = cI_DATE_FROM.HasValue ?
                new ObjectParameter("CI_DATE_FROM", cI_DATE_FROM) :
                new ObjectParameter("CI_DATE_FROM", typeof(System.DateTime));
    
            var cI_DATE_TOParameter = cI_DATE_TO.HasValue ?
                new ObjectParameter("CI_DATE_TO", cI_DATE_TO) :
                new ObjectParameter("CI_DATE_TO", typeof(System.DateTime));
    
            var vALIDATION_DEADLINEParameter = vALIDATION_DEADLINE.HasValue ?
                new ObjectParameter("VALIDATION_DEADLINE", vALIDATION_DEADLINE) :
                new ObjectParameter("VALIDATION_DEADLINE", typeof(System.DateTime));
    
            var uSERParameter = uSER != null ?
                new ObjectParameter("USER", uSER) :
                new ObjectParameter("USER", typeof(string));
    
            var aCTOR_ID_FROMParameter = aCTOR_ID_FROM != null ?
                new ObjectParameter("ACTOR_ID_FROM", aCTOR_ID_FROM) :
                new ObjectParameter("ACTOR_ID_FROM", typeof(string));
    
            var aCTOR_ID_TOParameter = aCTOR_ID_TO != null ?
                new ObjectParameter("ACTOR_ID_TO", aCTOR_ID_TO) :
                new ObjectParameter("ACTOR_ID_TO", typeof(string));
    
            var oRDER_NUMBERParameter = oRDER_NUMBER != null ?
                new ObjectParameter("ORDER_NUMBER", oRDER_NUMBER) :
                new ObjectParameter("ORDER_NUMBER", typeof(string));
    
            var sHOP_COUNT_OKParameter = sHOP_COUNT_OK.HasValue ?
                new ObjectParameter("SHOP_COUNT_OK", sHOP_COUNT_OK) :
                new ObjectParameter("SHOP_COUNT_OK", typeof(bool));
    
            var sHOP_COUNT_NOKParameter = sHOP_COUNT_NOK.HasValue ?
                new ObjectParameter("SHOP_COUNT_NOK", sHOP_COUNT_NOK) :
                new ObjectParameter("SHOP_COUNT_NOK", typeof(bool));
    
            var vALIDATION_DEADLINE_OPENParameter = vALIDATION_DEADLINE_OPEN.HasValue ?
                new ObjectParameter("VALIDATION_DEADLINE_OPEN", vALIDATION_DEADLINE_OPEN) :
                new ObjectParameter("VALIDATION_DEADLINE_OPEN", typeof(bool));
    
            var vALIDATION_DEADLINE_EXCEEDEDParameter = vALIDATION_DEADLINE_EXCEEDED.HasValue ?
                new ObjectParameter("VALIDATION_DEADLINE_EXCEEDED", vALIDATION_DEADLINE_EXCEEDED) :
                new ObjectParameter("VALIDATION_DEADLINE_EXCEEDED", typeof(bool));
    
            var vALIDATION_DEADLINE_PASSEDParameter = vALIDATION_DEADLINE_PASSED.HasValue ?
                new ObjectParameter("VALIDATION_DEADLINE_PASSED", vALIDATION_DEADLINE_PASSED) :
                new ObjectParameter("VALIDATION_DEADLINE_PASSED", typeof(bool));
    
            var aCTOR_IDParameter = aCTOR_ID != null ?
                new ObjectParameter("ACTOR_ID", aCTOR_ID) :
                new ObjectParameter("ACTOR_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ORDER_LIST_Result>("API_ORDER_LIST", oRD_ORDER_NUMBERParameter, rETAILER_CHAIN_IDParameter, oRDER_DATE_FROMParameter, oRDER_DATE_TOParameter, oRDER_NEWParameter, oRDER_OPENParameter, oRDER_VALIDATEDParameter, oRDER_IDParameter, cI_DATE_FROMParameter, cI_DATE_TOParameter, vALIDATION_DEADLINEParameter, uSERParameter, aCTOR_ID_FROMParameter, aCTOR_ID_TOParameter, oRDER_NUMBERParameter, sHOP_COUNT_OKParameter, sHOP_COUNT_NOKParameter, vALIDATION_DEADLINE_OPENParameter, vALIDATION_DEADLINE_EXCEEDEDParameter, vALIDATION_DEADLINE_PASSEDParameter, aCTOR_IDParameter);
        }
    
        public virtual ObjectResult<GetOrderDetail_Result> GetOrderDetail(Nullable<int> oRDER_ID, Nullable<int> rETAILER_CHAIN_ID)
        {
            var oRDER_IDParameter = oRDER_ID.HasValue ?
                new ObjectParameter("ORDER_ID", oRDER_ID) :
                new ObjectParameter("ORDER_ID", typeof(int));
    
            var rETAILER_CHAIN_IDParameter = rETAILER_CHAIN_ID.HasValue ?
                new ObjectParameter("RETAILER_CHAIN_ID", rETAILER_CHAIN_ID) :
                new ObjectParameter("RETAILER_CHAIN_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOrderDetail_Result>("GetOrderDetail", oRDER_IDParameter, rETAILER_CHAIN_IDParameter);
        }
    
        public virtual ObjectResult<API_LCP_COUNTING_Result> API_LCP_COUNTING(string sSCC)
        {
            var sSCCParameter = sSCC != null ?
                new ObjectParameter("SSCC", sSCC) :
                new ObjectParameter("SSCC", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<API_LCP_COUNTING_Result>("API_LCP_COUNTING", sSCCParameter);
        }
    
        public virtual ObjectResult<API_LCP_DEVIATIONS_Result> API_LCP_DEVIATIONS(string sSCC)
        {
            var sSCCParameter = sSCC != null ?
                new ObjectParameter("SSCC", sSCC) :
                new ObjectParameter("SSCC", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<API_LCP_DEVIATIONS_Result>("API_LCP_DEVIATIONS", sSCCParameter);
        }
    
        public virtual ObjectResult<API_LCP_IMAGES_Result> API_LCP_IMAGES(string sSCC)
        {
            var sSCCParameter = sSCC != null ?
                new ObjectParameter("SSCC", sSCC) :
                new ObjectParameter("SSCC", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<API_LCP_IMAGES_Result>("API_LCP_IMAGES", sSCCParameter);
        }
    
        public virtual ObjectResult<API_LCP_ORDER_DETAILS_Result> API_LCP_ORDER_DETAILS(string sSCC)
        {
            var sSCCParameter = sSCC != null ?
                new ObjectParameter("SSCC", sSCC) :
                new ObjectParameter("SSCC", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<API_LCP_ORDER_DETAILS_Result>("API_LCP_ORDER_DETAILS", sSCCParameter);
        }
    
        public virtual ObjectResult<API_LCP_TRANSACTIONS_Result> API_LCP_TRANSACTIONS(string sSCC)
        {
            var sSCCParameter = sSCC != null ?
                new ObjectParameter("SSCC", sSCC) :
                new ObjectParameter("SSCC", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<API_LCP_TRANSACTIONS_Result>("API_LCP_TRANSACTIONS", sSCCParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> API_INSERT_CHANGE(string sSCC, Nullable<decimal> oRDER_NUMBER, Nullable<decimal> nEW_ORDER_NUMBER, Nullable<decimal> oLD_ACTOR, Nullable<decimal> nEW_ACTOR, Nullable<int> lOAD_MESSAGE_STATUS_ID, Nullable<System.DateTime> uPDATE_DATE, string uPDATE_USER, string oLD_LOAD_UNIT_CONDITION_CODE, string nEW_LOAD_UNIT_CONDITION_CODE, Nullable<int> oLD_QTY_RTI, Nullable<decimal> eSOFT_PACKING_ID, Nullable<int> nEW_QTY_RTI, string dELETE_SSCC, string oLD_SSCC, string nEW_SSCC, Nullable<long> tRA_ITEM_IN_ID, string sLA_CODE, string tIME, string vALIDATION, string oLD_LOAD_UNIT_CONDITION_SUB_CODE, string nEW_LOAD_UNIT_CONDITION_SUB_CODE, string vOID_SSCC, string oLD_LOAD_CARRIER_EAN, string nEW_LOAD_CARRIER_EAN)
        {
            var sSCCParameter = sSCC != null ?
                new ObjectParameter("SSCC", sSCC) :
                new ObjectParameter("SSCC", typeof(string));
    
            var oRDER_NUMBERParameter = oRDER_NUMBER.HasValue ?
                new ObjectParameter("ORDER_NUMBER", oRDER_NUMBER) :
                new ObjectParameter("ORDER_NUMBER", typeof(decimal));
    
            var nEW_ORDER_NUMBERParameter = nEW_ORDER_NUMBER.HasValue ?
                new ObjectParameter("NEW_ORDER_NUMBER", nEW_ORDER_NUMBER) :
                new ObjectParameter("NEW_ORDER_NUMBER", typeof(decimal));
    
            var oLD_ACTORParameter = oLD_ACTOR.HasValue ?
                new ObjectParameter("OLD_ACTOR", oLD_ACTOR) :
                new ObjectParameter("OLD_ACTOR", typeof(decimal));
    
            var nEW_ACTORParameter = nEW_ACTOR.HasValue ?
                new ObjectParameter("NEW_ACTOR", nEW_ACTOR) :
                new ObjectParameter("NEW_ACTOR", typeof(decimal));
    
            var lOAD_MESSAGE_STATUS_IDParameter = lOAD_MESSAGE_STATUS_ID.HasValue ?
                new ObjectParameter("LOAD_MESSAGE_STATUS_ID", lOAD_MESSAGE_STATUS_ID) :
                new ObjectParameter("LOAD_MESSAGE_STATUS_ID", typeof(int));
    
            var uPDATE_DATEParameter = uPDATE_DATE.HasValue ?
                new ObjectParameter("UPDATE_DATE", uPDATE_DATE) :
                new ObjectParameter("UPDATE_DATE", typeof(System.DateTime));
    
            var uPDATE_USERParameter = uPDATE_USER != null ?
                new ObjectParameter("UPDATE_USER", uPDATE_USER) :
                new ObjectParameter("UPDATE_USER", typeof(string));
    
            var oLD_LOAD_UNIT_CONDITION_CODEParameter = oLD_LOAD_UNIT_CONDITION_CODE != null ?
                new ObjectParameter("OLD_LOAD_UNIT_CONDITION_CODE", oLD_LOAD_UNIT_CONDITION_CODE) :
                new ObjectParameter("OLD_LOAD_UNIT_CONDITION_CODE", typeof(string));
    
            var nEW_LOAD_UNIT_CONDITION_CODEParameter = nEW_LOAD_UNIT_CONDITION_CODE != null ?
                new ObjectParameter("NEW_LOAD_UNIT_CONDITION_CODE", nEW_LOAD_UNIT_CONDITION_CODE) :
                new ObjectParameter("NEW_LOAD_UNIT_CONDITION_CODE", typeof(string));
    
            var oLD_QTY_RTIParameter = oLD_QTY_RTI.HasValue ?
                new ObjectParameter("OLD_QTY_RTI", oLD_QTY_RTI) :
                new ObjectParameter("OLD_QTY_RTI", typeof(int));
    
            var eSOFT_PACKING_IDParameter = eSOFT_PACKING_ID.HasValue ?
                new ObjectParameter("ESOFT_PACKING_ID", eSOFT_PACKING_ID) :
                new ObjectParameter("ESOFT_PACKING_ID", typeof(decimal));
    
            var nEW_QTY_RTIParameter = nEW_QTY_RTI.HasValue ?
                new ObjectParameter("NEW_QTY_RTI", nEW_QTY_RTI) :
                new ObjectParameter("NEW_QTY_RTI", typeof(int));
    
            var dELETE_SSCCParameter = dELETE_SSCC != null ?
                new ObjectParameter("DELETE_SSCC", dELETE_SSCC) :
                new ObjectParameter("DELETE_SSCC", typeof(string));
    
            var oLD_SSCCParameter = oLD_SSCC != null ?
                new ObjectParameter("OLD_SSCC", oLD_SSCC) :
                new ObjectParameter("OLD_SSCC", typeof(string));
    
            var nEW_SSCCParameter = nEW_SSCC != null ?
                new ObjectParameter("NEW_SSCC", nEW_SSCC) :
                new ObjectParameter("NEW_SSCC", typeof(string));
    
            var tRA_ITEM_IN_IDParameter = tRA_ITEM_IN_ID.HasValue ?
                new ObjectParameter("TRA_ITEM_IN_ID", tRA_ITEM_IN_ID) :
                new ObjectParameter("TRA_ITEM_IN_ID", typeof(long));
    
            var sLA_CODEParameter = sLA_CODE != null ?
                new ObjectParameter("SLA_CODE", sLA_CODE) :
                new ObjectParameter("SLA_CODE", typeof(string));
    
            var tIMEParameter = tIME != null ?
                new ObjectParameter("TIME", tIME) :
                new ObjectParameter("TIME", typeof(string));
    
            var vALIDATIONParameter = vALIDATION != null ?
                new ObjectParameter("VALIDATION", vALIDATION) :
                new ObjectParameter("VALIDATION", typeof(string));
    
            var oLD_LOAD_UNIT_CONDITION_SUB_CODEParameter = oLD_LOAD_UNIT_CONDITION_SUB_CODE != null ?
                new ObjectParameter("OLD_LOAD_UNIT_CONDITION_SUB_CODE", oLD_LOAD_UNIT_CONDITION_SUB_CODE) :
                new ObjectParameter("OLD_LOAD_UNIT_CONDITION_SUB_CODE", typeof(string));
    
            var nEW_LOAD_UNIT_CONDITION_SUB_CODEParameter = nEW_LOAD_UNIT_CONDITION_SUB_CODE != null ?
                new ObjectParameter("NEW_LOAD_UNIT_CONDITION_SUB_CODE", nEW_LOAD_UNIT_CONDITION_SUB_CODE) :
                new ObjectParameter("NEW_LOAD_UNIT_CONDITION_SUB_CODE", typeof(string));
    
            var vOID_SSCCParameter = vOID_SSCC != null ?
                new ObjectParameter("VOID_SSCC", vOID_SSCC) :
                new ObjectParameter("VOID_SSCC", typeof(string));
    
            var oLD_LOAD_CARRIER_EANParameter = oLD_LOAD_CARRIER_EAN != null ?
                new ObjectParameter("OLD_LOAD_CARRIER_EAN", oLD_LOAD_CARRIER_EAN) :
                new ObjectParameter("OLD_LOAD_CARRIER_EAN", typeof(string));
    
            var nEW_LOAD_CARRIER_EANParameter = nEW_LOAD_CARRIER_EAN != null ?
                new ObjectParameter("NEW_LOAD_CARRIER_EAN", nEW_LOAD_CARRIER_EAN) :
                new ObjectParameter("NEW_LOAD_CARRIER_EAN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("API_INSERT_CHANGE", sSCCParameter, oRDER_NUMBERParameter, nEW_ORDER_NUMBERParameter, oLD_ACTORParameter, nEW_ACTORParameter, lOAD_MESSAGE_STATUS_IDParameter, uPDATE_DATEParameter, uPDATE_USERParameter, oLD_LOAD_UNIT_CONDITION_CODEParameter, nEW_LOAD_UNIT_CONDITION_CODEParameter, oLD_QTY_RTIParameter, eSOFT_PACKING_IDParameter, nEW_QTY_RTIParameter, dELETE_SSCCParameter, oLD_SSCCParameter, nEW_SSCCParameter, tRA_ITEM_IN_IDParameter, sLA_CODEParameter, tIMEParameter, vALIDATIONParameter, oLD_LOAD_UNIT_CONDITION_SUB_CODEParameter, nEW_LOAD_UNIT_CONDITION_SUB_CODEParameter, vOID_SSCCParameter, oLD_LOAD_CARRIER_EANParameter, nEW_LOAD_CARRIER_EANParameter);
        }
    
        public virtual ObjectResult<API_LIST_RETAILERS_Result> API_LIST_RETAILERS()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<API_LIST_RETAILERS_Result>("API_LIST_RETAILERS");
        }
    
        public virtual ObjectResult<API_LIST_LOAD_CARRIER_Result> API_LIST_LOAD_CARRIER()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<API_LIST_LOAD_CARRIER_Result>("API_LIST_LOAD_CARRIER");
        }
    
        public virtual ObjectResult<API_LIST_RTI_Result> API_LIST_RTI()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<API_LIST_RTI_Result>("API_LIST_RTI");
        }
    
        public virtual ObjectResult<API_LIST_ACTOR_MASTERDATA_Result> API_LIST_ACTOR_MASTERDATA(string aCTOR_NAME, Nullable<decimal> aCTOR_CODE, string rETAILER_CHAIN_ID, string lOCATION)
        {
            var aCTOR_NAMEParameter = aCTOR_NAME != null ?
                new ObjectParameter("ACTOR_NAME", aCTOR_NAME) :
                new ObjectParameter("ACTOR_NAME", typeof(string));
    
            var aCTOR_CODEParameter = aCTOR_CODE.HasValue ?
                new ObjectParameter("ACTOR_CODE", aCTOR_CODE) :
                new ObjectParameter("ACTOR_CODE", typeof(decimal));
    
            var rETAILER_CHAIN_IDParameter = rETAILER_CHAIN_ID != null ?
                new ObjectParameter("RETAILER_CHAIN_ID", rETAILER_CHAIN_ID) :
                new ObjectParameter("RETAILER_CHAIN_ID", typeof(string));
    
            var lOCATIONParameter = lOCATION != null ?
                new ObjectParameter("LOCATION", lOCATION) :
                new ObjectParameter("LOCATION", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<API_LIST_ACTOR_MASTERDATA_Result>("API_LIST_ACTOR_MASTERDATA", aCTOR_NAMEParameter, aCTOR_CODEParameter, rETAILER_CHAIN_IDParameter, lOCATIONParameter);
        }
    
        public virtual ObjectResult<API_LIST_SSCC_ON_ORDER_Result> API_LIST_SSCC_ON_ORDER(Nullable<long> oRDER_NUMBER)
        {
            var oRDER_NUMBERParameter = oRDER_NUMBER.HasValue ?
                new ObjectParameter("ORDER_NUMBER", oRDER_NUMBER) :
                new ObjectParameter("ORDER_NUMBER", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<API_LIST_SSCC_ON_ORDER_Result>("API_LIST_SSCC_ON_ORDER", oRDER_NUMBERParameter);
        }
    
        public virtual ObjectResult<API_LIST_ACTORID_FOR_RETAILERCHAIN_Result> API_LIST_ACTORID_FOR_RETAILERCHAIN(string rETAILERCHAIN_ID)
        {
            var rETAILERCHAIN_IDParameter = rETAILERCHAIN_ID != null ?
                new ObjectParameter("RETAILERCHAIN_ID", rETAILERCHAIN_ID) :
                new ObjectParameter("RETAILERCHAIN_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<API_LIST_ACTORID_FOR_RETAILERCHAIN_Result>("API_LIST_ACTORID_FOR_RETAILERCHAIN", rETAILERCHAIN_IDParameter);
        }
    
        public virtual ObjectResult<API_LIST_LOAD_UNIT_CONDITIONS_Result> API_LIST_LOAD_UNIT_CONDITIONS(Nullable<int> rETAILER_CHAIN_ID)
        {
            var rETAILER_CHAIN_IDParameter = rETAILER_CHAIN_ID.HasValue ?
                new ObjectParameter("RETAILER_CHAIN_ID", rETAILER_CHAIN_ID) :
                new ObjectParameter("RETAILER_CHAIN_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<API_LIST_LOAD_UNIT_CONDITIONS_Result>("API_LIST_LOAD_UNIT_CONDITIONS", rETAILER_CHAIN_IDParameter);
        }
    }
}
