using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDbForEF.OracleEntity
{
    [Table("VIEW_VITAL_SIGNS2")]
    public class VIEW_VITAL_SIGNS2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IID { get; set; }
        public string? BIZID { get; set; }
        public string? FULLNAME { get; set; }
        public string? PATIENTID { get; set; }
        public string? VISITID { get; set; }
        public string? RECORDTIME { get; set; }
        public string? TEMPERATURETYPE { get; set; }
        public string? BODYTEMPERATURE { get; set; }
        public string? PULSERATE { get; set; }
        public string? HEARTRATE { get; set; }
        public string? BREATHRATE { get; set; }
        public string? OUTWATER { get; set; }
        public string? INWATER { get; set; }
        public string? SYSTOLICPRESSURE { get; set; }
        public string? DIASTOLICPRESSURE { get; set; }
        public string? CONSCIOUSNESS { get; set; }
        public string? PERCENTAGEOFOXYGENSATURATION { get; set; }
        [Column("WEIGHT")]
        public string? WEIGHT { get; set; }
        [Column("HEIGHT")]
        public string? HEIGHT { get; set; }
        public string? BOWELS { get; set; }
        public string? PEE { get; set; }
        public string? RECORDNAME { get; set; }
        public string? RECORDCODE { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CTIME { get; set; }
        public string? STATE { get; set; }

    }
}
