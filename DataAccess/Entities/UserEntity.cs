using DataAccess.StorageTableRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    class UserEntity : Entity<string>
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("subscriptionId")]
        public string SubscriptionId { get; set; }

        public UserEntity() : base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Object = "User";
        }
    }
}
