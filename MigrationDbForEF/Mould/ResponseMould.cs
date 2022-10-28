using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbForEF.Mould
{
    public class ResponseMould
    {
        public int code { get; set; }
        public string? msg { get; set; }
        public object? data { get; set; }
    }
}
