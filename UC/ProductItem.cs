using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace UC
{
    public partial class ProductItem: UserControl
    {

        private Color originalBackColor; // Màu nền ban đầu
        private Color hoverBackColor = Color.LightSkyBlue; // Màu nền khi hover
        private bool isSelected;
        public bool IsSelected // Thuộc tính để kiểm tra trạng thái được chọn
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                this.BackColor = isSelected ? Color.LightBlue : Color.White; // Thay đổi màu nền theo trạng thái
            }
        }

        //public event EventHandler hover;
        public ProductItem()
        {
            InitializeComponent();
            this.Paint += ProductItem_Paint;

            originalBackColor = this.BackColor; // Lưu màu nền ban đầu
            //this.MouseEnter += ProductItem_MouseEnter;
            //this.MouseLeave += ProductItem_MouseLeave;

            // Đảm bảo rằng tất cả các điều khiển con không ngăn chặn sự kiện chuột
            foreach (Control control in this.Controls)
            {
                control.MouseEnter += (s, e) => this.OnMouseEnter(e);
                control.MouseLeave += (s, e) => this.OnMouseLeave(e);
            }

        }

        //private void ProductItem_MouseLeave(object sender, EventArgs e)
        //{
        //    this.BackColor = originalBackColor; // Khôi phục màu nền khi rời khỏi
        //    this.Invalidate(); // Yêu cầu vẽ lại để hiển thị viền
        //}

        //private void ProductItem_MouseEnter(object sender, EventArgs e)
        //{
        //    this.BackColor = hoverBackColor; // Thay đổi màu nền khi hover
        //    this.Invalidate(); // Yêu cầu vẽ lại để hiển thị viền
        //}

        private void ProductItem_Paint(object sender, PaintEventArgs e)
        {
            // Định nghĩa màu viền và độ dày viền
            Color borderColor = Color.Navy;
            int borderWidth = 1;

            // Tạo bút vẽ viền
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                // Vẽ viền cho 4 cạnh
                // Viền trên
                e.Graphics.DrawLine(pen, 0, 0, this.Width, 0);

                // Viền dưới
                e.Graphics.DrawLine(pen, 0, this.Height - 1, this.Width, this.Height - 1);

                // Viền trái
                e.Graphics.DrawLine(pen, 0, 0, 0, this.Height);

                // Viền phải
                e.Graphics.DrawLine(pen, this.Width - 1, 0, this.Width - 1, this.Height);
            }
        }
        // Thuộc tính để thiết lập tên sản phẩm
        public string TenSanPham
        {
            get { return label_tenSanPham.Text; }
            set { label_tenSanPham.Text = value; }
        }

    }
}
