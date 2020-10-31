USE [payroll_service]
GO

INSERT INTO [dbo].[employee_payroll]
           ([name]
           ,[salary]
           ,[start_date])
     VALUES
           ('Raju',
		   100000,
		   '2020-12-21'),
		   ('Mukesh',
		   300000,
		   '2016-09-14'),
		   ('Mohan',
		   200000,
		   '2019-01-15')
GO


