create procedure SpAddEmployeeDetails
(
@EmployeeName varchar(255),
@Salary int,
@StartDate Date,
@Gender char(1),
@PhoneNumber varchar(12),
@Address varchar(255),
@Department varchar(25),
@BasicPay int,
@TaxablePay int,
@IncomeTax int,
@NetPay int
)
as
begin
insert into employee_payroll values
(
@EmployeeName,@Salary,@StartDate,@Gender,@PhoneNumber,@Address,@Department,@BasicPay,@TaxablePay,@IncomeTax,@NetPay
)
end



CREATE procedure spUpdateEmployeeSalary
(
@id int,
@salary int
)
as
BEGIN
--below line will cause transaction uncommitable if constraint violation occur
set XACT_ABORT on;
begin try
begin TRANSACTION;
update Payroll
set Salary=@salary
where Id=@id;
select e.Id,e.Name,s.Salary
from Employee e inner join SALARY s
ON e.Id=s.Id where s.Id=@id;
COMMIT TRANSACTION;
END TRY
BEGIN CATCH
select ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage;
IF(XACT_STATE())=-1
BEGIN
  PRINT N'The transaction is in an uncommitable state.'+'Rolling back transaction.'
  ROLLBACK TRANSACTION;
  END;

  IF(XACT_STATE())=1
  BEGIN
    PRINT 
	    N'The transaction is committable. '+'Committing transaction.'
       COMMIT TRANSACTION;
	END;
	END CATCH
END
