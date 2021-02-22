using DataAccess.StorageTableRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class MenuSubmenuEntity : Entity<string>
    {
        [JsonProperty("submenuId")]
        public string SubmenuId { get; set; }

        [JsonProperty("menuId")]
        public string MenuId { get; set; }

        public MenuSubmenuEntity() : base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Object = "MenuSubmenu";
        }
    }

}