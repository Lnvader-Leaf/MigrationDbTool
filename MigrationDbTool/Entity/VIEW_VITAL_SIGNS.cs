using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDbTool.Entity
{
    public class VIEW_VITAL_SIGNS
    {
        public string RECORD_FLOW { get; set; }
        public string PATIENT_FLOW { get; set; }
        public string VISIT_FLOW { get; set; }
        public string VISIT_CODE { get; set; }
        public string VITAL_SIGNS_NO { get; set; }
        public string REC_DATE { get; set; }
        public string TIME_POINT { get; set; }
        public string VITAL_SIGNS_CODE { get; set; }
        public string VITAL_SIGNS_NAME { get; set; }
        public string VITAL_SIGNS_VALUES { get; set; }
        public string SIGNS_VALUES_FLAG { get; set; }
        public string SPECIAL_VALUE { get; set; }
        public string UNITS_CODE { get; set; }
        public string UNITS_NAME { get; set; }
        public string MEMO { get; set; }
        public string RECORDER_CODE { get; set; }
        public string RECORDER_NAME { get; set; }
        public DateTime ctime { get; set; }
        public string state { get; set; }
    }
}
