﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace College_Management_System
{
    public partial class frmSectionRecord : Form
    {
        ConnectionString cs = new ConnectionString();

        public frmSectionRecord()
        {
            InitializeComponent();
        }
  
        private SqlConnection Connection
        {
            get
            {
                SqlConnection ConnectionToFetch = new SqlConnection(cs.DBConn);
                ConnectionToFetch.Open();
                return ConnectionToFetch;
            }
        }
        public DataView GetData()
        {
            dynamic SelectQry = "SELECT RTRIM(Sectionid)[Section ID],RTRIM(SectionName)[Section Name],RTRIM(Course)[Course],rtrim(Branch)[Branch] FROM Section order by course,branch ";
            DataSet SampleSource = new DataSet();
            DataView TableView = null;
            try
            {
                SqlCommand SampleCommand = new SqlCommand();
                dynamic SampleDataAdapter = new SqlDataAdapter();
                SampleCommand.CommandText = SelectQry;
                SampleCommand.Connection = Connection;
                SampleDataAdapter.SelectCommand = SampleCommand;
                SampleDataAdapter.Fill(SampleSource);
                TableView = SampleSource.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return TableView;
        }
        private void frmSectionRecord_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetData();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            this.Hide();
            frmSection frm = new frmSection();
            // or simply use column name instead of index
            //dr.Cells["id"].Value.ToString();
            frm.Show();
            frm.txtSectionID.Text = dr.Cells[0].Value.ToString();
            frm.txtSectionName.Text = dr.Cells[1].Value.ToString();
            frm.cmbCourse.Text = dr.Cells[2].Value.ToString();
            frm.cmbBranch.Text = dr.Cells[3].Value.ToString();
            if (label1.Text == "Admin")
            {
                frm.btnDelete.Enabled = true;
                frm.btnUpdate.Enabled = true;
                frm.btnSave.Enabled = false;
                frm.txtSectionName.Focus();
                frm.label1.Text = label1.Text;
            }
            else
            {
                frm.btnDelete.Enabled = false;
                frm.btnUpdate.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.txtSectionName.Focus();
                frm.label1.Text = label1.Text;
            }

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
       
   

    }
}
