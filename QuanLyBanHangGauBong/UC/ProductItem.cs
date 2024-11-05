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
        private int _borderRadius = 20; // Bán kính bo tròn
        public Image ProductImage
        {
            get { return productImage.Image; }
            set { productImage.Image = value; }
        }
        public new string ProductName
        {
            get { return productName.Text; }
            set { productName.Text = value; }
        }
        public string ProductPrice
        {
            get { return productPrice.Text; }
            set { productPrice.Text = value; }
        }
        public ProductItem()
        {
            InitializeComponent();
            this.Paint += ProductItem_Paint;
        }

        // Hàm xử lý sự kiện Paint
        private void ProductItem_Paint(object sender, PaintEventArgs e)
        {
            SetRoundedShape(this, _borderRadius);
        }

        // Hàm bo tròn UserControl
        private void SetRoundedShape(Control control, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = control.ClientRectangle;
            float diameter = radius * 2;

            // Vẽ các góc bo tròn
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);                  // Góc trên-trái
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);   // Góc trên-phải
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);  // Góc dưới-phải
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);   // Góc dưới-trái
            path.CloseFigure();

            // Áp dụng bo tròn cho UserControl
            control.Region = new Region(path);
        }

    }
}
