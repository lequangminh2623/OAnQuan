using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAnQuan
{

    public partial class FrmMain2Player_48_Minh : Form
    {

        protected List<Button> arrButton_48_Minh;
        protected int giaTri_48_Minh;
        protected int thuTu_48_Minh;
        protected bool nguoiChoi_48_Minh = true;

        protected int noiThuTu_48_Minh(int tt_48_Minh)
        {
            if (tt_48_Minh == arrButton_48_Minh.Count) //Nếu chỉ mục là cuối mảng + 1
                return 0; //Trả về đầu mảng
            else if (tt_48_Minh == -1) //Ngược lại nếu chỉ mục là đầu mảng -1
                return arrButton_48_Minh.Count - 1; //Trả về cuối mảng
            else //Ngược lại thì trả về chỉ mục cũ
                return tt_48_Minh;
        }

        protected void hoatAnh_48_Minh(Control ct_48_Minh, int sizeDiff_48_Minh, Image im_48_Minh, int time_48_Minh)
        {
            int size_48_Minh = (int)ct_48_Minh.Font.Size; //Biến chứa giá trị size ban đầu của control
            Image crrIm_48_Minh = ct_48_Minh.BackgroundImage; //Biến chứa ảnh nền ban đầu của control
            ct_48_Minh.BackgroundImage = im_48_Minh; //Đổi nền
            ct_48_Minh.Font = new Font("Lucida Handwriting", size_48_Minh +  sizeDiff_48_Minh); //Thay đổi size
            ct_48_Minh.Update(); //Cập nhật thay đổi ngay lập tức
            Thread.Sleep(time_48_Minh); //Ngưng chương trình
            ct_48_Minh.BackgroundImage = crrIm_48_Minh; //Đặt lại ảnh nền ban đầu
            ct_48_Minh.Font = new Font("Lucida Handwriting", size_48_Minh); //Đặt lại size ban đầu
            ct_48_Minh.Update(); //Cập nhật thay đổi ngay lập tức
        }

        protected void hoatAnh_48_Minh(Control ct_48_Minh, int  sizeDiff_48_Minh, Color cl_48_Minh, int time_48_Minh)
        {
            int size_48_Minh = (int)ct_48_Minh.Font.Size; //Biến chứa giá trị size ban đầu của control
            ct_48_Minh.BackColor = cl_48_Minh; //Đổi màu nền
            ct_48_Minh.Font = new Font("Lucida Handwriting", size_48_Minh +  sizeDiff_48_Minh); //Thay đổi size
            ct_48_Minh.Update(); //Cập nhật thay đổi ngay lập tức
            Thread.Sleep(time_48_Minh); //Ngưng chương trình
            ct_48_Minh.BackColor = Color.White; //Đặt màu nền về trắng
            ct_48_Minh.Font = new Font("Lucida Handwriting", size_48_Minh); //Đặt lại size ban đầu
            ct_48_Minh.Update(); //Cập nhật thay đổi ngay lập tức
        }

        protected void layDa_48_Minh(Button btn_48_Minh)
        {
            giaTri_48_Minh = int.Parse(btn_48_Minh.Text); //Biến lưu Text của button chỉ định
            //Tìm kiếm button chỉ định trong mảng arrButton_48_Minh:
            for (int i = 0; i < arrButton_48_Minh.Count; i++) 
            {
                if (btn_48_Minh.Name == arrButton_48_Minh[i].Name)
                {
                    thuTu_48_Minh = i; //Biến lưu chỉ mục của button chỉ định trong mảng 
                    break;
                }
            }
        }

        protected void raiDa_48_Minh(ref int giaTri_48_Minh, ref int thuTu_48_Minh, bool flag_48_Minh)
        {
            if (giaTri_48_Minh > 0 || thuTu_48_Minh > 0)
            {
                if (flag_48_Minh) //Nếu theo chiều kim đồng hồ
                {
                    arrButton_48_Minh[thuTu_48_Minh].Text = "0"; //Lấy giá trị Text Button chỉ định và đặt nó về 0

                    //Hoạt ảnh lấy giá trị:
                    if (thuTu_48_Minh == 0 || thuTu_48_Minh == 6) 
                        hoatAnh_48_Minh(arrButton_48_Minh[thuTu_48_Minh], -2, Properties.Resources.OQuan2, 800);
                    else
                        hoatAnh_48_Minh(arrButton_48_Minh[thuTu_48_Minh], -2, Properties.Resources.ODan2, 800);

                    //Tăng 1 đơn vị cho lần lượt các Button kế tiếp theo chiều tăng dần chỉ mục, số Button chính là số giá trị đã lấy:
                    for (int i = 0; i < giaTri_48_Minh; i++)
                    {
                        thuTu_48_Minh = noiThuTu_48_Minh(thuTu_48_Minh + 1); //Tăng chỉ mục
                        arrButton_48_Minh[thuTu_48_Minh].Text = (int.Parse(arrButton_48_Minh[thuTu_48_Minh].Text) + 1).ToString(); //Tăng giá trị
                        
                        //Hoạt ảnh tăng giá trị:
                        if (thuTu_48_Minh == 0 || thuTu_48_Minh == 6)
                            hoatAnh_48_Minh(arrButton_48_Minh[thuTu_48_Minh], 4, Properties.Resources.OQuan2, 500);
                        else
                            hoatAnh_48_Minh(arrButton_48_Minh[thuTu_48_Minh], 4, Properties.Resources.ODan2, 500);
                    }

                    //Tiếp tục lặp lại bằng đệ quy nếu Button kế tiếp theo chiều tăng dần chỉ mục có Text khác O (Có giá trị để lấy) và chỉ mục của ô khác 0 và 6 (khác ô quan):
                    if (!arrButton_48_Minh[noiThuTu_48_Minh(thuTu_48_Minh + 1)].Text.Equals("0") && noiThuTu_48_Minh(thuTu_48_Minh + 1) != 0 && noiThuTu_48_Minh(thuTu_48_Minh + 1) != 6)
                    {
                        thuTu_48_Minh = noiThuTu_48_Minh(thuTu_48_Minh + 1); //Tăng chỉ mục
                        layDa_48_Minh(arrButton_48_Minh[thuTu_48_Minh]);
                        raiDa_48_Minh(ref giaTri_48_Minh, ref thuTu_48_Minh, flag_48_Minh);
                    }
                }
                else //Nếu theo chiều ngược kim đồng hồ (làm tương tự nhưng chỉ mục giảm dần thay vì tăng)
                {
                    arrButton_48_Minh[thuTu_48_Minh].Text = "0";
                    if (thuTu_48_Minh == 0 || thuTu_48_Minh == 6)
                        hoatAnh_48_Minh(arrButton_48_Minh[thuTu_48_Minh], -2, Properties.Resources.OQuan2, 800);
                    else
                        hoatAnh_48_Minh(arrButton_48_Minh[thuTu_48_Minh], -2, Properties.Resources.ODan2, 800);
                    for (int i = 0; i < giaTri_48_Minh; i++)
                    {
                        thuTu_48_Minh = noiThuTu_48_Minh(thuTu_48_Minh - 1);
                        arrButton_48_Minh[thuTu_48_Minh].Text = (int.Parse(arrButton_48_Minh[thuTu_48_Minh].Text) + 1).ToString();
                        if (thuTu_48_Minh == 0 || thuTu_48_Minh == 6)
                            hoatAnh_48_Minh(arrButton_48_Minh[thuTu_48_Minh], 4, Properties.Resources.OQuan2, 500);
                        else
                            hoatAnh_48_Minh(arrButton_48_Minh[thuTu_48_Minh], 4, Properties.Resources.ODan2, 500);
                    }
                    if (!arrButton_48_Minh[noiThuTu_48_Minh(thuTu_48_Minh - 1)].Text.Equals("0") && noiThuTu_48_Minh(thuTu_48_Minh - 1) != 0 && noiThuTu_48_Minh(thuTu_48_Minh - 1)  != 6)
                    {
                        thuTu_48_Minh = noiThuTu_48_Minh(thuTu_48_Minh - 1);
                        layDa_48_Minh(arrButton_48_Minh[thuTu_48_Minh]);
                        raiDa_48_Minh(ref giaTri_48_Minh, ref thuTu_48_Minh, flag_48_Minh);
                    }
                }
            }
            
        }

        protected void congDiem_48_Minh(bool flag_48_Minh)
        {
            if (flag_48_Minh) //Nếu Người chơi hiện tại là người chơi 1
            {
                txtDiem1_48_Minh.Text = (int.Parse(txtDiem1_48_Minh.Text) + giaTri_48_Minh).ToString(); //Tăng điểm người chơi 1 bằng với Text của Button ăn được
                arrButton_48_Minh[thuTu_48_Minh].Text = "0"; //Đặt Text Button bị ăn là 0

                //Hoạt ảnh đặt Button bị ăn về 0:
                if (thuTu_48_Minh == 0 || thuTu_48_Minh == 6)
                    hoatAnh_48_Minh(arrButton_48_Minh[thuTu_48_Minh], 4, Properties.Resources.OQuan2, 1000);
                else
                    hoatAnh_48_Minh(arrButton_48_Minh[thuTu_48_Minh], 4, Properties.Resources.ODan2, 1000);

                //Hoạt ảnh cộng điểm cho người chơi 1:
                hoatAnh_48_Minh(txtDiem1_48_Minh, 4, Color.LightBlue, 1000);
            }
            else //Nếu Người chơi hiện tại là người chơi 2 (tương tự nhưng cộng cho người chơi 2)
            {
                txtDiem2_48_Minh.Text = (int.Parse(txtDiem2_48_Minh.Text) + giaTri_48_Minh).ToString();
                arrButton_48_Minh[thuTu_48_Minh].Text = "0";
                if (thuTu_48_Minh == 0 || thuTu_48_Minh == 6)
                    hoatAnh_48_Minh(arrButton_48_Minh[thuTu_48_Minh], 4, Properties.Resources.OQuan2, 1000);
                else
                    hoatAnh_48_Minh(arrButton_48_Minh[thuTu_48_Minh], 4, Properties.Resources.ODan2, 1000);
                hoatAnh_48_Minh(txtDiem2_48_Minh, 4, Color.LightBlue, 1000);
            } 
        }

        protected void anDa_48_Minh(bool flag_48_Minh)
        {
            if (flag_48_Minh) //Nếu theo chiều kim đồng hồ
                while (arrButton_48_Minh[noiThuTu_48_Minh(thuTu_48_Minh + 1)].Text.Equals("0") && !arrButton_48_Minh[noiThuTu_48_Minh(noiThuTu_48_Minh(thuTu_48_Minh + 1) + 1)].Text.Equals("0"))
                    //Ăn cho đến khi Button kế tiếp bằng 0 và Button tiếp nữa khác 0 theo chiều tăng dần chỉ mục
                {
                    //Hoạt ảnh Text Button kế tiếp là 0:
                    if (noiThuTu_48_Minh(thuTu_48_Minh + 1) == 0 || noiThuTu_48_Minh(thuTu_48_Minh + 1) == 6) 
                        hoatAnh_48_Minh(arrButton_48_Minh[noiThuTu_48_Minh(thuTu_48_Minh + 1)], 0, Properties.Resources.OQuan2, 500);
                    else
                        hoatAnh_48_Minh(arrButton_48_Minh[noiThuTu_48_Minh(thuTu_48_Minh + 1)], 0, Properties.Resources.ODan2, 500);
                    thuTu_48_Minh = noiThuTu_48_Minh(noiThuTu_48_Minh(thuTu_48_Minh + 1) + 1); //Tăng thứ tự lên 2
                    layDa_48_Minh(arrButton_48_Minh[thuTu_48_Minh]); //Lấy đá ô chỉ định
                  
                    if ((thuTu_48_Minh == 0 && lbQuan1_48_Minh.Text.Equals("1")) || (thuTu_48_Minh == 6 && lbQuan2_48_Minh.Text.Equals("1")))
                    //Nếu thứ tự là 0 (ô quan 1) và quan 1 vẫn còn hoặc thứ tự là 6 (ô quan 2) và quan 2 vẫn còn
                    {
                        congDiem_48_Minh(nguoiChoi_48_Minh); //Cộng điểm cho người chơi tương ứng

                        //Cộng điểm quan cho người chơi 1:
                        if (nguoiChoi_48_Minh)
                        { 
                            txtDiemQuan1_48_Minh.Text = (int.Parse(txtDiemQuan1_48_Minh.Text) + 1).ToString();//Cộng điểm quan
                            if (thuTu_48_Minh == 0) //Nếu là Ô Quan 1
                            {
                                lbQuan1_48_Minh.Text = "0"; //Set Ô Quan bị ăn về 0
                                lbQuan1_48_Minh.Update(); //Cập nhật ngay lập tức
                            }
                            else //Nếu là ô quan 2 (tương tự)
                            {
                                lbQuan2_48_Minh.Text = "0";
                                lbQuan2_48_Minh.Update();
                            }
                            hoatAnh_48_Minh(txtDiemQuan1_48_Minh, 4, Color.LightBlue, 1000); //Hiệu ứng ăn quan 
                        }

                        //Cộng điểm quan cho người chơi 2 (tương tự):
                        else
                        {
                            txtDiemQuan2_48_Minh.Text = (int.Parse(txtDiemQuan2_48_Minh.Text) + 1).ToString();
                            if (thuTu_48_Minh == 0)
                            {
                                lbQuan1_48_Minh.Text = "0";
                                lbQuan1_48_Minh.Update();
                            }
                            else
                            {
                                lbQuan2_48_Minh.Text = "0";
                                lbQuan2_48_Minh.Update();   
                            }
                            hoatAnh_48_Minh(txtDiemQuan2_48_Minh, 4, Color.LightBlue, 1000);
                        }
                    }
                    else //Nếu là ô thường
                        congDiem_48_Minh(nguoiChoi_48_Minh);
                }
            else //Theo chiều ngược kim đồng hồ (tương tự nhưng theo chiều giảm dần chỉ mục)
                while (arrButton_48_Minh[noiThuTu_48_Minh(thuTu_48_Minh - 1)].Text.Equals("0") && !arrButton_48_Minh[noiThuTu_48_Minh(noiThuTu_48_Minh(thuTu_48_Minh - 1) - 1)].Text.Equals("0"))
                {
                    if (noiThuTu_48_Minh(thuTu_48_Minh - 1) == 0 || noiThuTu_48_Minh(thuTu_48_Minh - 1) == 6)
                        hoatAnh_48_Minh(arrButton_48_Minh[noiThuTu_48_Minh(thuTu_48_Minh - 1)], 0, Properties.Resources.OQuan2, 500);
                    else
                        hoatAnh_48_Minh(arrButton_48_Minh[noiThuTu_48_Minh(thuTu_48_Minh - 1)], 0, Properties.Resources.ODan2, 500);
                    thuTu_48_Minh = noiThuTu_48_Minh(noiThuTu_48_Minh(thuTu_48_Minh - 1) - 1);
                    layDa_48_Minh(arrButton_48_Minh[thuTu_48_Minh]);
                   
                    if ((thuTu_48_Minh == 0 && lbQuan1_48_Minh.Text.Equals("1")) || (thuTu_48_Minh == 6 && lbQuan2_48_Minh.Text.Equals("1")))
                    {
                        congDiem_48_Minh(nguoiChoi_48_Minh);

                        if (nguoiChoi_48_Minh)
                        {
                            txtDiemQuan1_48_Minh.Text = (int.Parse(txtDiemQuan1_48_Minh.Text) + 1).ToString();
                            if (thuTu_48_Minh == 0)
                            {
                                lbQuan1_48_Minh.Text = "0";
                                lbQuan1_48_Minh.Update();
                            }
                            else
                            {
                                lbQuan2_48_Minh.Text = "0";
                                lbQuan2_48_Minh.Update();
                            }
                            hoatAnh_48_Minh(txtDiemQuan1_48_Minh, 4, Color.LightBlue, 1000);
                        }
                        else
                        {
                            txtDiemQuan2_48_Minh.Text = (int.Parse(txtDiemQuan2_48_Minh.Text) + 1).ToString();
                            if (thuTu_48_Minh == 0)
                            {
                                lbQuan1_48_Minh.Text = "0";
                                lbQuan1_48_Minh.Update();
                            }
                            else
                            {
                                lbQuan2_48_Minh.Text = "0";
                                lbQuan2_48_Minh.Update();
                            }
                            hoatAnh_48_Minh(txtDiemQuan2_48_Minh, 4, Color.LightBlue, 1000);
                        }
                    }
                    else
                        congDiem_48_Minh(nguoiChoi_48_Minh); 
                }
        }

        protected void muonDa_48_Minh()
        {
            if (nguoiChoi_48_Minh) //Nếu là người chơi 1:
            {
                //Đặt Text của Button từ 1 đến 5 là 1 và Enable chúng:
                for (int i = 1; i <= 5; i++)
                {
                    arrButton_48_Minh[i].Text = "1";
                    arrButton_48_Minh[i].Enabled = true;
                }

                //Hoạt ảnh mượn đá:
                hoatAnh_48_Minh(gbPlayer1_48_Minh, 2, Color.LightPink, 1200);

                //Trừ điểm của người chơi đi 5:
                txtDiem1_48_Minh.Text = (int.Parse(txtDiem1_48_Minh.Text) - 5).ToString();

                //Hoạt ảnh trừ điểm:
                hoatAnh_48_Minh(txtDiem1_48_Minh, -2, Color.LightPink, 1200); 
            }
            else //Nếu là người chơi 2 (Tương tự)
            {
                for (int i = 7; i <= 11; i++)
                {
                    arrButton_48_Minh[i].Text = "1";
                    arrButton_48_Minh[i].Enabled = true;
                }
                hoatAnh_48_Minh(gbPlayer2_48_Minh, 2, Color.LightPink, 1200);
                txtDiem2_48_Minh.Text = (int.Parse(txtDiem2_48_Minh.Text) - 5).ToString();
                hoatAnh_48_Minh(txtDiem2_48_Minh, -2, Color.LightPink, 1200);
            }
        }

        protected virtual void doiLuotChoi_48_Minh()
        {
            btnLeft_48_Minh.Visible = false;
            btnRight_48_Minh.Visible = false;
            //Duyệt các Button, Disable các Button là quan và Button có Text là 0, Enable Button còn lại
            foreach (var btn in arrButton_48_Minh)
            {
                if (btn.Text.Equals("0") || btn == arrButton_48_Minh[0] || btn == arrButton_48_Minh[6])
                    btn.Enabled = false;
                else
                    btn.Enabled = true;
            }

            //Đến lượt người chơi nào thì Enable GroupBox phía người chơi đó và Disable phía còn lại:
            gbPlayer1_48_Minh.Enabled = !nguoiChoi_48_Minh;
            gbPlayer2_48_Minh.Enabled = nguoiChoi_48_Minh;
            int dem_48_Minh = 0; // Biến lưu số lượng Button tương ứng phía người chơi có Text bằng 0
            // nếu tất cả 5 Button đều bằng 0 thì mượn đá
            if (nguoiChoi_48_Minh) //Nếu là người chơi 1
            {
                nguoiChoi_48_Minh = false; //Chuyển sang người chơi 2
                txtThoiGian1_48_Minh.Text = "15"; //Set lại thời gian

                //Check mượn đá (nếu dem_48_Minh = 5 thì mượn đá):
                for (int i = 7; i <= 11; i++)
                {
                    if (arrButton_48_Minh[i].Text.Equals("0")) //Nếu Button có Text bằng 0 thì tăng đếm
                        dem_48_Minh++;
                    else
                        break;
                }
                hoatAnh_48_Minh(gbPlayer2_48_Minh, 0, Color.Yellow, 800); //Hoạt ảnh đổi lượt
            }
            else //Nếu là người chơi 2 (Tương tự)
            {
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
            }
            if (dem_48_Minh == 5) //Nếu dem_48_Minh = 0 thì mượn đá
                muonDa_48_Minh();

            giaTri_48_Minh = thuTu_48_Minh = 0;
        }

        protected bool checkGameOver_48_Minh()
        {
            if (arrButton_48_Minh[0].Text.Equals("0") && lbQuan1_48_Minh.Text.Equals("0")
                && arrButton_48_Minh[6].Text.Equals("0") && lbQuan2_48_Minh.Text.Equals("0"))
                //Nếu ô quan đều hết quan và dân
            {
                //Cộng Button còn dân phía người chơi 1(1->5) vào điểm của người chơi 1:
                for (int i = 1; i <= 5; i++)
                {
                    if (!arrButton_48_Minh[i].Text.Equals("0")) //Nếu còn dân
                    {
                        layDa_48_Minh(arrButton_48_Minh[i]);
                        congDiem_48_Minh(true);
                    }
                }
                //Cộng Button còn dân phía người chơi 2(7->11) vào điểm của người chơi 2:
                for (int i = 7; i <= 11; i++)
                {
                    if (!arrButton_48_Minh[i].Text.Equals("0")) //Nếu còn dân
                    {
                        layDa_48_Minh(arrButton_48_Minh[i]);
                        congDiem_48_Minh(false);
                    }
                }
                //Nếu điểm người chơi 1 âm thì cộng một lượng điểm vào cả 2 người chơi để số điểm bằng 0
                if (int.Parse(txtDiem1_48_Minh.Text) < 0)
                {
                    txtDiem2_48_Minh.Text = (int.Parse(txtDiem2_48_Minh.Text) - int.Parse(txtDiem1_48_Minh.Text)).ToString(); //Cộng điểm người chơi 2               
                    txtDiem1_48_Minh.Text = "0"; //Số điểm bằng 0
                    hoatAnh_48_Minh(txtDiem1_48_Minh, 6, Color.LightBlue, 1500); //Hoạt ảnh thay đổi điểm người chơi 1
                    hoatAnh_48_Minh(txtDiem2_48_Minh, 6, Color.LightBlue, 1500); //Hoạt ảnh thay đổi điểm người chơi 1
                }
                //Nếu điểm người chơi 2 âm thì cộng một lượng điểm vào cả 2 người chơi để số điểm bằng 0 (tương tự)
                if (int.Parse(txtDiem2_48_Minh.Text) < 0)
                {
                    txtDiem1_48_Minh.Text = (int.Parse(txtDiem1_48_Minh.Text) - int.Parse(txtDiem2_48_Minh.Text)).ToString();
                    txtDiem2_48_Minh.Text = "0";
                    hoatAnh_48_Minh(txtDiem2_48_Minh, 6, Color.LightBlue, 1500);
                    hoatAnh_48_Minh(txtDiem1_48_Minh, 6, Color.LightBlue, 1500);
                }    
                return true;
            }
            return false;
        }

        protected int checkWinner_48_Minh()
        {
            if (int.Parse(txtDiem1_48_Minh.Text) + 10 * int.Parse(txtDiemQuan1_48_Minh.Text) > int.Parse(txtDiem2_48_Minh.Text) + 10 * int.Parse(txtDiemQuan2_48_Minh.Text))
            //Nếu tổng điểm = điểm + 10 * Số quan ăn được của người chơi 1 lớn hơn người chơi 2
                return 1;
            else if (int.Parse(txtDiem1_48_Minh.Text) + 10 * int.Parse(txtDiemQuan1_48_Minh.Text) < int.Parse(txtDiem2_48_Minh.Text) + 10 * int.Parse(txtDiemQuan2_48_Minh.Text))
            //Ngược lại nếu tổng điểm = điểm + 10 * Số quan ăn được của người chơi 2 lớn hơn người chơi 1
                return -1;
            else
                return 0;
        }

        protected virtual void hienKetQua_48_Minh()
        {
            string thongTin_48_Minh;
            if (checkWinner_48_Minh() == 1) //Nếu người chơi 1 thắng
                thongTin_48_Minh = "NGƯỜI CHIẾN THẮNG: NGƯỜI CHƠI 1!\n\n\n";
            else if (checkWinner_48_Minh() == -1) //Ngược lại nếu người chơi 2 thắng
                thongTin_48_Minh = "NGƯỜI CHIẾN THẮNG: NGƯỜI CHƠI 2!\n\n\n";
            else //Ngược lại nếu 2 người chơi hòa nhau
                thongTin_48_Minh = "HAI NGƯỜI CHƠI HÒA NHAU!\n\n";
            thongTin_48_Minh += String.Format("Người chơi 1:\n\tSố dân ăn được {0}.\n\tSố quan ăn được {1}\n\tTổng điểm {2}\n\n" +
                                            "Người chơi 2:\n\tSố dân ăn được {3}.\n\tSố quan ăn được {4}\n\tTổng điểm {5}\n\n",
                                            txtDiem1_48_Minh.Text, txtDiemQuan1_48_Minh.Text, int.Parse(txtDiem1_48_Minh.Text) + 10 * int.Parse(txtDiemQuan1_48_Minh.Text),
                                            txtDiem2_48_Minh.Text, txtDiemQuan2_48_Minh.Text, int.Parse(txtDiem2_48_Minh.Text) + 10 * int.Parse(txtDiemQuan2_48_Minh.Text));
            MessageBox.Show(thongTin_48_Minh, "Kêt quả_48_Minh", MessageBoxButtons.OK); //MessageBox thông tin ván đấu
            this.Hide();
            docFile_48_Minh("OAnQuan.Resources.Data.txt"); //Đọc dữ liệu mặc định để tạo màn chơi mới
            Application.Restart(); //Khởi động lại chương trình
        }

        public void docFile_48_Minh(String path_48_Minh)
        {
            //Đọc file chứa dữ liệu mặc định từ lần trước
            Assembly assembly_48_Minh = Assembly.GetExecutingAssembly(); //Lấy kết quả biên dịch chương trình
            StreamReader reader_48_Minh = new StreamReader(assembly_48_Minh.GetManifestResourceStream(path_48_Minh)); 
            //Lấy tài nguyên từ kết quả biên dịch thông qua đường dẫn (tên) rồi đọc tài nguyên đó
            try
            {

                nguoiChoi_48_Minh = bool.Parse(reader_48_Minh.ReadLine());
                txtDiem1_48_Minh.Text = reader_48_Minh.ReadLine();
                txtDiemQuan1_48_Minh.Text = reader_48_Minh.ReadLine();
                txtDiem2_48_Minh.Text = reader_48_Minh.ReadLine();
                txtDiemQuan2_48_Minh.Text = reader_48_Minh.ReadLine();
                lbQuan1_48_Minh.Text = reader_48_Minh.ReadLine();
                lbQuan2_48_Minh.Text = reader_48_Minh.ReadLine();
                txtThoiGian1_48_Minh.Text = reader_48_Minh.ReadLine();
                txtThoiGian2_48_Minh.Text = reader_48_Minh.ReadLine();
                foreach (var btn in arrButton_48_Minh)
                {
                    btn.Text = reader_48_Minh.ReadLine();
                    if (btn.Text.Equals("0") || btn == arrButton_48_Minh[0] || btn == arrButton_48_Minh[6])
                        btn.Enabled = false;
                    else
                        btn.Enabled = true;
                }
                //Enable GroupBox của người chơi hiện tại và Disable người chơi kia:
                gbPlayer1_48_Minh.Enabled = nguoiChoi_48_Minh;
                gbPlayer2_48_Minh.Enabled = !nguoiChoi_48_Minh;
                FrmMenu_48_Minh.soNguoiChoi_48_Minh = bool.Parse(reader_48_Minh.ReadLine());

            }
            catch (Exception)
            { }
            finally
            {
                reader_48_Minh.Close();
            }
        }

        public void docFile_48_Minh()
        {
            //Đọc file từ Properties.Settings của chương trình (Chứa dữ liệu chơi dở từ lần trước)
            nguoiChoi_48_Minh = Properties.Settings.Default.nguoiChoi_48_Minh;
            txtDiem1_48_Minh.Text = Properties.Settings.Default.txtDiem1_48_Minh;
            txtDiem2_48_Minh.Text = Properties.Settings.Default.txtDiem2_48_Minh;
            txtDiemQuan1_48_Minh.Text = Properties.Settings.Default.txtDiemQuan1_48_Minh;
            txtDiemQuan2_48_Minh.Text = Properties.Settings.Default.txtDiemQuan2_48_Minh;
            lbQuan1_48_Minh.Text = Properties.Settings.Default.lbQuan1_48_Minh;
            lbQuan2_48_Minh.Text = Properties.Settings.Default.lbQuan2_48_Minh;
            txtThoiGian1_48_Minh.Text = Properties.Settings.Default.txtThoiGian1_48_Minh;
            txtThoiGian2_48_Minh.Text = Properties.Settings.Default.txtThoiGian2_48_Minh;
            btnO0_48_Minh.Text = Properties.Settings.Default.btnO0_48_Minh;
            btnO1_48_Minh.Text = Properties.Settings.Default.btnO1_48_Minh;
            btnO2_48_Minh.Text = Properties.Settings.Default.btnO2_48_Minh;
            btnO3_48_Minh.Text = Properties.Settings.Default.btnO3_48_Minh;
            btnO4_48_Minh.Text = Properties.Settings.Default.btnO4_48_Minh;
            btnO5_48_Minh.Text = Properties.Settings.Default.btnO5_48_Minh;
            btnO6_48_Minh.Text = Properties.Settings.Default.btnO6_48_Minh;
            btnO7_48_Minh.Text = Properties.Settings.Default.btnO7_48_Minh;
            btnO8_48_Minh.Text = Properties.Settings.Default.btnO8_48_Minh;
            btnO9_48_Minh.Text = Properties.Settings.Default.btnO9_48_Minh;
            btnO10_48_Minh.Text = Properties.Settings.Default.btnO10_48_Minh;
            btnO11_48_Minh.Text = Properties.Settings.Default.btnO11_48_Minh;
            foreach (var btn in arrButton_48_Minh)
            {
                if (btn.Text.Equals("0") || btn == arrButton_48_Minh[0] || btn == arrButton_48_Minh[6])
                    btn.Enabled = false;
                else
                    btn.Enabled = true;
            }
            //Enable GroupBox của người chơi hiện tại và Disable người chơi kia:
            gbPlayer1_48_Minh.Enabled = nguoiChoi_48_Minh;
            gbPlayer2_48_Minh.Enabled = !nguoiChoi_48_Minh;
        }

        private void ghiFile_48_Minh()
        {
            //Ghi file vào Properties.Settings của chương trình (Chứa dữ liệu chơi dở)
            Properties.Settings.Default.nguoiChoi_48_Minh = nguoiChoi_48_Minh;
            Properties.Settings.Default.txtDiem1_48_Minh = txtDiem1_48_Minh.Text;
            Properties.Settings.Default.txtDiem2_48_Minh = txtDiem2_48_Minh.Text;
            Properties.Settings.Default.txtDiemQuan1_48_Minh = txtDiemQuan1_48_Minh.Text;
            Properties.Settings.Default.txtDiemQuan2_48_Minh = txtDiemQuan2_48_Minh.Text;
            Properties.Settings.Default.lbQuan1_48_Minh = lbQuan1_48_Minh.Text;
            Properties.Settings.Default.lbQuan2_48_Minh = lbQuan2_48_Minh.Text;
            Properties.Settings.Default.txtThoiGian1_48_Minh = txtThoiGian1_48_Minh.Text;
            Properties.Settings.Default.txtThoiGian2_48_Minh = txtThoiGian2_48_Minh.Text;
            Properties.Settings.Default.btnO0_48_Minh = btnO0_48_Minh.Text;
            Properties.Settings.Default.btnO1_48_Minh = btnO1_48_Minh.Text;
            Properties.Settings.Default.btnO2_48_Minh = btnO2_48_Minh.Text;
            Properties.Settings.Default.btnO3_48_Minh = btnO3_48_Minh.Text;
            Properties.Settings.Default.btnO4_48_Minh = btnO4_48_Minh.Text;
            Properties.Settings.Default.btnO5_48_Minh = btnO5_48_Minh.Text;
            Properties.Settings.Default.btnO6_48_Minh = btnO6_48_Minh.Text;
            Properties.Settings.Default.btnO7_48_Minh = btnO7_48_Minh.Text;
            Properties.Settings.Default.btnO8_48_Minh = btnO8_48_Minh.Text;
            Properties.Settings.Default.btnO9_48_Minh = btnO9_48_Minh.Text;
            Properties.Settings.Default.btnO10_48_Minh = btnO10_48_Minh.Text;
            Properties.Settings.Default.btnO11_48_Minh = btnO11_48_Minh.Text;
            Properties.Settings.Default.soNguoiChoi_48_Minh = FrmMenu_48_Minh.soNguoiChoi_48_Minh;
            Properties.Settings.Default.Save(); //Lưu dữ liệu
        }
       
        public FrmMain2Player_48_Minh()
        {
            InitializeComponent();
            //Khởi tạo arrButton_48_Minh có các phần tử là các Button bên dưới
            arrButton_48_Minh = new List<Button>
            {btnO0_48_Minh, btnO1_48_Minh, btnO2_48_Minh, btnO3_48_Minh, btnO4_48_Minh, btnO5_48_Minh,
             btnO6_48_Minh, btnO7_48_Minh, btnO8_48_Minh, btnO9_48_Minh, btnO10_48_Minh, btnO11_48_Minh};
            for (int i = 0; i < arrButton_48_Minh.Count; i++)
                arrButton_48_Minh[i].Click += new EventHandler(arrButton_48_Minh_Click); //Gắn sự kiện click
        }

        private void arrButton_48_Minh_Click(object sender, EventArgs e)
        {
            Button btn_48_Minh = (Button)sender;
            btnLeft_48_Minh.Visible = true;
            btnRight_48_Minh.Visible = true;
            layDa_48_Minh(btn_48_Minh);
        }

        private void btnLeft_48_Minh_Click(object sender, EventArgs e)
        {
            tThoiGian_48_Minh.Stop();
            raiDa_48_Minh(ref giaTri_48_Minh, ref thuTu_48_Minh, !nguoiChoi_48_Minh);
            anDa_48_Minh(!nguoiChoi_48_Minh);
            if (checkGameOver_48_Minh()) //Nếu game kết thúc
                hienKetQua_48_Minh();
            else
                doiLuotChoi_48_Minh();
            tThoiGian_48_Minh.Start();
        }

        private void btnRight_48_Minh_Click(object sender, EventArgs e)
        {
            tThoiGian_48_Minh.Stop();
            raiDa_48_Minh(ref giaTri_48_Minh, ref thuTu_48_Minh, nguoiChoi_48_Minh);
            anDa_48_Minh(nguoiChoi_48_Minh);          
            if (checkGameOver_48_Minh()) //Nếu game kết thúc
                hienKetQua_48_Minh();
            else
                doiLuotChoi_48_Minh();
            tThoiGian_48_Minh.Start();
        }

        private void tThoiGian_48_Minh_Tick(object sender, EventArgs e)
        {
            if (nguoiChoi_48_Minh) //Nếu là người chơi 1
                //Giảm giá trị Text của txtThoiGian1_48_Minh đi 1 khi Tick
                txtThoiGian1_48_Minh.Text = String.Format("{0:00}", int.Parse(txtThoiGian1_48_Minh.Text) - 1);
            else //Nếu là người chơi 2 (tương tự)
                txtThoiGian2_48_Minh.Text = String.Format("{0:00}", int.Parse(txtThoiGian2_48_Minh.Text) - 1);
            if (int.Parse(txtThoiGian1_48_Minh.Text) == -1 || int.Parse(txtThoiGian2_48_Minh.Text) == -1)
            //Nếu Text giảm về -1 thì chọn mặc định Button đầu tiên có thể để chơi:
            {
                tThoiGian_48_Minh.Stop();
                foreach (Button btn in arrButton_48_Minh)
                    if (btn.Enabled == true)
                    {
                        layDa_48_Minh(btn);
                        raiDa_48_Minh(ref giaTri_48_Minh, ref thuTu_48_Minh, nguoiChoi_48_Minh);
                        anDa_48_Minh(nguoiChoi_48_Minh);                     
                        if (checkGameOver_48_Minh())
                            hienKetQua_48_Minh();
                        doiLuotChoi_48_Minh();
                        break;
                    }
                tThoiGian_48_Minh.Start();
            }    
        }

        private void FrmMain_48_Minh_FormClosing(object sender, FormClosingEventArgs e)
        {
            ghiFile_48_Minh(); //Ghi file khi đóng form mà đang chơi dở
            Application.Exit();
        }

        protected virtual void btnMenu_48_Minh_Click(object sender, EventArgs e)
        {
            //Chuyển sang form menu:
            tThoiGian_48_Minh.Stop();
            FrmMenu_48_Minh.frmMenu_48_Minh.Size = FrmMenu_48_Minh.frmMain2_48_Minh.Size;
            FrmMenu_48_Minh.frmMenu_48_Minh.Location = FrmMenu_48_Minh.frmMain2_48_Minh.Location;
            FrmMenu_48_Minh.frmMenu_48_Minh.Show();
            this.Hide();
        }

        private void FrmMain2Player_48_Minh_Load(object sender, EventArgs e)
        {
            tThoiGian_48_Minh.Enabled = true;
        }
    }

}
