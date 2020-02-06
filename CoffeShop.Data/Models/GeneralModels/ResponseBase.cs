using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeShop.Data.Models.GeneralModels
{
    public class ResponseBase
    {
        public bool IsOk { get; set; }
        public string Message { get; set; }
        public string ExtraData { get; set; }

    }
}
