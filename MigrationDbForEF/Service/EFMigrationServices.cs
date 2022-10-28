using Microsoft.EntityFrameworkCore;
using MigrationDbForEF.EfDbContext;
using MigrationDbForEF.IService;
using MigrationDbForEF.Mould;
using MigrationDbForEF.ToolHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbForEF.Service
{
    public class EFMigrationServices : IEFMigrationServices
    {
        private readonly OracleDbContext oracleDbContext;
        private readonly SqlServerDbContext sqlServerDbContext;
        private readonly MySqlDbContext mySqlDbContext;

        public EFMigrationServices(OracleDbContext oracleDbContext, SqlServerDbContext sqlServerDbContext,MySqlDbContext mySqlDbContext)
        {
            this.oracleDbContext = oracleDbContext;
            this.sqlServerDbContext = sqlServerDbContext;
            this.mySqlDbContext = mySqlDbContext;
        }
        public async Task<bool> MigrationBaseInfo()
        {
            try
            {
                var startTime = DateTime.Today.AddDays(-1).AddHours(0.0);
                var endTime = DateTime.Today.AddHours(0.0).AddMinutes(-1);
                int num = 0;
                var sqlBaseInfo = await sqlServerDbContext.VIEW_PATIENT_BASEINFO.Where(m => Convert.ToDateTime(m.AUT_CREATE_TIME) >= startTime && Convert.ToDateTime(m.AUT_CREATE_TIME) <= endTime).ToListAsync();
                var oracleBaseInfo = await oracleDbContext.VIEW_PATIENT_BASEINFO.ToListAsync();

                while (true)
                {
                    List<OracleEntity.VIEW_PATIENT_BASEINFO> listData = new List<OracleEntity.VIEW_PATIENT_BASEINFO>();
                    foreach (var item in sqlBaseInfo)
                    {
                        if (oracleBaseInfo.FirstOrDefault(m=>m.PATIENT_FLOW == item.PATIENT_FLOW) == null)
                        {
                            listData.Add(new OracleEntity.VIEW_PATIENT_BASEINFO()
                            {
                                SEX = item.SEX,
                                STATE = "0",
                                ADDRESS = item.ADDRESS,
                                RYCS = item.rycs.ToString(),
                                VISIT_CODE = item.visit_code,
                                AGE = item.AGE.ToString(),
                                AUT_CREATE_TIME = item.AUT_CREATE_TIME,
                                BIRTHDAY = item.BIRTHDAY == null ? DateTime.Now : Convert.ToDateTime(item.BIRTHDAY),
                                CITY = item.CITY,
                                COUNTY = item.COUNTY,
                                CTIME = DateTime.Now,
                                HEIGHT = item.HEIGHT.ToString(),
                                ID_CARD = item.ID_CARD,
                                MARITAL = item.MARITAL,
                                NAME = item.NAME,
                                NATION = item.NATION,
                                PATIENT_FLOW = item.PATIENT_FLOW,
                                PHONE = item.PHONE,
                                PIX_ID = item.PIX_ID,
                                PROF = item.PROF,
                                PROVINCE = item.PROVINCE,
                                REL_NAME = item.REL_NAME,
                                REL_PHONE = item.REL_PHONE,
                                REL_TYPE = item.REL_TYPE,
                                WEIGHT = item.WEIGHT.ToString()
                            });
                        }
                        
                    }
                    var temp = listData.Skip(num).Take(10000).ToList();
                    if (temp.Count == 0)
                    {
                        break;
                    }
                    //使用默认
                    oracleDbContext.VIEW_PATIENT_BASEINFO.AddRange(temp);
                    oracleDbContext.SaveChanges();
                    num += temp.Count;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public async Task<bool> MigrationDiagInfo()
        {
            try
            {
                var startTime = DateTime.Today.AddDays(-1).AddHours(0.0);
                var endTime = DateTime.Today.AddHours(0.0).AddMinutes(-1);
                int num = 0;
                var sqlDiagInfo = await sqlServerDbContext.VIEW_PATIENT_DIAG.Where(m => Convert.ToDateTime(m.DIAG_DATE) >= startTime && Convert.ToDateTime(m.DIAG_DATE) <= endTime).ToListAsync();
                var oracleDiagInfo = await oracleDbContext.VIEW_PATIENT_DIAG.ToListAsync();
                while (true)
                {
                    List<OracleEntity.VIEW_PATIENT_DIAG> listData = new List<OracleEntity.VIEW_PATIENT_DIAG>();
                    foreach (var item in sqlDiagInfo)
                    {
                        if (oracleDiagInfo.FirstOrDefault(m=>m.PATIENT_FLOW == item.PATIENT_FLOW) == null)
                        {
                            listData.Add(new OracleEntity.VIEW_PATIENT_DIAG()
                            {
                                STATE = "0",
                                TCM_DISEASE_CODE = item.TCM_DISEASE_CODE,
                                TCM_DISEASE_NAME = item.TCM_DISEASE_NAME,
                                TCM_SYND_CODE = item.TCM_SYND_CODE,
                                TCM_SYND_NAME = item.TCM_SYND_NAME,
                                VISIT_CODE = item.VISIT_CODE,
                                VISIT_FLOW = item.VISIT_FLOW,
                                CTIME = DateTime.Now,
                                DIAG_CODE = item.DIAG_CODE,
                                DIAG_DATE = item.DIAG_DATE,
                                DIAG_NAME = item.DIAG_NAME,
                                DIAG_TYPE_CODE = item.DIAG_TYPE_CODE,
                                DIAG_TYPE_NAME = item.DIAG_TYPE_NAME,
                                DOCTOR_FLOW = item.DOCTOR_FLOW,
                                DOCTOR_NAME = item.DOCTOR_NAME,
                                MAIN_FLAG = item.MAIN_FLAG,
                                PATIENT_FLOW = item.PATIENT_FLOW,
                                PIX_ID = item.PIX_ID,
                            });
                        }
                        
                    }
                    var temp = listData.Skip(num).Take(10000).ToList();
                    if (temp.Count == 0)
                    {
                        break;
                    }
                    //使用默认
                    oracleDbContext.VIEW_PATIENT_DIAG.AddRange(temp);
                    oracleDbContext.SaveChanges();
                    num += temp.Count;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public async Task<bool> MigrationLabItemInfo()
        {
            try
            {
                var startTime = DateTime.Today.AddDays(-1).AddHours(0.0);
                var endTime = DateTime.Today.AddHours(0.0).AddMinutes(-1);
                int num = 0;
                var sqlVisitInfo = await sqlServerDbContext.VIEW_LAB_ITEM.Where(m => Convert.ToDateTime(m.RESULT_DATE_TIME) >= startTime && Convert.ToDateTime(m.RESULT_DATE_TIME) <= endTime).ToListAsync();
                var oracleVisitInfo = await oracleDbContext.VIEW_LAB_ITEM.Where(m => Convert.ToDateTime(m.RESULT_DATE_TIME) >= startTime && Convert.ToDateTime(m.RESULT_DATE_TIME) <= endTime).ToListAsync();
                while (true)
                {
                    List<OracleEntity.VIEW_LAB_ITEM> listData = new List<OracleEntity.VIEW_LAB_ITEM>();
                    foreach (var item in sqlVisitInfo)
                    {
                        if (oracleVisitInfo.FirstOrDefault(m => m.RECORD_FLOW == item.RECORD_FLOW) == null)
                        {
                            listData.Add(new OracleEntity.VIEW_LAB_ITEM()
                            {
                                STATE = "0",
                                INSPECTION_CODE = item.INSPECTION_CODE,
                                INSPECTION_NAME = item.INSPECTION_NAME,
                                CTIME = DateTime.Now,
                                LAB_FLOW = item.LAB_FLOW,
                                PATIENT_FLOW = item.PATIENT_FLOW,
                                RECORD_FLOW = item.RECORD_FLOW,
                                RESULT = item.RESULT,
                                RESULT_DATE_TIME = item.RESULT_DATE_TIME.ToString("yyyy-MM-dd HH:mm:ss"),
                                RESULT_MEM = item.RESULT_MEM,
                                RESULT_NUM = item.RESULT_NUM,
                                RESULT_REFERENCE = item.RESULT_REFERENCE,
                                TEST_ITEM_CODE = item.TEST_ITEM_CODE,
                                TEST_ITEM_NAME = item.TEST_ITEM_NAME,
                                UNITS_CODE = item.UNITS_CODE,
                                UNITS_NAME = item.UNITS_NAME,
                                VISIT_CODE = item.VISIT_CODE,
                                ABNORMAL_INDICATOR = item.ABNORMAL_INDICATOR,
                                LOWER_LIMIT = item.LOWER_LIMIT,
                                UPPER_LIMIT = item.UPPER_LIMIT
                            });
                        }

                    }
                    var temp = listData.Skip(num).Take(10000).ToList();
                    if (temp.Count == 0)
                    {
                        break;
                    }
                    //使用默认
                    oracleDbContext.VIEW_LAB_ITEM.AddRange(temp);
                    oracleDbContext.SaveChanges();
                    num += temp.Count;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> MigrationLabInfo()
        {
            try
            {
                var startTime = DateTime.Today.AddDays(-1).AddHours(0.0);
                var endTime = DateTime.Today.AddHours(0.0).AddMinutes(-1);
                int num = 0;
                var sqlVisitInfo = await sqlServerDbContext.VIEW_LAB.Where(m => Convert.ToDateTime(m.REPORT_DATE) >= startTime && Convert.ToDateTime(m.REPORT_DATE) <= endTime).ToListAsync();
                var oracleVisitInfo = await oracleDbContext.VIEW_LAB.Where(m => Convert.ToDateTime(m.REPORT_DATE) >= startTime && Convert.ToDateTime(m.REPORT_DATE) <= endTime).ToListAsync();
                while (true)
                {
                    List<OracleEntity.VIEW_LAB> listData = new List<OracleEntity.VIEW_LAB>();
                    foreach (var item in sqlVisitInfo)
                    {
                        if (oracleVisitInfo.FirstOrDefault(m => m.RECORD_FLOW == item.RECORD_FLOW) == null)
                        {
                            listData.Add(new OracleEntity.VIEW_LAB()
                            {
                                STATE = "0",
                                SAMPLE_NO = item.SAMPLE_NO,
                                SAMPLE_TYPE_CODE = item.SAMPLE_TYPE_CODE,
                                SAMPLE_TYPE_NAME = item.SAMPLE_TYPE_NAME,
                                INSPECTION_CODE = item.INSPECTION_CODE,
                                INSPECTION_NAME = item.INSPECTION_NAME,
                                REQ_PHYSICIAN_CODE = item.REQ_PHYSICIAN_CODE,
                                REQ_PHYSICIAN_NAME = item.REQ_PHYSICIAN_NAME,
                                RESULT_STATUS_CODE = item.RESULT_STATUS_CODE,
                                RESULT_STATUS_NAME = item.RESULT_STATUS_NAME,
                                VISIT_CODE = item.VISIT_CODE,
                                VISIT_FLOW = item.VISIT_FLOW,
                                CTIME = DateTime.Now,
                                LAB_FLOW = item.LAB_FLOW,
                                PATIENT_FLOW = item.PATIENT_FLOW,
                                RECORD_FLOW = item.RECORD_FLOW,
                                REPORT_DATE = item.REPORT_DATE.ToString("yyyy-MM-dd HH:mm:ss"),
                                REQ_DEPT_CODE = item.REQ_DEPT_CODE,
                                REQ_DEPT_NAME = item.REQ_DEPT_NAME
                            });
                        }

                    }
                    var temp = listData.Skip(num).Take(10000).ToList();
                    if (temp.Count == 0)
                    {
                        break;
                    }
                    //使用默认
                    oracleDbContext.VIEW_LAB.AddRange(temp);
                    oracleDbContext.SaveChanges();
                    num += temp.Count;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> MigrationOrdersInfo()
        {
            try
            {
                var startTime = DateTime.Today.AddDays(-1).AddHours(0.0);
                var endTime = DateTime.Today.AddHours(0.0).AddMinutes(-1);
                int num = 0;
                var sqlVisitInfo = await sqlServerDbContext.VIEW_PATIENT_ORDERS.Where(m => Convert.ToDateTime(m.EXEC_TIME) >= startTime && Convert.ToDateTime(m.EXEC_TIME) <= endTime).ToListAsync();
                var oracleVisitInfo = await oracleDbContext.VIEW_PATIENT_ORDERS.Where(m => Convert.ToDateTime(m.EXEC_TIME) >= startTime && Convert.ToDateTime(m.EXEC_TIME) <= endTime).ToListAsync();
                while (true)
                {
                    List<OracleEntity.VIEW_PATIENT_ORDERS> listData = new List<OracleEntity.VIEW_PATIENT_ORDERS>();
                    foreach (var item in sqlVisitInfo)
                    {
                        if (oracleVisitInfo.FirstOrDefault(m => m.PATIENT_FLOW == item.PATIENT_FLOW) == null)
                        {
                            listData.Add(new OracleEntity.VIEW_PATIENT_ORDERS()
                            {
                                STATE = "0",
                                CTIME = DateTime.Now,
                                PATIENT_FLOW = item.PATIENT_FLOW,
                                RECORD_FLOW = item.RECORD_FLOW,
                                VISIT_CODE = item.VISIT_CODE,
                                STATUS_CODE = item.STATUS_CODE,
                                STATUS_NAME = item.STATUS_NAME,
                                STOP_TIME = item.STOP_TIME,
                                BASE_DOSE = item.BASE_DOSE.ToString(),
                                CHARGES = item.CHARGES,
                                CLASS_CODE = item.CLASS_CODE,
                                CLASS_NAME = item.CLASS_NAME,
                                DOSE_EACH = item.DOSE_EACH.ToString(),
                                DOSE_UNIT = item.DOSE_UNIT,
                                DRUG_SPECS = item.DRUG_SPECS,
                                USAGE_CODE = item.USAGE_CODE,
                                USAGE_NAME = item.USAGE_NAME,
                                VALID_DAYS = item.VALID_DAYS.ToString(),
                                VISIT_FLOW = item.VISIT_FLOW,
                                DEPT_CODE = item.DEPT_CODE,
                                DEPT_NAME = item.DEPT_NAME,
                                DOCTOR_CODE = item.DOCTOR_CODE,
                                DOCTOR_NAME = item.DOCTOR_NAME,
                                EXEC_TIME = item.EXEC_TIME,
                                FREQUENCY_CODE = item.FREQUENCY_CODE,
                                FREQUENCY_NAME = item.FREQUENCY_NAME,
                                GROUP_CODE = item.GROUP_CODE.ToString(),
                                LONG_FLAG = item.LONG_FLAG,
                                ORDER_CODE = item.ORDER_CODE,
                                ORDER_DATE = item.ORDER_DATE,
                                ORDER_MEMO = item.ORDER_MEMO,
                                ORDER_NAME = item.ORDER_NAME,
                                ORDER_NO = item.ORDER_NO,
                                PACK_QTY = item.PACK_QTY.ToString(),
                                QTY_TOT = item.QTY_TOT.ToString()
                            });
                        }

                    }
                    var temp = listData.Skip(num).Take(10000).ToList();
                    if (temp.Count == 0)
                    {
                        break;
                    }
                    //使用默认
                    oracleDbContext.VIEW_PATIENT_ORDERS.AddRange(temp);
                    oracleDbContext.SaveChanges();
                    num += temp.Count;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> MigrationVisitInfo()
        {
            try
            {
                var startTime = DateTime.Today.AddDays(-1).AddHours(0.0);
                var endTime = DateTime.Today.AddHours(0.0).AddMinutes(-1);
                int num = 0;
                var sqlVisitInfo = await sqlServerDbContext.VIEW_PATIENT_VISITINFO.Where(m => Convert.ToDateTime(m.VISIT_DATE) >= startTime && Convert.ToDateTime(m.VISIT_DATE) <= endTime).ToListAsync();
                var oracleVisitInfo = await oracleDbContext.VIEW_PATIENT_VISITINFO.Where(m => Convert.ToDateTime(m.VISIT_DATE) >= startTime && Convert.ToDateTime(m.VISIT_DATE) <= endTime).ToListAsync();
                while (true)
                {
                    List<OracleEntity.VIEW_PATIENT_VISITINFO> listData = new List<OracleEntity.VIEW_PATIENT_VISITINFO>();
                    foreach (var item in sqlVisitInfo)
                    {
                        if (oracleVisitInfo.FirstOrDefault(m=>m.PATIENT_FLOW == item.PATIENT_FLOW) == null)
                        {
                            listData.Add(new OracleEntity.VIEW_PATIENT_VISITINFO()
                            {
                                STATE = "0",
                                TCM_DISEASE_CODE = item.TCM_DISEASE_CODE,
                                TCM_DISEASE_NAME = item.TCM_DISEASE_NAME,
                                TCM_SYND_CODE = item.TCM_SYND_CODE,
                                TCM_SYND_NAME = item.TCM_SYND_NAME,
                                VISIT_CODE = item.VISIT_CODE,
                                VISIT_DATE = item.VISIT_DATE,
                                VISIT_FLOW = item.VISIT_FLOW,
                                CTIME = DateTime.Now,
                                DEPT_CODE = item.DEPT_CODE,
                                DEPT_NAME = item.DEPT_NAME,
                                DIAG_CODE = item.DIAG_CODE,
                                DIAG_NAME = item.DIAG_NAME,
                                DOCTOR_CODE = item.DOCTOR_CODE,
                                DOCTOR_NAME = item.DOCTOR_NAME,
                                IN_TIME = item.IN_TIME,
                                OUT_TIME = item.OUT_TIME,
                                PATIENT_FLOW = item.PATIENT_FLOW,
                                PIX_ID = item.PIX_ID,
                                TYPE = item.TYPE
                            });
                        }
                        
                    }
                    var temp = listData.Skip(num).Take(10000).ToList();
                    if (temp.Count == 0)
                    {
                        break;
                    }
                    //使用默认
                    oracleDbContext.VIEW_PATIENT_VISITINFO.AddRange(temp);
                    oracleDbContext.SaveChanges();
                    num += temp.Count;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public async Task<bool> MigrationExamInfo()
        {
            try
            {
                var startTime = DateTime.Today.AddDays(-1).AddHours(0.0);
                var endTime = DateTime.Today.AddHours(0.0).AddMinutes(-1);
                int num = 0;
                var sqlVisitInfo = await sqlServerDbContext.VIEW_EXAM.Where(m => Convert.ToDateTime(m.REPORT_DATE) >= startTime && Convert.ToDateTime(m.REPORT_DATE) <= endTime).ToListAsync();
                var oracleVisitInfo = await oracleDbContext.VIEW_EXAM.Where(m => Convert.ToDateTime(m.REPORT_DATE) >= startTime && Convert.ToDateTime(m.REPORT_DATE) <= endTime).ToListAsync();
                while (true)
                {
                    List<OracleEntity.VIEW_EXAM> listData = new List<OracleEntity.VIEW_EXAM>();
                    foreach (var item in sqlVisitInfo)
                    {
                        if (oracleVisitInfo.FirstOrDefault(m => m.PATIENT_FLOW == item.PATIENT_FLOW) == null)
                        {
                            listData.Add(new OracleEntity.VIEW_EXAM()
                            {
                                STATE = "0",
                                CTIME = DateTime.Now,
                                PATIENT_FLOW = item.PATIENT_FLOW,
                                RECORD_FLOW = item.RECORD_FLOW,
                                VISIT_CODE = item.VISIT_CODE,
                                POSITION = item.POSITION,
                                REPORT_DESC = item.REPORT_DESC,
                                VISIT_FLOW = item.VISIT_FLOW,
                                DEVICE_TYPE_CODE = item.DEVICE_TYPE_CODE,
                                DEVICE_TYPE_NAME = item.DEVICE_TYPE_NAME,
                                EXAM_IMAGE_NO = item.EXAM_IMAGE_NO,
                                EXAM_REPORT_NO = item.EXAM_REPORT_NO,
                                ITEM_CODE = item.ITEM_CODE,
                                ITEM_NAME = item.ITEM_NAME,
                                PATIENT_NAME = item.PATIENT_NAME,
                                REPORT_DATE = item.REPORT_DATE.ToString("yyyy-MM-dd HH:mm:ss"),
                                REPORT_DIAG = item.REPORT_DIAG,
                                REPORT_REMARK = item.REPORT_REMARK,
                                REPORT_URL = item.REPORT_URL,
                                REQ_DEPT_CODE = item.REQ_DEPT_CODE,
                                REQ_DEPT_NAME = item.REQ_DEPT_NAME,
                                REQ_DOCTOR_CODE = item.REQ_DOCTOR_CODE,
                                REQ_DOCTOR_NAME = item.REQ_DOCTOR_NAME
                            });
                        }

                    }
                    var temp = listData.Skip(num).Take(10000).ToList();
                    if (temp.Count == 0)
                    {
                        break;
                    }
                    //使用默认
                    oracleDbContext.VIEW_EXAM.AddRange(temp);
                    oracleDbContext.SaveChanges();
                    num += temp.Count;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> MigrationOperationInfo()
        {
            try
            {
                var startTime = DateTime.Today.AddDays(-1).AddHours(0.0);
                var endTime = DateTime.Today.AddHours(0.0).AddMinutes(-1);
                int num = 0;
                var mySqlVisitInfo = await mySqlDbContext.VIEW_OPERATION.Where(m => Convert.ToDateTime(m.OPER_DATE) >= startTime && Convert.ToDateTime(m.OPER_DATE) <= endTime).ToListAsync();
                var oracleVisitInfo = await oracleDbContext.VIEW_OPERATION.Where(m => Convert.ToDateTime(m.OPER_DATE) >= startTime && Convert.ToDateTime(m.OPER_DATE) <= endTime).ToListAsync();
                while (true)
                {
                    List<OracleEntity.VIEW_OPERATION> listData = new List<OracleEntity.VIEW_OPERATION>();
                    foreach (var item in mySqlVisitInfo)
                    {
                        if (oracleVisitInfo.FirstOrDefault(m => m.PATIENT_FLOW == item.PATIENT_FLOW) == null)
                        {
                            listData.Add(new OracleEntity.VIEW_OPERATION()
                            {
                                STATE = "0",
                                CTIME = DateTime.Now,
                                PATIENT_FLOW = item.PATIENT_FLOW,
                                RECORD_FLOW = item.RECORD_FLOW,
                                VISIT_CODE = item.VISIT_CODE,
                                SCALE_CODE = item.SCALE_CODE,
                                SCALE_NAME = item.SCALE_NAME,
                                OPER_START_TIME = item.OPER_START_TIME,
                                VISIT_FLOW = item.VISIT_FLOW,
                                BODY_PART_CODE = item.BODY_PART_CODE,
                                BODY_PART_NAME = item.BODY_PART_NAME,
                                DOCTOR_CODE = item.DOCTOR_CODE,
                                DOCTOR_NAME = item.DOCTOR_NAME,
                                GRADE_CODE = item.GRADE_CODE,
                                GRADE_NAME = item.GRADE_NAME,
                                MEMO = item.MEMO,
                                OPER_CODE = item.OPER_CODE,
                                OPER_DATE = item.OPER_DATE,
                                OPER_END_TIME = item.OPER_END_TIME,
                                OPER_NAME = item.OPER_NAME,
                                OPER_NO = item.OPER_NO
                            });
                        }

                    }
                    var temp = listData.Skip(num).Take(10000).ToList();
                    if (temp.Count == 0)
                    {
                        break;
                    }
                    //使用默认
                    oracleDbContext.VIEW_OPERATION.AddRange(temp);
                    oracleDbContext.SaveChanges();
                    num += temp.Count;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> MigrationSignsInfo()
        {
            var startTime = DateTime.Today.AddDays(-1).AddHours(0.0);
            var endTime = DateTime.Today.AddHours(0.0).AddMinutes(-1);
            string appkey = "mYETRYrm";
            string appsecret = "47c83ec28a79e693d30c42a470428eaac9aa5312";
            string url = "http://192.168.16.115:8080/interface-platform-web/api/nursing/patientSign";
            List<RequestMould> requests = new List<RequestMould>();
            try
            {
                int num = 0;
                var baseData = await oracleDbContext.VIEW_PATIENT_BASEINFO.ToArrayAsync();
                var oracleData = await oracleDbContext.VIEW_VITAL_SIGNS2.Where(m=>m.CTIME >= startTime && m.CTIME <= endTime).ToArrayAsync();
                foreach (var item in baseData)
                {
                    var date = Helper.GetTimeStamp(false);
                    string datavalue = @"begintime=" + startTime + "&" + "endtime=" + endTime + "&"
                        + "rycs=" + item.RYCS + "&" + "timestamp=" + date + "&" + "zyh=" + item.VISIT_CODE + appsecret;
                    var mdtvalue = Helper.Md5Func(datavalue);
                    string datavalue2 = @"appkey=" + appkey + "&" + "rycs=" + $"{item.RYCS}" + "&"
                        + "begintime=" + startTime + "&" + "endtime=" + endTime + "&" + "zyh=" + $"{item.VISIT_CODE}" + "&"
                        + "timestamp=" + $"{date}" + "&" + "sign=" + $"{mdtvalue}";
                    string httpurl = url + "?" + datavalue2;
                    var result = Helper.HttpGet(httpurl);
                    var data = JsonConvert.DeserializeObject<ResultMould>(result);
                    if (data.code == 200)
                    {
                        if (data.data.Count() > 0)
                        {
                            foreach (var requestData in data.data)
                            {
                                if (oracleData.Where(m => m.BIZID == requestData.bizid).Count() == 0)
                                {
                                    requests.AddRange(data.data);
                                }
                            }
                            //dataGridView1.Rows.Add(requests);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                List<OracleEntity.VIEW_VITAL_SIGNS2> info = new List<OracleEntity.VIEW_VITAL_SIGNS2>();
                foreach (var item in requests)
                {

                    var oracleEntity = new OracleEntity.VIEW_VITAL_SIGNS2()
                    {
                        STATE = "0",
                        CTIME = DateTime.Now,
                        SYSTOLICPRESSURE = item.systolicpressure,
                        BOWELS = item.bowels,
                        CONSCIOUSNESS = item.consciousness,
                        DIASTOLICPRESSURE = item.diastolicpressure,
                        PERCENTAGEOFOXYGENSATURATION = item.percentageofoxygensaturation,
                        PULSERATE = item.pulserate,
                        VISITID = item.visitid,
                        BIZID = item.bizid,
                        BODYTEMPERATURE = item.bodytemperature,
                        BREATHRATE = item.breathrate,
                        FULLNAME = item.fullname,
                        HEARTRATE = item.heartrate,
                        HEIGHT = item.height,
                        INWATER = item.inwater,
                        OUTWATER = item.outwater,
                        PATIENTID = item.patientid,
                        PEE = item.pee,
                        RECORDCODE = item.recordcode,
                        RECORDNAME = item.recordname,
                        RECORDTIME = item.recordtime,
                        TEMPERATURETYPE = item.temperaturetype,
                        WEIGHT = item.weight,
                    };
                    info.Add(oracleEntity);
                }

                while (true)
                {

                    var temp = info.Skip(num).Take(10000).ToList();
                    if (temp.Count == 0)
                    {
                        break;
                    }
                    //使用默认
                    oracleDbContext.VIEW_VITAL_SIGNS2.AddRange(temp);

                    oracleDbContext.SaveChanges();
                    num += temp.Count;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
