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
    public partial class frmSinhvien : Form
    {
        clsDuLieu dl = new clsDuLieu();
        DataTable tblSV = new DataTable();
        string DuongDanHinh = Application.StartupPath, TenHinh = "";
        public frmSinhvien()
        {
            InitializeComponent();
        }

        private void frmSinhvien_Load(object sender, EventArgs e)
        {
            if (!dl.KetNoi())
            {
                Close();
                return;
            }
            frmChinh.dangMo = true;
            DuongDanHinh = DuongDanHinh.Substring(0, DuongDanHinh.LastIndexOf("Bin",StringComparison.OrdinalIgnoreCase))+ @"HinhSV\";
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember= "MaLop";
            cboLop.DataSource = dl.LayDLcoDK("Lop", "", "MaLop");
            tblSV = dl.LayDLcoDK("SinhVien", "", "MaSV");
            dgrSinhVien.DataSource = tblSV;
        }

        private void dgrSinhVien_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow Dong = dgrSinhVien.CurrentRow;
            if (Dong != null) GanDLvaoDKhien(Dong);
        }

        private void frmSinhvien_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmChinh.dangMo = false;
        }

        private void GanDLvaoDKhien(DataGridViewRow Dong)
        {
            txtMaSV.Text = Dong.Cells["MaSV"].Value.ToString();
            txtHoTenSV.Text = Dong.Cells["HoTenSV"].Value.ToString();
            radNam.Checked = (bool)Dong.Cells["Nam"].Value;
            radNu.Checked = !radNam.Checked;
            dpkNgaySinh.Value = (DateTime)Dong.Cells["NgaySinh"].Value;
            txtDiaChi.Text = Dong.Cells["DiaChi"].Value.ToString();
            txtDienThoai.Text = Dong.Cells["DienThoai"].Value.ToString();
            cboLop.SelectedValue = Dong.Cells["MaLop"].Value.ToString();
            TenHinh = Dong.Cells["Hinh"].Value.ToString() ; 
            if(TenHinh != "")
            {
                picHinh.Image = Image.FromFile(DuongDanHinh + TenHinh);
            }
            else
            {
                picHinh.Image = null;
            }
        }
    }
}
