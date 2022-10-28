using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDbForEF.OracleEntity
{
    public class JZMould
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PATNAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? GENDER { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? AGE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? EXAMID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? DEPARTMENT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? REPORTER { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? BEDNO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PATIENTID { get; set; }
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
        public string? MENOPAUSEAGE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? TELEPHONE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? RESIDENCE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? OCCUPATION { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? NATION { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SPORTS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? BODYPARTS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? CLINICDIAGNOSIS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? JWCXGZS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? FMKBGZS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? MQCYXW { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? TPZJSLYWFYS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? LFSGJYBS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? JFXGZSSZ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? MRSRJJ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? GGJBMD { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SBXH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? CH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? GDY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SMFW { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SMFS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? GDL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? CJJ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? TXJZ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? LJ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? BMD_MEASURE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? BMD_CONCLUSION { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? QCT_T { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? QCT_Z { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? QCT_CONSLUSION { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? TOTALVOLUME_T11 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? TOTALVOLUME_T12 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? TOTALVOLUME_L1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? TOTALVOLUME_L2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZVOLUME_T11 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZVOLUME_T12 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZVOLUME_L1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZVOLUME_L2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZVOLUME_T11 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZVOLUME_T12 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZVOLUME_L1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZVOLUME_L2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZ_AVERTHICKNESS_T11 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZ_AVERTHICKNESS_T12 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZ_AVERTHICKNESS_L1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZ_AVERTHICKNESS_L2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZ_AVERAREA_T11 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZ_AVERAREA_T12 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZ_AVERAREA_L1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZ_AVERAREA_L2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZ_TOTALHU_T11 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZ_TOTALHU_T12 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZ_TOTALHU_L1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZ_TOTALHU_L2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZ_AVERHU_T11 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZ_AVERHU_T12 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZ_AVERHU_L1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PZ_AVERHU_L2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZ_AVERMAJORAXIALLENGTH_T11 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZ_AVERMAJORAXIALLENGTH_T12 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZ_AVERMAJORAXIALLENGTH_L1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZ_AVERMAJORAXIALLENGTH_L2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZ_AVERMINORAXIALLENGTH_T11 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZ_AVERMINORAXIALLENGTH_T12 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZ_AVERMINORAXIALLENGTH_L1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZ_AVERMINORAXIALLENGTH_L2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZ_TOTALHU_T11 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZ_TOTALHU_T12 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZ_TOTALHU_L1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZ_TOTALHU_L2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZ_AVERHU_T11 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZ_AVERHU_T12 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZ_AVERHU_L1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SZ_AVERHU_L2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? CONCLUSION { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? SUGGESTION { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? STUDY_INSTANCE_UID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? EXAMDATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? IMAGE1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? IMAGE2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? IMAGE3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? IMAGE4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? IMAGE5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? IMAGE6 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? DSTUDY_DATE { get; set; }
    }
}
