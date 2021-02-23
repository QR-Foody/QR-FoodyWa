using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Dtos
{
    public class MenuDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool Active { get; set; }
    }
}
