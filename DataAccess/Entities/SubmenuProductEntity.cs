using DataAccess.StorageTableRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class SubmenuProductEntity : Entity<string>
    {
        [JsonProperty("submenuId")]
        public string SubmenuId { get; set; }

        [JsonProperty("prodcutId")]
        public string ProductId { get; set; }

        public SubmenuProductEntity() : base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Object = "SubmenuProduct";
        }
    }
}
