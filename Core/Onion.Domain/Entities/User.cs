using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Onion.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { get; set; }    

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTiem { get; set; }
    }
}
