using Dapper;
using System.Data;
using HealthInsuranceCaseworkApi.Context;
using HealthInsuranceCaseworkApi.Contracts;
using HealthInsuranceCaseworkApi.Models;
using HealthInsuranceCaseworkApi.Dto;

namespace IssuerIssuerApi.Repository
{
    public class IssuerRepository : IIssuerRepository
    {
        private readonly DapperContext _context;
        public IssuerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Issuer>> GetIssuers()
        {
            var sproc = "[USERACCESS].[getListIssuers]";

            using (var connection = _context.CreateConnection())
            {
                var parentorgs = (await connection.QueryAsync<Issuer>(
                    sproc, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
       
                return parentorgs;
            }
        }

        public async Task<Issuer> GetIssuerById(int id)
        {
            var query = "SELECT * FROM [USERACCESS].[ISSUER_DISTINCT] WHERE ISSUER_ID = @id";

            using (var connection = _context.CreateConnection())
            {
                var parentorg = await connection.QuerySingleOrDefaultAsync<Issuer>(query, new { id });

                return parentorg;
            }
        }

        public async Task<Issuer> GetIssuerById(string id)
        {
            var query = "SELECT * FROM [USERACCESS].[ISSUER_DISTINCT] WHERE ID = @id";

            using (var connection = _context.CreateConnection())
            {
                var parentorg = await connection.QuerySingleOrDefaultAsync<Issuer>(query, new { id });

                return parentorg;
            }
        }    

        public async Task<IEnumerable<Issuer>> GetIssuersByUser(string id)
        {
            var query = "SELECT * FROM [USERACCESS].[PARENT_ORGS] WHERE USER_ID = @Id";

            using (var connection = _context.CreateConnection())
            {
                var issuers = await connection.QueryAsync<Issuer>(query, new { id });

                return issuers.ToList();
            }
        }

        public async Task<Issuer> CreateIssuer(IssuerForCreationDto Issuer)
        {
            var procedure = "Complaints.insertIssuer";

            var parameters = new DynamicParameters();
            parameters.Add("issuer_state", Issuer.ISSUER_STATE);
            parameters.Add("issuer_id", Issuer.ISSUER_ID);
            parameters.Add("issuer_name", Issuer.ISSUER_NAME);
            parameters.Add("product_id", Issuer.PRODUCT_ID);
            parameters.Add("standard_component_id", Issuer.STANDARD_COMPONENT_ID);
            parameters.Add("variant_id", Issuer.VARIANT_ID);
            parameters.Add("plan_id", Issuer.PLAN_ID);
            parameters.Add("marketplace_model", Issuer.MARKETPLACE_MODEL);
            parameters.Add("plan_name", Issuer.PLAN_NAME);
            parameters.Add("market_coverage_type", Issuer.MARKET_COVERAGE_TYPE);
            parameters.Add("hpid", Issuer.HPID);
            parameters.Add("dental_only_plan", Issuer.DENTAL_ONLY_PLAN);
            parameters.Add("plan_type", Issuer.PLAN_TYPE);
            parameters.Add("level_of_coverage", Issuer.LEVEL_OF_COVERAGE);
            parameters.Add("qhp_non_qhp", Issuer.QHP_NON_QHP);
            parameters.Add("plan_effective_date", Issuer.PLAN_EFFECTIVE_DATE);
            parameters.Add("plan_expiration_date", Issuer.PLAN_EXPIRATION_DATE);
            parameters.Add("url_for_sb_and_coverage", Issuer.URL_FOR_SB_AND_COVERAGE);
            parameters.Add("url_for_enrollment_payment", Issuer.URL_FOR_ENROLLMENT_PAYMENT);
            parameters.Add("url_for_plan_brochure", Issuer.URL_FOR_PLAN_BROCHURE);
            parameters.Add("cs_toll_free_ind_mkt", Issuer.CS_TOLL_FREE_IND_MKT);
            parameters.Add("cs_tty_ind_mkt", Issuer.CS_TTY_IND_MKT);
            parameters.Add("cs_url_ind_mkt", Issuer.CS_URL_IND_MKT);
            parameters.Add("cs_toll_free_shop", Issuer.CS_TOLL_FREE_SHOP);
            parameters.Add("cs_tty_shop", Issuer.CS_TTY_SHOP);
            parameters.Add("cs_url_shop", Issuer.CS_URL_SHOP);
            parameters.Add("enrl_cntct_first_name", Issuer.ENRL_CNTCT_FIRST_NAME);
            parameters.Add("enrl_cntct_last_name", Issuer.ENRL_CNTCT_LAST_NAME);
            parameters.Add("enrl_cntct_phone", Issuer.ENRL_CNTCT_PHONE);
            parameters.Add("enrl_cntct_ext", Issuer.ENRL_CNTCT_EXT);
            parameters.Add("enrl_cntct_email", Issuer.ENRL_CNTCT_EMAIL);
            parameters.Add("appeals_cntct_first_name", Issuer.APPEALS_CNTCT_FIRST_NAME);
            parameters.Add("appeals_cntct_last_name", Issuer.APPEALS_CNTCT_LAST_NAME);
            parameters.Add("appeals_cntct_phone", Issuer.APPEALS_CNTCT_PHONE);
            parameters.Add("appeals_cntct_ext", Issuer.APPEALS_CNTCT_EXT);
            parameters.Add("appeals_cntct_email", Issuer.APPEALS_CNTCT_EMAIL);
            parameters.Add("cs_cntct_first_name", Issuer.CS_CNTCT_FIRST_NAME);
            parameters.Add("cs_cntct_last_name", Issuer.CS_CNTCT_LAST_NAME);
            parameters.Add("cs_cntct_phone", Issuer.CS_CNTCT_PHONE);
            parameters.Add("cs_cntct_ext", Issuer.CS_CNTCT_EXT);
            parameters.Add("cs_cntct_email", Issuer.CS_CNTCT_EMAIL);
            parameters.Add("gvmt_cntct_first_name", Issuer.GVMT_CNTCT_FIRST_NAME);
            parameters.Add("gvmt_cntct_last_name", Issuer.GVMT_CNTCT_LAST_NAME);
            parameters.Add("gvmt_cntct_phone", Issuer.GVMT_CNTCT_PHONE);
            parameters.Add("gvmt_cntct_ext", Issuer.GVMT_CNTCT_EXT);
            parameters.Add("gvmt_cntct_email", Issuer.GVMT_CNTCT_EMAIL);
            parameters.Add("cmplnt_cntct_first_name", Issuer.CMPLNT_CNTCT_FIRST_NAME);
            parameters.Add("cmplnt_cntct_last_name", Issuer.CMPLNT_CNTCT_LAST_NAME);
            parameters.Add("cmplnt_cntct_phone", Issuer.CMPLNT_CNTCT_PHONE);
            parameters.Add("cmplnt_cntct_ext", Issuer.CMPLNT_CNTCT_EXT);
            parameters.Add("cmplnt_cntct_email", Issuer.CMPLNT_CNTCT_EMAIL);
            parameters.Add("compliance_cntct_first_name", Issuer.COMPLIANCE_CNTCT_FIRST_NAME);
            parameters.Add("compliance_cntct_last_name", Issuer.COMPLIANCE_CNTCT_LAST_NAME);
            parameters.Add("compliance_cntct_phone", Issuer.COMPLIANCE_CNTCT_PHONE);
            parameters.Add("compliance_cntct_ext", Issuer.COMPLIANCE_CNTCT_EXT);
            parameters.Add("compliance_cntct_email", Issuer.COMPLIANCE_CNTCT_EMAIL);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(procedure, parameters, commandType: CommandType.StoredProcedure);

                var createdIssuer = new Issuer
                {
                    ID = id,
                    ISSUER_STATE = Issuer.ISSUER_STATE,
                    ISSUER_ID = Issuer.ISSUER_ID,
                    ISSUER_NAME = Issuer.ISSUER_NAME,
                    PRODUCT_ID = Issuer.PRODUCT_ID,
                    STANDARD_COMPONENT_ID = Issuer.STANDARD_COMPONENT_ID,
                    VARIANT_ID = Issuer.VARIANT_ID,
                    PLAN_ID = Issuer.PLAN_ID,
                    MARKETPLACE_MODEL = Issuer.MARKETPLACE_MODEL,
                    PLAN_NAME = Issuer.PLAN_NAME,
                    MARKET_COVERAGE_TYPE = Issuer.MARKET_COVERAGE_TYPE,
                    HPID = Issuer.HPID,
                    DENTAL_ONLY_PLAN = Issuer.DENTAL_ONLY_PLAN,
                    PLAN_TYPE = Issuer.PLAN_TYPE,
                    LEVEL_OF_COVERAGE = Issuer.LEVEL_OF_COVERAGE,
                    QHP_NON_QHP = Issuer.QHP_NON_QHP,
                    PLAN_EFFECTIVE_DATE = Issuer.PLAN_EFFECTIVE_DATE,
                    PLAN_EXPIRATION_DATE = Issuer.PLAN_EXPIRATION_DATE,
                    URL_FOR_SB_AND_COVERAGE = Issuer.URL_FOR_SB_AND_COVERAGE,
                    URL_FOR_ENROLLMENT_PAYMENT = Issuer.URL_FOR_ENROLLMENT_PAYMENT,
                    URL_FOR_PLAN_BROCHURE = Issuer.URL_FOR_PLAN_BROCHURE,
                    CS_TOLL_FREE_IND_MKT = Issuer.CS_TOLL_FREE_IND_MKT,
                    CS_TTY_IND_MKT = Issuer.CS_TTY_IND_MKT,
                    CS_URL_IND_MKT = Issuer.CS_URL_IND_MKT,
                    CS_TOLL_FREE_SHOP = Issuer.CS_TOLL_FREE_SHOP,
                    CS_TTY_SHOP = Issuer.CS_TTY_SHOP,
                    CS_URL_SHOP = Issuer.CS_URL_SHOP,
                    ENRL_CNTCT_FIRST_NAME = Issuer.ENRL_CNTCT_FIRST_NAME,
                    ENRL_CNTCT_LAST_NAME = Issuer.ENRL_CNTCT_LAST_NAME,
                    ENRL_CNTCT_PHONE = Issuer.ENRL_CNTCT_PHONE,
                    ENRL_CNTCT_EXT = Issuer.ENRL_CNTCT_EXT,
                    ENRL_CNTCT_EMAIL = Issuer.ENRL_CNTCT_EMAIL,
                    APPEALS_CNTCT_FIRST_NAME = Issuer.APPEALS_CNTCT_FIRST_NAME,
                    APPEALS_CNTCT_LAST_NAME = Issuer.APPEALS_CNTCT_LAST_NAME,
                    APPEALS_CNTCT_PHONE = Issuer.APPEALS_CNTCT_PHONE,
                    APPEALS_CNTCT_EXT = Issuer.APPEALS_CNTCT_EXT,
                    APPEALS_CNTCT_EMAIL = Issuer.APPEALS_CNTCT_EMAIL,
                    CS_CNTCT_FIRST_NAME = Issuer.CS_CNTCT_FIRST_NAME,
                    CS_CNTCT_LAST_NAME = Issuer.CS_CNTCT_LAST_NAME,
                    CS_CNTCT_PHONE = Issuer.CS_CNTCT_PHONE,
                    CS_CNTCT_EXT = Issuer.CS_CNTCT_EXT,
                    CS_CNTCT_EMAIL = Issuer.CS_CNTCT_EMAIL,
                    GVMT_CNTCT_FIRST_NAME = Issuer.GVMT_CNTCT_FIRST_NAME,
                    GVMT_CNTCT_LAST_NAME = Issuer.GVMT_CNTCT_LAST_NAME,
                    GVMT_CNTCT_PHONE = Issuer.GVMT_CNTCT_PHONE,
                    GVMT_CNTCT_EXT = Issuer.GVMT_CNTCT_EXT,
                    GVMT_CNTCT_EMAIL = Issuer.GVMT_CNTCT_EMAIL,
                    CMPLNT_CNTCT_FIRST_NAME = Issuer.CMPLNT_CNTCT_FIRST_NAME,
                    CMPLNT_CNTCT_LAST_NAME = Issuer.CMPLNT_CNTCT_LAST_NAME,
                    CMPLNT_CNTCT_PHONE = Issuer.CMPLNT_CNTCT_PHONE,
                    CMPLNT_CNTCT_EXT = Issuer.CMPLNT_CNTCT_EXT,
                    CMPLNT_CNTCT_EMAIL = Issuer.CMPLNT_CNTCT_EMAIL,
                    COMPLIANCE_CNTCT_FIRST_NAME = Issuer.COMPLIANCE_CNTCT_FIRST_NAME,
                    COMPLIANCE_CNTCT_LAST_NAME = Issuer.COMPLIANCE_CNTCT_LAST_NAME,
                    COMPLIANCE_CNTCT_PHONE = Issuer.COMPLIANCE_CNTCT_PHONE,
                    COMPLIANCE_CNTCT_EXT = Issuer.COMPLIANCE_CNTCT_EXT,
                    COMPLIANCE_CNTCT_EMAIL = Issuer.COMPLIANCE_CNTCT_EMAIL,
                };

                return createdIssuer;
            }
        }

        public async Task UpdateIssuer(string id, IssuerForUpdateDto Issuer)
        {
            var procedure = "[USERACCESS].[updateIssuer]";

            var parameters = new DynamicParameters();
            parameters.Add("issuer_state", Issuer.ISSUER_STATE);
            parameters.Add("issuer_id", Issuer.ISSUER_ID);
            parameters.Add("issuer_name", Issuer.ISSUER_NAME);
            parameters.Add("product_id", Issuer.PRODUCT_ID);
            parameters.Add("standard_component_id", Issuer.STANDARD_COMPONENT_ID);
            parameters.Add("variant_id", Issuer.VARIANT_ID);
            parameters.Add("plan_id", Issuer.PLAN_ID);
            parameters.Add("marketplace_model", Issuer.MARKETPLACE_MODEL);
            parameters.Add("plan_name", Issuer.PLAN_NAME);
            parameters.Add("market_coverage_type", Issuer.MARKET_COVERAGE_TYPE);
            parameters.Add("hpid", Issuer.HPID);
            parameters.Add("dental_only_plan", Issuer.DENTAL_ONLY_PLAN);
            parameters.Add("plan_type", Issuer.PLAN_TYPE);
            parameters.Add("level_of_coverage", Issuer.LEVEL_OF_COVERAGE);
            parameters.Add("qhp_non_qhp", Issuer.QHP_NON_QHP);
            parameters.Add("plan_effective_date", Issuer.PLAN_EFFECTIVE_DATE);
            parameters.Add("plan_expiration_date", Issuer.PLAN_EXPIRATION_DATE);
            parameters.Add("url_for_sb_and_coverage", Issuer.URL_FOR_SB_AND_COVERAGE);
            parameters.Add("url_for_enrollment_payment", Issuer.URL_FOR_ENROLLMENT_PAYMENT);
            parameters.Add("url_for_plan_brochure", Issuer.URL_FOR_PLAN_BROCHURE);
            parameters.Add("cs_toll_free_ind_mkt", Issuer.CS_TOLL_FREE_IND_MKT);
            parameters.Add("cs_tty_ind_mkt", Issuer.CS_TTY_IND_MKT);
            parameters.Add("cs_url_ind_mkt", Issuer.CS_URL_IND_MKT);
            parameters.Add("cs_toll_free_shop", Issuer.CS_TOLL_FREE_SHOP);
            parameters.Add("cs_tty_shop", Issuer.CS_TTY_SHOP);
            parameters.Add("cs_url_shop", Issuer.CS_URL_SHOP);
            parameters.Add("enrl_cntct_first_name", Issuer.ENRL_CNTCT_FIRST_NAME);
            parameters.Add("enrl_cntct_last_name", Issuer.ENRL_CNTCT_LAST_NAME);
            parameters.Add("enrl_cntct_phone", Issuer.ENRL_CNTCT_PHONE);
            parameters.Add("enrl_cntct_ext", Issuer.ENRL_CNTCT_EXT);
            parameters.Add("enrl_cntct_email", Issuer.ENRL_CNTCT_EMAIL);
            parameters.Add("appeals_cntct_first_name", Issuer.APPEALS_CNTCT_FIRST_NAME);
            parameters.Add("appeals_cntct_last_name", Issuer.APPEALS_CNTCT_LAST_NAME);
            parameters.Add("appeals_cntct_phone", Issuer.APPEALS_CNTCT_PHONE);
            parameters.Add("appeals_cntct_ext", Issuer.APPEALS_CNTCT_EXT);
            parameters.Add("appeals_cntct_email", Issuer.APPEALS_CNTCT_EMAIL);
            parameters.Add("cs_cntct_first_name", Issuer.CS_CNTCT_FIRST_NAME);
            parameters.Add("cs_cntct_last_name", Issuer.CS_CNTCT_LAST_NAME);
            parameters.Add("cs_cntct_phone", Issuer.CS_CNTCT_PHONE);
            parameters.Add("cs_cntct_ext", Issuer.CS_CNTCT_EXT);
            parameters.Add("cs_cntct_email", Issuer.CS_CNTCT_EMAIL);
            parameters.Add("gvmt_cntct_first_name", Issuer.GVMT_CNTCT_FIRST_NAME);
            parameters.Add("gvmt_cntct_last_name", Issuer.GVMT_CNTCT_LAST_NAME);
            parameters.Add("gvmt_cntct_phone", Issuer.GVMT_CNTCT_PHONE);
            parameters.Add("gvmt_cntct_ext", Issuer.GVMT_CNTCT_EXT);
            parameters.Add("gvmt_cntct_email", Issuer.GVMT_CNTCT_EMAIL);
            parameters.Add("cmplnt_cntct_first_name", Issuer.CMPLNT_CNTCT_FIRST_NAME);
            parameters.Add("cmplnt_cntct_last_name", Issuer.CMPLNT_CNTCT_LAST_NAME);
            parameters.Add("cmplnt_cntct_phone", Issuer.CMPLNT_CNTCT_PHONE);
            parameters.Add("cmplnt_cntct_ext", Issuer.CMPLNT_CNTCT_EXT);
            parameters.Add("cmplnt_cntct_email", Issuer.CMPLNT_CNTCT_EMAIL);
            parameters.Add("compliance_cntct_first_name", Issuer.COMPLIANCE_CNTCT_FIRST_NAME);
            parameters.Add("compliance_cntct_last_name", Issuer.COMPLIANCE_CNTCT_LAST_NAME);
            parameters.Add("compliance_cntct_phone", Issuer.COMPLIANCE_CNTCT_PHONE);
            parameters.Add("compliance_cntct_ext", Issuer.COMPLIANCE_CNTCT_EXT);
            parameters.Add("compliance_cntct_email", Issuer.COMPLIANCE_CNTCT_EMAIL);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteIssuer(string id)
        {
            var procedure = "[USERACCESS].[deleteIssuerById";
            var parameters = new DynamicParameters();
            parameters.Add("ISSUER_ID", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(procedure,parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Issuer>> GetIssuersByParentOrg(int id)
        {
            var procedureName = "[USERACCESS].[getListParentOrgIssuerById]";
            var parameters = new DynamicParameters();
            parameters.Add("ParentId", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var Issuers = await connection.QueryAsync<Issuer>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);

                return Issuers.ToList();
            }
        }

        public async Task<Issuer> GetIssuerUsersMultipleResults(string id)
        {
            var query = "SELECT * FROM [USERACCESS].[ISSUER_DISTINCT] WHERE ISSUER_ID = @Id;" +
                        "SELECT * FROM [USERACCESS].[USERINFO] JOIN [USERACCESS].[ISSUER_X_USER] x " + 
                        "ON x.USER_ID = u.USER_ID AND x.ISSUER_ID =  = @Id;";

            using (var connection = _context.CreateConnection())
            using (var multi = await connection.QueryMultipleAsync(query, new { id }))
            {
                var Issuer = await multi.ReadSingleOrDefaultAsync<Issuer>();
                if (Issuer != null)
                    Issuer.Users = (await multi.ReadAsync<UserInfo>()).ToList();

                return Issuer;
            }
        }

        public async Task<List<Issuer>> GetIssuersUsersMultipleMapping()
        {
            var query = "SELECT * FROM [USERACCESS].[ISSUER_DISTINCT]  i " +
                            "JOIN[USERACCESS].[ISSUER_X_USER] x ON x.ISSUER_ID = i.ISSUER_ID " +
                            "JOIN[USERACCESS].[USERINFO] u ON x.USER_ID = u.USER_ID;";

            using (var connection = _context.CreateConnection())
            {
                var IssuerDict = new Dictionary<string, Issuer>();

                var Issuers = await connection.QueryAsync<Issuer, UserInfo, Issuer>(
                    query, (Issuer, Users) =>
                    {
                        if (!IssuerDict.TryGetValue(Issuer.ISSUER_ID, out var currentIssuer))
                        {
                            currentIssuer = Issuer;
                            IssuerDict.Add(currentIssuer.ISSUER_ID, currentIssuer);
                        }

                        currentIssuer.Users.Add(Users);
                        return currentIssuer;
                    }
                );

                return Issuers.Distinct().ToList();
            }
        }

        public async Task CreateMultipleIssuers(List<IssuerForCreationDto> Issuers)
        {
            var procedure = "[COMPLAINTS].[insertIssuers]";                      

            using (var connection = _context.CreateConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    foreach (var Issuer in Issuers)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("issuer_state", Issuer.ISSUER_STATE);
                        parameters.Add("issuer_id", Issuer.ISSUER_ID);
                        parameters.Add("issuer_name", Issuer.ISSUER_NAME);
                        parameters.Add("product_id", Issuer.PRODUCT_ID);
                        parameters.Add("standard_component_id", Issuer.STANDARD_COMPONENT_ID);
                        parameters.Add("variant_id", Issuer.VARIANT_ID);
                        parameters.Add("plan_id", Issuer.PLAN_ID);
                        parameters.Add("marketplace_model", Issuer.MARKETPLACE_MODEL);
                        parameters.Add("plan_name", Issuer.PLAN_NAME);
                        parameters.Add("market_coverage_type", Issuer.MARKET_COVERAGE_TYPE);
                        parameters.Add("hpid", Issuer.HPID);
                        parameters.Add("dental_only_plan", Issuer.DENTAL_ONLY_PLAN);
                        parameters.Add("plan_type", Issuer.PLAN_TYPE);
                        parameters.Add("level_of_coverage", Issuer.LEVEL_OF_COVERAGE);
                        parameters.Add("qhp_non_qhp", Issuer.QHP_NON_QHP);
                        parameters.Add("plan_effective_date", Issuer.PLAN_EFFECTIVE_DATE);
                        parameters.Add("plan_expiration_date", Issuer.PLAN_EXPIRATION_DATE);
                        parameters.Add("url_for_sb_and_coverage", Issuer.URL_FOR_SB_AND_COVERAGE);
                        parameters.Add("url_for_enrollment_payment", Issuer.URL_FOR_ENROLLMENT_PAYMENT);
                        parameters.Add("url_for_plan_brochure", Issuer.URL_FOR_PLAN_BROCHURE);
                        parameters.Add("cs_toll_free_ind_mkt", Issuer.CS_TOLL_FREE_IND_MKT);
                        parameters.Add("cs_tty_ind_mkt", Issuer.CS_TTY_IND_MKT);
                        parameters.Add("cs_url_ind_mkt", Issuer.CS_URL_IND_MKT);
                        parameters.Add("cs_toll_free_shop", Issuer.CS_TOLL_FREE_SHOP);
                        parameters.Add("cs_tty_shop", Issuer.CS_TTY_SHOP);
                        parameters.Add("cs_url_shop", Issuer.CS_URL_SHOP);
                        parameters.Add("enrl_cntct_first_name", Issuer.ENRL_CNTCT_FIRST_NAME);
                        parameters.Add("enrl_cntct_last_name", Issuer.ENRL_CNTCT_LAST_NAME);
                        parameters.Add("enrl_cntct_phone", Issuer.ENRL_CNTCT_PHONE);
                        parameters.Add("enrl_cntct_ext", Issuer.ENRL_CNTCT_EXT);
                        parameters.Add("enrl_cntct_email", Issuer.ENRL_CNTCT_EMAIL);
                        parameters.Add("appeals_cntct_first_name", Issuer.APPEALS_CNTCT_FIRST_NAME);
                        parameters.Add("appeals_cntct_last_name", Issuer.APPEALS_CNTCT_LAST_NAME);
                        parameters.Add("appeals_cntct_phone", Issuer.APPEALS_CNTCT_PHONE);
                        parameters.Add("appeals_cntct_ext", Issuer.APPEALS_CNTCT_EXT);
                        parameters.Add("appeals_cntct_email", Issuer.APPEALS_CNTCT_EMAIL);
                        parameters.Add("cs_cntct_first_name", Issuer.CS_CNTCT_FIRST_NAME);
                        parameters.Add("cs_cntct_last_name", Issuer.CS_CNTCT_LAST_NAME);
                        parameters.Add("cs_cntct_phone", Issuer.CS_CNTCT_PHONE);
                        parameters.Add("cs_cntct_ext", Issuer.CS_CNTCT_EXT);
                        parameters.Add("cs_cntct_email", Issuer.CS_CNTCT_EMAIL);
                        parameters.Add("gvmt_cntct_first_name", Issuer.GVMT_CNTCT_FIRST_NAME);
                        parameters.Add("gvmt_cntct_last_name", Issuer.GVMT_CNTCT_LAST_NAME);
                        parameters.Add("gvmt_cntct_phone", Issuer.GVMT_CNTCT_PHONE);
                        parameters.Add("gvmt_cntct_ext", Issuer.GVMT_CNTCT_EXT);
                        parameters.Add("gvmt_cntct_email", Issuer.GVMT_CNTCT_EMAIL);
                        parameters.Add("cmplnt_cntct_first_name", Issuer.CMPLNT_CNTCT_FIRST_NAME);
                        parameters.Add("cmplnt_cntct_last_name", Issuer.CMPLNT_CNTCT_LAST_NAME);
                        parameters.Add("cmplnt_cntct_phone", Issuer.CMPLNT_CNTCT_PHONE);
                        parameters.Add("cmplnt_cntct_ext", Issuer.CMPLNT_CNTCT_EXT);
                        parameters.Add("cmplnt_cntct_email", Issuer.CMPLNT_CNTCT_EMAIL);
                        parameters.Add("compliance_cntct_first_name", Issuer.COMPLIANCE_CNTCT_FIRST_NAME);
                        parameters.Add("compliance_cntct_last_name", Issuer.COMPLIANCE_CNTCT_LAST_NAME);
                        parameters.Add("compliance_cntct_phone", Issuer.COMPLIANCE_CNTCT_PHONE);
                        parameters.Add("compliance_cntct_ext", Issuer.COMPLIANCE_CNTCT_EXT);
                        parameters.Add("compliance_cntct_email", Issuer.COMPLIANCE_CNTCT_EMAIL);

                        await connection.ExecuteAsync(procedure, parameters, transaction: transaction);
                        //throw new Exception();
                    }

                    transaction.Commit();
                }
            }
        }

    }

}
