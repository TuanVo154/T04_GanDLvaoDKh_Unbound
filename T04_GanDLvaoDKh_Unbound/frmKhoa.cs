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
    public partial class frmKhoa : Form
    {
        clsDuLieu dl = new clsDuLieu();
        DataTable tblKhoa = new DataTable();
        int ViTri = -1;
        public frmKhoa()
        {
            InitializeComponent();
        }

        private void GanDLvaoDKh(DataTable tbl, int ViTri)
        {
            if(ViTri != -1)
            {
                DataRow Dong = tbl.Rows[ViTri];
                txtMaKhoa.Text = Dong["MaKhoa"].ToString();
                txtTenKhoa.Text = Dong["TenKhoa"].ToString();
                lblViTri.Text = (ViTri + 1) + "/" + tbl.Rows.Count;
            }
        }

        private void frmKhoa_Load(object sender, EventArgs e)
        {
            if (!dl.KetNoi())
            {
                Close();
                return;
            }
            frmChinh.dangMo = true;
            tblKhoa = dl.LayDLcoDK("Khoa", "", "MaKhoa");
            if(tblKhoa.Rows.Count > 0 )  ViTri = 0;
            GanDLvaoDKh(tblKhoa,ViTri); 
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            dl.Dau(tblKhoa, ref ViTri);
            GanDLvaoDKh(tblKhoa, ViTri);
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            dl.Truoc(tblKhoa, ref ViTri);
            GanDLvaoDKh(tblKhoa, ViTri);
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            dl.Sau(tblKhoa, ref ViTri);
            GanDLvaoDKh(tblKhoa, ViTri);
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            dl.Cuoi(tblKhoa, ref ViTri);
            GanDLvaoDKh(tblKhoa, ViTri);
        }

        private void frmKhoa_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmChinh.dangMo = false;
        }
    }
}
