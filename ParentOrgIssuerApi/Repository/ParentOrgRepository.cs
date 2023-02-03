using Dapper;
using System.Data;
using ParentOrgIssuerApi.Context;
using ParentOrgIssuerApi.Contracts;
using ParentOrgIssuerApi.Models;
using ParentOrgIssuerApi.Dto;

namespace ParentOrgIssuerApi.Repository
{
    public class ParentOrgRepository : IParentOrgRepository
    {
        private readonly DapperContext _context;
        public ParentOrgRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ParentOrg>> GetParentOrgs()
        {
            var sproc = "[USERACCESS].[getListParentOrgs]";

            //List<ParentOrg> parents = new List<ParentOrg>();

            using (var connection = _context.CreateConnection())
            {
                var parentorgs = (await connection.QueryAsync<ParentOrg>(
                    sproc, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                
                //foreach(ParentOrg org in parentorgs)
                //{
                //    ParentOrg parentOrg = new ParentOrg()
                //    {
                //        ParentId = org.ParentId,
                //        ParentName = org.ParentName
                //    };
                //    parents.Add(parentOrg);
                //}                
                return parentorgs;
            }
        }

        public async Task<ParentOrg> GetParentOrgById(int id)
        {
            var query = "SELECT * FROM [USERACCESS].[PARENT_ORGS] WHERE PARENT_ID = @id";

            using (var connection = _context.CreateConnection())
            {
                var parentorg = await connection.QuerySingleOrDefaultAsync<ParentOrg>(query, new { id });

                return parentorg;
            }
        }

        public async Task<IEnumerable<ParentOrg>> GetParentOrgByName(string name)
        {
            var query = "SELECT * FROM [USERACCESS].[PARENT_ORGS] WHERE PARENT_NAME LIKE CONCAT('%',@name,'%');";            

            using (var connection = _context.CreateConnection())
            {
                var parentorg = await connection.QueryAsync<ParentOrg>(query, new { name });

                return parentorg.ToList();
            }
        }

        public async Task<IEnumerable<UserInfo>> GetUsersByParentOrg(int id)
        {
            var query = "SELECT * FROM [USERACCESS].[USERINFO] WHERE PARENT_ID = @Id";

            using (var connection = _context.CreateConnection())
            {
                var userinfo = await connection.QueryAsync<UserInfo>(query, new { id });

                return userinfo.ToList();
            }
        }

        public async Task<ParentOrg> CreateParentOrg(ParentOrgForCreationDto ParentOrg)
        {
            var query = "IF NOT EXISTS(SELECT 1 FROM [USERACCESS].[PARENT_ORGS] WHERE PARENT_NAME = @PARENT_NAME) " +
                "BEGIN " +
                "INSERT INTO [USERACCESS].[PARENT_ORGS] (PARENT_NAME) VALUES (@PARENT_NAME) " +
                "END;" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("PARENT_NAME", ParentOrg.PARENT_NAME, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdParentOrg = new ParentOrg
                {
                    PARENT_NAME = ParentOrg.PARENT_NAME,
                    PARENT_ID = id,
                };

                return createdParentOrg;
            }
        }

        public async Task UpdateParentOrg(int id, ParentOrgForUpdateDto ParentOrg)
        {
            var query = "UPDATE [USERACCESS].[PARENT_ORGS] SET Parent_Name = @Name WHERE Parent_Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("ParentId", id, DbType.Int32);
            parameters.Add("Name", ParentOrg.ParentName, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteParentOrg(int id)
        {
            var query = "DELETE FROM [USERACCESS].[PARENT_ORGS] WHERE Parent_Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
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

        public async Task<ParentOrg> GetParentOrgUsersMultipleResults(int id)
        {
            var query = "SELECT * FROM ParentOrgs WHERE Parent_ID = @Id;" +
                        "SELECT * FROM [USERACCESS].[USERINFO] WHERE Parent_Id = @Id";

            using (var connection = _context.CreateConnection())
            using (var multi = await connection.QueryMultipleAsync(query, new { id }))
            {
                var ParentOrg = await multi.ReadSingleOrDefaultAsync<ParentOrg>();
                if (ParentOrg != null)
                    ParentOrg.Users = (await multi.ReadAsync<UserInfo>()).ToList();

                return ParentOrg;
            }
        }

        public async Task<List<ParentOrg>> GetParentOrgsUsersMultipleMapping()
        {
            var query = "SELECT * FROM [USERACCESS].[USERINFO] " +
                "JOIN [USERACCESS].[PARENT_ORGS] p on p.PARENT_ID = u.PARENT_ID";

            using (var connection = _context.CreateConnection())
            {
                var ParentOrgDict = new Dictionary<int, ParentOrg>();

                var ParentOrgs = await connection.QueryAsync<ParentOrg, UserInfo, ParentOrg>(
                    query, (ParentOrg, Users) =>
                    {
                        if (!ParentOrgDict.TryGetValue(ParentOrg.PARENT_ID, out var currentParentOrg))
                        {
                            currentParentOrg = ParentOrg;
                            ParentOrgDict.Add(currentParentOrg.PARENT_ID, currentParentOrg);
                        }

                        currentParentOrg.Users.Add(Users);
                        return currentParentOrg;
                    }
                );

                return ParentOrgs.Distinct().ToList();
            }
        }

        public async Task CreateMultipleParentOrgs(List<ParentOrgForCreationDto> ParentOrgs)
        {
            var query = "INSERT INTO [USERACCESS].[PARENT_ORGS] (Parent_Name) VALUES (@PARENT_NAME)";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    foreach (var ParentOrg in ParentOrgs)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("PARENT_NAME", ParentOrg.PARENT_NAME, DbType.String);

                        await connection.ExecuteAsync(query, parameters, transaction: transaction);
                        //throw new Exception();
                    }

                    transaction.Commit();
                }
            }
        }
    }

}
