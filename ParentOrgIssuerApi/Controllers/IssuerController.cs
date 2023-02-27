using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInsuranceCaseworkApi.Dto;
using HealthInsuranceCaseworkApi.Contracts;

namespace IssuerIssuerApi.Controllers
{
    [Route("api/Issuers")]
    [ApiController]
    public class IssuersController : ControllerBase
    {
        private readonly IIssuerRepository _issuerrepo;

        public IssuersController(IIssuerRepository issuerrepo)
        {
            _issuerrepo = issuerrepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetIssuers()
        {
            try
            {
                var Issuers = await _issuerrepo.GetIssuers();
                return Ok(Issuers);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetIssuerByIntID/{id}", Name = "ByIntIssuerID")]
        public async Task<IActionResult> GetIssuerById(int id)
        {
            try
            {
                var parentorg = await _issuerrepo.GetIssuerById(id);
                if (parentorg == null)
                    return NotFound();

                return Ok(parentorg);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "ByIssuerID")]
        public async Task<IActionResult> GetIssuerById(string id)
        {
            try
            {
                var parentorg = await _issuerrepo.GetIssuerById(id);
                if (parentorg == null)
                    return NotFound();

                return Ok(parentorg);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetIssuersByParentOrg/{id}", Name = "IssuersByParentID")]
        public async Task<IActionResult> GetIssuersByParentOrg(int id)
        {
            try
            {
                var issuers = await _issuerrepo.GetIssuersByParentOrg(id);
                if (issuers == null)
                    return NotFound();

                return Ok(issuers);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetIssuersByUser/{id}", Name = "IssuerByUserID")]
        public async Task<IActionResult> GetIssuersByUser(string id)
        {
            try
            {
                var users = await _issuerrepo.GetIssuersByUser(id);
                if (users == null)
                    return NotFound();

                return Ok(users);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("CreateIssuer")]
        public async Task<IActionResult> CreateIssuer(IssuerForCreationDto Issuer)
        {
            try
            {
                var createdIssuer = await _issuerrepo.CreateIssuer(Issuer);
                return CreatedAtRoute("ByIssuerId", new { id = createdIssuer.ID }, createdIssuer);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{issuerid}",Name="UpdateIssuer")]
        public async Task<IActionResult> UpdateIssuer(string id, IssuerForUpdateDto Issuer)
        {
            try
            {
                var dbIssuer = await _issuerrepo.GetIssuerById(id);
                    return NotFound();
                if (dbIssuer == null)

                await _issuerrepo.UpdateIssuer(id, Issuer);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}",Name="DeleteIssuer")]
        public async Task<IActionResult> DeleteIssuer(string id)
        {
            try
            {
                var dbIssuer = await _issuerrepo.GetIssuerById(id);
                if (dbIssuer == null)
                    return NotFound();

                await _issuerrepo.DeleteIssuer(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }

        }
       

        [HttpGet("MultipleMapping")]
        public async Task<IActionResult> GetIssuersUsersMultipleMapping()
        {
            try
            {
                var parentorg = await _issuerrepo.GetIssuersUsersMultipleMapping();

                return Ok(parentorg);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("multiple")]
        public async Task<IActionResult> CreateMultipleIssuers(List<IssuerForCreationDto> Issuers)
        {
            try
            {
                await _issuerrepo.CreateMultipleIssuers(Issuers);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        
    }
}
