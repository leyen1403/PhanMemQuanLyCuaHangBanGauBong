using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public class PlaceHolder
    {
        // Hàm thiết lập placeholder cho TextBox
        public static void SetPlaceholder(TextBox txtBox, string placeholderText)
        {
            // Gán placeholder khi TextBox rỗng và không có focus
            if (string.IsNullOrWhiteSpace(txtBox.Text))
            {
                txtBox.ForeColor = Color.Gray;  // Đặt màu chữ cho placeholder
                txtBox.Text = placeholderText;  // Đặt text là placeholder
            }

            // Khi người dùng bắt đầu nhập vào TextBox
            txtBox.Enter += (sender, e) =>
            {
                if (txtBox.Text == placeholderText)
                {
                    txtBox.Text = "";  // Xóa placeholder khi focus
                    txtBox.ForeColor = Color.Black;  // Đặt lại màu chữ khi người dùng nhập
                }
            };

            // Khi người dùng rời khỏi TextBox và không nhập gì
            txtBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtBox.Text))
                {
                    txtBox.ForeColor = Color.Gray;  // Đặt màu chữ thành màu placeholder
                    txtBox.Text = placeholderText;  // Hiển thị lại placeholder nếu rời khỏi mà không nhập
                }
            };
        }
    }
}
