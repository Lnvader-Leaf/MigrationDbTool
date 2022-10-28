using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbForEF.OracleEntity
{
    public class VIEW_PATIENT_BASEINFO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PATIENT_FLOW { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PIX_ID { get; set; }
        /// <summary>
        /// 孙自燕
        /// </summary>
        public string? NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SEX { get; set; }
        /// <summary>
        /// 1979/8/13 星期一 0:00:00
        /// </summary>
        public DateTime? BIRTHDAY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? AGE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? ID_CARD { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? MARITAL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? NATION { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PROF { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PHONE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PROVINCE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? CITY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? COUNTY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? ADDRESS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? HEIGHT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? WEIGHT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? REL_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? REL_TYPE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? REL_PHONE { get; set; }
        /// <summary>
        /// 2021/1/16 星期六 14:47:41
        /// </summary>
        public DateTime? AUT_CREATE_TIME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? RYCS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? VISIT_CODE { get; set; }
        /// <summary>
        /// 2022/10/17 星期一 12:11:19
        /// </summary>
        public DateTime? CTIME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? STATE { get; set; }
    }
}
