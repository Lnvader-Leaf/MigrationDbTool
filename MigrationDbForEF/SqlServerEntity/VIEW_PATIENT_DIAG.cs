using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDbForEF.SqlServerEntity
{
    public class VIEW_PATIENT_DIAG
    {
        // <summary>
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
        public string? VISIT_FLOW { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? VISIT_CODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? DIAG_TYPE_CODE { get; set; }
        /// <summary>
        /// 门诊诊断
        /// </summary>
        public string? DIAG_TYPE_NAME { get; set; }
        /// <summary>
        /// 主诊断
        /// </summary>
        public string? MAIN_FLAG { get; set; }
        /// <summary>
        /// 2016/11/21 星期一 23:45:28
        /// </summary>
        public DateTime? DIAG_DATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? DIAG_CODE { get; set; }
        /// <summary>
        /// 测试
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
        /// 
        /// </summary>
        public string? DOCTOR_FLOW { get; set; }
        /// <summary>
        /// 管理员
        /// </summary>
        public string? DOCTOR_NAME { get; set; }

    }
}
