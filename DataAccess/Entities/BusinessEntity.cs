using DataAccess.StorageTableRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class BusinessEntity : Entity<string>
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("contactNumber")]
        public string ContactNumber { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("openAt")]
        public DateTime OpenAt { get; set; }

        [JsonProperty("closeAt")]
        public DateTime CloseAt { get; set; }

        [JsonProperty("UserId")]
        public string UserId { get; set; }

        public BusinessEntity() : base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Object = "Business";
        }

    }
}
