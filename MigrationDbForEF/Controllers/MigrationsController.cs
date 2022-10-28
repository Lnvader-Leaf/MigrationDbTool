using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MigrationDbForEF.EfDbContext;
using MigrationDbForEF.SqlServerEntity;
using MigrationDbForEF.OracleEntity;
using MigrationDbForEF.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AutoMapper;
using MigrationDbForEF.Mould;
using MigrationDbForEF.IRespositoryConfig;
using MigrationDbForEF.ToolHelper;
using System.Configuration;

namespace MigrationDbForEF.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MigrationsController : ControllerBase
    {
        private readonly OracleDbContext oracleDb;
        private readonly SqlServerDbContext sqlContext;
        private readonly MySqlDbContext mySqlDbContext;
        private readonly IMapper mapper;
        private readonly IEFMigrationServices eFMigration;
        private readonly IRespository_Wrapper respository_Wrapper;
        readonly Log log = new Log();

        public IConfiguration Configuration { get; }

        public MigrationsController(OracleDbContext oracleDb, SqlServerDbContext SqlContext, MySqlDbContext mySqlDbContext, IConfiguration configuration, IMapper mapper, IEFMigrationServices eFMigration, IRespository_Wrapper respository_Wrapper)
        {
            this.oracleDb = oracleDb;
            this.sqlContext = SqlContext;
            this.mySqlDbContext = mySqlDbContext;
            Configuration = configuration;
            this.mapper = mapper;
            this.eFMigration = eFMigration;
            this.respository_Wrapper = respository_Wrapper;
        }
        [HttpGet]
        public async Task<ActionResult<ResponseMould>> TestOracleConnection()
        {
            ResponseMould response = new ResponseMould();

            try
            {
                var data = oracleDb.VIEW_VITAL_SIGNS2.AsEnumerable();
                var data2 = sqlContext.VIEW_VITAL_SIGNS.AsEnumerable();
                response.code = 200;

                return response;
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg += ex.Message + ex.InnerException + ex.Source;
                return response;
            }
        }
        [HttpGet]
        public ActionResult<ResponseMould> TestSqlDbConnection()
        {
            ResponseMould response = new ResponseMould();

            try
            {
                var str1 = Configuration.GetConnectionString("OracleConnectionString");
                var str2 = Configuration.GetConnectionString("SqlServerConnectionString");
                var dae = sqlContext.VIEW_LAB.ToArrayAsync();
                response.code = 200;
                response.msg = "连接成功";
                return response;
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message + ex.InnerException + ex.Source;
                return response;
            }

        }


        [HttpPost]
        public async Task<ActionResult<ResponseMould>> InsertBaseInfo()
        {
            ResponseMould response = new ResponseMould();
            try
            {
                int num = 0;
                var oracleData = await oracleDb.VIEW_PATIENT_BASEINFO.ToListAsync();
                var sqlData = await sqlContext.VIEW_PATIENT_BASEINFO.ToListAsync();
                List<OracleEntity.VIEW_PATIENT_BASEINFO> info = new List<OracleEntity.VIEW_PATIENT_BASEINFO>();
                foreach (var item in sqlData)
                {
                    if (oracleData.FirstOrDefault(m => m.PATIENT_FLOW == item.PATIENT_FLOW) == null)
                    {
                        var oracleBaseInfoEntity = new OracleEntity.VIEW_PATIENT_BASEINFO()
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
                        };
                        info.Add(oracleBaseInfoEntity);
                    }
                }
                while (true)
                {
                    var temp = info.Skip(num).Take(10000).ToList();
                    if (temp.Count == 0)
                    {
                        break;
                    }
                    //使用默认
                    oracleDb.VIEW_PATIENT_BASEINFO.AddRange(temp);
                    oracleDb.SaveChanges();
                    num += temp.Count;
                }
                response.code = 200;
                response.msg = "批量插入成功";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;
            }
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMould>> InsertDiag()
        {
            ResponseMould response = new ResponseMould();
            try
            {

                int num = 0;
                var oracleData = await oracleDb.VIEW_PATIENT_DIAG.ToListAsync();
                var sqlData = await sqlContext.VIEW_PATIENT_DIAG.ToListAsync();
                List<OracleEntity.VIEW_PATIENT_DIAG> info = new List<OracleEntity.VIEW_PATIENT_DIAG>();
                foreach (var item in sqlData)
                {
                    if (oracleData.FirstOrDefault(m => m.PATIENT_FLOW == item.PATIENT_FLOW) == null)
                    {
                        var oracleDiagEntity = new OracleEntity.VIEW_PATIENT_DIAG()
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
                        };
                        info.Add(oracleDiagEntity);
                    }
                }
                while (true)
                {
                    var temp = info.Skip(num).Take(10000).ToList();
                    if (temp.Count == 0)
                    {
                        break;
                    }
                    //使用默认
                    oracleDb.VIEW_PATIENT_DIAG.AddRange(temp);
                    oracleDb.SaveChanges();
                    num += temp.Count;
                }
                response.code = 200;
                response.msg = "批量插入成功";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message + ex.InnerException;
            }
            return response;
        }


        [HttpPost]
        public async Task<ActionResult<ResponseMould>> InsertVisitInfo()
        {
            ResponseMould response = new ResponseMould();
            try
            {

                int num = 0;
                var oracleData = await oracleDb.VIEW_PATIENT_VISITINFO.ToListAsync();
                var sqlData = await sqlContext.VIEW_PATIENT_VISITINFO.ToListAsync();
                List<OracleEntity.VIEW_PATIENT_VISITINFO> info = new List<OracleEntity.VIEW_PATIENT_VISITINFO>();
                foreach (var item in sqlData)
                {
                    var data = oracleData.FirstOrDefault(m => m.PATIENT_FLOW == item.PATIENT_FLOW);
                    if (data == null)
                    {
                        var oracleEntity = new OracleEntity.VIEW_PATIENT_VISITINFO()
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
                        };
                        info.Add(oracleEntity);
                    }
                }

                while (true)
                {

                    var temp = info.Skip(num).Take(10000).ToList();
                    if (temp.Count == 0)
                    {
                        break;
                    }
                    //使用默认
                    oracleDb.VIEW_PATIENT_VISITINFO.AddRange(temp);
                    oracleDb.SaveChanges();
                    num += temp.Count;
                }
                response.code = 200;
                response.msg = "批量插入成功";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message + ex.InnerException;
            }
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMould>> InsertLabInfo()
        {
            ResponseMould response = new ResponseMould();
            try
            {

                int num = 0;
                var oracleData = await oracleDb.VIEW_LAB.ToListAsync();
                var sqlData = await sqlContext.VIEW_LAB.ToListAsync();
                List<OracleEntity.VIEW_LAB> info = new List<OracleEntity.VIEW_LAB>();
                foreach (var item in sqlData)
                {
                    var data = oracleData.FirstOrDefault(m => m.RECORD_FLOW == item.RECORD_FLOW);
                    if (data == null)
                    {
                        var oracleEntity = new OracleEntity.VIEW_LAB()
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
                        };
                        info.Add(oracleEntity);
                    }
                }

                while (true)
                {

                    var temp = info.Skip(num).Take(10000).ToList();
                    if (temp.Count == 0)
                    {
                        break;
                    }
                    //使用默认
                    oracleDb.VIEW_LAB.AddRange(temp);
                    oracleDb.SaveChanges();
                    num += temp.Count;
                }
                response.code = 200;
                response.msg = "批量插入成功";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message + ex.InnerException;
            }
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMould>> InsertLabItemInfo()
        {
            ResponseMould response = new ResponseMould();
            try
            {
                int num = 0;
                var oracleData = await oracleDb.VIEW_LAB_ITEM.ToListAsync();
                var sqlData = await sqlContext.VIEW_LAB_ITEM.ToListAsync();
                List<OracleEntity.VIEW_LAB_ITEM> info = new List<OracleEntity.VIEW_LAB_ITEM>();
                foreach (var item in sqlData)
                {
                    var data = oracleData.FirstOrDefault(m => m.RECORD_FLOW == item.RECORD_FLOW);
                    if (data == null)
                    {
                        var oracleEntity = new OracleEntity.VIEW_LAB_ITEM()
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
                        };
                        info.Add(oracleEntity);
                    }
                }

                while (true)
                {

                    var temp = info.Skip(num).Take(10000).ToList();
                    if (temp.Count == 0)
                    {
                        break;
                    }
                    //使用默认
                    oracleDb.VIEW_LAB_ITEM.AddRange(temp);

                    oracleDb.SaveChanges();
                    num += temp.Count;
                }
                response.code = 200;
                response.msg = "批量插入成功";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message + ex.InnerException;
            }
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMould>> InsertExamInfo()
        {
            ResponseMould response = new ResponseMould();
            try
            {
                int num = 0;
                var oracleData = await oracleDb.VIEW_EXAM.ToListAsync();
                var sqlData = await sqlContext.VIEW_EXAM.ToListAsync();
                List<OracleEntity.VIEW_EXAM> info = new List<OracleEntity.VIEW_EXAM>();
                foreach (var item in sqlData)
                {
                    var data = oracleData.FirstOrDefault(m => m.RECORD_FLOW == item.RECORD_FLOW);
                    if (data == null)
                    {
                        var oracleEntity = new OracleEntity.VIEW_EXAM()
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
                        };
                        info.Add(oracleEntity);
                    }
                }

                while (true)
                {

                    var temp = info.Skip(num).Take(10000).ToList();
                    if (temp.Count == 0)
                    {
                        break;
                    }
                    //使用默认
                    oracleDb.VIEW_EXAM.AddRange(temp);

                    oracleDb.SaveChanges();
                    num += temp.Count;
                }
                response.code = 200;
                response.msg = "批量插入成功";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message + ex.InnerException;
            }
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMould>> InsertOperationInfo()
        {
            ResponseMould response = new ResponseMould();
            try
            {
                int num = 0;
                var oracleData = await oracleDb.VIEW_OPERATION.ToListAsync();
                var mysqData = await mySqlDbContext.VIEW_OPERATION.ToListAsync();
                List<OracleEntity.VIEW_OPERATION> info = new List<OracleEntity.VIEW_OPERATION>();
                foreach (var item in mysqData)
                {
                    var data = oracleData.FirstOrDefault(m => m.RECORD_FLOW == item.RECORD_FLOW);
                    if (data == null)
                    {
                        var oracleEntity = new OracleEntity.VIEW_OPERATION()
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
                        };
                        info.Add(oracleEntity);
                    }
                }

                while (true)
                {

                    var temp = info.Skip(num).Take(10000).ToList();
                    if (temp.Count == 0)
                    {
                        break;
                    }
                    //使用默认
                    oracleDb.VIEW_OPERATION.AddRange(temp);

                    oracleDb.SaveChanges();
                    num += temp.Count;
                }
                response.code = 200;
                response.msg = "批量插入成功";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message + ex.InnerException;
            }
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMould>> InsertOrdersInfo()
        {
            ResponseMould response = new ResponseMould();
            try
            {
                int num = 0;
                int num2 = 2220000;
                var oracleData = oracleDb.VIEW_PATIENT_ORDERS.AsEnumerable();
                var sqlData = sqlContext.VIEW_PATIENT_ORDERS.AsEnumerable();

                while (true)
                {
                    var sqlDto = sqlData.Skip(num2).Take(10000);
                    if (sqlData.Count() == 0)
                    {
                        break;
                    }
                    List<OracleEntity.VIEW_PATIENT_ORDERS> info = new List<OracleEntity.VIEW_PATIENT_ORDERS>();
                    foreach (var item in sqlDto)
                    {
                        //var data = oracleData.FirstOrDefault(m => m.RECORD_FLOW == item.RECORD_FLOW);
                        //if (data == null)
                        //{
                        var oracleEntity = new OracleEntity.VIEW_PATIENT_ORDERS()
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
                        };
                        info.Add(oracleEntity);
                        //}
                    }

                    oracleDb.VIEW_PATIENT_ORDERS.AddRange(info);

                    oracleDb.SaveChanges();


                    num2 += info.Count;
                }

                response.code = 200;
                response.msg = "批量插入成功";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message + ex.InnerException;
            }
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMould>> InsertSignsInfo()
        {
            Log_Read_Data LogMould = new Log_Read_Data();
            ResponseMould response = new ResponseMould();
            string appkey = "mYETRYrm";
            string appsecret = "47c83ec28a79e693d30c42a470428eaac9aa5312";
            string url = "http://192.168.16.115:8080/interface-platform-web/api/nursing/patientSign";
            List<RequestMould> requests = new List<RequestMould>();
            try
            {
                int num = 0;
                var baseData = await oracleDb.VIEW_PATIENT_BASEINFO.ToArrayAsync();
                var oracleData = await oracleDb.VIEW_VITAL_SIGNS2.ToArrayAsync();
                foreach (var item in baseData)
                {
                    var date = Helper.GetTimeStamp(false);
                    string datavalue = @"rycs=" + item.RYCS + "&" + "timestamp=" + date + "&" + "zyh=" + item.VISIT_CODE + appsecret;
                    var mdtvalue = Helper.Md5Func(datavalue);
                    string datavalue2 = @"appkey=" + appkey + "&" + "rycs=" + $"{item.RYCS}" + "&"
                        + "zyh=" + $"{item.VISIT_CODE}" + "&"
                        + "timestamp=" + $"{date}" + "&" + "sign=" + $"{mdtvalue}";
                    string httpurl = url + "?" + datavalue2;
                    var result = Helper.HttpGet(httpurl);
                    var data = JsonConvert.DeserializeObject<ResultMould>(result);

                    if (data.code == 200)
                    {
                        LogMould.In_parameter = httpurl;
                        LogMould.Out_parameter = result;
                        LogMould.MethodName = "InsertSignsInfo";

                        log.SaveInterfaceLog(JsonConvert.SerializeObject(LogMould));
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
                        LogMould.In_parameter = httpurl;
                        LogMould.Out_parameter = result;
                        LogMould.MethodName = "InsertSignsInfo";

                        log.SaveLog(JsonConvert.SerializeObject(LogMould));

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
                    oracleDb.VIEW_VITAL_SIGNS2.AddRange(temp);

                    oracleDb.SaveChanges();
                    num += temp.Count;
                }
                response.code = 200;
                response.msg = "批量插入成功";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message + ex.InnerException;
                return Ok(response);
            }

        }

        [HttpGet]
        public async Task<string> TimerMigration()
        {
            try
            {

                eFMigration.MigrationBaseInfo();
                eFMigration.MigrationDiagInfo();
                eFMigration.MigrationVisitInfo();
                eFMigration.MigrationLabInfo();
                eFMigration.MigrationLabItemInfo();
                eFMigration.MigrationExamInfo();
                eFMigration.MigrationOperationInfo();
                eFMigration.MigrationSignsInfo();
                eFMigration.MigrationOrdersInfo();
                return "成功";
            }
            catch (Exception ex)
            {
                return "失败";
            }
        }
    }
}
