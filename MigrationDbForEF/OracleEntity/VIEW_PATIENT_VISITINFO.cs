using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDbForEF.OracleEntity
{
    public class VIEW_PATIENT_VISITINFO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IID { get; set; }
        public string? VISIT_FLOW { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PATIENT_FLOW { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PIX_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? TYPE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? VISIT_CODE { get; set; }
        /// <summary>
        /// 2016/12/27 星期二 9:40:57
        /// </summary>
        public DateTime? VISIT_DATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? DEPT_CODE { get; set; }
        /// <summary>
        /// 专家门诊2
        /// </summary>
        public string? DEPT_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? DOCTOR_CODE { get; set; }
        /// <summary>
        /// 郑南方
        /// </summary>
        public string? DOCTOR_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? IN_TIME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OUT_TIME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? DIAG_CODE { get; set; }
        /// <summary>
        /// 痔
        /// </summary>
        public string? DIAG_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? TCM_DISEASE_CODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? TCM_DISEASE_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? TCM_SYND_CODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? TCM_SYND_NAME { get; set; }
        /// <summary>
        /// 2022/10/17 星期一 12:04:33
        /// </summary>
        public DateTime? CTIME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? STATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        

    }
}
