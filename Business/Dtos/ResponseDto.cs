using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Dtos
{
    public class ResponseDto
    {
        public bool IsSuccessFul { get; set; }
        public string Error { get; set; }
        public object Result { get; set; }
    }
}
