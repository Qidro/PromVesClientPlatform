using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromVesClientPlatform.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public bool Active { get; set; }
    }
}
