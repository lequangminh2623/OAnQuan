using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace OAnQuan
{
    public partial class FrmMain1Player_48_Minh : OAnQuan.FrmMain2Player_48_Minh
    {
        int[,] arrpossibleChoice_48_Minh = new int[10, 11];
        int[] arrValue_48_Minh = new int[12];
        bool[] arrQuan_48_Minh = new bool[2];

        public FrmMain1Player_48_Minh()
        {
            InitializeComponent();
        }

        private void botCalc_48_Minh(int[] arrV_48_Minh, bool[] arrQ_48_Minh, ref int possibleChoice_48_Minh, int row_48_Minh, int col_48_Minh)
        {
            /*Mỗi nước đi của máy thì sau đó người chơi có thể đi 10 nước.
            Có tất cả 10 nước có thể đi của máy.
            Vậy cần tính tổng cộng 110 nước đi của cả máy và người chơi.
            Hàm này tính toán 1 nước đi của máy và 10 nước đi tương ứng của người chơi.*/

            int index_48_Minh; //Chỉ mục Button cần tính toán
            bool direct_48_Minh; //Hướng cùng chiều hay ngược chiều kim đồng hồ
            if (col_48_Minh == 0) //Đang tính nước đi cho máy
            {
                if (0 <= row_48_Minh && row_48_Minh <= 4) //Theo chiều kim đồng hồ
                {
                    index_48_Minh = row_48_Minh + 7;
                    direct_48_Minh = true;
                }
                else //Ngược chiều kim đồng hồ
                {
                    index_48_Minh = row_48_Minh + 2;
                    direct_48_Minh = false;
                }
            }
            else //Đang tính nước đi cho người chơi ứng với nước đi của máy
            {
                if (1 <= col_48_Minh && col_48_Minh <= 5) //Theo chiều kim đồng hồ
                {
                    index_48_Minh = col_48_Minh;
                    direct_48_Minh = true;
                }
                else //Ngược chiều kim đồng hồ
                {
                    index_48_Minh = col_48_Minh - 5;
                    direct_48_Minh = false;
                }

                //Mô phỏng mượn đá (tương tự hàm raiDa_48_Minh:
                int dem_48_Minh = 0;
                for (int i = 1; i <= 5; i++)
                {
                    if (arrV_48_Minh[i] == 0)
                        dem_48_Minh++;
                    else
                        break;
                }
                if (dem_48_Minh == 5)
                {
                    for (int i = 1; i <= 5; i++)
                        arrV_48_Minh[i] = 1;
                    if (col_48_Minh == 1) // chỉ cộng 1 lần duy nhất
                        arrpossibleChoice_48_Minh[row_48_Minh, 0] += 5;//Rải đá tốn 5 điểm
                }
            }
            int temp_48_Minh = arrV_48_Minh[index_48_Minh]; //Lưu lại bản tạm thời của giả trị phần tử hiện tại

            //Mô phỏng rải đá (tương tự hàm raiDa_48_Minh):
            if (arrV_48_Minh[index_48_Minh] > 0) //nếu giá trị phần tử hiện tại lớn hơn 0 (có thể chọn)
            {
                do
                {
                    int n = arrV_48_Minh[index_48_Minh];
                    arrV_48_Minh[index_48_Minh] = 0;
                    if (direct_48_Minh)
                        index_48_Minh = noiThuTu_48_Minh(index_48_Minh + 1);
                    else
                        index_48_Minh = noiThuTu_48_Minh(index_48_Minh - 1);
                    for (int k = 0; k < n; k++)
                    {
                        arrV_48_Minh[index_48_Minh] = arrV_48_Minh[index_48_Minh] + 1;
                        if (direct_48_Minh)
                            index_48_Minh = noiThuTu_48_Minh(index_48_Minh + 1);
                        else
                            index_48_Minh = noiThuTu_48_Minh(index_48_Minh - 1);
                    }
                } while (arrV_48_Minh[index_48_Minh] != 0 && index_48_Minh != 0 && index_48_Minh != 6);

                //Mô phỏng ăn đá (tương tự hàm anDa_48_Minh) nhưng điểm được cộng vào possibleChoice_48_Minh :
                while (arrV_48_Minh[index_48_Minh] == 0)
                {
                    if (direct_48_Minh)
                        index_48_Minh = noiThuTu_48_Minh(index_48_Minh + 1);
                    else
                        index_48_Minh = noiThuTu_48_Minh(index_48_Minh - 1);
                    if (arrV_48_Minh[index_48_Minh] != 0)
                    {
                        if ((index_48_Minh == 0 && arrQ_48_Minh[0]) || (index_48_Minh == 6 && arrQ_48_Minh[1]))
                        {
                            possibleChoice_48_Minh += arrV_48_Minh[index_48_Minh];
                            arrV_48_Minh[index_48_Minh] = 0;
                            possibleChoice_48_Minh += 10;
                            if (index_48_Minh == 0)
                                arrQ_48_Minh[0] = false;
                            else
                                arrQ_48_Minh[1] = false;
                        }
                        else
                        {
                            possibleChoice_48_Minh += arrV_48_Minh[index_48_Minh];
                            arrV_48_Minh[index_48_Minh] = 0;
                        }
                        if (direct_48_Minh)
                            index_48_Minh = noiThuTu_48_Minh(index_48_Minh + 1);
                        else
                            index_48_Minh = noiThuTu_48_Minh(index_48_Minh - 1);
                    }
                    else
                        break;
                }

                //Mô phỏng check chiến thắng (tương tự hàm checkWinner_48_Minh):
                if (col_48_Minh == 0 && arrV_48_Minh[0] == 0 && arrQ_48_Minh[0] == false && arrQ_48_Minh[1] == false && arrV_48_Minh[6] == 0 &&
                   possibleChoice_48_Minh + int.Parse(txtDiem2_48_Minh.Text) + 10 * int.Parse(txtDiemQuan2_48_Minh.Text) > int.Parse(txtDiem1_48_Minh.Text) + 10 * int.Parse(txtDiemQuan1_48_Minh.Text))
                {
                    possibleChoice_48_Minh += 70; //Nếu thắng thì gán possibleChoice_48_Minh cho 1 sô cực lớn
                    return;
                }
                if (col_48_Minh != 0 && arrV_48_Minh[0] == 0 && arrQ_48_Minh[0] == false && arrQ_48_Minh[1] == false && arrV_48_Minh[6] == 0 &&
                   possibleChoice_48_Minh + int.Parse(txtDiem1_48_Minh.Text) + 10 * int.Parse(txtDiemQuan1_48_Minh.Text) > arrpossibleChoice_48_Minh[row_48_Minh, 0] + int.Parse(txtDiem2_48_Minh.Text) + 10 * int.Parse(txtDiemQuan2_48_Minh.Text))
                    possibleChoice_48_Minh += 70; //Nếu thắng thì gán possibleChoice_48_Minh cho 1 sô cực lớn
            }
            else //Nếu Button chỉ định có Text == 0 (Không thể chọn)
                possibleChoice_48_Minh = -1;

            //Tiếp tục gọi đệ quy để tính toán cho tất cả nước đi của người chơi ứng với 1 nước đi của máy
            if (col_48_Minh != 0 || temp_48_Minh > 0) //Nếu đang tính nước đi của người hoặc phần tử hiện tại có thể chọn (>0)
            {
                //Copy lại mảng chứa giá trị (arrValue_48_Minh):
                int[] arrTempValue_48_Minh = new int[arrButton_48_Minh.Count];
                for (int i = 0; i < arrButton_48_Minh.Count; i++)
                    arrTempValue_48_Minh[i] = arrValue_48_Minh[i];
                //Copy lại mảng chứa Quan (arrQuan_48_Minh):
                bool[] arrTempQuan_48_Minh = new bool[2];
                for (int i = 0; i < 2; i++)
                    arrTempQuan_48_Minh[i] = arrQuan_48_Minh[i];
                col_48_Minh++;
                if (col_48_Minh < 11) //Nếu chưa tính toán hết 11 trường hợp (1 nước của máy ứng 10 nước của người)
                    botCalc_48_Minh(arrTempValue_48_Minh, arrTempQuan_48_Minh, ref arrpossibleChoice_48_Minh[row_48_Minh, col_48_Minh], row_48_Minh, col_48_Minh);
                else
                    return;
            }
        }

        private int botChoosing_48_Minh()
        {
            //Khởi tạo mảng arrPossibleChoice_48_Minh:
            for (int i = 0; i < arrpossibleChoice_48_Minh.GetLength(0); i++)
                for (int j = 0; j < arrpossibleChoice_48_Minh.GetLength(1); j++)
                    arrpossibleChoice_48_Minh[i, j] = 0;

            //Tạo bản nháp bàn cờ để tính toán và tính toán các nước đi:
            for (int i = 0; i < arrpossibleChoice_48_Minh.GetLength(0); i++)
            {
                //Tạo bản nháp của 2 ô quan:
                if (lbQuan1_48_Minh.Text == "1") //Nếu còn quan 1
                    arrQuan_48_Minh[0] = true;
                else //Nếu mất quan 1:
                    arrQuan_48_Minh[0] = false;
                if (lbQuan2_48_Minh.Text == "1") //Nếu còn quan 2
                    arrQuan_48_Minh[1] = true;
                else //Nếu mất quan 2
                    arrQuan_48_Minh[1] = false;
                //Tạo bản nháp bàn cờ (arrButton_48_Minh):
                for (int k = 0; k < arrButton_48_Minh.Count; k++)
                    arrValue_48_Minh[k] = int.Parse(arrButton_48_Minh[k].Text);

                //Tính toán các nước đi của máy và của người chơi tương ứng:
                botCalc_48_Minh(arrValue_48_Minh, arrQuan_48_Minh, ref arrpossibleChoice_48_Minh[i, 0], i, 0);
            }

            int optim_48_Minh; //Chứa điểm tệ nhất sau 1 nước đi của máy và 1 trong các nước đi của người chơi tương ứng
            for (int i = 0; i < arrpossibleChoice_48_Minh.GetLength(0); i++)
            {
                optim_48_Minh = 140; //Cho optim là số cực lớn
                if (arrpossibleChoice_48_Minh[i, 0] != -1) //Nếu Button chỉ định có thể chọn (Text != 0)
                {
                    if (arrpossibleChoice_48_Minh[i, 0] < 70) //Nếu sau nước đi người chơi không chiến thắng
                    {
                        //Tìm min của hiệu giữa điểm của 1 nước đi máy và các nước đi người chơi:
                        for (int j = 1; j < arrpossibleChoice_48_Minh.GetLength(1); j++)
                        {
                            if (arrpossibleChoice_48_Minh[i, j] != -1 && optim_48_Minh > arrpossibleChoice_48_Minh[i, 0] - arrpossibleChoice_48_Minh[i, j])
                                optim_48_Minh = arrpossibleChoice_48_Minh[i, 0] - arrpossibleChoice_48_Minh[i, j];
                        }
                        arrpossibleChoice_48_Minh[i, 0] = optim_48_Minh; //Lưu điểm min vào Ô đầu tiên mỗi hàng
                    }
                    else //Nếu sau nước đi người chơi thắng
                    {
                        //Trả về ngay lập tức nước đi: 
                        if (0 <= i && i <= 4) 
                            return i + 7; //Giá trị dương là hướng cùng chiều kim đồng hồ
                        else
                            return -(i + 2); //Giá trị âm là hướng ngược chiều kim đồng hồ
                    }
                }
                else //Nếu Button chỉ đinh không thể chọn (Text = 0)
                    arrpossibleChoice_48_Minh[i, 0] = -140; //Lưu vào ô đầu tiên của hàng đó số cực nhỏ
            }

            optim_48_Minh = arrpossibleChoice_48_Minh[0, 0]; //Chứa max trong các giá trị tìm được và lưu vào ô đầu tiên của các hàng
            int result_48_Minh = 7; //Chứa chỉ mục của Button có giá trị optim_48_Minh trong arrButton_48_Minh
            
            //Tìm max:
            for (int i = 1; i < arrpossibleChoice_48_Minh.GetLength(0); i++)
            {
                if (optim_48_Minh < arrpossibleChoice_48_Minh[i, 0])
                {
                    optim_48_Minh = arrpossibleChoice_48_Minh[i, 0];
                    if (0 <= i && i <= 4)
                    {
                        result_48_Minh = i + 7; //Số dương theo chiều kim đồng hồ
                    }
                    else
                    {
                        result_48_Minh = -(i + 2); //Số âm theo chiều ngược kim đồng hồ
                    }
                }
            }
            return result_48_Minh; //Trả về kết quả
        }

        protected override void hienKetQua_48_Minh() 
        {
            //Tương tự hàm bị ghi đè nhưng thay người chơi 2 là máy
            string thongTin_48_Minh;
            if (checkWinner_48_Minh() == 1)
                thongTin_48_Minh = "BẠN ĐÃ CHIẾN THẮNG!\n\n\n";
            else if (checkWinner_48_Minh() == -1)
                thongTin_48_Minh = "NGƯỜI CHIẾN THẮNG: MÁY!\n\n\n";
            else
                thongTin_48_Minh = "HAI NGƯỜI CHƠI HÒA NHAU!\n\n";
            thongTin_48_Minh += String.Format("Bạn:\n\tSố dân ăn được {0}.\n\tSố quan ăn được {1}\n\tTổng điểm {2}\n\n" +
                                            "Máy:\n\tSố dân ăn được {3}.\n\tSố quan ăn được {4}\n\tTổng điểm: {5}",
                                            txtDiem1_48_Minh.Text, txtDiemQuan1_48_Minh.Text, int.Parse(txtDiem1_48_Minh.Text) + 10 * int.Parse(txtDiemQuan1_48_Minh.Text),
                                            txtDiem2_48_Minh.Text, txtDiemQuan2_48_Minh.Text, int.Parse(txtDiem2_48_Minh.Text) + 10 * int.Parse(txtDiemQuan2_48_Minh.Text));
            MessageBox.Show(thongTin_48_Minh, "Kêt quả_48_Minh", MessageBoxButtons.OK);
            this.Hide();
            docFile_48_Minh("OAnQuan.Resources.Data.txt");
            Application.Restart();
        }

        protected override void doiLuotChoi_48_Minh()
        {
            //Tương tự hàm bị ghi đè nhưng đến lượt máy thì tự chơi
            btnLeft_48_Minh.Visible = false;
            btnRight_48_Minh.Visible = false;
            int dem_48_Minh = 0;
            if (nguoiChoi_48_Minh)
            {
                gbPlayer1_48_Minh.Enabled = false;
                gbPlayer2_48_Minh.Enabled = false;
                nguoiChoi_48_Minh = false;
                txtThoiGian1_48_Minh.Text = "15";
                for (int i = 7; i <= 11; i++)
                {
                    if (arrButton_48_Minh[i].Text.Equals("0"))
                        dem_48_Minh++;
                    else
                        break;
                }
                if (dem_48_Minh == 5)
                    muonDa_48_Minh();
                hoatAnh_48_Minh(gbPlayer2_48_Minh, 0, Color.Yellow, 800);
                tThoiGian_48_Minh.Stop();              

                int botChoice_48_Minh = botChoosing_48_Minh(); //Tính toán và lựa chọn
                layDa_48_Minh(arrButton_48_Minh[Math.Abs(botChoice_48_Minh)]);
                if (botChoice_48_Minh < 0) //Theo chiều ngược kim đồng hồ
                {
                    raiDa_48_Minh(ref giaTri_48_Minh, ref thuTu_48_Minh, false);
                    anDa_48_Minh(false);
                }
                else //Theo chiều kim đồng hồ
                {
                    raiDa_48_Minh(ref giaTri_48_Minh, ref thuTu_48_Minh, true);
                    anDa_48_Minh(true);
                }
                if (checkGameOver_48_Minh())
                    hienKetQua_48_Minh();
                doiLuotChoi_48_Minh();
                tThoiGian_48_Minh.Start();

            }
            else
            {
                foreach (var btn in arrButton_48_Minh)
                {
                    if (btn.Text.Equals("0") || btn == arrButton_48_Minh[0] || btn == arrButton_48_Minh[6])
                        btn.Enabled = false;
                    else
                        btn.Enabled = true;
                }
                gbPlayer1_48_Minh.Enabled = true;
                gbPlayer2_48_Minh.Enabled = false;
                nguoiChoi_48_Minh = true;
                txtThoiGian2_48_Minh.Text = "15";
                for (int i = 1; i <= 5; i++)
                {
                    if (arrButton_48_Minh[i].Text.Equals("0"))
                        dem_48_Minh++;
                    else
                        break;
                }
                hoatAnh_48_Minh(gbPlayer1_48_Minh, 0, Color.Yellow, 800);
                if (dem_48_Minh == 5)
                    muonDa_48_Minh();
            }
            giaTri_48_Minh = thuTu_48_Minh = 0;
        }

        protected override void btnMenu_48_Minh_Click(object sender, EventArgs e)
        {
            //Chuyển sang form menu:
            tThoiGian_48_Minh.Stop();
            FrmMenu_48_Minh.frmMenu_48_Minh.Size = FrmMenu_48_Minh.frmMain1_48_Minh.Size;
            FrmMenu_48_Minh.frmMenu_48_Minh.Location = FrmMenu_48_Minh.frmMain1_48_Minh.Location;
            FrmMenu_48_Minh.frmMenu_48_Minh.Show();
            this.Hide();
        }
    }
}
