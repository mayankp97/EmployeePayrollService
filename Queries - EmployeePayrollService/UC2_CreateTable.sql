create table employee_payroll 
(
id int not null Identity(1,1) primary key ,
name varchar(25) not null,
salary int not null,
start_date date
);