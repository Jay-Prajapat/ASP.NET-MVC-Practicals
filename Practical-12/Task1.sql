Create Table Employee
(
	Id int primary key identity,
	FirstName varchar(50) not null,
	MiddleName varchar(50),
	LastName varchar(50) not null,
	DOB date not null,
	MobileNumber varchar(10) not null,
	Address varchar(100)
)

-- Write an insert query to insert a record in the above table
insert into Employee values
('Jay','A','Prajapati','2002-01-15','9797457032','Vyara'),
('Gaurav','K','Mori','2002-03-12','8975465452','Bhavnagar'),
('Suman',' S','Jha','2000-07-07','6556963251','Nepal'),
('Jenish','K','Raiyani','2002-05-31','5256965845','Junagadh'),
('Jainam','M','Bhavsar','2002-04-21','9478965236','Nadiad')

--Write an Update query to change the First Name to “SQLPerson” for the first record
update Employee set FirstName = 'SQLPerson' where id = 1

--Write an Update query to change the Middle Name to “I” for all records
update Employee set LastName = 'I'

-- Write a delete query to delete record having Id column value less than 2
delete from Employee where Id < 2

--Write a query to delete all the data from the table
truncate table Employee










