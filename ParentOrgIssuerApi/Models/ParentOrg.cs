using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsuranceCaseworkApi.Models
{
    public class ParentOrg
    {
        [Column("PARENT_ID")]
        public int PARENT_ID { get; set; }
        [Column("PARENT_NAME")]
        public String? PARENT_NAME { get; set; }

        public List<UserInfo> Users { get; set; } = new List<UserInfo>();
    }

    public class ParentOrgIssuerMapping
    {
        [Column("PARENT_ID")]
        public int PARENT_ID { get; set; }
        [Column("PARENT_NAME")]
        public String? PARENT_NAME { get; set; }

        public List<Issuer> Issuers { get; set; } = new List<Issuer>();
    }
}
