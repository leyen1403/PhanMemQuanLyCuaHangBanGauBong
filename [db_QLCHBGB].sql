create database [db_QLCHBGB]
go
USE [db_QLCHBGB]
GO
/****** Object:  Table [dbo].[ChiTietDonDatHang]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonDatHang](
	[MaChiTietDonDatHang] [nvarchar](10) NOT NULL,
	[MaDonDatHang] [nvarchar](10) NULL,
	[DonViTinh] [nvarchar](100) NULL,
	[SoLuongYeuCau] [int] NULL,
	[SoLuongCungCap] [int] NULL,
	[SoLuongThieu] [int] NULL,
	[DonGia] [decimal](10, 2) NULL,
	[ThanhTien] [decimal](12, 2) NULL,
	[TrangThai] [nvarchar](100) NULL,
	[GhiChu] [nvarchar](255) NULL,
	[MaSanPham] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChiTietDonDatHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDonBanHang]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDonBanHang](
	[MaChiTietHoaDonBanHang] [nvarchar](10) NOT NULL,
	[MaHoaDon] [nvarchar](10) NULL,
	[MaSanPham] [nvarchar](10) NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](10, 2) NULL,
	[ThanhTien] [decimal](10, 2) NULL,
	[GhiChu] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChiTietHoaDonBanHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuHoanTra]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuHoanTra](
	[MaPhieuHoanTra] [nvarchar](10) NOT NULL,
	[MaChiTietPhieuNhap] [nvarchar](10) NOT NULL,
	[SoLuong] [int] NULL,
	[LyDo] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuHoanTra] ASC,
	[MaChiTietPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuKiemKe]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuKiemKe](
	[MaPhieuKiemKe] [nvarchar](10) NOT NULL,
	[MaSanPham] [nvarchar](10) NOT NULL,
	[SoLuongHeThong] [int] NULL,
	[SoLuongThucTe] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuKiemKe] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[MaChiTietPhieuNhap] [nvarchar](10) NOT NULL,
	[MaPhieuNhap] [nvarchar](10) NULL,
	[DonViTinh] [nvarchar](20) NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](10, 2) NULL,
	[ThanhTien] [decimal](10, 2) NULL,
	[TrangThai] [nvarchar](100) NULL,
	[GhiChu] [nvarchar](255) NULL,
	[MaChiTietDonDatHang] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChiTietPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonDatHang]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonDatHang](
	[MaDonDatHang] [nvarchar](10) NOT NULL,
	[NgayDat] [date] NULL,
	[TongTien] [decimal](12, 2) NULL,
	[TrangThai] [nvarchar](255) NULL,
	[NgayTao] [date] NULL,
	[NgayCapNhat] [date] NULL,
	[MaNhaCungCap] [nvarchar](10) NULL,
	[MaNhanVien] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDonDatHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonBanHang]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonBanHang](
	[MaHoaDonBanHang] [nvarchar](10) NOT NULL,
	[NgayLap] [date] NULL,
	[TongSanPham] [int] NULL,
	[TongTien] [decimal](10, 2) NULL,
	[DiemCongTichLuy] [decimal](10, 2) NULL,
	[DiemTichLuy] [decimal](10, 2) NULL,
	[MaKhachHang] [nvarchar](10) NULL,
	[MaNhanVien] [nvarchar](10) NULL,
		[PhuongThucThanhToan] [nchar](200) NULL,
	[HinhThucGiaoHang] [nchar](200) NULL,
	[TrangThaiDonHang] [nchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHoaDonBanHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [nvarchar](10) NOT NULL,
	[TenKhachHang] [nvarchar](100) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[SoDienThoai] [nvarchar](11) NULL,
	[Email] [nvarchar](100) NULL,
	[DiemTichLuy] [decimal](10, 2) NULL,
	[TaiKhoan] [nvarchar](100) NULL,
	[MatKhau] [nvarchar](100) NULL,
	[HinhAnh] [nvarchar](255) NULL,
	[TrangThai] [bit] NULL,
	[NgayTao] [date] NULL,
	[NgayCapNhat] [date] NULL,
	[ThanhVien] [bit] NULL,
	[DiaChi] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KichThuoc]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KichThuoc](
	[MaKichThuoc] [nvarchar](10) NOT NULL,
	[TenKichThuoc] [nvarchar](255) NULL,
	[MoTa] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKichThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[MaLoai] [nvarchar](10) NOT NULL,
	[TenLoai] [nvarchar](100) NULL,
	[MoTa] [nvarchar](255) NULL,
	[HinhAnh] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManHinh]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManHinh](
	[MaManHinh] [nvarchar](10) NOT NULL,
	[TenManHinh] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaManHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MauSac]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MauSac](
	[MaMau] [nvarchar](10) NOT NULL,
	[TenMau] [nvarchar](100) NULL,
	[MoTa] [nvarchar](255) NULL,
	[HinhAnh] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNhaCungCap] [nvarchar](10) NOT NULL,
	[TenNhaCungCap] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[NguoiDaiDien] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[SoDienThoai] [nvarchar](11) NULL,
	[TrangThai] [bit] NULL,
	[NgayTao] [date] NULL,
	[NgayCapNhat] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhaCungCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [nvarchar](10) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[ChucVu] [nvarchar](100) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[SoDienThoai] [nvarchar](11) NULL,
	[Email] [nvarchar](100) NULL,
	[TaiKhoan] [nvarchar](100) NULL,
	[MatKhau] [nvarchar](100) NULL,
	[HinhAnh] [nvarchar](255) NULL,
	[TrangThai] [bit] NULL,
	[NgayTao] [date] NULL,
	[NgayCapNhat] [date] NULL,
	[DiaChi] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien_ManHinh]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien_ManHinh](
	[MaNhanVien] [nvarchar](10) NOT NULL,
	[MaManHinh] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC,
	[MaManHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhatKyDichVu]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhatKyDichVu](
	[Landichvu] [int] NOT NULL,
	[MaChiTietHoaDonBanHang] [nvarchar](10) NOT NULL,
	[MaPhieuDichVu] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Landichvu] ASC,
	[MaChiTietHoaDonBanHang] ASC,
	[MaPhieuDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuDichVu]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuDichVu](
	[MaPhieuDichVu] [nvarchar](10) NOT NULL,
	[NgayLap] [date] NULL,
	[TongTien] [decimal](10, 2) NULL,
	[MaKhachHang] [nvarchar](10) NULL,
	[MaNhanVien] [nvarchar](10) NULL,
	[GhiChu] [nvarchar](255) NULL,
	[TrangThai] [bit] NULL,
	[NgayTao] [date] NULL,
	[NgayCapNhat] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuDoiTra]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuDoiTra](
	[MaPhieuDoiTra] [nvarchar](10) NOT NULL,
	[NgayLap] [date] NULL,
	[LyDoDoiTra] [nvarchar](255) NULL,
	[TinhTrangSanPham] [nvarchar](255) NULL,
	[LoaiDoiTra] [nvarchar](30) NULL,
	[SoLuong] [int] NULL,
	[TongTienHoanLai] [decimal](10, 2) NULL,
	[GhiChuThem] [nvarchar](255) NULL,
	[NgayTao] [date] NULL,
	[NgayCapNhat] [date] NULL,
	[TrangThai] [bit] NULL,
	[MaNhanVien] [nvarchar](10) NULL,
	[MaChiTietDonBanHang] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuDoiTra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuHoanTra]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuHoanTra](
	[MaPhieuHoanTra] [nvarchar](10) NOT NULL,
	[NgayLap] [date] NULL,
	[TongSoLuong] [int] NULL,
	[NgayCapNhat] [date] NULL,
	[TinhTrang] [nvarchar](255) NULL,
	[MaNhanVien] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuHoanTra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuKiemKe]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuKiemKe](
	[MaPhieuKiemKe] [nvarchar](10) NOT NULL,
	[NgayLap] [date] NULL,
	[GhiChu] [nvarchar](255) NULL,
	[MaNhanVien] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuKiemKe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPhieuNhap] [nvarchar](10) NOT NULL,
	[NgayLap] [date] NULL,
	[TongTien] [decimal](10, 2) NULL,
	[TrangThai] [nvarchar](100) NULL,
	[LanNhap] [int] NULL,
	[MaDonDatHang] [nvarchar](10) NULL,
	[MaNhanVien] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [nvarchar](10) NOT NULL,
	[TenSanPham] [nvarchar](255) NULL,
	[DonViTinh] [nvarchar](100) NULL,
	[SoLuongTon] [int] NULL,
	[SoLuongToiThieu] [int] NULL,
	[GiaNhap] [decimal](10, 2) NULL,
	[GiaBan] [decimal](10, 2) NULL,
	[MoTa] [nvarchar](255) NULL,
	[HinhAnh] [nvarchar](255) NULL,
	[TrangThai] [bit] NULL,
	[NgayTao] [date] NULL,
	[NgayCapNhat] [date] NULL,
	[MaLoai] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham_KichThuoc]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham_KichThuoc](
	[MaSanPham] [nvarchar](10) NOT NULL,
	[MaKichThuoc] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC,
	[MaKichThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham_MauSac]    Script Date: 11/11/2024 1:56:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham_MauSac](
	[MaSanPham] [nvarchar](10) NOT NULL,
	[MaMau] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC,
	[MaMau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [DonViTinh], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien], [TrangThai], [GhiChu], [MaSanPham]) VALUES (N'CTDDH001', N'DDH001', N'Cái', 100, 0, 50, CAST(100000.00 AS Decimal(10, 2)), CAST(10000000.00 AS Decimal(12, 2)), N'Chưa xác nhận', N'', N'SP001')
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [DonViTinh], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien], [TrangThai], [GhiChu], [MaSanPham]) VALUES (N'CTDDH002', N'DDH002', N'Cái', 10, 0, 66, CAST(800000.00 AS Decimal(10, 2)), CAST(8000000.00 AS Decimal(12, 2)), N'Chưa xác nhận', N'', N'SP002')
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [DonViTinh], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien], [TrangThai], [GhiChu], [MaSanPham]) VALUES (N'CTDDH003', N'DDH003', N'Cái', 300, 0, 50, CAST(100000.00 AS Decimal(10, 2)), CAST(30000000.00 AS Decimal(12, 2)), N'Chưa xác nhận', N'', N'SP001')
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [DonViTinh], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien], [TrangThai], [GhiChu], [MaSanPham]) VALUES (N'CTDDH004', N'DDH004', N'Cái', 40, 0, 66, CAST(800000.00 AS Decimal(10, 2)), CAST(32000000.00 AS Decimal(12, 2)), N'Chưa xác nhận', N'', N'SP002')
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [DonViTinh], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien], [TrangThai], [GhiChu], [MaSanPham]) VALUES (N'CTDDH005', N'DDH004', N'Cái', 10, 0, 10, CAST(500000.00 AS Decimal(10, 2)), CAST(5000000.00 AS Decimal(12, 2)), N'Chưa xác nhận', N'', N'SP003')
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [DonViTinh], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien], [TrangThai], [GhiChu], [MaSanPham]) VALUES (N'CTDDH006', N'DDH004', N'Cái', 20, 0, 10, CAST(270000.00 AS Decimal(10, 2)), CAST(5400000.00 AS Decimal(12, 2)), N'Chưa xác nhận', N'', N'SP004')
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [DonViTinh], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien], [TrangThai], [GhiChu], [MaSanPham]) VALUES (N'CTDDH007', N'DDH004', N'Cái', 100, 0, 50, CAST(100000.00 AS Decimal(10, 2)), CAST(10000000.00 AS Decimal(12, 2)), N'Chưa xác nhận', N'', N'SP001')
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [DonViTinh], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien], [TrangThai], [GhiChu], [MaSanPham]) VALUES (N'CTDDH008', N'DDH004', N'Cái', 60, 0, 10, CAST(120000.00 AS Decimal(10, 2)), CAST(7200000.00 AS Decimal(12, 2)), N'Chưa xác nhận', N'', N'SP006')
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [DonViTinh], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien], [TrangThai], [GhiChu], [MaSanPham]) VALUES (N'CTDDH009', N'DDH008', N'Cái', 100, 0, 66, CAST(800000.00 AS Decimal(10, 2)), CAST(80000000.00 AS Decimal(12, 2)), N'Chưa xác nhận', N'', N'SP002')
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [DonViTinh], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien], [TrangThai], [GhiChu], [MaSanPham]) VALUES (N'CTDDH010', N'DDH009', N'Cái', 700, 700, 0, CAST(800000.00 AS Decimal(10, 2)), CAST(560000000.00 AS Decimal(12, 2)), N'Chưa xác nhận', N'', N'SP002')
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [DonViTinh], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien], [TrangThai], [GhiChu], [MaSanPham]) VALUES (N'CTDDH011', N'DDH009', N'Cái', 200, 200, 0, CAST(500000.00 AS Decimal(10, 2)), CAST(100000000.00 AS Decimal(12, 2)), N'Chưa xác nhận', N'', N'SP003')
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [DonViTinh], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien], [TrangThai], [GhiChu], [MaSanPham]) VALUES (N'CTDDH012', N'DDH009', N'Cái', 120, 400, -280, CAST(270000.00 AS Decimal(10, 2)), CAST(108000000.00 AS Decimal(12, 2)), N'Chưa xác nhận', N'', N'SP004')
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [DonViTinh], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien], [TrangThai], [GhiChu], [MaSanPham]) VALUES (N'CTDDH013', N'DDH009', N'Cái', 600, 600, 0, CAST(1000000.00 AS Decimal(10, 2)), CAST(600000000.00 AS Decimal(12, 2)), N'Chưa xác nhận', N'', N'SP005')
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [DonViTinh], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien], [TrangThai], [GhiChu], [MaSanPham]) VALUES (N'CTDDH014', N'DDH010', N'Cái', 500, 500, 0, CAST(900000.00 AS Decimal(10, 2)), CAST(450000000.00 AS Decimal(12, 2)), N'Đã hủy', N'', N'SP002')
GO
INSERT [dbo].[ChiTietPhieuKiemKe] ([MaPhieuKiemKe], [MaSanPham], [SoLuongHeThong], [SoLuongThucTe]) VALUES (N'PKK003', N'SP001', 0, 100)
GO
INSERT [dbo].[ChiTietPhieuKiemKe] ([MaPhieuKiemKe], [MaSanPham], [SoLuongHeThong], [SoLuongThucTe]) VALUES (N'PKK003', N'SP002', 0, 48)
GO
INSERT [dbo].[ChiTietPhieuKiemKe] ([MaPhieuKiemKe], [MaSanPham], [SoLuongHeThong], [SoLuongThucTe]) VALUES (N'PKK003', N'SP003', 0, 12)
GO
INSERT [dbo].[ChiTietPhieuKiemKe] ([MaPhieuKiemKe], [MaSanPham], [SoLuongHeThong], [SoLuongThucTe]) VALUES (N'PKK003', N'SP004', 0, 32)
GO
INSERT [dbo].[ChiTietPhieuKiemKe] ([MaPhieuKiemKe], [MaSanPham], [SoLuongHeThong], [SoLuongThucTe]) VALUES (N'PKK003', N'SP005', 0, 77)
GO
INSERT [dbo].[ChiTietPhieuKiemKe] ([MaPhieuKiemKe], [MaSanPham], [SoLuongHeThong], [SoLuongThucTe]) VALUES (N'PKK005', N'SP005', 0, 100)
GO
INSERT [dbo].[ChiTietPhieuKiemKe] ([MaPhieuKiemKe], [MaSanPham], [SoLuongHeThong], [SoLuongThucTe]) VALUES (N'PKK005', N'SP006', 0, 30)
GO
INSERT [dbo].[ChiTietPhieuKiemKe] ([MaPhieuKiemKe], [MaSanPham], [SoLuongHeThong], [SoLuongThucTe]) VALUES (N'PKK006', N'SP001', 100, 104)
GO
INSERT [dbo].[ChiTietPhieuKiemKe] ([MaPhieuKiemKe], [MaSanPham], [SoLuongHeThong], [SoLuongThucTe]) VALUES (N'PKK006', N'SP002', 48, 53)
GO
INSERT [dbo].[ChiTietPhieuKiemKe] ([MaPhieuKiemKe], [MaSanPham], [SoLuongHeThong], [SoLuongThucTe]) VALUES (N'PKK006', N'SP003', 12, 16)
GO
INSERT [dbo].[ChiTietPhieuKiemKe] ([MaPhieuKiemKe], [MaSanPham], [SoLuongHeThong], [SoLuongThucTe]) VALUES (N'PKK006', N'SP004', 32, 33)
GO
INSERT [dbo].[ChiTietPhieuKiemKe] ([MaPhieuKiemKe], [MaSanPham], [SoLuongHeThong], [SoLuongThucTe]) VALUES (N'PKK006', N'SP005', 100, 102)
GO
INSERT [dbo].[ChiTietPhieuKiemKe] ([MaPhieuKiemKe], [MaSanPham], [SoLuongHeThong], [SoLuongThucTe]) VALUES (N'PKK006', N'SP006', 30, 30)
GO
INSERT [dbo].[ChiTietPhieuKiemKe] ([MaPhieuKiemKe], [MaSanPham], [SoLuongHeThong], [SoLuongThucTe]) VALUES (N'PKK007', N'SP001', 104, 33)
GO
INSERT [dbo].[ChiTietPhieuKiemKe] ([MaPhieuKiemKe], [MaSanPham], [SoLuongHeThong], [SoLuongThucTe]) VALUES (N'PKK007', N'SP002', 53, 53)
GO
INSERT [dbo].[ChiTietPhieuKiemKe] ([MaPhieuKiemKe], [MaSanPham], [SoLuongHeThong], [SoLuongThucTe]) VALUES (N'PKK007', N'SP003', 16, 16)
GO
INSERT [dbo].[ChiTietPhieuKiemKe] ([MaPhieuKiemKe], [MaSanPham], [SoLuongHeThong], [SoLuongThucTe]) VALUES (N'PKK007', N'SP004', 33, 33)
GO
INSERT [dbo].[ChiTietPhieuKiemKe] ([MaPhieuKiemKe], [MaSanPham], [SoLuongHeThong], [SoLuongThucTe]) VALUES (N'PKK007', N'SP005', 102, 102)
GO
INSERT [dbo].[ChiTietPhieuKiemKe] ([MaPhieuKiemKe], [MaSanPham], [SoLuongHeThong], [SoLuongThucTe]) VALUES (N'PKK007', N'SP006', 30, 30)
GO
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [NgayDat], [TongTien], [TrangThai], [NgayTao], [NgayCapNhat], [MaNhaCungCap], [MaNhanVien]) VALUES (N'DDH001', CAST(N'2024-11-11' AS Date), CAST(10000000.00 AS Decimal(12, 2)), N'Chưa xác nhận', CAST(N'2024-11-11' AS Date), CAST(N'2024-11-11' AS Date), N'NCC003', N'NV001')
GO
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [NgayDat], [TongTien], [TrangThai], [NgayTao], [NgayCapNhat], [MaNhaCungCap], [MaNhanVien]) VALUES (N'DDH002', CAST(N'2024-11-11' AS Date), NULL, N'Chưa xác nhận', CAST(N'2024-11-11' AS Date), CAST(N'2024-11-11' AS Date), N'NCC003', N'NV001')
GO
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [NgayDat], [TongTien], [TrangThai], [NgayTao], [NgayCapNhat], [MaNhaCungCap], [MaNhanVien]) VALUES (N'DDH003', CAST(N'2024-11-11' AS Date), CAST(30000000.00 AS Decimal(12, 2)), N'Chưa xác nhận', CAST(N'2024-11-11' AS Date), CAST(N'2024-11-11' AS Date), N'NCC002', N'NV001')
GO
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [NgayDat], [TongTien], [TrangThai], [NgayTao], [NgayCapNhat], [MaNhaCungCap], [MaNhanVien]) VALUES (N'DDH004', CAST(N'2024-11-11' AS Date), CAST(59600000.00 AS Decimal(12, 2)), N'Chưa xác nhận', CAST(N'2024-11-11' AS Date), CAST(N'2024-11-11' AS Date), N'NCC003', N'NV001')
GO
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [NgayDat], [TongTien], [TrangThai], [NgayTao], [NgayCapNhat], [MaNhaCungCap], [MaNhanVien]) VALUES (N'DDH005', CAST(N'2024-11-11' AS Date), NULL, N'Chưa xác nhận', CAST(N'2024-11-11' AS Date), CAST(N'2024-11-11' AS Date), N'NCC002', N'NV001')
GO
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [NgayDat], [TongTien], [TrangThai], [NgayTao], [NgayCapNhat], [MaNhaCungCap], [MaNhanVien]) VALUES (N'DDH006', CAST(N'2024-11-11' AS Date), NULL, N'Chưa xác nhận', CAST(N'2024-11-11' AS Date), CAST(N'2024-11-11' AS Date), N'NCC004', N'NV001')
GO
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [NgayDat], [TongTien], [TrangThai], [NgayTao], [NgayCapNhat], [MaNhaCungCap], [MaNhanVien]) VALUES (N'DDH007', CAST(N'2024-11-11' AS Date), NULL, N'Chưa xác nhận', CAST(N'2024-11-11' AS Date), CAST(N'2024-11-11' AS Date), N'NCC008', N'NV001')
GO
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [NgayDat], [TongTien], [TrangThai], [NgayTao], [NgayCapNhat], [MaNhaCungCap], [MaNhanVien]) VALUES (N'DDH008', CAST(N'2024-11-11' AS Date), NULL, N'Chưa xác nhận', CAST(N'2024-11-11' AS Date), CAST(N'2024-11-11' AS Date), N'NCC003', N'NV001')
GO
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [NgayDat], [TongTien], [TrangThai], [NgayTao], [NgayCapNhat], [MaNhaCungCap], [MaNhanVien]) VALUES (N'DDH009', CAST(N'2024-11-11' AS Date), CAST(972400000.00 AS Decimal(12, 2)), N'Chưa xác nhận', CAST(N'2024-11-11' AS Date), CAST(N'2024-11-11' AS Date), N'NCC001', N'NV002')
GO
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [NgayDat], [TongTien], [TrangThai], [NgayTao], [NgayCapNhat], [MaNhaCungCap], [MaNhanVien]) VALUES (N'DDH010', CAST(N'2024-11-11' AS Date), CAST(440000000.00 AS Decimal(12, 2)), N'Đã hủy', CAST(N'2024-11-11' AS Date), CAST(N'2024-11-11' AS Date), N'NCC004', N'NV002')
GO
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [DiemTichLuy], [TaiKhoan], [MatKhau], [HinhAnh], [TrangThai], [NgayTao], [NgayCapNhat], [ThanhVien], [DiaChi]) VALUES (N'KH001', N'Hoàng Đức Quân', NULL, NULL, N'', NULL, CAST(150000.00 AS Decimal(10, 2)), NULL, NULL, NULL, 1, NULL, NULL, 0, N'')
GO
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [DiemTichLuy], [TaiKhoan], [MatKhau], [HinhAnh], [TrangThai], [NgayTao], [NgayCapNhat], [ThanhVien], [DiaChi]) VALUES (N'KH002', N'Hoàng Đức Quân', NULL, NULL, N'034928374', NULL, CAST(50000.00 AS Decimal(10, 2)), NULL, NULL, NULL, 1, NULL, NULL, 0, N'')
GO
INSERT [dbo].[KichThuoc] ([MaKichThuoc], [TenKichThuoc], [MoTa]) VALUES (N'KT001', N'Nhỏ', N'Kích thước nhỏ - phù hợp làm quà lưu niệm')
GO
INSERT [dbo].[KichThuoc] ([MaKichThuoc], [TenKichThuoc], [MoTa]) VALUES (N'KT002', N'Vừa', N'Kích thước vừa - ôm vừa tay')
GO
INSERT [dbo].[KichThuoc] ([MaKichThuoc], [TenKichThuoc], [MoTa]) VALUES (N'KT003', N'Lớn', N'Kích thước lớn - ôm vừa người')
GO
INSERT [dbo].[KichThuoc] ([MaKichThuoc], [TenKichThuoc], [MoTa]) VALUES (N'KT004', N'Siêu Lớn', N'Kích thước siêu lớn - gấu bông khổng lồ')
GO
INSERT [dbo].[KichThuoc] ([MaKichThuoc], [TenKichThuoc], [MoTa]) VALUES (N'KT005', N'Mini', N'Kích thước mini - nhỏ gọn, dễ mang theo')
GO
INSERT [dbo].[KichThuoc] ([MaKichThuoc], [TenKichThuoc], [MoTa]) VALUES (N'KT006', N'Đặc Biệt', N'Kích thước đặc biệt theo yêu cầu')
GO
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa], [HinhAnh]) VALUES (N'LSP001', N'Gấu Bông Teddy', N'Gấu bông Teddy lông mềm mại, nhiều kích cỡ', N'gaubong_teddy.jpg')
GO
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa], [HinhAnh]) VALUES (N'LSP002', N'Gấu Bông Pooh', N'Gấu bông Winnie the Pooh dễ thương, màu vàng', N'gaubong_pooh.jpg')
GO
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa], [HinhAnh]) VALUES (N'LSP003', N'Gấu Bông Panda', N'Gấu bông Panda đen trắng, lông mịn', N'gaubong_panda.jpg')
GO
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa], [HinhAnh]) VALUES (N'LSP004', N'Thỏ Bông', N'Thỏ bông đáng yêu, nhiều màu sắc', N'thobong.jpg')
GO
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa], [HinhAnh]) VALUES (N'LSP005', N'Mèo Bông', N'Mèo bông xinh xắn, mềm mịn', N'meobong.jpg')
GO
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa], [HinhAnh]) VALUES (N'LSP006', N'Chó Bông', N'Chó bông dễ thương, nhiều mẫu mã', N'chobong.jpg')
GO
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa], [HinhAnh]) VALUES (N'LSP007', N'Gấu Bông Cỡ Lớn', N'Gấu bông khổng lồ, lông mềm', N'gaubong_colo.jpg')
GO
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa], [HinhAnh]) VALUES (N'LSP008', N'Gấu Bông Hoạt Hình', N'Gấu bông các nhân vật hoạt hình', N'gaubong_hoathinh.jpg')
GO
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa], [HinhAnh]) VALUES (N'LSP009', N'Gấu Bông Biểu Cảm', N'Gấu bông có nhiều biểu cảm khác nhau', N'gaubong_bieucam.jpg')
GO
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa], [HinhAnh]) VALUES (N'LSP010', N'Gấu Bông Búp Bê', N'Gấu bông hình búp bê, dễ thương', N'gaubong_bupbe.jpg')
GO
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa], [HinhAnh]) VALUES (N'LSP011', N'Gấu bông capypara', N'', N'_balo-capybara-doi-cam-1-400x400.jpg')
GO
INSERT [dbo].[MauSac] ([MaMau], [TenMau], [MoTa], [HinhAnh]) VALUES (N'MS001', N'Trắng', N'Màu trắng tinh khiết, dễ phối màu', NULL)
GO
INSERT [dbo].[MauSac] ([MaMau], [TenMau], [MoTa], [HinhAnh]) VALUES (N'MS002', N'Nâu', N'Màu nâu ấm áp, phù hợp với gấu bông Teddy', NULL)
GO
INSERT [dbo].[MauSac] ([MaMau], [TenMau], [MoTa], [HinhAnh]) VALUES (N'MS003', N'Xám', N'Màu xám nhẹ nhàng, tạo cảm giác dễ chịu', NULL)
GO
INSERT [dbo].[MauSac] ([MaMau], [TenMau], [MoTa], [HinhAnh]) VALUES (N'MS004', N'Hồng', N'Màu hồng ngọt ngào, đáng yêu', NULL)
GO
INSERT [dbo].[MauSac] ([MaMau], [TenMau], [MoTa], [HinhAnh]) VALUES (N'MS005', N'Vàng', N'Màu vàng tươi sáng cho gấu bông Pooh', NULL)
GO
INSERT [dbo].[MauSac] ([MaMau], [TenMau], [MoTa], [HinhAnh]) VALUES (N'MS006', N'Đen', N'Màu đen đặc trưng cho gấu bông Panda', NULL)
GO
INSERT [dbo].[MauSac] ([MaMau], [TenMau], [MoTa], [HinhAnh]) VALUES (N'MS007', N'Xanh Dương', N'Màu xanh dương tươi mát', NULL)
GO
INSERT [dbo].[MauSac] ([MaMau], [TenMau], [MoTa], [HinhAnh]) VALUES (N'MS008', N'Xanh Lá', N'Màu xanh lá cho gấu bông kiểu đặc biệt', NULL)
GO
INSERT [dbo].[MauSac] ([MaMau], [TenMau], [MoTa], [HinhAnh]) VALUES (N'MS009', N'Cam', N'Màu cam nổi bật cho gấu bông lạ mắt', NULL)
GO
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [NguoiDaiDien], [Email], [SoDienThoai], [TrangThai], [NgayTao], [NgayCapNhat]) VALUES (N'NCC001', N'Công ty TNHH Gấu Bông Việt', N'123 Đường ABC, Quận 1, TP.HCM', N'Nguyễn Văn A', N'gaubongviet@gmail.com', N'0901234567', 1, CAST(N'2024-01-15' AS Date), CAST(N'2024-01-20' AS Date))
GO
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [NguoiDaiDien], [Email], [SoDienThoai], [TrangThai], [NgayTao], [NgayCapNhat]) VALUES (N'NCC002', N'Xưởng Gấu Bông Siêu Cấp', N'456 Đường DEF, Quận 3, TP.HCM', N'Lê Thị B', N'gaubongsieucap@gmail.com', N'0902234567', 1, CAST(N'2023-11-10' AS Date), CAST(N'2024-02-15' AS Date))
GO
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [NguoiDaiDien], [Email], [SoDienThoai], [TrangThai], [NgayTao], [NgayCapNhat]) VALUES (N'NCC003', N'Công ty Cổ phần Gấu Bông Xinh', N'789 Đường GHI, Quận 5, TP.HCM', N'Phạm Văn C', N'gaubongxinh@gmail.com', N'0903234567', 1, CAST(N'2023-12-01' AS Date), CAST(N'2024-03-18' AS Date))
GO
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [NguoiDaiDien], [Email], [SoDienThoai], [TrangThai], [NgayTao], [NgayCapNhat]) VALUES (N'NCC004', N'Gấu Bông Thủ Đô', N'321 Đường JKL, Quận Ba Đình, Hà Nội', N'Trần Thị D', N'gaubongthudo@gmail.com', N'0904234567', 1, CAST(N'2023-10-05' AS Date), CAST(N'2024-01-12' AS Date))
GO
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [NguoiDaiDien], [Email], [SoDienThoai], [TrangThai], [NgayTao], [NgayCapNhat]) VALUES (N'NCC005', N'Gấu Bông Tân Phát', N'654 Đường MNO, Quận 2, TP.HCM', N'Nguyễn Văn E', N'gaubongtanphat@gmail.com', N'0905234567', 1, CAST(N'2023-11-20' AS Date), CAST(N'2024-04-05' AS Date))
GO
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [NguoiDaiDien], [Email], [SoDienThoai], [TrangThai], [NgayTao], [NgayCapNhat]) VALUES (N'NCC006', N'Xưởng Gấu Bông Hà Thành', N'987 Đường PQR, Quận Hoàng Mai, Hà Nội', N'Lê Văn F', N'gaubonghathanh@gmail.com', N'0906234567', 1, CAST(N'2023-08-15' AS Date), CAST(N'2024-02-10' AS Date))
GO
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [NguoiDaiDien], [Email], [SoDienThoai], [TrangThai], [NgayTao], [NgayCapNhat]) VALUES (N'NCC007', N'Công ty TNHH Gấu Bông Miền Tây', N'222 Đường STU, Quận Ninh Kiều, Cần Thơ', N'Phạm Thị G', N'gaubongmientay@gmail.com', N'0907234567', 1, CAST(N'2023-09-01' AS Date), CAST(N'2024-03-20' AS Date))
GO
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [NguoiDaiDien], [Email], [SoDienThoai], [TrangThai], [NgayTao], [NgayCapNhat]) VALUES (N'NCC008', N'Gấu Bông Ngọc Hạnh', N'333 Đường VWX, Quận Thanh Khê, Đà Nẵng', N'Trần Văn H', N'gaubongngochanh@gmail.com', N'0908234567', 1, CAST(N'2023-07-25' AS Date), CAST(N'2024-01-25' AS Date))
GO
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [NguoiDaiDien], [Email], [SoDienThoai], [TrangThai], [NgayTao], [NgayCapNhat]) VALUES (N'NCC009', N'Công ty TNHH Gấu Bông Panda', N'444 Đường YZA, Quận 7, TP.HCM', N'Nguyễn Thị I', N'gaubongpanda@gmail.com', N'0909234567', 1, CAST(N'2023-09-18' AS Date), CAST(N'2024-02-28' AS Date))
GO
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [NguoiDaiDien], [Email], [SoDienThoai], [TrangThai], [NgayTao], [NgayCapNhat]) VALUES (N'NCC010', N'Thiên Đường Gấu Bông', N'555 Đường BCD, Quận Hải Châu, Đà Nẵng', N'Hoàng Văn K', N'thienduonggaubong@gmail.com', N'0910234567', 1, CAST(N'2023-06-10' AS Date), CAST(N'2024-03-01' AS Date))
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [ChucVu], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [TaiKhoan], [MatKhau], [HinhAnh], [TrangThai], [NgayTao], [NgayCapNhat], [DiaChi]) VALUES (N'NV001', N'Nguyễn Văn An', N'Quản lý', CAST(N'1990-02-15' AS Date), N'Nam', N'0901123456', N'nguyenvanan@gmail.com', N'admin', N'admin', N'/images/nv001.jpg', 1, CAST(N'2023-01-10' AS Date), CAST(N'2023-06-15' AS Date), N'123 Đường ABC, Quận 1, TP.HCM')
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [ChucVu], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [TaiKhoan], [MatKhau], [HinhAnh], [TrangThai], [NgayTao], [NgayCapNhat], [DiaChi]) VALUES (N'NV002', N'Lê Thị Bích', N'Nhân viên bán hàng', CAST(N'1995-05-22' AS Date), N'Nữ', N'0902234567', N'lethibich@gmail.com', N'bich.le', N'MatKhauBich456', N'/images/nv002.jpg', 1, CAST(N'2023-02-18' AS Date), CAST(N'2023-08-25' AS Date), N'456 Đường DEF, Quận 3, TP.HCM')
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [ChucVu], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [TaiKhoan], [MatKhau], [HinhAnh], [TrangThai], [NgayTao], [NgayCapNhat], [DiaChi]) VALUES (N'NV003', N'Trần Văn Cường', N'Thu ngân', CAST(N'1992-11-03' AS Date), N'Nam', N'0903345678', N'tranvancuong@gmail.com', N'cuong.tran', N'MatKhauCuong789', N'/images/nv003.jpg', 0, CAST(N'2023-03-12' AS Date), CAST(N'2023-10-05' AS Date), N'789 Đường GHI, Quận 5, TP.HCM')
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [ChucVu], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [TaiKhoan], [MatKhau], [HinhAnh], [TrangThai], [NgayTao], [NgayCapNhat], [DiaChi]) VALUES (N'NV004', N'Phạm Thị Dung', N'Chăm sóc khách hàng', CAST(N'1998-07-09' AS Date), N'Nữ', N'0904456789', N'phamthidung@gmail.com', N'dung.pham', N'MatKhauDung012', N'/images/nv004.jpg', 1, CAST(N'2023-04-20' AS Date), CAST(N'2023-09-15' AS Date), N'321 Đường JKL, Quận 7, TP.HCM')
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [ChucVu], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [TaiKhoan], [MatKhau], [HinhAnh], [TrangThai], [NgayTao], [NgayCapNhat], [DiaChi]) VALUES (N'NV005', N'Hoàng Văn Hưng', N'Nhân viên kho', CAST(N'1988-12-25' AS Date), N'Nam', N'0905567890', N'hoangvanhung@gmail.com', N'hung.hoang', N'MatKhauHung345', N'/images/nv005.jpg', 0, CAST(N'2023-05-15' AS Date), CAST(N'2023-07-30' AS Date), N'654 Đường MNO, Quận 9, TP.HCM')
GO
INSERT [dbo].[PhieuKiemKe] ([MaPhieuKiemKe], [NgayLap], [GhiChu], [MaNhanVien]) VALUES (N'PKK001', CAST(N'2024-10-15' AS Date), N'Kiểm kê định kỳ hàng tháng', N'NV001')
GO
INSERT [dbo].[PhieuKiemKe] ([MaPhieuKiemKe], [NgayLap], [GhiChu], [MaNhanVien]) VALUES (N'PKK002', CAST(N'2024-11-05' AS Date), N'Kiểm kê đột xuất trước đợt nhập hàng lớn', N'NV002')
GO
INSERT [dbo].[PhieuKiemKe] ([MaPhieuKiemKe], [NgayLap], [GhiChu], [MaNhanVien]) VALUES (N'PKK003', CAST(N'2024-11-10' AS Date), N'Kiểm kê đột xuất trước đợt nhập hàng lớn', N'NV001')
GO
INSERT [dbo].[PhieuKiemKe] ([MaPhieuKiemKe], [NgayLap], [GhiChu], [MaNhanVien]) VALUES (N'PKK004', CAST(N'2024-11-10' AS Date), N'Kiểm kê đột xuất trước đợt nhập hàng lớn', N'NV001')
GO
INSERT [dbo].[PhieuKiemKe] ([MaPhieuKiemKe], [NgayLap], [GhiChu], [MaNhanVien]) VALUES (N'PKK005', CAST(N'2024-11-10' AS Date), N'Kiểm kê đột xuất trước đợt nhập hàng lớn', N'NV001')
GO
INSERT [dbo].[PhieuKiemKe] ([MaPhieuKiemKe], [NgayLap], [GhiChu], [MaNhanVien]) VALUES (N'PKK006', CAST(N'2024-11-10' AS Date), N'Kiểm kê đột xuất trước đợt nhập hàng lớn', N'NV001')
GO
INSERT [dbo].[PhieuKiemKe] ([MaPhieuKiemKe], [NgayLap], [GhiChu], [MaNhanVien]) VALUES (N'PKK007', CAST(N'2024-11-10' AS Date), N'Kiểm kê đột xuất trước đợt nhập hàng lớn', N'NV001')
GO
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [DonViTinh], [SoLuongTon], [SoLuongToiThieu], [GiaNhap], [GiaBan], [MoTa], [HinhAnh], [TrangThai], [NgayTao], [NgayCapNhat], [MaLoai]) VALUES (N'SP001', N'Balo capypara đội cam', N'Cái', 33, 50, CAST(100000.00 AS Decimal(10, 2)), CAST(200000.00 AS Decimal(10, 2)), N'Hihi', N'_balo-capybara-doi-cam-1-400x400.jpg', 1, CAST(N'2024-11-10' AS Date), CAST(N'2024-11-11' AS Date), N'LSP001')
GO
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [DonViTinh], [SoLuongTon], [SoLuongToiThieu], [GiaNhap], [GiaBan], [MoTa], [HinhAnh], [TrangThai], [NgayTao], [NgayCapNhat], [MaLoai]) VALUES (N'SP002', N'Balo capypara chảy mũi', N'Cái', 53, 66, CAST(900000.00 AS Decimal(10, 2)), CAST(370000.00 AS Decimal(10, 2)), N'Hihi', N'SP001_balo-gau-bong-capybara-chay-mui-1-400x400.jpg', 1, CAST(N'2024-11-10' AS Date), CAST(N'2024-11-11' AS Date), N'LSP001')
GO
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [DonViTinh], [SoLuongTon], [SoLuongToiThieu], [GiaNhap], [GiaBan], [MoTa], [HinhAnh], [TrangThai], [NgayTao], [NgayCapNhat], [MaLoai]) VALUES (N'SP003', N'Bồ nông cosplay capypara', N'Cái', 16, 10, CAST(500000.00 AS Decimal(10, 2)), CAST(330000.00 AS Decimal(10, 2)), N'Hihi', N'SP001_bo-nong-cosplay-capybara-1-400x400.jpg', 1, CAST(N'2024-11-10' AS Date), CAST(N'2024-11-11' AS Date), N'LSP001')
GO
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [DonViTinh], [SoLuongTon], [SoLuongToiThieu], [GiaNhap], [GiaBan], [MoTa], [HinhAnh], [TrangThai], [NgayTao], [NgayCapNhat], [MaLoai]) VALUES (N'SP004', N'Capypara hồng áo sọc', N'Cái', 33, 10, CAST(270000.00 AS Decimal(10, 2)), CAST(400000.00 AS Decimal(10, 2)), N'Hihi', N'SP002_capybara-hong-ao-soc-1-400x400.jpg', 1, CAST(N'2024-11-10' AS Date), CAST(N'2024-11-11' AS Date), N'LSP001')
GO
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [DonViTinh], [SoLuongTon], [SoLuongToiThieu], [GiaNhap], [GiaBan], [MoTa], [HinhAnh], [TrangThai], [NgayTao], [NgayCapNhat], [MaLoai]) VALUES (N'SP005', N'Capypara hồng đeo balo', N'Cái', 102, 10, CAST(1000000.00 AS Decimal(10, 2)), CAST(600000.00 AS Decimal(10, 2)), N'Hihi', N'SP005_capybara-hong-deo-balo-1-400x400.jpg', 1, CAST(N'2024-11-10' AS Date), CAST(N'2024-11-11' AS Date), N'LSP001')
GO
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [DonViTinh], [SoLuongTon], [SoLuongToiThieu], [GiaNhap], [GiaBan], [MoTa], [HinhAnh], [TrangThai], [NgayTao], [NgayCapNhat], [MaLoai]) VALUES (N'SP006', N'Balo capypara đội cam', N'Cái', 30, 10, CAST(120000.00 AS Decimal(10, 2)), CAST(200000.00 AS Decimal(10, 2)), N'Hihi', N'_balo-capybara-doi-cam-1-400x400.jpg', 1, CAST(N'2024-11-10' AS Date), CAST(N'2024-11-10' AS Date), N'LSP001')
GO
INSERT [dbo].[SanPham_KichThuoc] ([MaSanPham], [MaKichThuoc]) VALUES (N'SP001', N'KT001')
GO
INSERT [dbo].[SanPham_KichThuoc] ([MaSanPham], [MaKichThuoc]) VALUES (N'SP002', N'KT003')
GO
INSERT [dbo].[SanPham_KichThuoc] ([MaSanPham], [MaKichThuoc]) VALUES (N'SP003', N'KT001')
GO
INSERT [dbo].[SanPham_KichThuoc] ([MaSanPham], [MaKichThuoc]) VALUES (N'SP004', N'KT004')
GO
INSERT [dbo].[SanPham_KichThuoc] ([MaSanPham], [MaKichThuoc]) VALUES (N'SP005', N'KT001')
GO
INSERT [dbo].[SanPham_KichThuoc] ([MaSanPham], [MaKichThuoc]) VALUES (N'SP006', N'KT001')
GO
INSERT [dbo].[SanPham_MauSac] ([MaSanPham], [MaMau]) VALUES (N'SP001', N'MS002')
GO
INSERT [dbo].[SanPham_MauSac] ([MaSanPham], [MaMau]) VALUES (N'SP002', N'MS002')
GO
INSERT [dbo].[SanPham_MauSac] ([MaSanPham], [MaMau]) VALUES (N'SP003', N'MS001')
GO
INSERT [dbo].[SanPham_MauSac] ([MaSanPham], [MaMau]) VALUES (N'SP004', N'MS004')
GO
INSERT [dbo].[SanPham_MauSac] ([MaSanPham], [MaMau]) VALUES (N'SP005', N'MS004')
GO
INSERT [dbo].[SanPham_MauSac] ([MaSanPham], [MaMau]) VALUES (N'SP006', N'MS008')
GO
ALTER TABLE [dbo].[ChiTietDonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_CTDDH_DDH] FOREIGN KEY([MaDonDatHang])
REFERENCES [dbo].[DonDatHang] ([MaDonDatHang])
GO
ALTER TABLE [dbo].[ChiTietDonDatHang] CHECK CONSTRAINT [FK_CTDDH_DDH]
GO
ALTER TABLE [dbo].[ChiTietDonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_CTDDH_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[ChiTietDonDatHang] CHECK CONSTRAINT [FK_CTDDH_SanPham]
GO
ALTER TABLE [dbo].[ChiTietHoaDonBanHang]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_HDBH] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDonBanHang] ([MaHoaDonBanHang])
GO
ALTER TABLE [dbo].[ChiTietHoaDonBanHang] CHECK CONSTRAINT [FK_CTHD_HDBH]
GO
ALTER TABLE [dbo].[ChiTietHoaDonBanHang]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_SP] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[ChiTietHoaDonBanHang] CHECK CONSTRAINT [FK_CTHD_SP]
GO
ALTER TABLE [dbo].[ChiTietPhieuHoanTra]  WITH CHECK ADD  CONSTRAINT [fk_CTPHT_CTPN] FOREIGN KEY([MaChiTietPhieuNhap])
REFERENCES [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap])
GO
ALTER TABLE [dbo].[ChiTietPhieuHoanTra] CHECK CONSTRAINT [fk_CTPHT_CTPN]
GO
ALTER TABLE [dbo].[ChiTietPhieuHoanTra]  WITH CHECK ADD  CONSTRAINT [Fk_CTPHT_PHT] FOREIGN KEY([MaPhieuHoanTra])
REFERENCES [dbo].[PhieuHoanTra] ([MaPhieuHoanTra])
GO
ALTER TABLE [dbo].[ChiTietPhieuHoanTra] CHECK CONSTRAINT [Fk_CTPHT_PHT]
GO
ALTER TABLE [dbo].[ChiTietPhieuKiemKe]  WITH CHECK ADD  CONSTRAINT [FK_CTPKK_PKK] FOREIGN KEY([MaPhieuKiemKe])
REFERENCES [dbo].[PhieuKiemKe] ([MaPhieuKiemKe])
GO
ALTER TABLE [dbo].[ChiTietPhieuKiemKe] CHECK CONSTRAINT [FK_CTPKK_PKK]
GO
ALTER TABLE [dbo].[ChiTietPhieuKiemKe]  WITH CHECK ADD  CONSTRAINT [FK_CTPKK_SP] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[ChiTietPhieuKiemKe] CHECK CONSTRAINT [FK_CTPKK_SP]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_CTPH_CTDonHang] FOREIGN KEY([MaChiTietDonDatHang])
REFERENCES [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_CTPH_CTDonHang]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_CTPH_PN] FOREIGN KEY([MaPhieuNhap])
REFERENCES [dbo].[PhieuNhap] ([MaPhieuNhap])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_CTPH_PN]
GO
ALTER TABLE [dbo].[DonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_DDH_NCC] FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([MaNhaCungCap])
GO
ALTER TABLE [dbo].[DonDatHang] CHECK CONSTRAINT [FK_DDH_NCC]
GO
ALTER TABLE [dbo].[DonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_DDH_NV] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[DonDatHang] CHECK CONSTRAINT [FK_DDH_NV]
GO
ALTER TABLE [dbo].[HoaDonBanHang]  WITH CHECK ADD  CONSTRAINT [FK_HDBH_KH] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HoaDonBanHang] CHECK CONSTRAINT [FK_HDBH_KH]
GO
ALTER TABLE [dbo].[HoaDonBanHang]  WITH CHECK ADD  CONSTRAINT [FK_HDBH_NV] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HoaDonBanHang] CHECK CONSTRAINT [FK_HDBH_NV]
GO
ALTER TABLE [dbo].[NhanVien_ManHinh]  WITH CHECK ADD  CONSTRAINT [KF_NVMH_MH] FOREIGN KEY([MaManHinh])
REFERENCES [dbo].[ManHinh] ([MaManHinh])
GO
ALTER TABLE [dbo].[NhanVien_ManHinh] CHECK CONSTRAINT [KF_NVMH_MH]
GO
ALTER TABLE [dbo].[NhanVien_ManHinh]  WITH CHECK ADD  CONSTRAINT [KF_NVMH_NV] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[NhanVien_ManHinh] CHECK CONSTRAINT [KF_NVMH_NV]
GO
ALTER TABLE [dbo].[NhatKyDichVu]  WITH CHECK ADD  CONSTRAINT [FK_NKD_CTHDBH] FOREIGN KEY([MaChiTietHoaDonBanHang])
REFERENCES [dbo].[ChiTietHoaDonBanHang] ([MaChiTietHoaDonBanHang])
GO
ALTER TABLE [dbo].[NhatKyDichVu] CHECK CONSTRAINT [FK_NKD_CTHDBH]
GO
ALTER TABLE [dbo].[NhatKyDichVu]  WITH CHECK ADD  CONSTRAINT [FK_NKD_PDV] FOREIGN KEY([MaPhieuDichVu])
REFERENCES [dbo].[PhieuDichVu] ([MaPhieuDichVu])
GO
ALTER TABLE [dbo].[NhatKyDichVu] CHECK CONSTRAINT [FK_NKD_PDV]
GO
ALTER TABLE [dbo].[PhieuDichVu]  WITH CHECK ADD  CONSTRAINT [FK_PD_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[PhieuDichVu] CHECK CONSTRAINT [FK_PD_KhachHang]
GO
ALTER TABLE [dbo].[PhieuDichVu]  WITH CHECK ADD  CONSTRAINT [FK_PD_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[PhieuDichVu] CHECK CONSTRAINT [FK_PD_NhanVien]
GO
ALTER TABLE [dbo].[PhieuDoiTra]  WITH CHECK ADD  CONSTRAINT [FK_PDT_CTDH] FOREIGN KEY([MaChiTietDonBanHang])
REFERENCES [dbo].[ChiTietHoaDonBanHang] ([MaChiTietHoaDonBanHang])
GO
ALTER TABLE [dbo].[PhieuDoiTra] CHECK CONSTRAINT [FK_PDT_CTDH]
GO
ALTER TABLE [dbo].[PhieuDoiTra]  WITH CHECK ADD  CONSTRAINT [FK_PDT_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[PhieuDoiTra] CHECK CONSTRAINT [FK_PDT_NhanVien]
GO
ALTER TABLE [dbo].[PhieuHoanTra]  WITH CHECK ADD  CONSTRAINT [FK_PHT_NV] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[PhieuHoanTra] CHECK CONSTRAINT [FK_PHT_NV]
GO
ALTER TABLE [dbo].[PhieuKiemKe]  WITH CHECK ADD  CONSTRAINT [FK_PKK_NV] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[PhieuKiemKe] CHECK CONSTRAINT [FK_PKK_NV]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PN_DDH] FOREIGN KEY([MaDonDatHang])
REFERENCES [dbo].[DonDatHang] ([MaDonDatHang])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PN_DDH]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [Fk_PN_NV] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [Fk_PN_NV]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SP_Loai] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiSanPham] ([MaLoai])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SP_Loai]
GO
ALTER TABLE [dbo].[SanPham_KichThuoc]  WITH CHECK ADD  CONSTRAINT [FK_SPKT_KT] FOREIGN KEY([MaKichThuoc])
REFERENCES [dbo].[KichThuoc] ([MaKichThuoc])
GO
ALTER TABLE [dbo].[SanPham_KichThuoc] CHECK CONSTRAINT [FK_SPKT_KT]
GO
ALTER TABLE [dbo].[SanPham_KichThuoc]  WITH CHECK ADD  CONSTRAINT [FK_SPKT_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[SanPham_KichThuoc] CHECK CONSTRAINT [FK_SPKT_SanPham]
GO
ALTER TABLE [dbo].[SanPham_MauSac]  WITH CHECK ADD  CONSTRAINT [FK_MauSac] FOREIGN KEY([MaMau])
REFERENCES [dbo].[MauSac] ([MaMau])
GO
ALTER TABLE [dbo].[SanPham_MauSac] CHECK CONSTRAINT [FK_MauSac]
GO
ALTER TABLE [dbo].[SanPham_MauSac]  WITH CHECK ADD  CONSTRAINT [FK_SP_MauSac] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[SanPham_MauSac] CHECK CONSTRAINT [FK_SP_MauSac]
GO
USE [master]
GO
ALTER DATABASE [db_QLCHBGB] SET  READ_WRITE 
GO
