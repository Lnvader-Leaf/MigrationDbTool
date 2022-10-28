
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDbForEF.SqlServerEntity
{
    public class VIEW_PATIENT_ORDERS
    {
        public string? RECORD_FLOW { get; set; }
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
        public string? PATIENT_FLOW { get; set; }
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
        /// 管理员
        /// </summary>
        public string? DOCTOR_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? CLASS_CODE { get; set; }
        /// <summary>
        /// 处置
        /// </summary>
        public string? CLASS_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CHARGES { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? STATUS_CODE { get; set; }
        /// <summary>
        /// 未交费
        /// </summary>
        public string? STATUS_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? ORDER_NO { get; set; }
        /// <summary>
        /// 2016/11/21 星期一 23:46:10
        /// </summary>
        public DateTime? ORDER_DATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? ORDER_CODE { get; set; }
        /// <summary>
        /// 大换药
        /// </summary>
        public string? ORDER_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? ORDER_MEMO { get; set; }
        /// <summary>
        /// 否
        /// </summary>
        public string? LONG_FLAG { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public short? GROUP_CODE { get; set; }
        /// <summary>
        /// 2016/11/21 星期一 23:46:10
        /// </summary>
        public DateTime? EXEC_TIME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? STOP_TIME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? USAGE_CODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? USAGE_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? DOSE_EACH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? DOSE_UNIT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? BASE_DOSE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? FREQUENCY_CODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? FREQUENCY_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? DRUG_SPECS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PACK_QTY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? QTY_TOT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? VALID_DAYS { get; set; }
    }
}
