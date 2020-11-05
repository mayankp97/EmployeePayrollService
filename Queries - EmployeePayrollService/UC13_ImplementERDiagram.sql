use AddressBookDB;



alter table ABookTable
drop column PhoneNumber, Address, City, State, Email, ZipCode
Go

alter table ABookTable
add primary key (Id)
Go

create table ContactInfo  
(
	Id Int Primary Key not null identity(1,1) foreign key references ABookTable(Id),
	PhoneNumber varchar(13) not null,
	Email varchar(25) not null
)
Go

create table AddressInfo
(
	Id Int Primary Key not null identity(1,1) foreign key references ABookTable(Id),
	Address varchar(15) not null,
	City varchar(15) not null,
	State varchar(20) not null,
	Zipcode varchar(6) not null,
)
Go

SET IDENTITY_INSERT dbo.AddressInfo ON
Go

INSERT INTO AddressInfo(Id,Address,City,State,Zipcode)
     VALUES
           (1,'28/A','Bhilai','C.G.','490006'),
		   (3,'28/A','Hyd','T.L.','490566'),
		   (4,'28/A','Vizag','A.P.','499876'),
		   (5,'LtWllaims','Raigarh','C.G.','579893'),
		   (6,'Ban/A','Bhellary','K.A.','780006')

GO

SET IDENTITY_INSERT dbo.AddressInfo OFF
Go

SET IDENTITY_INSERT dbo.ContactInfo ON
Go

INSERT INTO ContactInfo(Id,PhoneNumber,Email)
     VALUES
           (1,'9674879893','monee99@gmail.com'),
		   (3,'8555466603','pru17@gmail.com'),
		   (4,'7487009893','rajat002@gmail.com'),
		   (5,'7487009893','ank675@gmail.com'),
		   (6,'924579893','chin56@gmail.com')
GO