using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbForEF.OracleEntity
{
    public class VIEW_LAB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IID { get; set; }
        public string? RECORD_FLOW { get; set; }
        public string? LAB_FLOW { get; set; }
        public string? PATIENT_FLOW { get; set; }
        public string? VISIT_FLOW { get; set; }
        public string? VISIT_CODE { get; set; }
        public string? REQ_DEPT_CODE { get; set; }
        public string? REQ_DEPT_NAME { get; set; }
        public string? REQ_PHYSICIAN_CODE { get; set; }
        public string? REQ_PHYSICIAN_NAME { get; set; }
        public string? RESULT_STATUS_CODE { get; set; }
        public string? RESULT_STATUS_NAME { get; set; }
        public string? REPORT_DATE { get; set; }
        public string? INSPECTION_CODE { get; set; }
        public string? INSPECTION_NAME { get; set; }
        public string? SAMPLE_TYPE_CODE { get; set; }
        public string? SAMPLE_TYPE_NAME { get; set; }
        public string? SAMPLE_NO { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CTIME { get; set; }
        public string? STATE { get; set; }
    }
}
