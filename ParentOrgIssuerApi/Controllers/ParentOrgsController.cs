using Dapper;
using Microsoft.AspNetCore.Mvc;
using ParentOrgIssuerApi.Contracts;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParentOrgIssuerApi.Dto;

namespace ParentOrgIssuerApi.Controllers
{
    [Route("api/ParentOrgs")]
    [ApiController]
    public class ParentOrgsController : ControllerBase
    {
        private readonly IParentOrgRepository _parentorgrepo;

        public ParentOrgsController(IParentOrgRepository parentorgrepo)
        {
            _parentorgrepo = parentorgrepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetParentOrgs()
        {
            try
            {
                var ParentOrgs = await _parentorgrepo.GetParentOrgs();
                return Ok(ParentOrgs);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "ByParentID")]
        public async Task<IActionResult> GetParentOrgById(int id)
        {
            try
            {
                var parentorg = await _parentorgrepo.GetParentOrgById(id);
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

        [HttpGet("{name}",Name = "ByParentName")]
        public async Task<IActionResult> GetParentOrgByName(string name)
        {
            try
            {
                var ParentOrg = await _parentorgrepo.GetParentOrgByName(name);
                if (ParentOrg == null)
                    return NotFound();

                return Ok(ParentOrg);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("CreateParentOrg")]
        public async Task<IActionResult> CreateParentOrg(ParentOrgForCreationDto ParentOrg)
        {
            try
            {
                var createdParentOrg = await _parentorgrepo.CreateParentOrg(ParentOrg);
                return CreatedAtRoute("ByParentId", new { id = createdParentOrg.PARENT_ID }, createdParentOrg);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{parentid}",Name="UpdateParentOrg")]
        public async Task<IActionResult> UpdateParentOrg(int id, ParentOrgForUpdateDto ParentOrg)
        {
            try
            {
                var dbParentOrg = await _parentorgrepo.GetParentOrgById(id);
                if (dbParentOrg == null)
                    return NotFound();

                await _parentorgrepo.UpdateParentOrg(id, ParentOrg);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{parentid}",Name="DeleteParentOrg")]
        public async Task<IActionResult> DeleteParentOrg(int id)
        {
            try
            {
                var dbParentOrg = await _parentorgrepo.GetParentOrgById(id);
                if (dbParentOrg == null)
                    return NotFound();

                await _parentorgrepo.DeleteParentOrg(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("{id}/MultipleResult")]
        public async Task<IActionResult> GetParentOrgUsersMultipleResult(int id)
        {
            try
            {
                var parentorg = await _parentorgrepo.GetParentOrgUsersMultipleResults(id);
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

        [HttpGet("MultipleMapping")]
        public async Task<IActionResult> GetParentOrgsUsersMultipleMapping()
        {
            try
            {
                var parentorg = await _parentorgrepo.GetParentOrgsUsersMultipleMapping();

                return Ok(parentorg);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("multiple")]
        public async Task<IActionResult> CreateParentOrg(List<ParentOrgForCreationDto> parentorgs)
        {
            try
            {
                await _parentorgrepo.CreateMultipleParentOrgs(parentorgs);
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
