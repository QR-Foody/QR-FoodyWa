using DataAccess.StorageTableRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class SubmenuEntity : Entity<string>
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public SubmenuEntity() : base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Object = "Submenu";
        }
    }
}
