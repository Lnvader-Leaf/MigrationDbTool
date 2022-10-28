using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbUpdateTimer.Entity
{
    public class VIEW_PATIENT_BASEINFO
    {
        public string PATIENT_FLOW { get; set; }
        public string PIX_ID { get; set; }
        public string NAME { get; set; }
        public string SEX { get; set; }
        public string BIRTHDAY { get; set; }
        public int AGE { get; set; }
        public string ID_CARD { get; set; }
        public string MARITAL { get; set; }
        public string NATION { get; set; }
        public string PROF { get; set; }
        public string PHONE { get; set; }
        public string PROVINCE { get; set; }
        public string CITY { get; set; }
        public string COUNTY { get; set; }
        public string ADDRESS { get; set; }
        public float HEIGHT { get; set; }
        public float WEIGHT { get; set; }
        public string REL_NAME { get; set; }
        public string REL_TYPE { get; set; }
        public string REL_PHONE { get; set; }
        public string AUT_CREATE_TIME { get; set; }
        public int rycs { get; set; }
        public string visit_code { get; set; }
        public DateTime ctime { get; set; }
        public string state { get; set; }
    }
}
