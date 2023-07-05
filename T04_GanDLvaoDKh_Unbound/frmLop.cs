using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T04_GanDLvaoDKh_Unbound
{
    public partial class frmLop : Form
    {
        clsDuLieu dl = new clsDuLieu();
        DataTable tblKhoa = new DataTable();
        DataTable tblLop = new DataTable();

        public frmLop()
        {
            InitializeComponent();
        }

        private void frmLop_Load(object sender, EventArgs e)
        {
            if (!dl.KetNoi())
            {
                Close();
                return;
            }
            frmChinh.dangMo = true;
            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";
            cboKhoa.DataSource = dl.LayDLcoDK("Khoa", "", "MaKhoa");

            lstLop.DisplayMember = "TenLop";
            lstLop.ValueMember = "MaLop";
            lstLop.DataSource = dl.LayDLcoDK("Lop", "", "TenLop");
        }

        private void GanDLvaoDKhien(DataTable tbl)
        {
            DataRow Dong = tbl.Rows[0];
            if (Dong != null)
           {
             txtMaLop.Text = Dong["MaLop"].ToString();
             txtTenLop.Text = Dong["TenLop"].ToString();
             txtNienKhoa.Text = Dong["NienKhoa"].ToString();
             cboKhoa.SelectedValue = Dong["MaKhoa"].ToString();
             txtGVCN.Text = Dong["GVCN"].ToString();
            }
        }

        private void lstLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstLop.SelectedItems.Count != -1)
            {
                string sML = lstLop.SelectedValue.ToString();
                tblLop = dl.LayDLcoDK("Lop", " MaLop='" + sML + "'");
                GanDLvaoDKhien(tblLop);
            }
        }

        private void frmLop_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmChinh.dangMo = false;
        }
    }
}
