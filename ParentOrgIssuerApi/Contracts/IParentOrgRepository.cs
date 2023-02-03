using ParentOrgIssuerApi.Dto;
using ParentOrgIssuerApi.Models;

namespace ParentOrgIssuerApi.Contracts
{
    public interface IParentOrgRepository
    {
        public Task<IEnumerable<ParentOrg>> GetParentOrgs();
        public Task<ParentOrg> GetParentOrgById(int id);
        public Task<IEnumerable<ParentOrg>> GetParentOrgByName(string name);
        public Task<ParentOrg> CreateParentOrg(ParentOrgForCreationDto ParentOrg);
        public Task UpdateParentOrg(int id, ParentOrgForUpdateDto ParentOrg);
        public Task DeleteParentOrg(int id);
        public Task<IEnumerable<Issuer>> GetIssuersByParentOrg(int id);
        public Task<IEnumerable<UserInfo>> GetUsersByParentOrg(int id);
        public Task<ParentOrg> GetParentOrgUsersMultipleResults(int id);
        public Task<List<ParentOrg>> GetParentOrgsUsersMultipleMapping();
        public Task CreateMultipleParentOrgs(List<ParentOrgForCreationDto> ParentOrgs);
    }
}
