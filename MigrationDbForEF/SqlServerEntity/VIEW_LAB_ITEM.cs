using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbForEF.SqlServerEntity
{
    public class VIEW_LAB_ITEM
    {
        public string? RECORD_FLOW { get; set; }
        public string? LAB_FLOW { get; set; }
        public string? PATIENT_FLOW { get; set; }
        public string? VISIT_CODE { get; set; }
        public string? TEST_ITEM_CODE { get; set; }
        public string? TEST_ITEM_NAME { get; set; }
        public string? RESULT { get; set; }
        public string? RESULT_NUM { get; set; }
        public string? UNITS_CODE { get; set; }
        public string? UNITS_NAME { get; set; }
        public string? ABNORMAL_INDICATOR { get; set; }
        public DateTime RESULT_DATE_TIME { get; set; }
        public string? RESULT_REFERENCE { get; set; }
        public string? UPPER_LIMIT { get; set; }

        public string? LOWER_LIMIT { get; set; }
        public string? RESULT_MEM { get; set; }
        public string? INSPECTION_CODE { get; set; }
        public string? INSPECTION_NAME { get; set; }

    }
}
