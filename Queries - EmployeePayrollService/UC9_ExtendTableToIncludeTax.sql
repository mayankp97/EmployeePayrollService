USE [payroll_service]
GO
ALTER TABLE [dbo].[employee_payroll]
	ADD 
		basic_pay INT DEFAULT 50000,
		taxable_pay INT DEFAULT 0,
		income_tax INT DEFAULT 0,
		net_pay INT DEFAULT 0
GO


