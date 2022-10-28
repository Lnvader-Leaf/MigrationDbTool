using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbTool.Entity
{
    public class VIEW_PATIENT_BASEINFO
    {
        public string PATIENT_FLOW { get; set; }
        public string PIX_ID { get; set; }
        public string NAME { get; set; }
        public string SEX { get; set; }
        public string BIRTHDAY { get; set; }
        private int? _age;

        public int? AGE
        {
            get { return _age; }
            set { _age = value == null ? 0 : value; }
        }

        public string ID_CARD { get; set; }
        public string MARITAL { get; set; }
        public string NATION { get; set; }
        public string PROF { get; set; }
        public string PHONE { get; set; }
        public string PROVINCE { get; set; }
        public string CITY { get; set; }
        public string COUNTY { get; set; }
        public string ADDRESS { get; set; }
        private decimal? _height;

        public decimal? HEIGHT
        {
            get { return _height; }
            set { _height = value == null ? 0 : value; }
        }

        private decimal? _weight;

        public decimal? WEIGHT
        {
            get { return _weight; }
            set { _weight = value == null ? 0 : value; }
        }

        public string REL_NAME { get; set; }
        public string REL_TYPE { get; set; }
        public string REL_PHONE { get; set; }
        public string AUT_CREATE_TIME { get; set; }
        private int? _rycs;

        public int? rycs
        {
            get { return _rycs; }
            set { _rycs = value == null ? 0 : value; }
        }

        public string visit_code { get; set; }

        private string _ctime;

        public string CTIME
        {
            get { return _ctime == null ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : _ctime; }
            set { _ctime = value == null ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : value; }
        }
        private string _state;

        public string STATE
        {
            get { return _state == null ? "0":_state; }
            set { _state = value == null  ? "0" : value; }
        }
    }
}
