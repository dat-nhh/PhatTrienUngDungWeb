CREATE DATABASE KT0720_63133655
GO
USE KT0720_63133655
GO
CREATE TABLE LOP
(
	MaLop nvarchar(10) PRIMARY KEY,
	TenLop nvarchar(50) NOT NULL
)
GO
CREATE TABLE SINHVIEN
(
	MaSV nvarchar(10) PRIMARY KEY,
	HoSV nvarchar(50) NOT NULL,
	TenSV nvarchar(10) NOT NULL,
	NgaySinh date,
	GioiTinh bit DEFAULT(1),
	AnhSV nvarchar(50),
	DiaChi nvarchar(100) NOT NULL,
	MaLop nvarchar(10) NOT NULL FOREIGN KEY REFERENCES LOP(MaLop)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)
GO
INSERT INTO LOP VALUES
	('CNTT1',N'Công nghệ thông tin 1'),
	('CNTT2',N'Công nghệ thông tin 2'),
	('CNTT3',N'Công nghệ thông tin 3')
GO
INSERT INTO SINHVIEN VALUES
	('TT001',N'Nguyễn Văn',N'An',CAST(N'2000-01-01' AS Date),1,N'', N'Nha Trang - Khánh Hòa','CNTT3'),
	('TT002',N'Lê Thị',N'Diệu',CAST(N'2000-08-25' AS Date),0,N'', N'Nha Trang - Khánh Hòa','CNTT1'),
	('TT003',N'Trần Xuân',N'Tín',CAST(N'2000-11-15' AS Date),1,N'', N'Nha Trang - Khánh Hòa','CNTT2')
GO
CREATE PROCEDURE TimKiem_63133655
    @MaSV varchar(10)=NULL,
	@HoTen nvarchar(50)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM SINHVIEN
       WHERE  (1=1)
       '
IF @MaSV IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaSV LIKE ''%'+@MaSV+'%'')
              '
IF @HoTen IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (HoSV+'' ''+TenSV LIKE N''%'+@HoTen+'%'')
              '
	EXEC SP_EXECUTESQL @SqlStr
END