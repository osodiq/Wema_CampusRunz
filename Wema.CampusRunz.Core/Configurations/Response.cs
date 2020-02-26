using System;
using System.Collections.Generic;
using System.Text;

namespace Wema.CampusRunz.Core.Configurations
{
    public class Response<T>
    {
        //public bool IsError { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
