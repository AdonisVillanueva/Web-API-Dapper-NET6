
using Castle.Core.Resource;
using HealthInsuranceCaseworkApi.Controllers;
using HealthInsuranceCaseworkApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace HealthInsuranceCaseworApi.Tests.Controller
{

    public class ParentOrgControllerTests
    {
        private readonly Mock<IParentOrgRepository> _mockRepo;
        private readonly ParentOrgsController _controller;

        public ParentOrgControllerTests()
        {
            _mockRepo = new Mock<IParentOrgRepository>();
            _controller = new ParentOrgsController(_mockRepo.Object);           

        }

        [Fact]
        public async Task Index_ReturnsExactNumberOfParentOrgsAsync()
        {
            _mockRepo.Setup(repo => repo.GetParentOrgs())
               .ReturnsAsync(new List<ParentOrg>() { new ParentOrg() { PARENT_ID = 1, PARENT_NAME = "Test1" },
                    new ParentOrg() { PARENT_ID = 2, PARENT_NAME = "Test2" },
                    new ParentOrg() { PARENT_ID = 3, PARENT_NAME = "Test3" },
                    new ParentOrg() { PARENT_ID = 4, PARENT_NAME = "Test4" }});

            var result = await _controller.GetParentOrgs();   
            var content = ((OkObjectResult)result).Value;

            Assert.NotNull(result);
            Assert.IsType<List<ParentOrg>>(content);
            
            var parentOrgs = (List<ParentOrg>)content;

            Assert.Equal(4,parentOrgs.Count);

        }

        [Fact]
        public async Task Index_ReturnExactParentOrgAsync()
        {
            var parentOrg = new ParentOrg() { PARENT_ID = 123, PARENT_NAME = "Test2" };

            _mockRepo.Setup(r => r.GetParentOrgById(123)).ReturnsAsync(parentOrg);

            var result = await _controller.GetParentOrgById(123);
            var content = ((OkObjectResult)result).Value;            

            Assert.NotNull(result);
            Assert.Equal(123, (content as ParentOrg).PARENT_ID);
        }
    }
}