
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDbTool.Entity
{
    public class VIEW_PATIENT_ORDERS
    {
        public string RECORD_FLOW { get; set; }
        public string VISIT_FLOW { get; set; }
        public string VISIT_CODE { get; set; }
        public string PATIENT_FLOW { get; set; }
        public string DEPT_CODE { get; set; }
        public string DEPT_NAME { get; set; }
        public string DOCTOR_CODE { get; set; }
        public string DOCTOR_NAME { get; set; }
        public string CLASS_CODE { get; set; }
        public string CLASS_NAME { get; set; }
        public int? CHARGES { get; set; }
        public string STATUS_CODE { get; set; }
        public string STATUS_NAME { get; set; }
        public string ORDER_NO { get; set; }
        public string ORDER_DATE { get; set; }
        public string ORDER_CODE { get; set; }
        public string ORDER_NAME { get; set; }
        public string ORDER_MEMO { get; set; }
        public string LONG_FLAG { get; set; }
        public string GROUP_CODE { get; set; }
        public string EXEC_TIME { get; set; }
        public string STOP_TIME { get; set; }
        public string USAGE_CODE { get; set; }
        public string USAGE_NAME { get; set; }
        public string DOSE_EACH { get; set; }
        public string DOSE_UNIT { get; set; }
        public string BASE_DOSE { get; set; }
        public string FREQUENCY_CODE { get; set; }
        public string FREQUENCY_NAME { get; set; }
        public string DRUG_SPECS { get; set; }
        public string PACK_QTY { get; set; }
        public string QTY_TOT { get; set; }
        public int VALID_DAYS { get; set; }
        public DateTime? ctime { get; set; }
        public string state { get; set; }
    }
}
