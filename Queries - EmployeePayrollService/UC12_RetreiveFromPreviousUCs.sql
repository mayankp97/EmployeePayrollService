USE [payroll_service]
GO

SELECT *
  FROM [dbo].[Employee] AS emp INNER JOIN [dbo].[Payroll] AS pay
  ON emp.Id = pay.Id

GO
SELECT [Salary]
  FROM [dbo].[Employee] AS emp INNER JOIN [dbo].[Payroll] AS pay
  ON emp.Id = pay.Id
  WHERE [StartDate] BETWEEN CAST('2017-01-01' AS DATE) AND GETDATE()

GO

SELECT COUNT(*) AS NumMales,
		AVG(Salary) AverageSalary,
		MAX(Salary) AS MaxSalary,
		MIN(Salary) AS MinSalary
	FROM [dbo].[Employee] AS emp INNER JOIN [dbo].[Payroll] AS pay
    ON emp.Id = pay.Id
	WHERE Gender = 'M'
	GROUP BY Gender
GO
SELECT COUNT(*) AS NumFemales,
		AVG(Salary) AS AverageSalary,
		MAX(Salary) AS MaxSalary,
		MIN(Salary) AS MinSalary
	FROM [dbo].[Employee] AS emp INNER JOIN [dbo].[Payroll] AS pay
    ON emp.Id = pay.Id
	WHERE Gender = 'F'
	GROUP BY Gender
GO

