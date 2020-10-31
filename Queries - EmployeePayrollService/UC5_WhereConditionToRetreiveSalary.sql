USE [payroll_service]
GO

SELECT [name],
	   [salary]
  FROM [dbo].[employee_payroll]
  WHERE name = 'Mayank' 
  OR [start_date] BETWEEN CAST('2017-01-01' AS DATE) AND GETDATE()

GO


