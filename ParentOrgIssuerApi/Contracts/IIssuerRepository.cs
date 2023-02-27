using HealthInsuranceCaseworkApi.Dto;
using HealthInsuranceCaseworkApi.Models;

namespace HealthInsuranceCaseworkApi.Contracts
{
    public interface IIssuerRepository
    {
        public Task<Issuer> GetIssuerById(string id);
        public Task<Issuer> GetIssuerById(int id);
        public Task<IEnumerable<Issuer>> GetIssuers();
        public Task<IEnumerable<Issuer>> GetIssuersByParentOrg(int id);
        public Task<IEnumerable<Issuer>> GetIssuersByUser(string id);
        public Task<Issuer> CreateIssuer(IssuerForCreationDto Issuer);
        public Task UpdateIssuer(string id, IssuerForUpdateDto Issuer);
        public Task DeleteIssuer(string id);
        public Task<List<Issuer>> GetIssuersUsersMultipleMapping();
        public Task CreateMultipleIssuers(List<IssuerForCreationDto> Issuers);
    }
}
