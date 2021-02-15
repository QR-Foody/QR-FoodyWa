using DataAccess.StorageTableRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    class ChoiceEntity : Entity<string>
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }

        public ChoiceEntity() : base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Object = "Choice";
        }
    }
}
