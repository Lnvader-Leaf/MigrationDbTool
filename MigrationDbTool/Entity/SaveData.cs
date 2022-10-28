using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDbTool.Entity
{
    public class SaveData
    {
        public List<VIEW_PATIENT_BASEINFO> VIEW_PATIENT_BASEINFO_1 { get; set; } = new List<VIEW_PATIENT_BASEINFO>();
        public List<VIEW_PATIENT_BASEINFO> VIEW_PATIENT_BASEINFO_2 { get; set; } = new List<VIEW_PATIENT_BASEINFO>();
        public List<VIEW_PATIENT_VISITINFO> VIEW_PATIENT_VISITINFO_1 { get; set; } = new List<VIEW_PATIENT_VISITINFO>();
        public List<VIEW_PATIENT_VISITINFO> VIEW_PATIENT_VISITINFO_2 { get; set; } = new List<VIEW_PATIENT_VISITINFO>();

        public List<VIEW_PATIENT_DIAG> VIEW_PATIENT_DIAG_1 { get; set; } = new List<VIEW_PATIENT_DIAG>();
        public List<VIEW_PATIENT_DIAG> VIEW_PATIENT_DIAG_2 { get; set; } = new List<VIEW_PATIENT_DIAG>();
        public List<VIEW_PATIENT_ORDERS> VIEW_PATIENT_ORDERS_1 { get; set; } = new List<VIEW_PATIENT_ORDERS>();
        public List<VIEW_PATIENT_ORDERS> VIEW_PATIENT_ORDERS_2 { get; set; } = new List<VIEW_PATIENT_ORDERS>();
    }
}
