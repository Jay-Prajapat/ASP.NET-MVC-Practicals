Create Table Employee
(
	Id int primary key identity,
	FirstName varchar(50) not null,
	MiddleName varchar(50),
	LastName varchar(50) not null,
	DOB date not null,
	MobileNumber varchar(10) not null,
	Address varchar(100),
	Salary Decimal not null
)

insert into Employee values
('Jay','A','Prajapati','2002-01-15','9797457032','Vyara',50000),
('Gaurav','K','Mori','2002-03-12','8975465452','Bhavnagar',60000),
('Suman',' S','Jha','2000-07-07','6556963251','Nepal',50000),
('Jenish','K','Raiyani','2002-05-31','5256965845','Junagadh',70000),
('Jainam','M','Bhavsar','1999-04-21','9478965236','Nadiad',55000)

--Write an SQL query to find the total amount of salaries
select sum(Salary) AS TotalAmount from Employee

--Write an SQL query to find all employees having DOB less than 01-01-2000
select * from Employee where DOB < '2000-01-01'

--Write an SQL query to count employees having Middle Name NULL
select count(*) as EmployeeAsMiddleNameNull from Employee where MiddleName is null