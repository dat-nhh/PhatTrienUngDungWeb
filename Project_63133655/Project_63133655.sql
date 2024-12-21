create database Project_63133655
go 
use Project_63133655
go

--các bảng bao gồm
--NHANVIEN(MaNV,HoNV,TenNV,NgaySinh,GioiTinh,Anh,DiaChi,SDT,ChucVu,Luong) 
--THEKHO(MaCF,LoaiCF,SoLuong,DVT,DonGia) 
--NHAPKHO(SoPhieuNhap,NgayNhap,MaNV) 
--NDNHAPKHO(SoPhieuNhap,MaCF,LoaiCF,SoLuong,DVT) 
--XUATKHO(SoPhieuXuat,NgayXuat,MaNV,TenNgNhan,DiaChi,SDT) 
--NDXUATKHO(SoPhieuXuat,MaCF,LoaiCF,SoLuong,DVT) 

create table NHANVIEN
(
	MaNV nvarchar(10) primary key,
	HoNV nvarchar(50) not null,
	TenNV nvarchar(10) not null,
	NgaySinh date,
	GioiTinh bit default(1),
	AnhNV nvarchar(50) default('profile.png'),
	DiaChi nvarchar(100) not null,
	SDT nvarchar(20),
	ChucVu nvarchar(30),
	Luong int
)
go
create table THEKHO
(
	MaCF nvarchar(10) primary key,
	LoaiCF nvarchar(50) not null,
	SoLuong smallint,
	DVT nvarchar(5) not null default('kg'),
	DonGia int
)
go
create table NHAPKHO
(
	SoPhieuNhap nvarchar(10) primary key,
	NgayNhap date not null,
	MaNV nvarchar(10) not null foreign key references NHANVIEN(MaNV) on update cascade
)
go
create table NDNHAPKHO
(
	SoPhieuNhap nvarchar(10) foreign key references NHAPKHO(SoPhieuNhap) on update cascade on delete cascade,
	MaCF nvarchar(10) foreign key references THEKHO(MaCF) on update cascade,
	LoaiCF nvarchar(50) not null,
	SoLuong smallint,
	DVT nvarchar(5) not null default('kg'),
	primary key (SoPhieuNhap, MaCF)
)
go
create table XUATKHO
(
	SoPhieuXuat nvarchar(10) primary key,
	NgayXuat date not null,
	MaNV nvarchar(10) not null foreign key references NHANVIEN(MaNV) on update cascade,
	TenNgNhan nvarchar(100) not null,
	DiaChi nvarchar(100),
	SDT nvarchar(20) not null
)
go
create table NDXUATKHO
(
	SoPhieuXuat nvarchar(10) foreign key references XUATKHO(SoPhieuXuat) on update cascade on delete cascade,
	MaCF nvarchar(10) foreign key references THEKHO(MaCF) on update cascade,
	LoaiCF nvarchar(50) not null,
	SoLuong smallint,
	DVT nvarchar(5) not null default('kg'),
	primary key (SoPhieuXuat, MaCF)
)
go

--quản trị
CREATE TABLE QuanTri
(
	Email varchar(50) PRIMARY KEY,
	Admin bit,
	HoTen nvarchar(50),
	Password nvarchar(50)
)
go
INSERT INTO QuanTri VALUES
('dat.nhh@gmail.com',1,N'Nguyễn Hoài Huy Đạt','123'),
('quanli@gmail.com',1,N'Nguyễn Xuân Vinh','123')
GO

--dữ liệu
insert into NHANVIEN values
('QL001',N'Nguyễn Xuân',N'Vinh','1998/05/23',1,'',N'25 Hoàng Hoa Thám, Nha Trang','07853132132',N'Quản lý',10000000),
('TK001',N'Trần Thảo',N'Linh','1990/10/09',0,'',N'40 Phong Châu, Nha Trang','01232934492',N'Thủ kho',8000000),
('TK002',N'Phan Nhật',N'Nguyên','1990/03/12',1,'',N'13 Nguyễn Trãi, Nha Trang','07864236163',N'Thủ kho',8000000),
('NV001',N'Lưu Xuân',N'Nghĩa','1992/04/05',1,'',N'80 Hùng Vương, Nha Trang','09091315783',N'Nhân viên',5000000),
('NV002',N'Nguyễn Anh',N'Thư','1992/12/29',0,'',N'51 Thống Nhất, Nha Trang','09099812645',N'Nhân viên',5000000),
('NV003',N'Nguyễn Huy',N'Phong','1993/03/18',1,'',N'21 Phương Sài, Nha Trang','01232137312',N'Nhân viên',5000000),
('NV004',N'Lê',N'Bách','1994/01/01',1,'',N'138 Hương Lộ 45, Nha Trang','07898234813',N'Nhân viên',5000000),
('NV005',N'Trần Thị Kim',N'Tuyền','1996/05/20',0,'',N'36 Đặng Tất, Nha Trang','09043828434',N'Nhân viên',5000000),
('NV006',N'Nguyễn Gia Phương',N'Định','1997/12/31',1,'',N'10 Trương Định, Nha Trang','09080343428',N'Nhân viên',5000000),
('NV007',N'Hồ An',N'Bình','1999/03/03',1,'',N'29 Ngô Gia Tự, Nha Trang','07841345604',N'Nhân viên',5000000)
go

insert into THEKHO values
('RB01',N'Robusta',35,'Kg','75000'),
('AR02',N'Arabica',30,'Kg','130000'),
('CL03',N'Culi',10,'Kg','85000'),
('MK04',N'Moka',15,'Kg','150000'),
('CT05',N'Catimor',10,'Kg','195000')
go

insert into NHAPKHO values 
('N231111','2023/11/11','NV002'),
('N231110','2023/10/11','NV002'),
('N231109','2023/09/11','NV002'),
('N231108','2023/08/11','NV002'),
('N231107','2023/07/11','NV002'),
('N231106','2023/06/11','NV002')
go

insert into NDNHAPKHO values
('N231111','RB01',N'Robusta',35,'kg'),
('N231111','AR02',N'Arabica',30,'kg'),
('N231111','CL03',N'Culi',10,'kg'),
('N231111','MK04',N'Moka',15,'kg'),
('N231111','CT05',N'Catimor',10,'kg'),
('N231110','RB01',N'Robusta',35,'kg'),
('N231110','AR02',N'Arabica',30,'kg'),
('N231110','CL03',N'Culi',10,'kg'),
('N231110','MK04',N'Moka',15,'kg'),
('N231110','CT05',N'Catimor',10,'kg'),
('N231109','RB01',N'Robusta',35,'kg'),
('N231109','AR02',N'Arabica',30,'kg'),
('N231109','CL03',N'Culi',10,'kg'),
('N231109','MK04',N'Moka',15,'kg'),
('N231109','CT05',N'Catimor',10,'kg'),
('N231108','RB01',N'Robusta',35,'kg'),
('N231108','AR02',N'Arabica',30,'kg'),
('N231108','CL03',N'Culi',10,'kg'),
('N231108','MK04',N'Moka',15,'kg'),
('N231108','CT05',N'Catimor',10,'kg'),
('N231107','RB01',N'Robusta',35,'kg'),
('N231107','AR02',N'Arabica',30,'kg'),
('N231107','CL03',N'Culi',10,'kg'),
('N231107','MK04',N'Moka',15,'kg'),
('N231107','CT05',N'Catimor',10,'kg'),
('N231106','RB01',N'Robusta',35,'kg'),
('N231106','AR02',N'Arabica',30,'kg'),
('N231106','CL03',N'Culi',10,'kg'),
('N231106','MK04',N'Moka',15,'kg'),
('N231106','CT05',N'Catimor',10,'kg')
go

insert into XUATKHO values
('X23251001','2023/10/25','NV003',N'Lê Chí Phương','10 Thái Nguyên, Nha Trang','09023552182'),
('X23251002','2023/10/25','NV003',N'Hoàng Công Trứ','125 Võ Nguyên Giáp, Nha Trang','07834738565'),
('X23251003','2023/10/25','NV003',N'Nguyễn Hồng Khanh','31 Lam Sơn, Nha Trang','09088634329'),
('X23250901','2023/09/25','NV003',N'Lê Chí Phương','10 Thái Nguyên, Nha Trang','09023552182'),
('X23250902','2023/09/25','NV003',N'Hoàng Công Trứ','125 Võ Nguyên Giáp, Nha Trang','07834738565'),
('X23250903','2023/09/25','NV003',N'Nguyễn Hồng Khanh','31 Lam Sơn, Nha Trang','09088634329'),
('X23250801','2023/08/25','NV003',N'Lê Chí Phương','10 Thái Nguyên, Nha Trang','09023552182'),
('X23250802','2023/08/25','NV003',N'Hoàng Công Trứ','125 Võ Nguyên Giáp, Nha Trang','07834738565'),
('X23250803','2023/08/25','NV003',N'Nguyễn Hồng Khanh','31 Lam Sơn, Nha Trang','09088634329'),
('X23250701','2023/07/25','NV003',N'Lê Chí Phương','10 Thái Nguyên, Nha Trang','09023552182'),
('X23250702','2023/07/25','NV003',N'Hoàng Công Trứ','125 Võ Nguyên Giáp, Nha Trang','07834738565'),
('X23250703','2023/07/25','NV003',N'Nguyễn Hồng Khanh','31 Lam Sơn, Nha Trang','09088634329'),
('X23250601','2023/06/25','NV003',N'Lê Chí Phương','10 Thái Nguyên, Nha Trang','09023552182'),
('X23250602','2023/06/25','NV003',N'Hoàng Công Trứ','125 Võ Nguyên Giáp, Nha Trang','07834738565'),
('X23250603','2023/06/25','NV003',N'Nguyễn Hồng Khanh','31 Lam Sơn, Nha Trang','09088634329')
go

insert into NDXUATKHO values
('X23251001','RB01',N'Robusta',20,'kg'),
('X23251001','AR02',N'Arabica',20,'kg'),
('X23251002','AR02',N'Arabica',10,'kg'),
('X23251002','CL03',N'Culi',10,'kg'),
('X23251002','CT05',N'Catimor',10,'kg'),
('X23251003','RB01',N'Robusta',15,'kg'),
('X23251003','MK04',N'Moka',15,'kg'),
('X23250901','RB01',N'Robusta',20,'kg'),
('X23250901','AR02',N'Arabica',20,'kg'),
('X23250902','AR02',N'Arabica',10,'kg'),
('X23250902','CL03',N'Culi',10,'kg'),
('X23250902','CT05',N'Catimor',10,'kg'),
('X23250903','RB01',N'Robusta',15,'kg'),
('X23250903','MK04',N'Moka',15,'kg'),
('X23250801','RB01',N'Robusta',20,'kg'),
('X23250801','AR02',N'Arabica',20,'kg'),
('X23250802','AR02',N'Arabica',10,'kg'),
('X23250802','CL03',N'Culi',10,'kg'),
('X23250802','CT05',N'Catimor',10,'kg'),
('X23250803','RB01',N'Robusta',15,'kg'),
('X23250803','MK04',N'Moka',15,'kg'),
('X23250701','RB01',N'Robusta',20,'kg'),
('X23250701','AR02',N'Arabica',20,'kg'),
('X23250702','AR02',N'Arabica',10,'kg'),
('X23250702','CL03',N'Culi',10,'kg'),
('X23250702','CT05',N'Catimor',10,'kg'),
('X23250703','RB01',N'Robusta',15,'kg'),
('X23250703','MK04',N'Moka',15,'kg'),
('X23250601','RB01',N'Robusta',20,'kg'),
('X23250601','AR02',N'Arabica',20,'kg'),
('X23250602','AR02',N'Arabica',10,'kg'),
('X23250602','CL03',N'Culi',10,'kg'),
('X23250602','CT05',N'Catimor',10,'kg'),
('X23250603','RB01',N'Robusta',15,'kg'),
('X23250603','MK04',N'Moka',15,'kg')
go

--thủ thuật
create procedure TIMKIEM_NHANVIEN
    @MaNV varchar(10)=NULL,
	@HoTen nvarchar(100)=NULL,
	@GioiTinh nvarchar(5)= NULL
as
begin
declare @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
select @SqlStr = '
       select * 
       from NHANVIEN
       where (1=1)
       '
if @MaNV is not null
       select @SqlStr = @SqlStr + '
              and (MaNV like ''%'+@MaNV+'%'')
              '
if @HoTen is not null
       select @SqlStr = @SqlStr + '
              and (HoNV+'' ''+TenNV like ''%'+@HoTen+'%'')
              '
if @GioiTinh is not null
       select @SqlStr = @SqlStr + '
             and (GioiTinh like ''%'+@GioiTinh+'%'')
             '
	exec SP_EXECUTESQL @SqlStr
end
go

create procedure TIMKIEM_THEKHO
	@MaCF nvarchar(10) =null,
	@LoaiCF nvarchar(50) =null
as
begin
declare @SqlStr nvarchar(4000),
		@ParamList nvarchar(2000)
select @SqlStr = '
       select * 
       from THEKHO
       where (1=1)
       '
if @MaCF is not null
       select @SqlStr = @SqlStr + '
              and (MaCF like ''%'+@MaCF+'%'')
			  '
if @LoaiCF is not null
       select @SqlStr = @SqlStr + '
              and (LoaiCF like ''%'+@LoaiCF+'%'')
			  '
	exec SP_EXECUTESQL @SqlStr
end
go

create procedure TIMKIEM_NHAPKHO
	@SoPhieuNhap nvarchar(10) =null
as
begin
declare @SqlStr nvarchar(4000),
		@ParamList nvarchar(2000)
select @SqlStr = '
       select * 
       from NHAPKHO
       where  (1=1)
       '
if @SoPhieuNhap is not null
       select @SqlStr = @SqlStr + '
              and (SoPhieuNhap like ''%'+@SoPhieuNhap+'%'')
			  '
	exec SP_EXECUTESQL @SqlStr
end
go

create procedure TIMKIEM_XUATKHO
	@SoPhieuXuat nvarchar(10) =null
as
begin
declare @SqlStr nvarchar(4000),
		@ParamList nvarchar(2000)
select @SqlStr = '
       select * 
       from XUATKHO
       where (1=1)
       '
if @SoPhieuXuat is not null
       select @SqlStr = @SqlStr + '
              and (SoPhieuXuat like ''%'+@SoPhieuXuat+'%'')
			  '
	exec SP_EXECUTESQL @SqlStr
end
go

create procedure LOC_NDNHAPKHO
	@SoPhieuNhap nvarchar(10) =null
as
begin
declare @SqlStr nvarchar(4000),
		@ParamList nvarchar(2000)
select @SqlStr = '
       select * 
       from NDNHAPKHO
       where (1=1)
       '
if @SoPhieuNhap is not null
       select @SqlStr = @SqlStr + '
              and (SoPhieuNhap like ''%'+@SoPhieuNhap+'%'')
			  '
	exec SP_EXECUTESQL @SqlStr
end
go
create procedure LOC_NDXUATKHO
	@SoPhieuXuat nvarchar(10) =null
as
begin
declare @SqlStr nvarchar(4000),
		@ParamList nvarchar(2000)
select @SqlStr = '
       select * 
       from NDXUATKHO
       where (1=1)
       '
if @SoPhieuXuat is not null
       select @SqlStr = @SqlStr + '
              and (SoPhieuXuat like ''%'+@SoPhieuXuat+'%'')
			  '
	exec SP_EXECUTESQL @SqlStr
end
go