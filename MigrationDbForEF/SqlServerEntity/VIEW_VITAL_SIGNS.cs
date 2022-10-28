using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDbForEF.SqlServerEntity
{
    public class VIEW_VITAL_SIGNS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /// <summary>
        /// 
        /// </summary>
        public string? RECORD_FLOW { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PATIENT_FLOW { get; set; }
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
        public string? VITAL_SIGNS_NO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? REC_DATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? TIME_POINT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? VITAL_SIGNS_CODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? VITAL_SIGNS_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? VITAL_SIGNS_VALUES_tw1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? VITAL_SIGNS_VALUES_tw2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? VITAL_SIGNS_VALUES_tw3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? VITAL_SIGNS_VALUES_tw4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? VITAL_SIGNS_VALUES_tw5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? VITAL_SIGNS_VALUES_tw6 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? gw_one { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? gw_two { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? gw_three { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? gw_four { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? gw_five { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? gw_six { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? mb_one { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? mb_two { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? mb_three { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? mb_four { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? mb_five { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? mb_six { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? xl_one { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? xl_two { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? xl_three { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? xl_four { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? xl_five { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? xl_six { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? hx_one { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? hx_two { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? hx_three { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? hx_four { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? hx_five { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? hx_six { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? dbcs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? dbxz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? dbcs_gc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? csl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? rsl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? xbcs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? xbl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? xy_g { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? xy_d { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SIGNS_VALUES_FLAG { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SPECIAL_VALUE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? UNITS_CODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? UNITS_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? MEMO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? RECORDER_CODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? RECORDER_NAME { get; set; }
    }
}
