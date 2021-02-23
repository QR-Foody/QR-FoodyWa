using DataAccess.StorageTableRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class MenuEntity : Entity<string>
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("expirationDate")]
        public DateTime ExpirationDate { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        public MenuEntity() : base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Object = "Menu";
            this.CreatedDate = DateTime.UtcNow;
        }
    }
}
