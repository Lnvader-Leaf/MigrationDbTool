using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbForEF.Mould
{
    public class Log_Read_Data
    {
        public string? Time { get; set; }
        public string? MethodName { get; set; }
        public string? In_parameter { get; set; }
        public string? Out_parameter { get; set; }
        public string? Status { get; set; }
        public string? ErroMessage { get; set; }
    }
}
