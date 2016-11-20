﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
namespace College_Management_System
{
    public partial class frmScholarshipPaymentRecord1 : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();


        public frmScholarshipPaymentRecord1()
        {
            InitializeComponent();
        }

        private void ExportExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView1.RowCount - 1;
                colsTotal = dataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView1.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }
        private void AutocompleteScholarNo()
        {

            try
            {
               

                SqlConnection CN = new SqlConnection(cs.DBConn);

                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(ScholarNo) FROM ScholarshipPayment", CN);
                ds = new DataSet("ds");

                adp.Fill(ds);
                dtable = ds.Tables[0];
                ScholarNo.Items.Clear();

                foreach (DataRow drow in dtable.Rows)
                {
                    ScholarNo.Items.Add(drow[0].ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AutocompleteCourse()
        {

            try
            {
                SqlConnection CN = new SqlConnection(cs.DBConn);
                CN.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT distinct RTRIM(Course) FROM ScholarshipPayment,Student where Student.ScholarNo=ScholarshipPayment.ScholarNo", CN);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                Course.Items.Clear();

                foreach (DataRow drow in dtable.Rows)
                {
                    Course.Items.Add(drow[0].ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void frmScholarshipPaymentRecord_Load(object sender, EventArgs e)
        {
            AutocompleteCourse();
            AutocompleteScholarNo();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView2.RowCount - 1;
                colsTotal = dataGridView2.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView2.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView2.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView3.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView3.RowCount - 1;
                colsTotal = dataGridView3.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView3.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView3.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView4.DataSource == null)
            {
                MessageBox.Show("Sorry nothing to export into excel sheet..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView4.RowCount - 1;
                colsTotal = dataGridView4.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView4.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView4.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Course.Text = "";
            Branch.Text = "";
            Date_from.Text = System.DateTime.Today.ToString();
            Date_to.Text = System.DateTime.Today.ToString();
            dataGridView1.DataSource = null;
            Branch.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ScholarNo.Text = "";
            dataGridView2.DataSource = null;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PaymentDateFrom.Text = System.DateTime.Today.ToString();
            PaymentDateTo.Text = System.DateTime.Today.ToString();
            dataGridView3.DataSource = null;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DateFrom.Text = System.DateTime.Today.ToString();
            DateTo.Text = System.DateTime.Today.ToString();
            dataGridView4.DataSource = null;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            Course.Text = "";
            Branch.Text = "";
            Date_from.Text = DateTime.Today.ToString();
            Date_to.Text = DateTime.Today.ToString();
            ScholarNo.Text = "";
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            dataGridView4.DataSource = null;
        
            PaymentDateFrom.Text = DateTime.Today.ToString();
            PaymentDateTo.Text = DateTime.Today.ToString();
            DateFrom.Text = DateTime.Today.ToString();
            DateTo.Text = DateTime.Today.ToString();
          
            Branch.Enabled = false;
        }

        private void Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            Branch.Items.Clear();
            Branch.Text = "";
            Branch.Enabled = true;

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();


                string ct = "select distinct RTRIM(branch) from ScholarshipPayment,Student where Student.ScholarNo=ScholarshipPayment.ScholarNo and course= '" + Course.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Branch.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ScholarNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = new SqlCommand("select  RTrim(ScholarshipPaymentID)[Scholarship Payment ID],RTRIM(ScholarshipPayment.ScholarshipID)[Scholarship ID],RTRIM(ScholarshipName)[Scholarship Name],RTRIM(ScholarshipPayment.Amount)[Amount],RTRIM(Student.ScholarNo)[Scholar No.], RTRIM(Student_name)[Student Name],RTRIM(Course)[Course],RTRIM(Branch)[Branch],RTRIM(PaymentDate)[Payment Date],RTRIM(PaymentMode)[Payment Mode],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(DuePayment)[Due Payment]   from ScholarshipPayment,Student,Scholarship where Student.ScholarNo=ScholarshipPayment.ScholarNo and Scholarship.ScholarshipID=ScholarshipPayment.ScholarshipID and ScholarshipPayment.ScholarNo= '" + ScholarNo.Text + "' order by PaymentDate", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ScholarshipPayment");
                myDA.Fill(myDataSet, "Student");
                myDA.Fill(myDataSet, "Scholarship");
                dataGridView2.DataSource = myDataSet.Tables["ScholarshipPayment"].DefaultView;
                dataGridView2.DataSource = myDataSet.Tables["Student"].DefaultView;
                dataGridView2.DataSource = myDataSet.Tables["Scholarship"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (Course.Text == "")
                {
                    MessageBox.Show("Please select course", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Course.Focus();
                    return;
                }
                if (Branch.Text == "")
                {
                    MessageBox.Show("Please select branch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Branch.Focus();
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("select  RTrim(ScholarshipPaymentID)[Scholarship Payment ID],RTRIM(ScholarshipPayment.ScholarshipID)[Scholarship ID],RTRIM(ScholarshipName)[Scholarship Name],RTRIM(ScholarshipPayment.Amount)[Amount],RTRIM(Student.ScholarNo)[Scholar No.], RTRIM(Student_name)[Student Name],RTRIM(Course)[Course],RTRIM(Branch)[Branch],RTRIM(PaymentDate)[Payment Date],RTRIM(PaymentMode)[Payment Mode],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(DuePayment)[Due Payment]   from ScholarshipPayment,Student,Scholarship where Student.ScholarNo=ScholarshipPayment.ScholarNo and Scholarship.ScholarshipID=ScholarshipPayment.ScholarshipID and PaymentDate between @date1 and @date2 and Course= '" + Course.Text + "'and branch='" + Branch.Text + "' order by PaymentDate", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = Date_from.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = Date_to.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ScholarshipPayment");
                myDA.Fill(myDataSet, "Student");
                myDA.Fill(myDataSet, "Scholarship");
                dataGridView1.DataSource = myDataSet.Tables["ScholarshipPayment"].DefaultView;
                dataGridView1.DataSource = myDataSet.Tables["Student"].DefaultView;
                dataGridView1.DataSource = myDataSet.Tables["Scholarship"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = new SqlCommand(" select  RTrim(ScholarshipPaymentID)[Scholarship Payment ID],RTRIM(ScholarshipPayment.ScholarshipID)[Scholarship ID],RTRIM(ScholarshipName)[Scholarship Name],RTRIM(ScholarshipPayment.Amount)[Amount],RTRIM(Student.ScholarNo)[Scholar No.], RTRIM(Student_name)[Student Name],RTRIM(Course)[Course],RTRIM(Branch)[Branch],RTRIM(PaymentDate)[Payment Date],RTRIM(PaymentMode)[Payment Mode],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(DuePayment)[Due Payment]   from ScholarshipPayment,Student,Scholarship where Student.ScholarNo=ScholarshipPayment.ScholarNo and Scholarship.ScholarshipID=ScholarshipPayment.ScholarshipID and PaymentDate between @date1 and @date2 order by PaymentDate ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = PaymentDateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = PaymentDateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ScholarshipPayment");
                myDA.Fill(myDataSet, "Student");
                myDA.Fill(myDataSet, "Scholarship");
                dataGridView3.DataSource = myDataSet.Tables["ScholarshipPayment"].DefaultView;
                dataGridView3.DataSource = myDataSet.Tables["Student"].DefaultView;
                dataGridView3.DataSource = myDataSet.Tables["Scholarship"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = new SqlCommand("select  RTrim(ScholarshipPaymentID)[Scholarship Payment ID],RTRIM(ScholarshipPayment.ScholarshipID)[Scholarship ID],RTRIM(ScholarshipName)[Scholarship Name],RTRIM(ScholarshipPayment.Amount)[Amount],RTRIM(Student.ScholarNo)[Scholar No.], RTRIM(Student_name)[Student Name],RTRIM(Course)[Course],RTRIM(Branch)[Branch],RTRIM(PaymentDate)[Payment Date],RTRIM(PaymentMode)[Payment Mode],RTRIM(PaymentModeDetails)[Payment Mode Details],RTRIM(TotalPaid)[Total Paid],RTRIM(DuePayment)[Due Payment]   from ScholarshipPayment,Student,Scholarship where Student.ScholarNo=ScholarshipPayment.ScholarNo and Scholarship.ScholarshipID=ScholarshipPayment.ScholarshipID and PaymentDate between @date1 and @date2 and DuePayment > 0 order by PaymentDate ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "PaymentDate").Value = DateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "PaymentDate").Value = DateTo.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "ScholarshipPayment");
                myDA.Fill(myDataSet, "Student");
                myDA.Fill(myDataSet, "Scholarship");
                dataGridView4.DataSource = myDataSet.Tables["ScholarshipPayment"].DefaultView;
                dataGridView4.DataSource = myDataSet.Tables["Student"].DefaultView;
                dataGridView4.DataSource = myDataSet.Tables["Scholarship"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                frmScholarshipPayment frm = new frmScholarshipPayment();
                // or simply use column name instead of index
                //dr.Cells["id"].Value.ToString();
                frm.Show();
                frm.ScholarshipPaymentID.Text = dr.Cells[0].Value.ToString();
                frm.ScholarshipID.Text = dr.Cells[1].Value.ToString();
                frm.ScholarshipName.Text = dr.Cells[2].Value.ToString();
                frm.Amount.Text = dr.Cells[3].Value.ToString();
                frm.ScholarNo.Text = dr.Cells[4].Value.ToString();
                frm.StudentName.Text = dr.Cells[5].Value.ToString();
                frm.Course.Text = dr.Cells[6].Value.ToString();
                frm.Branch.Text = dr.Cells[7].Value.ToString();
                frm.PaymentDate.Text = dr.Cells[8].Value.ToString();
                frm.ModeOfPayment.Text = dr.Cells[9].Value.ToString();
                frm.PaymentModeDetails.Text = dr.Cells[10].Value.ToString();
                frm.TotalPaid.Text = dr.Cells[11].Value.ToString();
                frm.DuePayment.Text = dr.Cells[12].Value.ToString();
                if (label10.Text == "Admin")
                {
                    frm.Delete.Enabled = true;
                    frm.Update_record.Enabled = true;
                    frm.Print.Enabled = true;
                    frm.btnSave.Enabled = false;
                    frm.label5.Text = label10.Text;
                    frm.label6.Text = label11.Text;
                }
                else
                {
                    frm.Delete.Enabled = false;
                    frm.Update_record.Enabled = false;
                    frm.Print.Enabled = true;
                    frm.btnSave.Enabled = false;
                    frm.label5.Text = label10.Text;
                    frm.label6.Text = label11.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView2.SelectedRows[0];
                this.Hide();
                frmScholarshipPayment frm = new frmScholarshipPayment();
                // or simply use column name instead of index
                //dr.Cells["id"].Value.ToString();
                frm.Show();
                frm.ScholarshipPaymentID.Text = dr.Cells[0].Value.ToString();
                frm.ScholarshipID.Text = dr.Cells[1].Value.ToString();
                frm.ScholarshipName.Text = dr.Cells[2].Value.ToString();
                frm.Amount.Text = dr.Cells[3].Value.ToString();
                frm.ScholarNo.Text = dr.Cells[4].Value.ToString();
                frm.StudentName.Text = dr.Cells[5].Value.ToString();
                frm.Course.Text = dr.Cells[6].Value.ToString();
                frm.Branch.Text = dr.Cells[7].Value.ToString();
                frm.PaymentDate.Text = dr.Cells[8].Value.ToString();
                frm.ModeOfPayment.Text = dr.Cells[9].Value.ToString();
                frm.PaymentModeDetails.Text = dr.Cells[10].Value.ToString();
                frm.TotalPaid.Text = dr.Cells[11].Value.ToString();
                frm.DuePayment.Text = dr.Cells[12].Value.ToString();
                if (label10.Text == "Admin")
                {
                    frm.Delete.Enabled = true;
                    frm.Update_record.Enabled = true;
                    frm.Print.Enabled = true;
                    frm.btnSave.Enabled = false;
                    frm.label5.Text = label10.Text;
                    frm.label6.Text = label11.Text;
                }
                else
                {
                    frm.Delete.Enabled = false;
                    frm.Update_record.Enabled = false;
                    frm.Print.Enabled = true;
                    frm.btnSave.Enabled = false;
                    frm.label5.Text = label10.Text;
                    frm.label6.Text = label11.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView3.SelectedRows[0];
                this.Hide();
                frmScholarshipPayment frm = new frmScholarshipPayment();
                // or simply use column name instead of index
                //dr.Cells["id"].Value.ToString();
                frm.Show();
                frm.ScholarshipPaymentID.Text = dr.Cells[0].Value.ToString();
                frm.ScholarshipID.Text = dr.Cells[1].Value.ToString();
                frm.ScholarshipName.Text = dr.Cells[2].Value.ToString();
                frm.Amount.Text = dr.Cells[3].Value.ToString();
                frm.ScholarNo.Text = dr.Cells[4].Value.ToString();
                frm.StudentName.Text = dr.Cells[5].Value.ToString();
                frm.Course.Text = dr.Cells[6].Value.ToString();
                frm.Branch.Text = dr.Cells[7].Value.ToString();
                frm.PaymentDate.Text = dr.Cells[8].Value.ToString();
                frm.ModeOfPayment.Text = dr.Cells[9].Value.ToString();
                frm.PaymentModeDetails.Text = dr.Cells[10].Value.ToString();
                frm.TotalPaid.Text = dr.Cells[11].Value.ToString();
                frm.DuePayment.Text = dr.Cells[12].Value.ToString();
                if (label10.Text == "Admin")
                {
                    frm.Delete.Enabled = true;
                    frm.Update_record.Enabled = true;
                    frm.Print.Enabled = true;
                    frm.btnSave.Enabled = false;
                    frm.label5.Text = label10.Text;
                    frm.label6.Text = label11.Text;
                }
                else
                {
                    frm.Delete.Enabled = false;
                    frm.Update_record.Enabled = false;
                    frm.Print.Enabled = true;
                    frm.btnSave.Enabled = false;
                    frm.label5.Text = label10.Text;
                    frm.label6.Text = label11.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView4_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView4.SelectedRows[0];
                this.Hide();
                frmScholarshipPayment frm = new frmScholarshipPayment();
                // or simply use column name instead of index
                //dr.Cells["id"].Value.ToString();
                frm.Show();
                frm.ScholarshipPaymentID.Text = dr.Cells[0].Value.ToString();
                frm.ScholarshipID.Text = dr.Cells[1].Value.ToString();
                frm.ScholarshipName.Text = dr.Cells[2].Value.ToString();
                frm.Amount.Text = dr.Cells[3].Value.ToString();
                frm.ScholarNo.Text = dr.Cells[4].Value.ToString();
                frm.StudentName.Text = dr.Cells[5].Value.ToString();
                frm.Course.Text = dr.Cells[6].Value.ToString();
                frm.Branch.Text = dr.Cells[7].Value.ToString();
                frm.PaymentDate.Text = dr.Cells[8].Value.ToString();
                frm.ModeOfPayment.Text = dr.Cells[9].Value.ToString();
                frm.PaymentModeDetails.Text = dr.Cells[10].Value.ToString();
                frm.TotalPaid.Text = dr.Cells[11].Value.ToString();
                frm.DuePayment.Text = dr.Cells[12].Value.ToString();
                if (label10.Text == "Admin")
                {
                    frm.Delete.Enabled = true;
                    frm.Update_record.Enabled = true;
                    frm.btnSave.Enabled = false;
                    frm.Print.Enabled = true;
                    frm.label5.Text = label10.Text;
                    frm.label6.Text = label11.Text;
                }
                else
                {
                    frm.Delete.Enabled = false;
                    frm.Update_record.Enabled = false;
                    frm.btnSave.Enabled = false;
                    frm.Print.Enabled = true;
                    frm.label5.Text = label10.Text;
                    frm.label6.Text = label11.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmScholarshipPaymentRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmScholarshipPayment frm = new frmScholarshipPayment();
            frm.label5.Text = label10.Text;
            frm.label6.Text = label11.Text;
            frm.Show();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void dataGridView3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView3.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView3.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void dataGridView4_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView4.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView4.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }
    
    }
}
