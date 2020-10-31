USE [payroll_service]
GO

SELECT  COUNT(*) AS number_of_males,
		AVG(salary) AS avg_salary,
		MIN(salary) AS min_salary,
		MAX(salary) AS max_salary
  FROM [dbo].[employee_payroll]
  WHERE [gender] = 'M'
  GROUP BY [gender]

GO
SELECT  COUNT(*) AS number_of_females,
		AVG(salary) AS avg_salary,
		MIN(salary) AS min_salary,
		MAX(salary) AS max_salary
  FROM [dbo].[employee_payroll]
  WHERE [gender] = 'F'
  GROUP BY [gender]


