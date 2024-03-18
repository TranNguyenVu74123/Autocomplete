create database NhaSach
go
use NhaSach
go
create table TheLoai
(
maloai int identity primary key,
tenloai nvarchar(30)
)
go
create table Sach
(
masach int identity(1,1) primary key,
maloai int references TheLoai(maloai),
tensach nvarchar(100) not null,
hinh varchar(50),
giaban decimal(18,0),
ngaycapnhat smalldatetime,
soluongton int
)
go
---------------------
insert into TheLoai(tenloai) values(N'Công nghệ thông tin')
insert into TheLoai(tenloai) values(N'Kinh tế')
insert into TheLoai(tenloai) values(N'Mỹ thuật')
select * from TheLoai
go
---------------------
insert into Sach(maloai,tensach,hinh,giaban,ngaycapnhat,soluongton) values(1,N'Lập
trình Java','/Content/images/book1.jpg',40000,'12/02/2022',20)
insert into Sach(maloai,tensach,hinh,giaban,ngaycapnhat,soluongton) values(2,N'Quản
trị kinh doanh quốc tế','/Content/images/book2.jpg',50000,'02/24/2022',20)
insert into Sach(maloai,tensach,hinh,giaban,ngaycapnhat,soluongton) values(3,N'Kỹ
thuật tô màu','/Content/images/book3.jpg',75000,'02/24/2022',20)
select * from Sach