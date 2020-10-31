USE [payroll_service]
GO
ALTER TABLE [dbo].[employee_payroll]
	ADD
		phone varchar(12),
		address varchar(255) DEFAULT 'Home',
		department varchar(25)
GO
	
UPDATE [dbo].[employee_payroll]
   SET [phone] = '1234567890'
      ,[address] = 'office'
      ,[department] = 'Analyst'
GO

ALTER TABLE [dbo].[employee_payroll]
ALTER COLUMN 
	[department]
		varchar(25) not null
GO


