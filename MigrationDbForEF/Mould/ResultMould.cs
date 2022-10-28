using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDbForEF.Mould
{
    public class ResultMould
    {
        public int code { get; set; }
        public string msg { get; set; }
        public List<RequestMould> data { get; set; } = new List<RequestMould>();
    }
}
