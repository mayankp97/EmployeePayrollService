Create Table PayrollDetails 
(
	SalaryId Int Primary Key,
	Salary float,
	Deductions As Salary * 0.2,
	TaxablePay As Salary - Salary * 0.2,
	Tax As (Salary - Salary * 0.2) * 0.1,
	NetPay As Salary - ((Salary - Salary * 0.2) * 0.1)
)

Alter Table Employee
	Add SalaryId Int Foreign Key References PayrollDetails(SalaryId)
	Go
Insert Into PayrollDetails Values 
	(1,1000000),
	(2,1400000),
	(3,2000000),
	(4,5000000)
GO