using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbForEF.SqlServerEntity
{
    public class VIEW_PATIENT_BASEINFO
    {
        public string? PATIENT_FLOW { get; set; }
        [Column("PIX_ID")]
        public string? PIX_ID { get; set; }
        [Column("visit_code")]
        public string? visit_code { get; set; }
        [Column("rycs")]
        public short? rycs { get; set; }
        [Column("NAME")]
        public string? NAME { get; set; }
        [Column("SEX")]
        public string? SEX { get; set; }
        [Column("BIRTHDAY")]
        public string? BIRTHDAY { get; set; }
        [Column("AGE")]
        public int? AGE { get; set; }
        [Column("ID_CARD")]
        public string? ID_CARD { get; set; }
        [Column("MARITAL")]
        public string? MARITAL { get; set; }
        [Column("NATION")]
        public string? NATION { get; set; }
        [Column("PROF")]
        public string? PROF { get; set; }
        [Column("PHONE")]
        public string? PHONE { get; set; }
        [Column("PROVINCE")]
        public string? PROVINCE { get; set; }
        [Column("CITY")]
        public string? CITY { get; set; }
        [Column("COUNTY")]
        public string? COUNTY { get; set; }
        [Column("ADDRESS")]
        public string? ADDRESS { get; set; }
        [Column("HEIGHT")]
        public int? HEIGHT { get; set; }
        [Column("WEIGHT")]
        public int? WEIGHT { get; set; }
        [Column("REL_NAME")]
        public string? REL_NAME { get; set; }
        [Column("REL_TYPE")]
        public string? REL_TYPE { get; set; }
        [Column("REL_PHONE")]
        public string? REL_PHONE { get; set; }
        [Column("AUT_CREATE_TIME")]
        public DateTime AUT_CREATE_TIME { get; set; }
    }
}
