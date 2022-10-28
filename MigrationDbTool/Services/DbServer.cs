
using MigrationDbTool.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDbTool.Services
{
    public static class DbServer
    {
        public static List<VIEW_PATIENT_BASEINFO> Contrast(List<VIEW_PATIENT_BASEINFO> data1, List<VIEW_PATIENT_BASEINFO> data2)
        {
            List<VIEW_PATIENT_BASEINFO> listView = new List<VIEW_PATIENT_BASEINFO>();
            foreach (var item in data2)
            {
                var dataDto = data1.Find(m => m.PATIENT_FLOW == item.PATIENT_FLOW);
                if (dataDto == null)
                {
                    listView.Add(item);
                }
            }
            return listView;
        }

        public static List<VIEW_PATIENT_VISITINFO> Contrast(List<VIEW_PATIENT_VISITINFO> data1, List<VIEW_PATIENT_VISITINFO> data2)
        {
            List<VIEW_PATIENT_VISITINFO> listView = new List<VIEW_PATIENT_VISITINFO>();
            foreach (var item in data2)
            {
                var dataDto = data1.Find(m => m.VISIT_FLOW == item.VISIT_FLOW);
                if (dataDto == null)
                {
                    listView.Add(item);
                }
            }
            return listView;
        }
    }
}
