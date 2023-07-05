using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace T04_GanDLvaoDKh_Unbound
{
    internal class clsDuLieu
    {
        SqlConnection cn = new SqlConnection();
        public bool KetNoi()
        {
            string ChuoiKN = "Data Source =TUANVO_ROG;Initial Catalog = QLySinhVienCD; Integrated Security = True";
            try
            {
                if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
                {
                    cn.ConnectionString = ChuoiKN;
                    cn.Open();
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối, vui lòng kiểm tra lại kết nối");
                return false;
            }
        }

        public DataTable LayDLcoDK(string TenBang, string DK = "", string TenFieldSX = "")
        {
            DataTable tbl = new DataTable();
            string ChuoiSQL = "Select * from " + TenBang;
            if (DK != "") ChuoiSQL += " Where " + DK;
            if (TenFieldSX != "") ChuoiSQL += " Order By " + TenFieldSX;
            SqlDataAdapter da = new SqlDataAdapter(ChuoiSQL, cn);
            da.Fill(tbl);
            return tbl;
        }

        public void HienThiCay2Tang(TreeView tw, DataTable tblCha, DataTable tblCon, string TenCha, string TenCon, string MaBgCha, string MaBgCon)
        {
            TreeNode NutCha, NutCon;
            tw.Nodes.Clear();
            foreach (DataRow DongCha in tblCha.Rows)
            {
                NutCha = new TreeNode();
                NutCha.Text = DongCha[TenCha].ToString();
                NutCha.Tag = DongCha[MaBgCha].ToString();
                NutCha.ForeColor = Color.Brown;
                foreach (DataRow DongCon in tblCon.Rows)
                {
                    if (DongCon[MaBgCha].ToString().ToUpper() == NutCha.Tag.ToString().ToUpper())
                    {
                        NutCon = new TreeNode();
                        NutCon.Text = DongCon[TenCon].ToString() + "(" + DongCon[MaBgCon].ToString() + ")";
                        NutCon.Tag = DongCon;
                        NutCon.ForeColor = Color.DarkCyan;
                        NutCha.Nodes.Add(NutCon);
                    }
                }
                tw.Nodes.Add(NutCha);
            }
            if (tw.Nodes.Count > 0) tw.Nodes[0].ExpandAll();
        }

        public DataRow LaydongDL(TreeNode Nut)
        {
            DataRow Dong = (DataRow)Nut.Tag;
            return Dong;
        }

        public int Dau(DataTable tbl, ref int VT) //ref khi thay doi bien ben ngoai bien ngoai cung bi thay doi
        {
            if(tbl.Rows.Count > 0)
            {
                return VT = 0;
            }
            return -1;
        }

        public int Truoc(DataTable tbl, ref int VT)
        {
            if (VT > 0)
            {
                VT--;
                return VT;
            }
            return -1;
        }

        public int Sau(DataTable tbl, ref int VT)
        {
            if (VT < tbl.Rows.Count -1)
            {
                VT++;
                return VT;
            }
            return tbl.Rows.Count - 1;
        }

        public int Cuoi(DataTable tbl, ref int VT)
        {
            VT = tbl.Rows.Count - 1;
            return VT;
        }
    }
}
