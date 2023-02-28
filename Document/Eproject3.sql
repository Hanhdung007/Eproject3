create database eProject3
go
USE eProject3;
GO 

create table Labs
(
	Labs_ID int primary key identity,
	LabsName varchar(max),
	Quantity int,
)
go

create table Suppliers
(
	Supplier_ID int primary key identity,
	SupplierName varchar(max) not null,
)
go 
CREATE TABLE Devices (
Devices_ID varchar(50) PRIMARY KEY,
DeviceName NVARCHAR(MAX) NOT NULL,
DeviceType NVARCHAR(MAX) NULL,
SupplyFrom NVARCHAR(MAX) NULL,
Status NVARCHAR(MAX) NULL,
DateMaintance DATETIME NULL,
DeviceImg NVARCHAR(MAX) NULL,
Labs_ID int not null,
Supplier_ID int not null,
CONSTRAINT fk_labs_Labs_ID
FOREIGN KEY (Labs_ID)
REFERENCES Labs (Labs_ID), 
CONSTRAINT fk_supplier_Supplier_ID
FOREIGN KEY (Supplier_ID)
REFERENCES Suppliers (Supplier_ID),
);
go 
CREATE TABLE Admins (
ID nvarchar(50) PRIMARY KEY,
AdminName NVARCHAR(MAX) NOT NULL,
Password NVARCHAR(MAX) NOT NULL,
Role varchar(max) not null
);
go
create table users
(
	Users_ID int primary key identity,
	Username nvarchar(max) not null,
	Passwords nvarchar(max) not null,
	Email nvarchar(max) not null
)
go
create table Complain
(
	Complain_ID int primary key identity,
	description nvarchar(max) not null,
	Reason nvarchar(max) not null,
	Status_CP nvarchar(max) not null,
	Date_CP datetime not null,
	Category nvarchar(max) not null,
	ID nvarchar(50) not null,
	CONSTRAINT fk_admins_Admin_ID
    FOREIGN KEY (ID)
    REFERENCES Admins (ID)
)
go
create table report 
(
	Report_ID int primary key identity,
	Descriptions varchar(max) null,
	ReportDate datetime not null,
	Reciver varchar(max) not null,
	Complain_ID int not null,
	Devices_ID varchar(50) not null,
	CONSTRAINT fk_report_Report_ID
	FOREIGN KEY (Complain_ID)
	REFERENCES Complain (Complain_ID),
	CONSTRAINT fk_Devices_Devices_ID
	FOREIGN KEY (Devices_ID)
	REFERENCES Devices (Devices_ID)
)
go 
create table MaintainceDevices
(
	Maintn_ID int primary key identity,
	Descriptions varchar(max)not null,
	Reason varchar(max)not null,
	Date datetime not null,
	Creater varchar(max) not null,
	Devices_ID varchar(50) not null,
	ID nvarchar(50) not null,
	CONSTRAINT fk_device_Devices_ID
	FOREIGN KEY (Devices_ID)
	REFERENCES Devices (Devices_ID),
	CONSTRAINT fk_admin_ID
	FOREIGN KEY (ID)
	REFERENCES Admins(ID)
)

