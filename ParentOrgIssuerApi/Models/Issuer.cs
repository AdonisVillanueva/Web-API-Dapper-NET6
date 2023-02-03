using System.Reflection;

namespace ParentOrgIssuerApi.Models
{
    public class Issuer
    {
        public int ID { get; set; }
        public string ISSUER_STATE { get; set; }
        public string ISSUER_ID { get; set; }
        public string ISSUER_NAME { get; set; }
        public string PRODUCT_ID { get; set; }
        public string STANDARD_COMPONENT_ID { get; set; }
        public int VARIANT_ID { get; set; }
        public string PLAN_ID { get; set; }
        public decimal? MARKETPLACE_MODEL { get; set; }
        public string PLAN_NAME { get; set; }
        public string MARKET_COVERAGE_TYPE { get; set; }
        public string HPID { get; set; }
        public string DENTAL_ONLY_PLAN { get; set; }
        public string PLAN_TYPE { get; set; }
        public string LEVEL_OF_COVERAGE { get; set; }
        public string QHP_NON_QHP { get; set; }
        public DateTime? PLAN_EFFECTIVE_DATE { get; set; }
        public DateTime? PLAN_EXPIRATION_DATE { get; set; }
        public string URL_FOR_SB_AND_COVERAGE { get; set; }
        public string URL_FOR_ENROLLMENT_PAYMENT { get; set; }
        public string URL_FOR_PLAN_BROCHURE { get; set; }
        public string CS_TOLL_FREE_IND_MKT { get; set; }
        public string CS_TTY_IND_MKT { get; set; }
        public string CS_URL_IND_MKT { get; set; }
        public string CS_TOLL_FREE_SHOP { get; set; }
        public string CS_TTY_SHOP { get; set; }
        public string CS_URL_SHOP { get; set; }
        public string ENRL_CNTCT_FIRST_NAME { get; set; }
        public string ENRL_CNTCT_LAST_NAME { get; set; }
        public string ENRL_CNTCT_PHONE { get; set; }
        public string ENRL_CNTCT_EXT { get; set; }
        public string ENRL_CNTCT_EMAIL { get; set; }
        public string APPEALS_CNTCT_FIRST_NAME { get; set; }
        public string APPEALS_CNTCT_LAST_NAME { get; set; }
        public string APPEALS_CNTCT_PHONE { get; set; }
        public string APPEALS_CNTCT_EXT { get; set; }
        public string APPEALS_CNTCT_EMAIL { get; set; }
        public string CS_CNTCT_FIRST_NAME { get; set; }
        public string CS_CNTCT_LAST_NAME { get; set; }
        public string CS_CNTCT_PHONE { get; set; }
        public string CS_CNTCT_EXT { get; set; }
        public string CS_CNTCT_EMAIL { get; set; }
        public string GVMT_CNTCT_FIRST_NAME { get; set; }
        public string GVMT_CNTCT_LAST_NAME { get; set; }
        public string GVMT_CNTCT_PHONE { get; set; }
        public string GVMT_CNTCT_EXT { get; set; }
        public string GVMT_CNTCT_EMAIL { get; set; }
        public string CMPLNT_CNTCT_FIRST_NAME { get; set; }
        public string CMPLNT_CNTCT_LAST_NAME { get; set; }
        public string CMPLNT_CNTCT_PHONE { get; set; }
        public string CMPLNT_CNTCT_EXT { get; set; }
        public string CMPLNT_CNTCT_EMAIL { get; set; }
        public string COMPLIANCE_CNTCT_FIRST_NAME { get; set; }
        public string COMPLIANCE_CNTCT_LAST_NAME { get; set; }
        public string COMPLIANCE_CNTCT_PHONE { get; set; }
        public string COMPLIANCE_CNTCT_EXT { get; set; }
        public string COMPLIANCE_CNTCT_EMAIL { get; set; }
    }

}
