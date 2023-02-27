using HealthInsuranceCaseworkApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsuranceCaseworApi.Tests.Repository
{
    public class MockRepository
    {
        List<ParentOrg> parentOrgs;

        public bool FailGet { get; set; }

        public MockRepository()
        {
            parentOrgs = new List<ParentOrg>() {
             new ParentOrg() { PARENT_ID = 1, PARENT_NAME = "Test1" },
            new ParentOrg() { PARENT_ID = 2, PARENT_NAME = "Test2" },
            new ParentOrg() { PARENT_ID = 3, PARENT_NAME = "Test3" },
            new ParentOrg() { PARENT_ID = 4, PARENT_NAME = "Test4" }};
        }

    public async Task<IEnumerable<ParentOrg>> GetAllParentOrgsAsync()
    {
        if (FailGet)
        {
            throw new InvalidOperationException();
        }
        await Task.Delay(1000);
        return parentOrgs;
    }
}
}
