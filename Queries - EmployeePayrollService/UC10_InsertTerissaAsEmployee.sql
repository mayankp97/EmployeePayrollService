USE [payroll_service]
GO

INSERT INTO [dbo].[employee_payroll]
           ([name]
           ,[salary]
           ,[start_date]
           ,[gender]
           ,[phone]
           ,[address]
           ,[department]
           ,[basic_pay]
           ,[taxable_pay]
           ,[income_tax]
           ,[net_pay])
     VALUES
           ('Terissa'
           ,100000
           ,'2018-05-05'
           ,'F'
           ,'8874578954'
           ,'near shushi kingdom'
           ,'Sales'
           ,40000
           ,60000
           ,6000
           ,54000),
		   ('Terissa'
           ,100000
           ,'2018-05-05'
           ,'F'
           ,'8874578954'
           ,'near shushi kingdom'
           ,'Marketing'
           ,50000
           ,60000
           ,16000
           ,44000)
GO


