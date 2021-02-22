using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Dtos
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string SubscriptionId { get; set; }
    }
}
