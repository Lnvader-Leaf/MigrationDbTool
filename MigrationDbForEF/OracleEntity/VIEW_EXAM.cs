using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbForEF.OracleEntity
{
    public class VIEW_EXAM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IID { get; set; }
        public string? RECORD_FLOW { get; set; }
        public string? EXAM_REPORT_NO { get; set; }
        public string? PATIENT_FLOW { get; set; }
        public string? PATIENT_NAME { get; set; }
        public string? VISIT_FLOW { get; set; }
        public string? VISIT_CODE { get; set; }
        public string? REQ_DEPT_CODE { get; set; }
        public string? REQ_DEPT_NAME { get; set; }
        public string? REQ_DOCTOR_CODE { get; set; }
        public string? REQ_DOCTOR_NAME { get; set; }
        public string? REPORT_DATE { get; set; }
        public string? DEVICE_TYPE_CODE { get; set; }
        public string? DEVICE_TYPE_NAME { get; set; }
        public string? ITEM_CODE { get; set; }
        public string? ITEM_NAME { get; set; }
        public string? POSITION { get; set; }
        public string? REPORT_DESC { get; set; }
        public string? REPORT_DIAG { get; set; }
        public string? REPORT_REMARK { get; set; }
        public string? EXAM_IMAGE_NO { get; set; }
        public string? REPORT_URL { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CTIME { get; set; }
        public string? STATE { get; set; }
    }
}
