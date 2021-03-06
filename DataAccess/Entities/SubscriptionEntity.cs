﻿using DataAccess.StorageTableRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class SubscriptionEntity : Entity<string>
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public double Cost { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public SubscriptionEntity() : base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Object = "Subscription";
        }
    }
}
