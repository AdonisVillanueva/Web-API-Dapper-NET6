using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParentOrgIssuerApi.Models
{
    public class ParentOrg
    {
        [Column("PARENT_NAME")]
        public int PARENT_ID { get; set; }
        [Column("PARENT_NAME")]
        public String? PARENT_NAME { get; set; }

        public List<UserInfo> Users { get; set; } = new List<UserInfo>();

    }
}
