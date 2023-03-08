using HealthInsuranceCaseworkApi;
using HealthInsuranceCaseworkApi.Controllers;

namespace HealthInsuranceCaseworkApi.Tests
{
    [TestClass]
    public class ParentOrgController_Tests
    {
        [TestMethod]
        public void GetParentOrgs()
        {
            // Arrange
            var controller = new ParentOrgsController(repository);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
        }
    }
}