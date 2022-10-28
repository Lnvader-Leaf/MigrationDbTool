using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDbTool.Entity
{
    public class VIEW_PATIENT_VISITINFO
    {
        public string VISIT_FLOW { get; set; }
        public string PATIENT_FLOW { get; set; }
        public string PIX_ID { get; set; }
        public int? TYPE { get; set; }
        public string VISIT_CODE { get; set; }
        public string VISIT_DATE { get; set; }
        public string DEPT_CODE { get; set; }
        public string DEPT_NAME { get; set; }
        public string DOCTOR_CODE { get; set; }
        public string DOCTOR_NAME { get; set; }
        public string IN_TIME { get; set; }
        public string OUT_TIME { get; set; }
        public string DIAG_CODE { get; set; }
        public string DIAG_NAME { get; set; }
        public string TCM_DISEASE_CODE { get; set; }
        public string TCM_DISEASE_NAME { get; set; }
        public string TCM_SYND_CODE { get; set; }
        public string TCM_SYND_NAME { get; set; }
        public string _ctime { get; set; }
        public string CTIME
        {
            get { return _ctime == null ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : _ctime; }
            set { _ctime = value == null ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : value; }
        }
        private string _state;

        public string STATE
        {
            get { return _state == null ? "0" : _state; }
            set { _state = value == null ? "0" : value; }
        }
    }
}
