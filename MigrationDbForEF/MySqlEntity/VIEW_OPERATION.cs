using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbForEF.MySqlEntity
{
    public class VIEW_OPERATION
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? RECORD_FLOW { get; set; }
        public string? PATIENT_FLOW { get; set; }
        public string? VISIT_FLOW { get; set; }
        public string? VISIT_CODE { get; set; }
        public string? OPER_NO { get; set; }
        public string? OPER_CODE { get; set; }
        public string? OPER_NAME { get; set; }
        public string? BODY_PART_CODE { get; set; }
        public string? BODY_PART_NAME { get; set; }
        public string? SCALE_CODE { get; set; }
        public string? SCALE_NAME { get; set; }
        public string? GRADE_CODE { get; set; }
        public string? GRADE_NAME { get; set; }
        public string? DOCTOR_CODE { get; set; }
        public string? DOCTOR_NAME { get; set; }
        public string? OPER_DATE { get; set; }
        public string? OPER_START_TIME { get; set; }
        public string? OPER_END_TIME { get; set; }
        public string? MEMO { get; set; }
    }
}
