using DataAccess.StorageTableRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class BusinessMenuEntity : Entity<string>
    {
        [JsonProperty("businessId")]
        public string BusinessId { get; set; }

        [JsonProperty("menuId")]
        public string MenuId { get; set; }

        public BusinessMenuEntity() : base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Object = "BusinessMenu";
        }
    }
}
