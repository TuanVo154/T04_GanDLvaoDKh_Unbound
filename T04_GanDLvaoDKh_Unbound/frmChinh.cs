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
    public partial class frmChinh : Form
    {
        public static bool dangMo = false;
        public frmChinh()
        {
            InitializeComponent();
        }

        private void frmChinh_Load(object sender, EventArgs e)
        {

        }

        private void khoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!dangMo)
            {
                frmKhoa frKhoa = new frmKhoa();
                frKhoa.MdiParent= this;
                frKhoa.Show();  
            }
            else
            {
                MessageBox.Show("Vui lòng đóng form đang mở...");
            }
        }

        private void lớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!dangMo)
            {
                frmLop frLop = new frmLop();
                frLop.MdiParent = this;
                frLop.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng đóng form đang mở...");
            }
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!dangMo)
            {
                frmSinhvien frSV = new frmSinhvien();
                frSV.MdiParent = this;
                frSV.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng đóng form đang mở...");
            }
        }
    }
}
