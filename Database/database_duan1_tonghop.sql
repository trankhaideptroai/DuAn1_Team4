CREATE DATABASE qlnhahang1
use qlnhahang1

CREATE TABLE NhanVien
(
  IdNV INT IDENTITY(1,1) NOT NULL PRIMARY key,
  MaNV NVARCHAR(20) UNIQUE,
  HoTen NVARCHAR(50) NOT NULL, -- 
  SDT VARCHAR(15) NOT NULL, 
  NgaySinh DATE NOT NULL, --
  Email NVARCHAR(100) NOT NULL, 
  MatKhau NVARCHAR(100) NOT NULL, 
  ChucVu NVARCHAR(50) not null,
  phai nvarchar(20) not null,
  
 
);
CREATE TABLE BanAn
(
  maban INT IDENTITY(1,1), -- + IDENTITY CHO MaBan
  tenban NVARCHAR(50), --+ TEN BAN, - SO NGUOI
  trangthai NVARCHAR(50) NOT NULL, 
  PRIMARY KEY (maban)
);




CREATE TABLE HoaDon
(
  idHD INT IDENTITY(1,1) ,-- + NGAY NHAN HOA DON(DateCheckIn), + NGAY TRA HOA DON (DateCheckOut), + Ma Ban An (idTable), - NgayXuatHD, -IdNV, -TongTien, INT Cho trangthai
  dateCheckIn date NOT NULL,
  dateCheckOut date ,
  idTable INT NOT NULL,
  trangthai INT NOT NULL, 
  tenKH nvarchar(50) ,
  PRIMARY KEY (idHD),
  FOREIGN KEY (idTable) REFERENCES BanAn(MaBan)
);



CREATE TABLE LoaiMonAn --Them Table LoaiMonAn
(
	id INT PRIMARY KEY,
	name NVARCHAR(50) NOT NULL
)

CREATE TABLE MonAn
(
  IdMon INT IDENTITY(1,1), -- +IDENTITY Cho IdMon, +FLOAT Cho Gia
  TenMon NVARCHAR(100) NOT NULL, 
  Gia FLOAT NOT NULL,
  idLoaiMonAn INT NOT NULL,
  hinhMonAN image,
  PRIMARY KEY (IdMon),
  FOREIGN KEY (idLoaiMonAn) REFERENCES LoaiMonAn(id)
);


CREATE TABLE HoaDonChiTiet
(
  id INT,
   -- -ThanhTien, + id
  idHD INT NOT NULL,
  IdMon INT NOT NULL,
  SoLuong INT NOT NULL,
  PRIMARY KEY (idHD, IdMon, id),
  FOREIGN KEY (idHD) REFERENCES HoaDon(idHD),
  FOREIGN KEY (IdMon) REFERENCES MonAn(IdMon)
);
-------------------------------------------------------------------------------

go
-- Danh sách nhân viên
create proc DSNV
as
begin
	select * from NhanVien
end
-- thực thi
--exec DSNV
go
-- thêm nhân viên
CREATE PROCEDURE themnhanvien
    @HoTen NVARCHAR(50),
    @SDT VARCHAR(15),
    @NgaySinh DATE,
    @Email NVARCHAR(100),
    @MatKhau NVARCHAR(50),
    @ChucVu NVARCHAR(50),
    @phai NVARCHAR(20)
AS
BEGIN
    -- Biến để lưu IdNV mới
    DECLARE @new_IdNV INT;
    
    -- Bước 1: Thêm bản ghi mới vào bảng NhanVien
    INSERT INTO NhanVien (HoTen, SDT, NgaySinh, Email, MatKhau, ChucVu, phai)
    VALUES (@HoTen, @SDT, @NgaySinh, @Email, @MatKhau, @ChucVu, @phai);
    
    -- Bước 2: Lấy IdNV của bản ghi mới thêm vào
    SET @new_IdNV = SCOPE_IDENTITY();
    
    -- Bước 3: Cập nhật MaNV với giá trị 'nv' + IdNV
    UPDATE NhanVien
    SET MaNV = 'NV' + RIGHT('00' + CAST(@new_IdNV AS NVARCHAR(4)), 4)
    WHERE IdNV = @new_IdNV;
END;


/*EXEC themnhanvien
    @HoTen = 'Nguyen Van C', 
    @SDT = '0123456789', 
    @NgaySinh = '1990-01-01', 
    @Email = 'nguyenvana@example.com', 
    @MatKhau = 'password123', 
    @ChucVu = 'NhanVien', 
    @phai = 'Nam';
		
	-- select * from NhanVien

GO
*/
-- Cập nhật nhân viên 
go
create proc CapNhatDSNV @MaNV NVARCHAR(50), 
						@HoTen NVARCHAR(50),
						@SDT VARCHAR(15),
						@NgaySinh DATE,
						@Email NVARCHAR(100),
						@MatKhau NVARCHAR(50),
						@ChucVu NVARCHAR(50),
						@phai NVARCHAR(20)
as
begin
	update NhanVien
	set HoTen = @HoTen,
		SDT = @SDT,
		NgaySinh = @NgaySinh,
		Email = @Email,
		MatKhau = @MatKhau,
		ChucVu = @ChucVu,
		phai = @phai
	 where MaNV = @MaNV;
end

 /*Exec CapNhatDSNV
	@HoTen = 'Nguyen Van D', 
    @SDT = '0123456789', 
    @NgaySinh = '1990-01-01', 
    @Email = 'nguyenvana@example.com', 
    @MatKhau = 'password123', 
    @ChucVu = 'NhanVien', 
    @phai = 'Nam',
	@MaNV = 'NV008';

	select * from NhanVien
*/
GO

-- Tìm kiếm nhân viên 
create proc TimKiemNV (@tukhoa nvarchar(100))
as
begin
	select * from NhanVien where 
	MaNV like '%' + @tukhoa + '%'
	or HoTen like '%' + @tukhoa + '%'
	or NgaySinh like '%' + @tukhoa + '%'
	or SDT like '%' + @tukhoa + '%'
	or Phai like '%' + @tukhoa + '%'
	or Chucvu like '%' + @tukhoa + '%'
	or Email like '%' + @tukhoa + '%'
	or MatKhau like '%' + @tukhoa + '%'
end

GO
create proc TimKiemDSNV (@MaNV nvarchar(100))
as
begin
	select * from NhanVien where 
	MaNV like '%' + @MaNV + '%'
	
end


GO
-- Xóa nhân viên 
create proc XoaDSNV (@MaNV varchar(100))
as
begin
	delete from NhanVien where MaNV = @MaNV;
end

-- Exec XoaDSNV 'NV008';


GO
-- danh sách chức vụ

create proc DSCV
as
begin
	select Chucvu from NhanVien
end



-------------------------------------------------------
---------------------------------------------------------------------
-- san phamnhapkho

CREATE TABLE [dbo].[SPNhapKho](
	[HSD] [date] NOT NULL,
	[NgayNhap] [date] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[TenSP] [nvarchar](100) NOT NULL,
	[MaLoai] [varchar](20) NOT NULL Primary key,
	[NhaCungCap] [nvarchar](100) NOT NULL,
	[IdNV] [int] NOT NULL,
)  
go
CREATE or ALTER PROCEDURE [dbo].[sp_nhkh_del]
    @maloai VARCHAR(20)
AS
BEGIN
    DELETE FROM SPNhapKho WHERE MaLoai = @maloai;
END
GO




GO

-- tìm
create  or ALTER proc [dbo].[sp_nhkh_find]
@ten nvarchar(100)
as begin
	select  MaLoai, TenSP, SoLuong, NgayNhap, NhaCungCap, HSD, IdNV from SPNhapKho
	where TenSP = @ten
end
GO


GO

-- Thêm
CREATE  or ALTER PROC [dbo].[sp_nhkh_insert]
    @maloai varchar(20),
    @tensp nvarchar(100),
    @soluong int,
    @ngaynh date,
    @ncc varchar(100),
	@hsd date,
    @email varchar(100)
AS
BEGIN
    DECLARE @idnv nvarchar(20)
    SELECT @idnv = IdNV FROM NhanVien WHERE Email = @email

    DECLARE @max_maloai NVARCHAR(20);
    SELECT @max_maloai = MAX(MaLoai) FROM SPNhapKho;

    IF @max_maloai IS NULL
    BEGIN
        SET @maloai = 'SP001';
    END
    ELSE
    BEGIN
        SET @maloai = 'SP' + RIGHT('000' + CAST(CAST(SUBSTRING(@max_maloai, 3, LEN(@max_maloai) - 2) AS INT) + 1 AS NVARCHAR(20)), 3);
    END;

    INSERT INTO SPNhapKho(MaLoai, TenSP, SoLuong, NgayNhap, NhaCungCap, HSD, IdNV) 
    VALUES (@maloai, @tensp, @soluong, @ngaynh, @ncc, @hsd, @idnv)
END

GO



GO
--load list
create  or ALTER proc [dbo].[sp_nhkh_load]
as begin
	select  MaLoai, TenSP, SoLuong, NgayNhap, NhaCungCap, HSD, IdNV from SPNhapKho
end
GO

-- sửa
create   proc [dbo].[sp_nhkh_upd]
	@maloai varchar(20),
    @tensp nvarchar(100),
    @soluong int,
    @ngaynh date,
    @ncc varchar(100),
	@hsd date,
	@email varchar (150)
as begin
	declare @idnv varchar(50)
	select @idnv = IdNV from NhanVien where Email = @email
	update SPNhapKho
	set TenSP = @tensp, SoLuong = @soluong, NgayNhap = @ngaynh, NhaCungCap = @ncc, HSD = @hsd
	where MaLoai = @maloai
end
GO

------------------------thong kê 






-- select * from nhanvien


-- Chèn dữ liệu vào bảng NhanVien
INSERT INTO NhanVien (MaNV, HoTen, SDT, NgaySinh, Email, MatKhau, ChucVu, phai)
VALUES 
('NV001', 'Nguyen Van A', '0909123456', '1990-01-01', 'abc', 'a123', 'quanly', 'Nam'),
('NV002', 'Tran Thi B', '0912345678', '1992-02-02', 'def', 'b123', 'nhanvien', 'Nu');

-- Chèn dữ liệu vào bảng BanAn
INSERT INTO BanAn (tenban, trangthai)
VALUES 
('Ban 1', 'Trong'),
('Ban 2', 'Co Khach');

-- Chèn dữ liệu vào bảng LoaiMonAn
INSERT INTO LoaiMonAn (id, name)
VALUES 
(1, 'Khai Vi'),
(2, 'Mon Chinh'),
(3, 'Trang Mieng');

-- Chèn dữ liệu vào bảng MonAn
INSERT INTO MonAn (TenMon, Gia, idLoaiMonAn, hinhMonAN)
VALUES 
('Goi Cuon', 50000, 1, NULL),
('Pho Bo', 70000, 2, NULL),
('Che Ba Mau', 30000, 3, NULL);

-- Chèn dữ liệu vào bảng HoaDon
INSERT INTO HoaDon (dateCheckIn, dateCheckOut, idTable, trangthai, tenKH)
VALUES 
('2023-07-28', '2023-07-28', 1, 1, 'Nguyen Van C'),
('2023-07-29', NULL, 2, 0, 'Tran Thi D');

-- Chèn dữ liệu vào bảng HoaDonChiTiet
INSERT INTO HoaDonChiTiet (id, idHD, IdMon, SoLuong)
VALUES 
(1, 1, 1, 2),
(2, 1, 2, 1),
(3, 2, 3, 3);





















-- SELECT f.tenmon, bi.soluong, f.gia, f.gia * bi.soluong as totalPrice FROM dbo.HoaDonChiTiet as bi, dbo.HoaDon as b, dbo.MonAn as f 
-- WHERE bi.idHD = b.idHD AND b.TrangThai = 0 AND bi.IdMon = f.idMon AND b.idTable =3
go
--InsertBill
CREATE or ALTER PROC sp_InsertBIll @idTable INT
AS
BEGIN
	INSERT dbo.HoaDon(dateCheckIn, dateCheckOut, idTable, trangthai)
	VALUES(GETDATE(), NULL, @idTable, 0)
END
GO


--InsertBillInfo
CREATE OR ALTER PROC sp_InsertBillInfo @idBill INT, @idFood INT, @count INT
AS
BEGIN
	DECLARE @isExitsBillInfo INT;
	DECLARE @foodCount INT = 1;
	SELECT @isExitsBillInfo = id , @foodCount = b.soluong 
	FROM dbo.HoaDonChiTiet AS b 
	WHERE idHD = @idBill AND IdMon = @idFood
	
	IF(@isExitsBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @foodCount + @count
		IF (@newCount > 0)
		BEGIN
			UPDATE dbo.HoaDonChiTiet SET  soluong = @foodCount + @count WHERE IdMon = @idFood
		END
		ELSE
		BEGIN
			DELETE dbo.HoaDonChiTiet WHERE idHD = @idBill AND IdMon = @idFood
		END
	END

	ELSE
	BEGIN
		INSERT dbo.HoaDonChiTiet(idHD, IdMon, soluong)
		VALUES (@idBill, @idFood, @count)
	END
END
GO

--Hien Table
CREATE PROC sp_GetTableList
AS
BEGIN
	SELECT * FROM dbo.BanAn
END

GO-------------




CREATE OR ALTER PROCEDURE tkThongKeDoanhThuTheoNgay
    @NgayBatDau DATE,
    @NgayKetThuc DATE
AS
BEGIN
    SELECT 
        CONVERT(DATE, h.dateCheckin) AS Ngay,
        SUM(hct.SoLuong * ma.Gia) AS TongTien,
        COUNT(h.idHD) AS slhd
    FROM 
        HoaDon h
    JOIN 
        HoaDonChiTiet hct ON h.idHD = hct.idHD
    JOIN 
        MonAn ma ON hct.IdMon = ma.IdMon
    WHERE 
        h.dateCheckIn BETWEEN @NgayBatDau AND @NgayKetThuc
    GROUP BY 
        CONVERT(DATE, h.dateCheckIn)
    ORDER BY 
        Ngay;
END

