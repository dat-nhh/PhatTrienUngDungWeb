CREATE DATABASE ThiGK_63133655
GO
USE ThiGK_63133655
GO
CREATE TABLE LoaiDG
(
	MaLoaiDG nvarchar(10) PRIMARY KEY,
	TenLoaiDG nvarchar(50) NOT NULL
)
GO
CREATE TABLE DocGia
(
	MaDG nvarchar(10) PRIMARY KEY,
	HoDG nvarchar(50) NOT NULL,
	TenDG nvarchar(10) NOT NULL,
	NgaySinh date,
	GioiTinh bit DEFAULT(1),
	Email nvarchar(100) NOT NULL,
	AnhDG nvarchar(50),
	MaLoaiDG nvarchar(10) NOT NULL FOREIGN KEY REFERENCES LoaiDG(MaLoaiDG)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)
GO
INSERT INTO LoaiDG VALUES
	('DG1',N'Độc giả loại 1'),
	('DG2',N'Độc giả loại 2'),
	('DG3',N'Độc giả loại 3')
GO
INSERT INTO DocGia VALUES
	('TT001',N'Nguyễn Văn',N'An',CAST(N'2000-01-01' AS Date),1,'vanan@gmail.com',N'docgia.png','DG3'),
	('TT002',N'Lê Thị',N'Diệu',CAST(N'2000-08-25' AS Date),0,'thidieu@gmail.com',N'docgia.png','DG1'),
	('TT003',N'Trần Xuân',N'Tín',CAST(N'2000-11-15' AS Date),1,'xuantin@gmail.com',N'docgia.png','DG2')
GO
CREATE PROCEDURE TimKiem
    @MaDG varchar(10)=NULL,
	@HoTen nvarchar(50)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM DocGia
       WHERE  (1=1)
       '
IF @MaDG IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaDG LIKE ''%'+@MaDG+'%'')
              '
IF @HoTen IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (HoDG+'' ''+TenDG LIKE N''%'+@HoTen+'%'')
              '
	EXEC SP_EXECUTESQL @SqlStr
END