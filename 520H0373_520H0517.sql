create database 

use SupplementProductManagement

create table Categories (
	Id varchar(40) not null,
	Consumer varchar(40),
	Gender varchar(40),
	Age int,
	Effect varchar(40)
)

create table Manufacturers (
	Id varchar(40) not null,
	Name varchar(40),
	Email varchar(40),
	Nation varchar(40),
	Phone varchar(40),
	Address varchar(40)
)

create table Consignments (
	Id varchar(40) not null,
	Produced_Date DateTime,
	Expired_Date DateTime,
	Imported_Date DateTime
)

create table Products (
	Id varchar(40) not null,
	Name varchar(40),
	Price float,
	Tax float,
	Quantity_Theory int,
	Quantity_Real int,
	Unit varchar(40),
	Sold int,
	Manufacturer_Id varchar(40),
	Category_Id varchar(40),
	Consignment_Id varchar(40)
)

create table Accountants (
	Id varchar(40) not null,
	Name varchar(40),
	Email varchar(40),
	Gender varchar(40),
	Phone varchar(40),
	Address varchar(40)
)

create table Suppliers (
	Id varchar(40) not null,
	Name varchar(40),
	Email varchar(40),
	Phone varchar(40),
	Address varchar(40)
) 

create table Receipts (
	Id int identity(1,1) not null,
	Created_Date varchar(40),
	Price float,
	Address varchar(40),
	Supplier_Id varchar(40),
	Accountant_Id varchar(40),
)

create table ReceiptDetails (
	Receipt_Id int not null,
	Product_Id varchar(40) not null,
	Quantity int
)

create table Agencies (
	Id int identity(1,1) not null,
	Name varchar(40),
	Email varchar(40),
	Phone varchar(40),
	Address varchar(40)
)

create table Bills (
	Id int identity(1,1) not null,
	Exported_Date varchar(40),
	Checked_Date varchar(40),
	Price float,
	Payment varchar(40),
	Status varchar(40),
	Paid varchar(40),
	Accountant_Id varchar(40),
	Agency_Id int
)

create table BillDetails (
	Bill_Id int not null,
	Product_Id varchar(40) not null,
	Quantity int
)

create table Customers (
	Id int identity(1,1) not null,
	Name varchar(40),
	Email varchar(40),
	Password varchar(40),
	Phone varchar(40),
	Address varchar(40),
	Gender varchar(40)
)

create table Invoices (
	Id int identity(1,1) not null,
	Exported_Date varchar(40),
	Checked_Date varchar(40),
	Price float,
	Payment varchar(40),
	Status varchar(40),
	Paid varchar(40),
	Accountant_Id varchar(40),
	Customer_Id int
)

create table InvoiceDetails (
	Invoice_Id int not null,
	Product_Id varchar(40) not null,
	Quantity int
)

alter table Categories add constraint PK_Categories primary key (Id)

alter table Manufacturers add constraint PK_Manufacturers primary key (Id)

alter table Products add constraint PK_Products primary key (Id)
alter table Products add constraint FK_Products_Categories foreign key (Category_Id) references Categories (Id)
alter table Products add constraint FK_Products_Manufacturers foreign key (Manufacturer_Id) references Manufacturers (Id)
alter table Products add constraint FK_Products_Consignments foreign key (Consignment_Id) references Consignments (Id)

alter table Consignments add constraint PK_Consignments primary key(Id)

alter table Accountants add constraint PK_Accountants primary key (Id)

alter table Suppliers add constraint PK_Suppliers primary key (Id)

alter table Receipts add constraint PK_Receipts primary key (Id)
alter table Receipts add constraint FK_Receipt_Suppliers foreign key (Supplier_Id) references Suppliers (Id)
alter table Receipts add constraint FK_Receipt_Accountants foreign key (Accountant_Id) references Accountants (Id)

alter table ReceiptDetails add constraint PK_ReceiptDetails primary key (Receipt_Id, Product_Id)
alter table ReceiptDetails add constraint FK_ReceiptDetails_Receipts foreign key (Receipt_Id) references Receipts (Id)
alter table ReceiptDetails add constraint FK_ReceiptDetails_Products foreign key (Product_Id) references Products (Id)

alter table Agencies add constraint PK_Agencies primary key (Id)

alter table Bills add constraint PK_Bills primary key (Id)
alter table Bills add constraint FK_Bill_Agencies foreign key (Agency_Id) references Agencies (Id)
alter table Bills add constraint FK_Bill_Accountants foreign key (Accountant_Id) references Accountants (Id)

alter table BillDetails add constraint PK_BillDetails primary key (Bill_Id, Product_Id)
alter table BillDetails add constraint FK_BillDetails_Bills foreign key (Bill_Id) references Bills (Id)
alter table BillDetails add constraint FK_BillDetails_Products foreign key (Product_Id) references Products (Id)

alter table Customers add constraint PK_Customers primary key (Id)

alter table Invoices add constraint PK_Invoices primary key (Id)
alter table Invoices add constraint FK_Invoices_Customers foreign key (Customer_Id) references Customers (Id)
alter table Invoices add constraint FK_Invoices_Accountants foreign key (Accountant_Id) references Accountants (Id)

alter table InvoiceDetails add constraint PK_InvoiceDetails primary key (Invoice_Id, Product_Id)
alter table InvoiceDetails add constraint FK_InvoiceDetails_Invoices foreign key (Invoice_Id) references Invoices (Id)
alter table InvoiceDetails add constraint FK_InvoiceDetails_Products foreign key (Product_Id) references Products (Id)

insert into Categories ( Id, Consumer, Gender, Age, Effect) values (
	'I0024M00A0001', 'Infants', 'All', 2, 'Digestive System'
),(
	'I0024M00A0002', 'Infants', 'All', 2, 'Respiratory System'
),(
	'I0024M00A0003', 'Infants', 'All', 2, 'Nerve System'
),(
	'I0024M00A0004', 'Infants', 'All', 2, 'Eyes'
),(
	'C005Y00A0001', 'Children', 'All', 5, 'Nerve System'
),(
	'A0050Y00A0001', 'Adults', 'All', 50, 'Osteoarthritis'
)

insert into Manufacturers ( Id, Name, Email, Nation, Address, Phone) values (
	'C00H00000', 'Canadian pharmaceutical company', 'canadianpharmacom@gmail.com', 'Canada', 'Grulph, Ontario, Canada', '613 456 2344'
),(
	'USA00H00000', 'American pharmaceutical company', 'americanpharmacom@gmail.com', 'United State Of America', 'California, USA', '951 589 4224'
)

insert into Products ( Id, Name, Price, Tax, Quantity_Theory, Quantity_Real, Unit, Sold, Manufacturer_Id, Category_Id) values (
	'P00M00001', 'Healthy Eyes', 100, 5, 10, 10, 'Can', 0, 'C00H00000', 'I0024M00A0004'
),(
	'P00H00002', 'Advanced Healthy Eyes', 140, 5, 10, 10, 'Can', 0, 'C00H00000', 'I0024M00A0004'
),(
	'P00H00003', 'Enhanced Memory Capability', 150, 5, 20, 20, 'Jar', 0, 'USA00H00000', 'C005Y00A0001'
)

insert into Accountants ( Id, Name, Email, Gender, Address, Phone) values (
	'20EH00373', 'Nguyen Le Minh Khanh', 'minhkhanh@gmail.com', 'Male', 'District 3, Ho Chi Minh city', '0936 730 339'
)

insert into Suppliers ( Id, Name, Email, Address, Phone) values (
	'20SH00517', 'Tran Thien Bao','thienbao@gmail.com', 'Tan Binh District, Ho Chi Minh city', '0945 123 769'
)

drop table Categories
drop table Manufacturers
drop table Products
drop table Consignments
drop table Receipts
drop table ReceiptDetails
drop table BillDetails

select * from Products
select * from Categories
select * from Manufacturers
select * from Accountants
select * from Consignments
select * from Receipts
select * from Suppliers
select * from ReceiptDetails
select * from Bills
select * from BillDetails
select * from Customers
select * from Invoices
select * from InvoiceDetails

delete Bills
delete BillDetails


