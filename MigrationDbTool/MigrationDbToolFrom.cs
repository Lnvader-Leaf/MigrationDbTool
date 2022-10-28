using DevExpress.Utils;
using DevExpress.XtraWaitForm;
using MigrationDbTool.Entity;
using MigrationDbTool.Helper;
using MigrationDbTool.Services;
using Newtonsoft.Json;
using PubLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MigrationDbTool
{
    public partial class MigrationDbToolFrom : Form
    {
        WaitDialogForm wForm = null;
        public string oracleUrl { get; set; }
        public string sqlserverUrl { get; set; }

        SaveData saveData = new SaveData();
        public MigrationDbToolFrom()
        {
            InitializeComponent();
        }

        public void setTaskAtFixedTime()
        {
            DateTime now = DateTime.Now;
            DateTime oneOClock = DateTime.Today.AddHours(1.0);
            if (now > oneOClock)
            {
                oneOClock = oneOClock.AddDays(1.0);
            }
            int msUntilFour = (int)((oneOClock - now).TotalMilliseconds);

            var t = new System.Threading.Timer(doAt1AM);
            t.Change(msUntilFour, Timeout.Infinite);
        }
        public void Contrast_VIEW_PATIENT_BASEINFO()
        {
            wForm = new WaitDialogForm("正在对比并插入数据...");
            try
            {
                if (wForm.IsDisposed)
                {
                    wForm.Show();
                }
                List<VIEW_PATIENT_BASEINFO> listView = new List<VIEW_PATIENT_BASEINFO>();
                foreach (var item in saveData.VIEW_PATIENT_BASEINFO_2)
                {
                    var dataDto = saveData.VIEW_PATIENT_BASEINFO_1.Find(m => m.PATIENT_FLOW == item.PATIENT_FLOW);
                    if (dataDto == null)
                    {
                        listView.Add(item);
                    }
                }

                textBox2.AppendText("对比查出" + listView.Count() + "行数据" + "\r\n");

                uDataSet mDs = new uDataSet(new string[] { "select * from view_patient_baseinfo t where 1 = 2" }, new uParameter[] { }, oracleUrl);
                textBox2.AppendText("已查出" + "\r\n");
                foreach (var item in listView)
                {
                    var currentRow = mDs.InsertRow();
                    mDs.SetItem(currentRow, "ADDRESS", item.ADDRESS);
                    mDs.SetItem(currentRow, "AGE", item.AGE.ToString());
                    mDs.SetItem(currentRow, "AUT_CREATE_TIME", item.AUT_CREATE_TIME);
                    mDs.SetItem(currentRow, "BIRTHDAY", item.BIRTHDAY);
                    mDs.SetItem(currentRow, "CITY", item.CITY);
                    mDs.SetItem(currentRow, "COUNTY", item.COUNTY);
                    mDs.SetItem(currentRow, "ctime", item.CTIME.ToString() == null ? DateTime.Now.ToString("yyyy-MM-dd HH:mm-ss") : item.CTIME.ToString());
                    mDs.SetItem(currentRow, "HEIGHT", item.HEIGHT.ToString());
                    mDs.SetItem(currentRow, "ID_CARD", item.ID_CARD);
                    mDs.SetItem(currentRow, "MARITAL", item.MARITAL);
                    mDs.SetItem(currentRow, "NAME", item.NAME);
                    mDs.SetItem(currentRow, "NATION", item.NATION);
                    mDs.SetItem(currentRow, "PATIENT_FLOW", item.PATIENT_FLOW);
                    mDs.SetItem(currentRow, "PHONE", item.PHONE);
                    mDs.SetItem(currentRow, "PIX_ID", item.PIX_ID);
                    mDs.SetItem(currentRow, "PROF", item.PROF);
                    mDs.SetItem(currentRow, "PROVINCE", item.PROVINCE);
                    mDs.SetItem(currentRow, "REL_NAME", item.REL_NAME);
                    mDs.SetItem(currentRow, "REL_PHONE", item.REL_PHONE);
                    mDs.SetItem(currentRow, "REL_TYPE", item.REL_TYPE);
                    mDs.SetItem(currentRow, "rycs", item.rycs.ToString());
                    mDs.SetItem(currentRow, "SEX", item.SEX);
                    mDs.SetItem(currentRow, "STATE", item.STATE);
                    mDs.SetItem(currentRow, "VISIT_CODE", item.visit_code == null ? "" : item.visit_code);
                    mDs.SetItem(currentRow, "WEIGHT", item.WEIGHT.ToString());
                    mDs.Update(oracleUrl);
                }
                if (!wForm.IsDisposed)
                {
                    wForm.Dispose();
                }
                textBox2.AppendText("执行成功；" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
                setTaskAtFixedTime();
                textBox2.AppendText("执行成功；" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
            }
            catch (Exception ex)
            {
                if (!wForm.IsDisposed)
                {
                    wForm.Dispose();
                }
                textBox2.AppendText(ex.Message + ex.InnerException + ex.Source + "\r\n");
            }
        }
        public void doAt1AM(object state)
        {
            try
            {
                List<VIEW_PATIENT_BASEINFO> listView = new List<VIEW_PATIENT_BASEINFO>();
                string startTime = DateTime.Today.AddDays(-1).AddHours(0.0).AddSeconds(0.0).ToString("yyyy-MM-dd HH:mm:ss");
                string endTime = DateTime.Today.AddHours(0.0).AddSeconds(0.0).ToString("yyyy-MM-dd HH:mm:ss");
                string strSql = "select * from VIEW_PATIENT_BASEINFO where AUT_CREATE_TIME >= " + startTime + "and AUT_CREATE_TIME <=" + endTime;
                string strSql2 = "select * from VIEW_PATIENT_BASEINFO";
                uDataSet uDataSet1 = new uDataSet(new string[] { strSql2 }, new uParameter[] { }, oracleUrl);
                uDataSet uDataSet2 = new uDataSet(new string[] { strSql }, new uParameter[] { }, sqlserverUrl);
                var dataJson1 = DataHelper.ToJson(uDataSet1.Tables[0]);
                var dataJson2 = DataHelper.ToJson(uDataSet2.Tables[0]);
                saveData.VIEW_PATIENT_BASEINFO_1 = JsonConvert.DeserializeObject<List<VIEW_PATIENT_BASEINFO>>(dataJson1);
                saveData.VIEW_PATIENT_BASEINFO_2 = JsonConvert.DeserializeObject<List<VIEW_PATIENT_BASEINFO>>(dataJson2);
                Thread th = new Thread(Contrast_VIEW_PATIENT_BASEINFO);
                th.Start();
            }
            catch (Exception ex)
            {
                textBox2.AppendText(ex.Message);
            }

        }
        private void ConnectTest_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = textBox1.Text;
                conn.Open();
                MessageBox.Show("连接成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setTaskAtFixedTime();
            textBox2.AppendText("初始化成功" + "\r\n");
        }

        private void btn_migrationAll_Click(object sender, EventArgs e)
        {
            textBox2.AppendText(oracleUrl + "\r\n" + sqlserverUrl);
            List<VIEW_PATIENT_BASEINFO> listView = new List<VIEW_PATIENT_BASEINFO>();
            string strSql = "select * from VIEW_PATIENT_BASEINFO";
            uDataSet uDataSet1 = new uDataSet(new string[] { strSql }, new uParameter[] { }, oracleUrl);
            textBox2.AppendText("Oracle查询成功，共" + uDataSet1.RowCount() + "条数据" + "\r\n");
            uDataSet uDataSet2 = new uDataSet(new string[] { strSql }, new uParameter[] { }, sqlserverUrl);
            textBox2.AppendText("Sqlserver查询成功，共" + uDataSet2.RowCount() + "条数据" + "\r\n");
            var dataJson1 = DataHelper.ToJson(uDataSet1.Tables[0]);
            textBox2.AppendText("OracleToJson成功" + "\r\n");
            var dataJson2 = DataHelper.ToJson(uDataSet2.Tables[0]);
            textBox2.AppendText("SqlserverToJson成功" + "\r\n");
            saveData.VIEW_PATIENT_BASEINFO_1 = JsonConvert.DeserializeObject<List<VIEW_PATIENT_BASEINFO>>(dataJson1);
            textBox2.AppendText("OracleToEntity成功" + "\r\n");
            saveData.VIEW_PATIENT_BASEINFO_2 = JsonConvert.DeserializeObject<List<VIEW_PATIENT_BASEINFO>>(dataJson2);
            textBox2.AppendText("SqlserverToEntity成功" + "\r\n");
            Thread th = new Thread(Contrast_VIEW_PATIENT_BASEINFO);
            th.Start();
        }

        public void Contrast_VIEW_PATIENT_VISITINFO()
        {
            wForm = new WaitDialogForm("正在对比并插入数据...");
            try
            {

                if (wForm.IsDisposed)
                {
                    wForm.Show();
                }


                List<VIEW_PATIENT_VISITINFO> listView = new List<VIEW_PATIENT_VISITINFO>();
                foreach (var item in saveData.VIEW_PATIENT_VISITINFO_2)
                {
                    var dataDto = saveData.VIEW_PATIENT_VISITINFO_1.Find(m => m.VISIT_FLOW == item.VISIT_FLOW);
                    if (dataDto == null)
                    {
                        listView.Add(item);
                    }
                }

                textBox3.AppendText("对比查出" + listView.Count() + "行数据" + "\r\n");
                uDataSet mDs = new uDataSet(new string[] { "select * from VIEW_PATIENT_VISITINFO where 1 = 2" }, new uParameter[] { }, oracleUrl);
                foreach (var item in listView)
                {
                    var currentRow = mDs.InsertRow();
                    mDs.SetItem(currentRow, "ctime", item.CTIME.ToString() == null ? DateTime.Now.ToString("yyyy-MM-dd HH:mm-ss") : item.CTIME.ToString());
                    mDs.SetItem(currentRow, "DEPT_CODE", item.DEPT_CODE);
                    mDs.SetItem(currentRow, "DEPT_NAME", item.DEPT_NAME);
                    mDs.SetItem(currentRow, "DIAG_CODE", item.DIAG_CODE);
                    mDs.SetItem(currentRow, "DIAG_NAME", item.DIAG_NAME);
                    mDs.SetItem(currentRow, "DOCTOR_CODE", item.DOCTOR_CODE);
                    mDs.SetItem(currentRow, "DOCTOR_NAME", item.DOCTOR_NAME);
                    mDs.SetItem(currentRow, "IN_TIME", item.IN_TIME);
                    mDs.SetItem(currentRow, "OUT_TIME", item.OUT_TIME);
                    mDs.SetItem(currentRow, "PATIENT_FLOW", item.PATIENT_FLOW);
                    mDs.SetItem(currentRow, "PIX_ID", item.PIX_ID);
                    mDs.SetItem(currentRow, "state", item.STATE);
                    mDs.SetItem(currentRow, "TCM_DISEASE_CODE", item.TCM_DISEASE_CODE);
                    mDs.SetItem(currentRow, "TCM_DISEASE_NAME", item.TCM_DISEASE_NAME);
                    mDs.SetItem(currentRow, "TCM_SYND_CODE", item.TCM_SYND_CODE);
                    mDs.SetItem(currentRow, "TCM_SYND_NAME", item.TCM_SYND_NAME);
                    mDs.SetItem(currentRow, "TYPE", item.TYPE.ToString() == null ? "1" : item.TYPE.ToString());
                    mDs.SetItem(currentRow, "VISIT_CODE", item.VISIT_CODE);
                    mDs.SetItem(currentRow, "VISIT_DATE", item.VISIT_DATE);
                    mDs.SetItem(currentRow, "VISIT_FLOW", item.VISIT_FLOW);
                    mDs.Update(oracleUrl);
                }
                if (!wForm.IsDisposed)
                {
                    wForm.Dispose();
                }
                setTaskAtFixedTime();
                textBox3.AppendText("执行成功；" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
            }
            catch (Exception ex)
            {
                if (!wForm.IsDisposed)
                {
                    wForm.Dispose();
                }
                textBox3.AppendText(ex.Message + ex.InnerException);
            }

        }
        private void btn_magrationAll2_Click(object sender, EventArgs e)
        {
            textBox3.AppendText(oracleUrl + "\r\n" + sqlserverUrl);
            List<VIEW_PATIENT_VISITINFO> listView = new List<VIEW_PATIENT_VISITINFO>();
            string strSql = "select * from VIEW_PATIENT_VISITINFO";
            uDataSet uDataSet1 = new uDataSet(new string[] { strSql }, new uParameter[] { }, oracleUrl);
            textBox3.AppendText("Oracle查询成功，共" + uDataSet1.RowCount() + "条数据" + "\r\n");
            uDataSet uDataSet2 = new uDataSet(new string[] { strSql }, new uParameter[] { }, sqlserverUrl);
            textBox3.AppendText("Sqlserver查询成功，共" + uDataSet2.RowCount() + "条数据" + "\r\n");
            var dataJson1 = DataHelper.ToJson(uDataSet1.Tables[0]);
            textBox3.AppendText("OracleToJson成功" + "\r\n");
            var dataJson2 = DataHelper.ToJson(uDataSet2.Tables[0]);
            textBox3.AppendText("SqlserverToJson成功" + "\r\n");
            saveData.VIEW_PATIENT_VISITINFO_1 = JsonConvert.DeserializeObject<List<VIEW_PATIENT_VISITINFO>>(dataJson1);
            textBox3.AppendText("OracleToEntity成功" + "\r\n");
            saveData.VIEW_PATIENT_VISITINFO_2 = JsonConvert.DeserializeObject<List<VIEW_PATIENT_VISITINFO>>(dataJson2);
            textBox3.AppendText("SqlserverToEntity成功" + "\r\n");
            Thread th = new Thread(Contrast_VIEW_PATIENT_VISITINFO);
            th.Start();

        }

        private void btn_migrationtimer2_Click(object sender, EventArgs e)
        {
            setTaskAtFixedTime2();
            textBox3.AppendText("初始化成功" + "\r\n");
        }


        public void setTaskAtFixedTime2()
        {
            DateTime now = DateTime.Now;
            DateTime oneOClock = DateTime.Today.AddHours(1.0);
            if (now > oneOClock)
            {
                oneOClock = oneOClock.AddDays(1.0);
            }
            int msUntilFour = (int)((oneOClock - now).TotalMilliseconds);

            var t = new System.Threading.Timer(doAt1AM2);
            t.Change(msUntilFour, Timeout.Infinite);
        }

        public void doAt1AM2(object state)
        {
            try
            {
                textBox3.AppendText("开始执行；" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
                List<VIEW_PATIENT_VISITINFO> listView = new List<VIEW_PATIENT_VISITINFO>();
                string startTime = DateTime.Today.AddDays(-1).AddHours(0.0).AddSeconds(0.0).ToString("yyyy-MM-dd HH:mm:ss");
                string endTime = DateTime.Today.AddHours(0.0).AddSeconds(0.0).ToString("yyyy-MM-dd HH:mm:ss");
                string strSql = "select * from VIEW_PATIENT_VISITINFO where VISIT_DATE >= " + startTime + "and VISIT_DATE <=" + endTime;
                string strSql2 = "select * from VIEW_PATIENT_VISITINFO";
                uDataSet uDataSet1 = new uDataSet(new string[] { strSql2 }, new uParameter[] { }, oracleUrl);
                uDataSet uDataSet2 = new uDataSet(new string[] { strSql }, new uParameter[] { }, sqlserverUrl);
                var dataJson1 = DataHelper.ToJson(uDataSet1.Tables[0]);
                var dataJson2 = DataHelper.ToJson(uDataSet2.Tables[0]);
                saveData.VIEW_PATIENT_VISITINFO_1 = JsonConvert.DeserializeObject<List<VIEW_PATIENT_VISITINFO>>(dataJson1);
                saveData.VIEW_PATIENT_VISITINFO_2 = JsonConvert.DeserializeObject<List<VIEW_PATIENT_VISITINFO>>(dataJson2);
                Thread th = new Thread(Contrast_VIEW_PATIENT_VISITINFO);
                th.Start();
            }
            catch (Exception ex)
            {
                textBox3.AppendText(ex.Message);
            }

        }


        private void btn_magrationAll3_Click(object sender, EventArgs e)
        {
            textBox4.AppendText(oracleUrl + "\r\n" + sqlserverUrl);
            string startTime = DateTime.Today.AddDays(-1).AddHours(0.0).AddSeconds(0.0).ToString("yyyy-MM-dd HH:mm:ss");
            string endTime = DateTime.Today.AddHours(0.0).AddSeconds(0.0).ToString("yyyy-MM-dd HH:mm:ss");
            string strSql = "select * from VIEW_PATIENT_ORDERS where ORDER_DATE >= " + startTime + "and ORDER_DATE <=" + endTime;
            uDataSet uDataSet1 = new uDataSet(new string[] { strSql }, new uParameter[] { }, sqlserverUrl);
            textBox4.AppendText("Sqlserver查询成功，共" + uDataSet1.RowCount() + "条数据" + "\r\n");
            var dataJson1 = DataHelper.ToJson(uDataSet1.Tables[0]);
            textBox4.AppendText("SqlserverToJson成功" + "\r\n");
            var dataMoulds1 = JsonConvert.DeserializeObject<List<VIEW_PATIENT_ORDERS>>(dataJson1);
            textBox4.AppendText("SqlserverToEntity成功" + "\r\n");

            uDataSet mDs = new uDataSet(new string[] { "select * from VIEW_PATIENT_ORDERS where 1 = 2" }, new uParameter[] { }, oracleUrl);
            foreach (var item in dataMoulds1)
            {
                var currentRow = mDs.InsertRow();
                mDs.SetItem(currentRow, "BASE_DOSE", item.BASE_DOSE);
                mDs.SetItem(currentRow, "CHARGES", item.CHARGES.ToString());
                mDs.SetItem(currentRow, "CLASS_CODE", item.CLASS_CODE);
                mDs.SetItem(currentRow, "CLASS_NAME", item.CLASS_NAME);
                mDs.SetItem(currentRow, "ctime", item.ctime.ToString());
                mDs.SetItem(currentRow, "DEPT_CODE", item.DEPT_CODE);
                mDs.SetItem(currentRow, "DEPT_NAME", item.DEPT_NAME);
                mDs.SetItem(currentRow, "DOCTOR_CODE", item.DOCTOR_CODE);
                mDs.SetItem(currentRow, "DOCTOR_NAME", item.DOCTOR_NAME);
                mDs.SetItem(currentRow, "DOSE_EACH", item.DOSE_EACH);
                mDs.SetItem(currentRow, "DOSE_UNIT", item.DOSE_UNIT);
                mDs.SetItem(currentRow, "DRUG_SPECS", item.DRUG_SPECS);
                mDs.SetItem(currentRow, "EXEC_TIME", item.EXEC_TIME);
                mDs.SetItem(currentRow, "FREQUENCY_CODE", item.FREQUENCY_CODE);
                mDs.SetItem(currentRow, "FREQUENCY_NAME", item.FREQUENCY_NAME);
                mDs.SetItem(currentRow, "GROUP_CODE", item.GROUP_CODE);
                mDs.SetItem(currentRow, "LONG_FLAG", item.LONG_FLAG);
                mDs.SetItem(currentRow, "ORDER_CODE", item.ORDER_CODE);
                mDs.SetItem(currentRow, "ORDER_DATE", item.ORDER_DATE);
                mDs.SetItem(currentRow, "ORDER_MEMO", item.ORDER_MEMO);
                mDs.SetItem(currentRow, "ORDER_NAME", item.ORDER_NAME);
                mDs.SetItem(currentRow, "ORDER_NO", item.ORDER_NO);
                mDs.SetItem(currentRow, "PACK_QTY", item.PACK_QTY);
                mDs.SetItem(currentRow, "PATIENT_FLOW", item.PATIENT_FLOW);
                mDs.SetItem(currentRow, "QTY_TOT", item.QTY_TOT);
                mDs.SetItem(currentRow, "RECORD_FLOW", item.RECORD_FLOW);
                mDs.SetItem(currentRow, "state", item.state);
                mDs.SetItem(currentRow, "STATUS_CODE", item.STATUS_CODE);
                mDs.SetItem(currentRow, "STATUS_NAME", item.STATUS_NAME);
                mDs.SetItem(currentRow, "STOP_TIME", item.STOP_TIME);
                mDs.SetItem(currentRow, "USAGE_CODE", item.USAGE_CODE);
                mDs.SetItem(currentRow, "USAGE_NAME", item.USAGE_NAME);
                mDs.SetItem(currentRow, "VALID_DAYS", item.VALID_DAYS);
                mDs.SetItem(currentRow, "VISIT_CODE", item.VISIT_CODE);
                mDs.SetItem(currentRow, "VISIT_FLOW", item.VISIT_FLOW);
                mDs.Update(oracleUrl);
            }
            textBox4.AppendText("导入完成" + "\r\n");
        }

        private void btn_migrationtimer3_Click(object sender, EventArgs e)
        {
            setTaskAtFixedTime3();
            textBox4.AppendText("初始化成功" + "\r\n");
        }

        public void setTaskAtFixedTime3()
        {
            DateTime now = DateTime.Now;
            DateTime oneOClock = DateTime.Today.AddHours(1.0);
            if (now > oneOClock)
            {
                oneOClock = oneOClock.AddDays(1.0);
            }
            int msUntilFour = (int)((oneOClock - now).TotalMilliseconds);

            var t = new System.Threading.Timer(doAt1AM3);
            t.Change(msUntilFour, Timeout.Infinite);
        }

        public void doAt1AM3(object state)
        {
            wForm = new WaitDialogForm("正在对比并插入数据...");
            try
            {
                if (wForm.IsDisposed)
                {
                    wForm.Show();
                }
                textBox4.AppendText("开始执行；" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");

                List<VIEW_PATIENT_ORDERS> listView = new List<VIEW_PATIENT_ORDERS>();
                string startTime = DateTime.Today.AddDays(-1).AddHours(0.0).AddSeconds(0.0).ToString("yyyy-MM-dd HH:mm:ss");
                string endTime = DateTime.Today.AddHours(0.0).AddSeconds(0.0).ToString("yyyy-MM-dd HH:mm:ss");
                string strSql = "select * from VIEW_PATIENT_ORDERS where ORDER_DATE >= " + startTime + "and ORDER_DATE <=" + endTime;
                string strSql2 = "select * from VIEW_PATIENT_ORDERS";
                uDataSet uDataSet1 = new uDataSet(new string[] { strSql2 }, new uParameter[] { }, oracleUrl);
                uDataSet uDataSet2 = new uDataSet(new string[] { strSql }, new uParameter[] { }, sqlserverUrl);
                var dataJson1 = DataHelper.ToJson(uDataSet1.Tables[0]);
                var dataJson2 = DataHelper.ToJson(uDataSet2.Tables[0]);
                var dataMoulds1 = JsonConvert.DeserializeObject<List<VIEW_PATIENT_ORDERS>>(dataJson1);
                var dataMoulds2 = JsonConvert.DeserializeObject<List<VIEW_PATIENT_ORDERS>>(dataJson2);

                foreach (var item in dataMoulds2)
                {
                    var dataDto = dataMoulds1.Find(m => m.RECORD_FLOW == item.RECORD_FLOW);
                    if (dataDto == null)
                    {
                        listView.Add(item);
                    }
                }
                if (!wForm.IsDisposed)
                {
                    wForm.Dispose();
                }
                uDataSet mDs = new uDataSet(new string[] { "select * from VIEW_PATIENT_ORDERS where 1 = 2" }, new uParameter[] { }, oracleUrl);
                foreach (var item in listView)
                {
                    var currentRow = mDs.InsertRow();
                    mDs.SetItem(currentRow, "BASE_DOSE", item.BASE_DOSE);
                    mDs.SetItem(currentRow, "CHARGES", item.CHARGES.ToString() == null ? "1" : item.CHARGES.ToString());
                    mDs.SetItem(currentRow, "CLASS_CODE", item.CLASS_CODE);
                    mDs.SetItem(currentRow, "CLASS_NAME", item.CLASS_NAME);
                    mDs.SetItem(currentRow, "ctime", item.ctime.ToString() == null ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:dd") : item.ctime.ToString());
                    mDs.SetItem(currentRow, "DEPT_CODE", item.DEPT_CODE);
                    mDs.SetItem(currentRow, "DEPT_NAME", item.DEPT_NAME);
                    mDs.SetItem(currentRow, "DOCTOR_CODE", item.DOCTOR_CODE);
                    mDs.SetItem(currentRow, "DOCTOR_NAME", item.DOCTOR_NAME);
                    mDs.SetItem(currentRow, "DOSE_EACH", item.DOSE_EACH);
                    mDs.SetItem(currentRow, "DOSE_UNIT", item.DOSE_UNIT);
                    mDs.SetItem(currentRow, "DRUG_SPECS", item.DRUG_SPECS);
                    mDs.SetItem(currentRow, "EXEC_TIME", item.EXEC_TIME);
                    mDs.SetItem(currentRow, "FREQUENCY_CODE", item.FREQUENCY_CODE);
                    mDs.SetItem(currentRow, "FREQUENCY_NAME", item.FREQUENCY_NAME);
                    mDs.SetItem(currentRow, "GROUP_CODE", item.GROUP_CODE);
                    mDs.SetItem(currentRow, "LONG_FLAG", item.LONG_FLAG);
                    mDs.SetItem(currentRow, "ORDER_CODE", item.ORDER_CODE);
                    mDs.SetItem(currentRow, "ORDER_DATE", item.ORDER_DATE);
                    mDs.SetItem(currentRow, "ORDER_MEMO", item.ORDER_MEMO);
                    mDs.SetItem(currentRow, "ORDER_NAME", item.ORDER_NAME);
                    mDs.SetItem(currentRow, "ORDER_NO", item.ORDER_NO);
                    mDs.SetItem(currentRow, "PACK_QTY", item.PACK_QTY);
                    mDs.SetItem(currentRow, "PATIENT_FLOW", item.PATIENT_FLOW);
                    mDs.SetItem(currentRow, "QTY_TOT", item.QTY_TOT);
                    mDs.SetItem(currentRow, "RECORD_FLOW", item.RECORD_FLOW);
                    mDs.SetItem(currentRow, "state", item.state);
                    mDs.SetItem(currentRow, "STATUS_CODE", item.STATUS_CODE);
                    mDs.SetItem(currentRow, "STATUS_NAME", item.STATUS_NAME);
                    mDs.SetItem(currentRow, "STOP_TIME", item.STOP_TIME);
                    mDs.SetItem(currentRow, "USAGE_CODE", item.USAGE_CODE);
                    mDs.SetItem(currentRow, "USAGE_NAME", item.USAGE_NAME);
                    mDs.SetItem(currentRow, "VALID_DAYS", item.VALID_DAYS);
                    mDs.SetItem(currentRow, "VISIT_CODE", item.VISIT_CODE);
                    mDs.SetItem(currentRow, "VISIT_FLOW", item.VISIT_FLOW);
                    mDs.Update(oracleUrl);
                }
                setTaskAtFixedTime3();
                textBox4.AppendText("执行成功；" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
            }
            catch (Exception ex)
            {

                textBox4.AppendText(ex.Message);
            }

        }

        private void btn_magrationAll4_Click(object sender, EventArgs e)
        {
            List<VIEW_VITAL_SIGNS> listView = new List<VIEW_VITAL_SIGNS>();
            string strSql = "select * from VIEW_VITAL_SIGNS where REC_DATE >= 2022-10-10 00:00:00 and  REC_DATE <= 2022-10-10 00:00:00";
            uDataSet uDataSet1 = new uDataSet(new string[] { strSql }, new uParameter[] { }, oracleUrl);
            uDataSet uDataSet2 = new uDataSet(new string[] { strSql }, new uParameter[] { }, sqlserverUrl);
            var dataJson1 = DataHelper.ToJson(uDataSet1.Tables[0]);
            var dataJson2 = DataHelper.ToJson(uDataSet2.Tables[0]);
            var dataMoulds1 = JsonConvert.DeserializeObject<List<VIEW_VITAL_SIGNS>>(dataJson1);
            var dataMoulds2 = JsonConvert.DeserializeObject<List<VIEW_VITAL_SIGNS>>(dataJson2);


            wForm.Show();
            foreach (var item in dataMoulds2)
            {
                var dataDto = dataMoulds1.Find(m => m.RECORD_FLOW == item.RECORD_FLOW);
                if (dataDto == null)
                {
                    listView.Add(item);
                }
            }
            if (!wForm.IsDisposed)
            {
                wForm.Dispose();
            }

            uDataSet mDs = new uDataSet(new string[] { "select * from VIEW_VITAL_SIGNS where 1 = 2" }, new uParameter[] { }, oracleUrl);
            foreach (var item in listView)
            {
                var currentRow = mDs.InsertRow();
                mDs.SetItem(currentRow, "ctime", item.ctime.ToString());
                mDs.SetItem(currentRow, "MEMO", item.MEMO);
                mDs.SetItem(currentRow, "PATIENT_FLOW", item.PATIENT_FLOW);
                mDs.SetItem(currentRow, "RECORDER_CODE", item.RECORDER_CODE);
                mDs.SetItem(currentRow, "RECORDER_NAME", item.RECORDER_NAME);
                mDs.SetItem(currentRow, "RECORD_FLOW", item.RECORD_FLOW);
                mDs.SetItem(currentRow, "REC_DATE", item.REC_DATE);
                mDs.SetItem(currentRow, "SIGNS_VALUES_FLAG", item.SIGNS_VALUES_FLAG);
                mDs.SetItem(currentRow, "SPECIAL_VALUE", item.SPECIAL_VALUE);
                mDs.SetItem(currentRow, "state", item.state);
                mDs.SetItem(currentRow, "TIME_POINT", item.TIME_POINT);
                mDs.SetItem(currentRow, "UNITS_CODE", item.UNITS_CODE);
                mDs.SetItem(currentRow, "UNITS_NAME", item.UNITS_NAME);
                mDs.SetItem(currentRow, "VISIT_CODE", item.VISIT_CODE);
                mDs.SetItem(currentRow, "VISIT_FLOW", item.VISIT_FLOW);
                mDs.SetItem(currentRow, "VITAL_SIGNS_CODE", item.VITAL_SIGNS_CODE);
                mDs.SetItem(currentRow, "VITAL_SIGNS_NAME", item.VITAL_SIGNS_NAME);
                mDs.SetItem(currentRow, "VITAL_SIGNS_NO", item.VITAL_SIGNS_NO);
                mDs.SetItem(currentRow, "VITAL_SIGNS_VALUES", item.VITAL_SIGNS_VALUES);
                mDs.Update(oracleUrl);
            }
        }

        private void btn_migrationtimer4_Click(object sender, EventArgs e)
        {
            setTaskAtFixedTime4();
            textBox5.AppendText("初始化成功");
        }
        public void setTaskAtFixedTime4()
        {
            DateTime now = DateTime.Now;
            DateTime oneOClock = DateTime.Today.AddHours(1.0);
            if (now > oneOClock)
            {
                oneOClock = oneOClock.AddDays(1.0);
            }
            int msUntilFour = (int)((oneOClock - now).TotalMilliseconds);

            var t = new System.Threading.Timer(doAt1AM4);
            t.Change(msUntilFour, Timeout.Infinite);
        }

        public void doAt1AM4(object state)
        {
            try
            {
                string startTime = DateTime.Today.AddDays(-1).AddHours(0.0).AddSeconds(0.0).ToString("yyyy-MM-dd HH:mm:ss");
                string endTime = DateTime.Today.AddHours(0.0).AddSeconds(0.0).ToString("yyyy-MM-dd HH:mm:ss");
                string strSql = "select * from VIEW_VITAL_SIGNS where REC_DATE >= " + startTime + "and REC_DATE <=" + endTime;
                uDataSet uDataSet1 = new uDataSet(new string[] { strSql }, new uParameter[] { }, sqlserverUrl);
                var dataJson1 = DataHelper.ToJson(uDataSet1.Tables[0]);
                var dataMoulds1 = JsonConvert.DeserializeObject<List<VIEW_VITAL_SIGNS>>(dataJson1);
                uDataSet mDs = new uDataSet(new string[] { "select * from VIEW_VITAL_SIGNS where 1 = 2" }, new uParameter[] { }, oracleUrl);
                foreach (var item in dataMoulds1)
                {
                    var currentRow = mDs.InsertRow();
                    mDs.SetItem(currentRow, "ctime", item.ctime.ToString());
                    mDs.SetItem(currentRow, "MEMO", item.MEMO);
                    mDs.SetItem(currentRow, "PATIENT_FLOW", item.PATIENT_FLOW);
                    mDs.SetItem(currentRow, "RECORDER_CODE", item.RECORDER_CODE);
                    mDs.SetItem(currentRow, "RECORDER_NAME", item.RECORDER_NAME);
                    mDs.SetItem(currentRow, "RECORD_FLOW", item.RECORD_FLOW);
                    mDs.SetItem(currentRow, "REC_DATE", item.REC_DATE);
                    mDs.SetItem(currentRow, "SIGNS_VALUES_FLAG", item.SIGNS_VALUES_FLAG);
                    mDs.SetItem(currentRow, "SPECIAL_VALUE", item.SPECIAL_VALUE);
                    mDs.SetItem(currentRow, "state", item.state);
                    mDs.SetItem(currentRow, "TIME_POINT", item.TIME_POINT);
                    mDs.SetItem(currentRow, "UNITS_CODE", item.UNITS_CODE);
                    mDs.SetItem(currentRow, "UNITS_NAME", item.UNITS_NAME);
                    mDs.SetItem(currentRow, "VISIT_CODE", item.VISIT_CODE);
                    mDs.SetItem(currentRow, "VISIT_FLOW", item.VISIT_FLOW);
                    mDs.SetItem(currentRow, "VITAL_SIGNS_CODE", item.VITAL_SIGNS_CODE);
                    mDs.SetItem(currentRow, "VITAL_SIGNS_NAME", item.VITAL_SIGNS_NAME);
                    mDs.SetItem(currentRow, "VITAL_SIGNS_NO", item.VITAL_SIGNS_NO);
                    mDs.SetItem(currentRow, "VITAL_SIGNS_VALUES", item.VITAL_SIGNS_VALUES);
                    mDs.Update(oracleUrl);
                }
                setTaskAtFixedTime4();
                textBox5.AppendText("执行成功；" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            catch (Exception ex)
            {
                textBox5.AppendText(ex.Message);
            }

        }

        public void Contrast_VIEW_PATIENT_DIAG()
        {
            wForm = new WaitDialogForm("正在对比并插入数据...");
            try
            {

                if (wForm.IsDisposed)
                {
                    wForm.Show();
                }


                List<VIEW_PATIENT_DIAG> listView = new List<VIEW_PATIENT_DIAG>();
                foreach (var item in saveData.VIEW_PATIENT_DIAG_2)
                {
                    var dataDto = saveData.VIEW_PATIENT_DIAG_1.Find(m => m.PATIENT_FLOW == item.PATIENT_FLOW);
                    if (dataDto == null)
                    {
                        listView.Add(item);
                    }
                }

                textBox6.AppendText("对比查出" + listView.Count() + "行数据" + "\r\n");

                uDataSet mDs = new uDataSet(new string[] { "select * from VIEW_PATIENT_DIAG where 1 = 2" }, new uParameter[] { }, oracleUrl);
                foreach (var item in listView)
                {
                    var currentRow = mDs.InsertRow();
                    mDs.SetItem(currentRow, "ctime", item.CTIME.ToString() == null ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:dd") : item.CTIME.ToString());
                    mDs.SetItem(currentRow, "DIAG_CODE", item.DIAG_CODE);
                    mDs.SetItem(currentRow, "DIAG_DATE", item.DIAG_DATE);
                    mDs.SetItem(currentRow, "DIAG_NAME", item.DIAG_NAME);
                    mDs.SetItem(currentRow, "DIAG_TYPE_CODE", item.DIAG_TYPE_CODE);
                    mDs.SetItem(currentRow, "DIAG_TYPE_NAME", item.DIAG_TYPE_NAME);
                    mDs.SetItem(currentRow, "DOCTOR_FLOW", item.DOCTOR_FLOW);
                    mDs.SetItem(currentRow, "DOCTOR_NAME", item.DOCTOR_NAME);
                    mDs.SetItem(currentRow, "MAIN_FLAG", item.MAIN_FLAG.ToString() == null ? 1 : item.MAIN_FLAG);
                    mDs.SetItem(currentRow, "PATIENT_FLOW", item.PATIENT_FLOW);
                    mDs.SetItem(currentRow, "PIX_ID", item.PIX_ID);
                    mDs.SetItem(currentRow, "STATE", item.STATE);
                    mDs.SetItem(currentRow, "TCM_DISEASE_CODE", item.TCM_DISEASE_CODE);
                    mDs.SetItem(currentRow, "TCM_DISEASE_NAME", item.TCM_DISEASE_NAME);
                    mDs.SetItem(currentRow, "TCM_SYND_CODE", item.TCM_SYND_CODE);
                    mDs.SetItem(currentRow, "TCM_SYND_NAME", item.TCM_SYND_NAME);
                    mDs.SetItem(currentRow, "VISIT_CODE", item.VISIT_CODE);
                    mDs.SetItem(currentRow, "VISIT_FLOW", item.VISIT_FLOW);
                    mDs.Update(oracleUrl);
                }
                if (!wForm.IsDisposed)
                {
                    wForm.Dispose();
                }
                setTaskAtFixedTime5();
                textBox6.AppendText("执行成功；" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
            }
            catch (Exception ex)
            {
                if (!wForm.IsDisposed)
                {
                    wForm.Dispose();
                }
                textBox6.AppendText(ex.Message + ex.InnerException);
            }

        }
        private void btn_magrationAll5_Click(object sender, EventArgs e)
        {
            textBox6.AppendText(oracleUrl + "\r\n" + sqlserverUrl);
            List<VIEW_PATIENT_DIAG> listView = new List<VIEW_PATIENT_DIAG>();
            string strSql = "select * from VIEW_PATIENT_DIAG";
            uDataSet uDataSet1 = new uDataSet(new string[] { strSql }, new uParameter[] { }, oracleUrl);
            textBox6.AppendText("Oracle查询成功,共" + uDataSet1.RowCount() + "条数据" + "\r\n");
            uDataSet uDataSet2 = new uDataSet(new string[] { strSql }, new uParameter[] { }, sqlserverUrl);
            textBox6.AppendText("Sqlserver查询成功，共" + uDataSet2.RowCount() + "条数据" + "\r\n");
            var dataJson1 = DataHelper.ToJson(uDataSet1.Tables[0]);
            textBox6.AppendText("OracleToJson成功" + "\r\n");
            var dataJson2 = DataHelper.ToJson(uDataSet2.Tables[0]);
            textBox6.AppendText("SqlserverToJson成功" + "\r\n");
            saveData.VIEW_PATIENT_DIAG_1 = JsonConvert.DeserializeObject<List<VIEW_PATIENT_DIAG>>(dataJson1);
            textBox6.AppendText("OracleToEntity成功" + "\r\n");
            saveData.VIEW_PATIENT_DIAG_2 = JsonConvert.DeserializeObject<List<VIEW_PATIENT_DIAG>>(dataJson2);
            textBox6.AppendText("SqlserverToEntity成功" + "\r\n");
            Thread th = new Thread(Contrast_VIEW_PATIENT_DIAG);
            th.Start();
        }

        private void btn_migrationtimer5_Click(object sender, EventArgs e)
        {
            setTaskAtFixedTime5();
            textBox6.AppendText("初始化成功" + "\r\n");
        }

        public void setTaskAtFixedTime5()
        {
            DateTime now = DateTime.Now;
            DateTime oneOClock = DateTime.Today.AddHours(1.0);
            if (now > oneOClock)
            {
                oneOClock = oneOClock.AddDays(1.0);
            }
            int msUntilFour = (int)((oneOClock - now).TotalMilliseconds);

            var t = new System.Threading.Timer(doAt1AM5);
            t.Change(msUntilFour, Timeout.Infinite);
        }

        public void doAt1AM5(object state)
        {
            try
            {
                textBox6.AppendText("开始执行；" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
                List<VIEW_PATIENT_DIAG> listView = new List<VIEW_PATIENT_DIAG>();
                string startTime = DateTime.Today.AddDays(-1).AddHours(0.0).AddSeconds(0.0).ToString("yyyy-MM-dd HH:mm:ss");
                string endTime = DateTime.Today.AddHours(0.0).AddSeconds(0.0).ToString("yyyy-MM-dd HH:mm:ss");
                string strSql = "select * from VIEW_PATIENT_DIAG where DIAG_DATE >= " + startTime + "and DIAG_DATE <=" + endTime;
                string strSql2 = "select * from VIEW_PATIENT_DIAG";
                uDataSet uDataSet1 = new uDataSet(new string[] { strSql2 }, new uParameter[] { }, oracleUrl);
                uDataSet uDataSet2 = new uDataSet(new string[] { strSql }, new uParameter[] { }, sqlserverUrl);

                var dataJson1 = DataHelper.ToJson(uDataSet1.Tables[0]);
                var dataJson2 = DataHelper.ToJson(uDataSet2.Tables[0]);
                saveData.VIEW_PATIENT_DIAG_1 = JsonConvert.DeserializeObject<List<VIEW_PATIENT_DIAG>>(dataJson1);
                saveData.VIEW_PATIENT_DIAG_2 = JsonConvert.DeserializeObject<List<VIEW_PATIENT_DIAG>>(dataJson2);
                Thread th = new Thread(Contrast_VIEW_PATIENT_DIAG);
                th.Start();
            }
            catch (Exception ex)
            {
                textBox6.AppendText(ex.Message);
            }

        }

        private void MigrationDbToolFrom_Load(object sender, EventArgs e)
        {
            oracleUrl = ConfigurationManager.AppSettings["oracle"];
            sqlserverUrl = ConfigurationManager.AppSettings["sqlserver"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uDataSet uDataSet2 = new uDataSet(new string[] { "select * from VIEW_VITAL_SIGNS WHERE RECORD_FLOW = 45655" }, new uParameter[] { }, oracleUrl);
            var dataJson1 = DataHelper.ToJson(uDataSet2.Tables[0]);
            textBox2.Text = dataJson1;
        }
    }
}
