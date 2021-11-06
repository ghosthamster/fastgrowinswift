using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfRegister { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
