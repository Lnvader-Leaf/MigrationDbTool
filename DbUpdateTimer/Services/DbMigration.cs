using DbUpdateTimer.DBHelper;
using DbUpdateTimer.IServices;
using DbUpdateTimer.Mould;
using PubLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DbUpdateTimer.Services
{
    public class DbMigration : IDbMigration
    {
        public ResultMould Migration_View_Patient_Baseinfo(int currentTime)
        {
            ResultMould result = new ResultMould();
            try
            {
                //select * from VIEW_PATIENT_BASEINFO
                string strSql = "select * from qct_jzai t";
                uDataSet uds = new uDataSet(new string[] { strSql }, new uParameter[] { });
                foreach (DataRow item in uds.Tables[0].Rows)
                {
                    var dataItem = item;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
