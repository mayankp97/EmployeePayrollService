use AddressBookDB
Go

Select * from ABookTable
	Inner Join AddressInfo On ABookTable.Id = AddressInfo.Id
	Where City = 'Bhilai'
GO

Select City,COUNT(City) from ABookTable
	Inner Join AddressInfo On ABookTable.Id = AddressInfo.Id
	Group By City,State
GO

Select * from ABookTable
	Inner Join AddressInfo On ABookTable.Id = AddressInfo.Id
	Where City = 'Bhilai'
	Order By FirstName
GO

Select Count(RelationType) from ABookTable
Go