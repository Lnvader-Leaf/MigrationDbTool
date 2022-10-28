using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDbForEF.OracleEntity
{
    public class VIEW_PATIENT_DIAG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IID { get; set; }
        public string? PATIENT_FLOW { get; set; }
        public string? PIX_ID { get; set; }
        public string? VISIT_FLOW { get; set; }
        public string? VISIT_CODE { get; set; }
        public string? DIAG_TYPE_CODE { get; set; }
        public string? DIAG_TYPE_NAME { get; set; }
        public string? MAIN_FLAG { get; set; }
        public DateTime? DIAG_DATE { get; set; }
        public string? DIAG_CODE { get; set; }
        public string? DIAG_NAME { get; set; }
        public string? TCM_DISEASE_CODE { get; set; }
        public string? TCM_DISEASE_NAME { get; set; }
        public string? TCM_SYND_CODE { get; set; }
        public string? TCM_SYND_NAME { get; set; }
        public string? DOCTOR_FLOW { get; set; }
        public string? DOCTOR_NAME { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CTIME { get; set; }

        public string? STATE { get; set; }

    }
}
