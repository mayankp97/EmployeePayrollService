USE [payroll_service]
GO
ALTER TABLE [dbo].[employee_payroll]
	ADD gender varchar(1)
GO
UPDATE [dbo].[employee_payroll]
   SET [gender] = 'M'
GO



