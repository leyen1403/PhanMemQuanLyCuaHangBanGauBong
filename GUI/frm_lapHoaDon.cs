using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UC;

namespace GUI
{
    public partial class frm_lapHoaDon : Form
    {
        ProductItem productSelected = null;
        private Timer timer;

        public frm_lapHoaDon()
        {
            InitializeComponent();
            this.Load += Frm_lapHoaDon_Load;
            // Khởi tạo Timer
            timer = new Timer();
            timer.Interval = 1000; // Cài đặt thời gian 1 giây (1000 ms)
            timer.Tick += Timer_Tick; ; // Gán sự kiện Tick
            timer.Start(); // Bắt đầu Timer
            loadNgayHT();

        }

        private void dsSanPham_Paint(object sender, PaintEventArgs e)
        {
            //using (Pen pen = new Pen(Color.Navy, 2)) // Màu xanh, độ dày 2 pixel
            //{
            //    e.Graphics.DrawRectangle(pen, 0, 0, dsSanPham.Width - 1, dsSanPham.Height - 1);
            //}
        }

        private void Frm_lapHoaDon_Load(object sender, EventArgs e)
        {
            txt_tenSanPham.Text = "Nhập thông tin sản phẩm";
            txt_tenSanPham.ForeColor = Color.Gray;
            this.txt_tenSanPham.Enter += Txt_tenSanPham_Enter;
            this.txt_tenSanPham.Leave += Txt_tenSanPham_Leave;
            dsSanPham.AutoScroll = true;
            loadSanPham();

        }

        private void loadSanPham()
        {
            dsSanPham.Controls.Clear();

            int controlWidth = 165;
            int controlHeight = 170;
            int spacing = 15;
            int panelWidth = dsSanPham.ClientSize.Width;

            int currentX = 10; // Vị trí X bắt đầu
            int currentY = 10; // Vị trí Y bắt đầu

            for (int i = 0; i < 50; i++)
            {
                ProductItem myControl = new ProductItem();
                myControl.Click += MyControl_Click;
                myControl.MouseEnter += MyControl_MouseEnter;
                myControl.MouseLeave += MyControl_MouseLeave;
                myControl.Size = new Size(controlWidth, controlHeight);
                myControl.Location = new Point(currentX, currentY);
                dsSanPham.Controls.Add(myControl);
                currentX += controlWidth + spacing;
                if (currentX + controlWidth > panelWidth)
                {
                    currentX = 10;
                    currentY += controlHeight + spacing;
                }
            }
            foreach (ProductItem myControl in dsSanPham.Controls)
            {

            }
            dsSanPham.AutoScrollMinSize = new Size(0, currentY + controlHeight + spacing);
        }

        private void MyControl_MouseLeave(object sender, EventArgs e)
        {
            var hoverItem = sender as ProductItem;
            if (hoverItem != null && !hoverItem.IsSelected) // Chỉ thay đổi màu nếu không được chọn
            {
                hoverItem.BackColor = Color.White;
            }
        }

        private void MyControl_MouseEnter(object sender, EventArgs e)
        {
            var hoverItem = sender as ProductItem;
            if (hoverItem != null && !hoverItem.IsSelected) // Chỉ thay đổi màu nếu không được chọn
            {
                hoverItem.BackColor = Color.LightCyan;
            }
        }

        private void MyControl_Click(object sender, EventArgs e)
        {
            var clickItem = sender as ProductItem;
            if (clickItem != null)
            {
                if (productSelected != null && productSelected != clickItem)
                {
                    productSelected.IsSelected = false; // Bỏ chọn sản phẩm đã chọn
                }
                productSelected = clickItem;
                productSelected.IsSelected = true; // Đánh dấu sản phẩm hiện tại là được chọn
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            loadNgayHT();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void Txt_tenSanPham_Enter(object sender, EventArgs e)
        {
            if (txt_tenSanPham.Text == "Nhập thông tin sản phẩm")
            {
                txt_tenSanPham.Text = string.Empty;
                txt_tenSanPham.ForeColor = Color.Black;
            }
        }


        private void Txt_tenSanPham_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_tenSanPham.Text))
            {
                txt_tenSanPham.Text = "Nhập thông tin sản phẩm";
                txt_tenSanPham.ForeColor = Color.Gray;
            }
        }

        public void loadNgayHT()
        {
            DateTime currentDateTime = DateTime.Now;

            // Định dạng ngày theo dd/MM/yyyy
            string formattedDate = currentDateTime.ToString("dd/MM/yyyy HH:mm:ss");

            // Hiển thị ra giao diện, ví dụ, vào một Label
            label_ngayHT.Text = formattedDate; // lblNgayHT là tên Label để hiển thị ngày giờ
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
