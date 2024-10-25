using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace OAnQuan
{
    public partial class FrmMenu_48_Minh : Form
    {

        private static bool isFirstLoggin1_48_Minh = true;
        private static bool isFirstLoggin2_48_Minh = true;
        public static bool soNguoiChoi_48_Minh;
        private SoundPlayer choiNhac_48_Minh;
        public static FrmMenu_48_Minh frmMenu_48_Minh;
        public static FrmMain2Player_48_Minh frmMain2_48_Minh;
        public static FrmMain2Player_48_Minh frmMain1_48_Minh;

        public FrmMenu_48_Minh()
        {
            InitializeComponent();
        }

        private void frmMenu_48_Minh_Load(object sender, EventArgs e)
        {
            choiNhac_48_Minh = new SoundPlayer(Properties.Resources.FolkMusic);
            this.Size = new Size(1200, 800); //Gán size cho form
        }

        private void btnChoiTiep_48_Minh_Click(object sender, EventArgs e)
        {
            frmMenu_48_Minh = this;
            this.Hide();
            if (isFirstLoggin1_48_Minh && isFirstLoggin2_48_Minh) //Nếu chưa từng truy cập vào form chơi
                soNguoiChoi_48_Minh = Properties.Settings.Default.soNguoiChoi_48_Minh; //Đọc số người chơi đang chơi dở ở lần chơi trước
            if (soNguoiChoi_48_Minh) //Nếu là 2 người chơi
            {
                if (isFirstLoggin2_48_Minh) //Nếu chưa từng truy cập vào form chơi 2 người
                {
                    frmMain2_48_Minh = new FrmMain2Player_48_Minh();
                    isFirstLoggin2_48_Minh = false; //Đã truy cập vào form 2 người chơi
                    frmMain2_48_Minh.docFile_48_Minh(); //Đọc dữ liệu chơi dở ở lần chơi trước
                }
                frmMain2_48_Minh.Size = this.Size;
                frmMain2_48_Minh.Location = this.Location;
                frmMain2_48_Minh.Show();
                frmMain2_48_Minh.tThoiGian_48_Minh.Start();
            }
            else //Nếu là 1 người chơi
            {
                if (isFirstLoggin1_48_Minh) //Nếu chưa từng truy cập vào form chơi 1 người
                {
                    frmMain1_48_Minh = new FrmMain1Player_48_Minh();
                    isFirstLoggin1_48_Minh = false; //Đã truy cập vào form 1 người chơi
                    frmMain1_48_Minh.docFile_48_Minh(); //Đọc dữ liệu chơi dở ở lần chơi trước
                }
                frmMain1_48_Minh.Size = this.Size;
                frmMain1_48_Minh.Location = this.Location;
                frmMain1_48_Minh.Show();
                frmMain1_48_Minh.tThoiGian_48_Minh.Start();
            }
        }

        private void btnThoat_48_Minh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo_48_Min", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Application.Exit();
        }

        private void cbNhac_48_Minh_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNhac_48_Minh.Checked)
                choiNhac_48_Minh.PlayLooping();
            else
                choiNhac_48_Minh.Stop();
        }

        private void frmMenu_48_Minh_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Thoát form thì thoát luôn chương trình
        }

        private void btnVanMoi2Player_48_Minh_Click(object sender, EventArgs e)
        {
            if (isFirstLoggin2_48_Minh) //Nếu chưa từng truy cập vào form chơi 2 người
            {
                frmMain2_48_Minh = new FrmMain2Player_48_Minh();
                isFirstLoggin2_48_Minh = false; //Đã truy cập vào form 2 người chơi
            }
            soNguoiChoi_48_Minh = true; //Hiện đang là 2 người chơi
            frmMenu_48_Minh = this;
            this.Hide();
            frmMain2_48_Minh.docFile_48_Minh("OAnQuan.Resources.Data.txt"); //Đọc dữ liệu mặc định
            frmMain2_48_Minh.Size = this.Size;
            frmMain2_48_Minh.Location = this.Location;
            frmMain2_48_Minh.Show();
            frmMain2_48_Minh.tThoiGian_48_Minh.Start();
        }

        private void btnVanMoi1Player_48_Minh_Click(object sender, EventArgs e)
        {
            if (isFirstLoggin1_48_Minh) //Nếu chưa từng truy cập vào form chơi 1 người
            {
                frmMain1_48_Minh = new FrmMain1Player_48_Minh();
                isFirstLoggin1_48_Minh = false; //Đã truy cập vào form 1 người chơi
            }
            soNguoiChoi_48_Minh = false; //Hiện đang là 1 người chơi
            frmMenu_48_Minh = this;
            this.Hide();
            frmMain1_48_Minh.docFile_48_Minh("OAnQuan.Resources.Data.txt"); //Đọc dữ liệu mặc định
            frmMain1_48_Minh.Size = this.Size;
            frmMain1_48_Minh.Location = this.Location;
            frmMain1_48_Minh.Show();
            frmMain1_48_Minh.tThoiGian_48_Minh.Start();
        }
    }
}
