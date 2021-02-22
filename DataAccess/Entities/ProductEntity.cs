using DataAccess.StorageTableRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class ProductEntity : Entity<string>
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("imageUri")]
        public string ImageUri { get; set; }

        public ProductEntity() : base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Object = "Product";
        }
    }
}
