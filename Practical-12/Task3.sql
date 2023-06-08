Create Table Employee
(
	Id int primary key identity,
	FirstName varchar(50) not null,
	MiddleName varchar(50),
	LastName varchar(50) not null,
	DOB date not null,
	MobileNumber varchar(10) not null,
	Address varchar(100),
	Salary decimal not null,
	DesignationId int foreign key REFERENCES Designation(Id)
)

Create Table Designation
(
	Id int primary key identity,
	Designation varchar(50) not null
)

Insert into Designation values 
('Team Leader'),
('Director'),
('HR'),
('Administrator')

insert into Employee values
('Jay','A','Prajapati','2002-01-15','9797457032','Vyara',50000,1),
('Gaurav','K','Mori','2002-03-12','8975465452','Bhavnagar',60000,1),
('Suman',' S','Jha','2000-07-07','6556963251','Nepal',50000,2),
('Jenish','K','Raiyani','2002-05-31','5256965845','Junagadh',70000,3),
('Jainam','M','Bhavsar','1999-04-21','9478965236','Nadiad',55000,4)

select * from Employee

-- Write a query to count the number of records by designation name
select Designation,count(Designation) 
from Employee inner join Designation on 
Employee.DesignationId = Designation.Id 
group by Designation

--Write a query to display First Name, Middle Name, Last Name & Designation name
select FirstName,MiddleName, LastName,Designation 
from Employee inner join Designation on 
Employee.DesignationId = Designation.Id

--Create a database view that outputs Employee Id, First Name, Middle Name, Last Name, 
--Designation, DOB, Mobile Number, Address & Salary
create view EmployeeView as
Select E.Id, E.FirstName, E.MiddleName, E.LastName, D.Designation, E.DOB, E.MobileNumber, E.Salary, E.Address
from Employee as E inner join Designation as D on 
E.DesignationId = D.Id

select * from EmployeeView

--Create a stored procedure to insert data into the Designation table with required parameters
create procedure sp_InsertDesignation
@Designation varchar(50)

as
begin
	insert into Designation values(@Designation)
end

sp_InsertDesignation 'Manager'

--Create a stored procedure to insert data into the Employee table with required parameters
create procedure sp_InsertEmployee
@FirstName varchar(50),
@MiddleName varchar(50),
@LastName varchar(50),
@DOB date,
@MobileNumber varchar(10),
@Address varchar(100),
@Salary decimal,
@DesignationId int

as
begin
	insert into Employee Values (@FirstName,@MiddleName,@LastName,@DOB,@MobileNumber,@Address,@Salary,@DesignationId)
end

sp_InsertEmployee 'SqlUser','A','Server','1998-05-06',8585966589,'Local DB',30000,5

--Write a query that displays only those designation names that have more than 1 employee
select Designation,Count(Designation) as TotalEmployee from Employee inner join Designation on 
Employee.DesignationId = Designation.Id
group by Designation having count(Designation) > 1

--Create a stored procedure that returns a list of employees with columns Employee Id, First Name,
--Middle Name, Last Name, Designation, DOB, Mobile Number, Address & Salary (records should be ordered by DOB)

create procedure sp_EmployeeOrderByDOB
as
begin
	select Employee.Id,FirstName, MiddleName, LastName, Designation, DOB, MobileNumber, Address, Salary
	from Employee inner join Designation on 
	Employee.DesignationId = Designation.Id
	order by DOB
end

--Create a stored procedure that return a list of employees by designation id (Input) with columns
--Employee Id, First Name, Middle Name, Last Name, DOB, Mobile Number, Address & Salary (records should be ordered by First Name)

Create procedure sp_GetEmployeeByDesignationId
@DesignationId int
as
begin
	select Employee.Id,FirstName, MiddleName, LastName, DOB, MobileNumber, Address, Salary
	from Employee 
	where DesignationId = @DesignationId
	order by FirstName
end

sp_GetEmployeeByDesignationId 1

--Create Non-Clustered index on the DesignationId column of the Employee table

create nonclustered index IX_DesignationId on Employee(DesignationId)

--Write a query to find the employee having maximum salary
select top 1 * from Employee order by Salary desc

select * from Employee
order by Salary desc
offset 0 rows
fetch next 1 rows only