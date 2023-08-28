using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Entities.Profiles
{
    public class Role
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }

        public List<User>? Users { get; set; }
    }
}
