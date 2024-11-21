using BLL;
using DevExpress.XtraExport.Helpers;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_QuanLyPhieuHoanTra : Form
    {
        List<PhieuHoanTra> listPhieuHoanTra = new List<PhieuHoanTra>();
        PhieuHoanTraBLL phieuHoanTraBLL = new PhieuHoanTraBLL();
        List<ChiTietPhieuHoanTra> listCTPhieuHoanTra = new List<ChiTietPhieuHoanTra>();
        ChiTietPhieuHoanTraBLL chiTietPhieuHoanTraBLL = new ChiTietPhieuHoanTraBLL();
        NhanVienBLL nhanVienBLL = new NhanVienBLL();
        private BindingList<ChiTietPhieuHoanTra> bindingList = new BindingList<ChiTietPhieuHoanTra>();
        public frm_QuanLyPhieuHoanTra()
        {
            InitializeComponent();
            this.Load += Frm_QuanLyPhieuHoanTra_Load;
            this.btnTim.Click += BtnTim_Click;
            dgvPhieuHoanTra.SelectionChanged += DgvPhieuHoanTra_SelectionChanged;
            this.btnThemPHT.Click += BtnThemPHT_Click;
            this.btnHuyPhieu.Click += BtnHuyPhieu_Click;
            this.btnLuuPhieu.Click += BtnLuuPhieu_Click;
            this.deleteMenuItem.Click += DeleteMenuItem_Click;
        }
        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvChiTietPhieuHoanTra.CurrentRow != null)
            {
                // Lấy MaChiTietPhieuHoanTra của dòng hiện tại
                string maPhieuHoanTra = dgvChiTietPhieuHoanTra.CurrentRow.Cells["MaPhieuHoanTra"].Value.ToString();

                // Tìm và xóa sản phẩm trong BindingList dựa trên MaChiTietPhieuHoanTra
                var itemToRemove = bindingList.FirstOrDefault(ct => ct.MaPhieuHoanTra == maPhieuHoanTra);
                if (itemToRemove != null)
                {
                    bindingList.Remove(itemToRemove); // Xóa từ BindingList
                }

                // Để DataGridView cập nhật, gán lại DataSource của dgvChiTietPhieuHoanTra với bindingList
                dgvChiTietPhieuHoanTra.DataSource = null;
                dgvChiTietPhieuHoanTra.DataSource = bindingList;

                // Cập nhật lại giao diện
                dgvChiTietPhieuHoanTra.Refresh();

                MessageBox.Show("Sản phẩm đã được xóa khỏi chi tiết phiếu hoàn trả.");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.");
            }
        }

        private void BtnLuuPhieu_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnHuyPhieu_Click(object sender, EventArgs e)
        {
            string maPHT = txtMaPHT.Text;
            bool isSuccess = phieuHoanTraBLL.DeletePhieuHoanTra(maPHT);
            if (isSuccess)
            {
                MessageBox.Show("Xóa phiếu hoàn trả thành công.");
                listPhieuHoanTra = phieuHoanTraBLL.GetAllPhieuHoanTra();
                dgvPhieuHoanTra.DataSource = listPhieuHoanTra;
                anhXaPhieuHoanTra();
            }
            else
            {
                MessageBox.Show("Xóa thất bại.");
            }
        }

        private void BtnTaoMoi_Click(object sender, EventArgs e)
        {
            cbbLuaChonHienThi.SelectedIndex = 0;
            loadCbbMaNhanVien();
            loadCbbNhanVien();
            dtpTuNgay.Value = DateTime.Now;
            dtpDenNgay.Value = DateTime.Now;
            txtMaPHT.Clear();
            txtTongSoLuong.Clear();
            dTPNgayLap.Value = DateTime.Now;
            dTPNgayCapNhat.Value = DateTime.Now;
        }

        private void BtnThemPHT_Click(object sender, EventArgs e)
        {

        }

        private void DgvPhieuHoanTra_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhieuHoanTra.CurrentRow != null)
            {
                DataGridViewRow currentRow = dgvPhieuHoanTra.CurrentRow;
                txtMaPHT.Text = currentRow.Cells["MaPhieuHoanTra"].Value?.ToString();
                txtTongSoLuong.Text = currentRow.Cells["LanNhap"].Value?.ToString();
                cbbNhanVien.SelectedValue = currentRow.Cells["MaNhanVien"].Value?.ToString();
                //cbbTinhTrang.SelectedValue = currentRow.Cells["TinhTrang"].Value?.ToString(); // bị lỗi nha
                dTPNgayLap.Value = Convert.ToDateTime(currentRow.Cells["NgayLap"].Value);
                dTPNgayCapNhat.Value = Convert.ToDateTime(currentRow.Cells["NgayCapNhat"].Value);
                loadChiTietPhieuHoanTra(txtMaPHT.Text);
            }
            else
            {
                Console.WriteLine("Không có dòng nào được chọn.");
            }
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            string selectedValue = cbbLuaChonHienThi.SelectedItem.ToString();
            if (selectedValue == "Tất cả phiếu hoàn trả")
            {
                listPhieuHoanTra = phieuHoanTraBLL.GetAllPhieuHoanTra();
                dgvPhieuHoanTra.DataSource = listPhieuHoanTra;
                anhXaPhieuHoanTra();
            }
        }
        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            string rowIdx = (e.RowIndex + 1).ToString();

            System.Drawing.Font rowFont = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);

            var leftFormat = new System.Drawing.StringFormat()
            {
                Alignment = System.Drawing.StringAlignment.Near, // Căn trái
                LineAlignment = System.Drawing.StringAlignment.Center // Giữa theo chiều dọc
            };

            System.Drawing.Rectangle headerBounds = new System.Drawing.Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.Columns[0].Width, e.RowBounds.Height);

            e.Graphics.DrawString(rowIdx, rowFont, System.Drawing.SystemBrushes.ControlText, headerBounds, leftFormat);
        }
        private void loadDSPhieuHoanTra()
        {
            dgvPhieuHoanTra.Columns["MaPhieuHoanTra"].HeaderText = "Mã phiếu hoàn trả";
            dgvPhieuHoanTra.Columns["NgayLap"].HeaderText = "Ngày lập";
            dgvPhieuHoanTra.Columns["NgayCapNhat"].HeaderText = "Ngày cập nhật";
            dgvPhieuHoanTra.Columns["TinhTrang"].HeaderText = "Tình trạng";
            dgvPhieuHoanTra.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            dgvPhieuHoanTra.Columns["TongSoLuong"].HeaderText = "Tổng số lượng";

            // Căn giữa tiêu đề cột và chỉnh font chữ
            foreach (DataGridViewColumn column in dgvPhieuHoanTra.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            }
            dgvPhieuHoanTra.RowPostPaint += dgv_RowPostPaint;
        }
        private void anhXaPhieuHoanTra()
        {
            if (listPhieuHoanTra != null && listPhieuHoanTra.Count > 0)
            {
                var ds = from pht in listPhieuHoanTra
                         select new
                         {
                             MaPhieuHoanTra = pht.MaPhieuHoanTra,
                             NgayLap = pht.NgayLap,
                             NgayCapNhat = pht.NgayCapNhat,
                             TinhTrang = pht.TinhTrang,
                             MaNhanVien = pht.MaNhanVien,
                             TongSoLuong = pht.TongSoLuong
                         };
                dgvPhieuHoanTra.DataSource = ds.ToList();
                loadDSPhieuHoanTra();
            }
        }
        private void loadChiTietPhieuHoanTra(string maPHT)
        {
            listCTPhieuHoanTra = chiTietPhieuHoanTraBLL.GetChiTietPhieuHoanTra(maPHT);
            bindingList = new BindingList<ChiTietPhieuHoanTra>(listCTPhieuHoanTra);
            dgvChiTietPhieuHoanTra.DataSource = bindingList;
        }
        private void loadCbbMaNhanVien()
        {
            List<NhanVien> listNV = nhanVienBLL.getAllNhanVien();
            cbbNhanVien.DataSource = listNV;
            cbbNhanVien.DisplayMember = "TenNhanVien";
            cbbNhanVien.ValueMember = "MaNhanVien";
        }
        private void loadCbbNhanVien()
        {
            List<NhanVien> listNhanVien = nhanVienBLL.getAllNhanVien();
            cbbNhanVien.DataSource = listNhanVien;
            cbbNhanVien.DisplayMember = "TenNhanVien";
            cbbNhanVien.ValueMember = "MaNhanVien";
        }
  
    private void Frm_QuanLyPhieuHoanTra_Load(object sender, EventArgs e)
        {
            // Load dữ liệu cho các combobox và DataGridView khi form được tải
            loadCbbMaNhanVien();
            loadCbbNhanVien();
            listPhieuHoanTra = phieuHoanTraBLL.GetAllPhieuHoanTra();
            dgvPhieuHoanTra.DataSource = listPhieuHoanTra;
            anhXaPhieuHoanTra();
        }
    }
}
