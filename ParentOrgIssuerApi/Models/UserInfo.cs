namespace ParentOrgIssuerApi.Models
{
    public class UserInfo
    {
        public string USER_ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string MID_INITIAL { get; set; }
        public string LAST_NAME { get; set; }
        public string EMAIL { get; set; }
        public string ORG_NAME { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string ADDRESS3 { get; set; }
        public string CITY { get; set; }
        public string STATE_CODE { get; set; }
        public string ZIPCODE { get; set; }
        public string PHONE { get; set; }
        public string FAX { get; set; }
        public decimal? FIRST_TIME { get; set; }
        public string REGION_ID { get; set; }
        public string USER_STATE { get; set; }
        public DateTime USER_CREATION_DATE { get; set; }
        public string ACTIVE { get; set; }
        public DateTime? LAST_ACCESS_DATE { get; set; }
        public DateTime? LAST_DEACTIVATION_DATE { get; set; }
        public string LAST_DEACTIVATION_USER { get; set; }
        public string DEACTIVATION_REASON { get; set; }
        public int? COMPONENT { get; set; }
        public int? ParentID { get; set; }
    }
}
