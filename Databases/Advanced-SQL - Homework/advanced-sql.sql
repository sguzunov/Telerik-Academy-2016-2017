USE TelerikAcademy;

/* Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company */

SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees);

/* Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher
than the minimal salary for the company. */

SELECT e.FirstName, e.LastName, e.Salary
FROM Employees e
WHERE e.Salary < 
	(SELECT MIN(Salary) * 1.1 
	FROM Employees);

/* Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department. */

SELECT e.FirstName + ' ' + e.LastName AS [Full name], e.Salary, d.Name AS [Department name]
FROM Employees e, Departments d
	WHERE e.DepartmentID = d.DepartmentID
	AND	e.Salary = 
			(SELECT MIN(Salary)
				FROM Employees
				WHERE DepartmentID = d.DepartmentID);

/* Write a SQL query to find the average salary in the department #1. */

SELECT AVG(Salary)
FROM Employees
WHERE DepartmentID = 1;

/* Write a SQL query to find the average salary in the "Sales" department. */

SELECT AVG(Salary)
FROM Employees
WHERE DepartmentID = 
	(SELECT DepartmentID 
		FROM Departments
		WHERE Name = 'Sales');

/* Write a SQL query to find the number of employees in the "Sales" department */

SELECT COUNT(*)
FROM Employees
WHERE DepartmentID = 
	(SELECT DepartmentID 
		FROM Departments
		WHERE Name = 'Sales');

/* Write a SQL query to find the number of all employees that have manager. */

SELECT COUNT(*)
FROM Employees e
WHERE e.ManagerID IS NOT NULL;

/* Write a SQL query to find the number of all employees that have no manager. */

SELECT COUNT(*)
FROM Employees e
	WHERE e.ManagerID IS NULL;

/* Write a SQL query to find all departments and the average salary for each of them. */

SELECT d.Name AS 'Department name', AVG(Salary) AS 'Average salary'
FROM Departments d, Employees e
	WHERE d.DepartmentID = e.DepartmentID
GROUP BY d.Name;

/* Write a SQL query to find the count of all employees in each department and for each town. */

SELECT COUNT(e.FirstName) AS 'Employees count', d.Name AS 'Department name', t.Name AS 'Town name'
	FROM Employees e
	JOIN Departments d
		ON d.DepartmentID = e.DepartmentID
	JOIN Addresses ad
		ON ad.AddressID = e.AddressID
	JOIN Towns t
		ON ad.TownID = t.TownID
GROUP BY d.Name, t.Name;

/* Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name. */

SELECT *
FROM Employees e
	JOIN Employees m
	ON e.ManagerID = m.EmployeeID
GROUP BY m.EmployeeID, 


/* Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager) */

SELECT e.FirstName + ' ' + e.LastName AS 'Employee name', 
	COALESCE(m.FirstName + ' ' + m.LastName, 'No manager') AS 'Manager name'
FROM Employees e
LEFT JOIN Employees m
ON e.ManagerID = m.EmployeeID;

/* Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function */

SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5;

/* Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds". */

SELECT CONVERT(VARCHAR(50), GETDATE(), 104) + ' ' + CONVERT(VARCHAR(50), GETDATE(), 114);

/* Write a SQL statement to create a table Users. Users should have username, password, full name and last login time. */

CREATE TABLE Users(
	UserId INT NOT NULL PRIMARY KEY IDENTITY,
	Username NVARCHAR(50) NOT NULL UNIQUE,
	Password VARCHAR(50) NOT NULL,
	Fullname NVARCHAR(100),
	LastLogin SMALLDATETIME,
	CHECK (LEN(Password) > 5)
);

INSERT INTO Users(Username, Password, FullName, LastLogin)
VALUES('pesho', 'pesho123', 'Peter Petrov', GETDATE()),
('gosho', 'gosho321', 'Georgi Georgiev', GETDATE()),
('StAmAt', 'stamat123', 'Stamat Stamatov', GETDATE());

/* Write a SQL statement to create a view that displays the users from the Users table that have been in the system today. */

CREATE VIEW [V_UsersToday] AS
(SELECT * FROM Users WHERE DAY(LastLogin) = DAY(GETDATE()));

SELECT * FROM V_UsersToday;

/* Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint). */

CREATE TABLE Groups(
	GroupId INT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) UNIQUE
);

/* Write a SQL statement to add a column GroupID to the table Users. 
	Fill some data in this new column and as well in the `Groups table.
	Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
*/

ALTER TABLE Users
ADD GroupId INT;

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups FOREIGN KEY(GroupId) REFERENCES Groups(GroupId);

INSERT INTO Groups(Name)
VALUES('Group 1'),
('Group 2'),
('Group 3'),
('Group 4'),
('Group 5');

UPDATE Users
SET GroupId = 1
WHERE UserId = 1;

UPDATE Users
SET GroupId = 1
WHERE UserId = 2;

/* TODO */

/* Write SQL statements to insert several records in the Users and Groups tables. */

INSERT INTO Groups(Name)
VALUES('Group 6'),
('Group 7'),
('Group 8');

INSERT INTO Users(Username, Password, FullName, LastLogin)
VALUES('ivancho', 'ivancho123', 'Ivan Ivanov', GETDATE()),
('toshko', 'tosheto321', 'Todor Todorov', GETDATE()),
('roskata', 'roskataasdasdad', 'Rosen Rosenov', '10.02.2010'),
('tancheto', 'tancheto213', 'Tanya Tatynova', '02.01.2009'),
('rumbata', 'rumbata123', 'Rumen Rumenov', GETDATE());

/* Write SQL statements to update some of the records in the Users and Groups tables. */

UPDATE Users
SET Username = 'todor'
WHERE Username = 'toshko';

UPDATE Groups
SET Name = 'Grupata'
WHERE GroupId = 1;

/* Write SQL statements to delete some of the records from the Users and Groups tables. */

DELETE FROM Users
WHERE Username = 'rumbata';

DELETE FROM Groups
WHERE Name = 'Grupata';

/* Write SQL statements to insert in the Users table the names of all employees from the Employees tab 
	Combine the first and last names as a full name.
	For username use the first letter of the first name + the last name (in lowercase).
	Use the same for the password, and NULL for last login time.
*/

INSERT INTO Users(Username, Password, Fullname, LastLogin)
	(SELECT LOWER(SUBSTRING(FirstName, 1, 1) + SUBSTRING(LastName, LEN(LastName) - 1, 1)),
	LOWER(SUBSTRING(FirstName, 1, 1) + SUBSTRING(LastName, LEN(LastName) - 1, 1)) + 'secret',
	FirstName + ' ' + LastName,
	NULL
	FROM Employees);

/* Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010. */

UPDATE Users
SET Password = NULL
WHERE LastLogin < '10.03.2010';

/* Write a SQL statement that deletes all users without passwords (NULL password). */

DELETE FROM Users
WHERE Password IS NULL;

/* Write a SQL query to display the average employee salary by department and job title. */

SELECT d.DepartmentID, e.JobTitle, AVG(Salary) AS [Avg salary]
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.DepartmentID, e.JobTitle;

/* Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it. */

SELECT e.FirstName, e.LastName, MIN(e.Salary), d.Name, e.JobTitle
FROM Employees e
	JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle, e.FirstName, e.LastName;

/* Write a SQL query to display the town where maximal number of employees work. */

SELECT MAX(EmT.EmployeesInTown) AS [Maximal employees in city]
FROM (SELECT COUNT(*) AS EmployeesInTown
FROM Employees e
	JOIN Addresses ad
ON e.AddressID = ad.AddressID
	JOIN Towns t
ON ad.TownID = t.TownID
GROUP BY t.TownID) AS EmT

/* Write a SQL query to display the number of managers from each town. */

SELECT COUNT(*) AS EmployeesInTown, t.Name
FROM Employees e
	JOIN Addresses ad
ON e.AddressID = ad.AddressID
	JOIN Towns t
ON ad.TownID = t.TownID
WHERE e.ManagerID IS NULL
GROUP BY t.TownID, t.Name;

/*  Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
	Don't forget to define identity, primary key and appropriate foreign key.
	Issue few SQL statements to insert, update and delete of some data in the table.
	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
	For each change keep the old record data, the new record data and the command (insert / update / delete).
*/

CREATE TABLE WorkHours(
	WorkHoursID INT NOT NULL PRIMARY KEY IDENTITY,
	EmployeeID INT,
	Date SMALLDATETIME NOT NULL,
	Task VARCHAR(100) NOT NULL,
	Hours INT NOT NULL,
	Comments TEXT,
	CONSTRAINT FK_WorkHours_Employees FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID)
);

INSERT INTO WorkHours
VALUES(1, '2016-10-25', 'Labs', 10, 'Academy all day'),
(1, '2016-10-25', 'HardWork', 5, 'Academy all day'),
(2, '2015-09-21', 'Labs', 2, 'Academy all day'),
(1, '2016-11-26', 'Labs', 8, 'Academy all day');

CREATE TABLE WorkHoursLogs(
	WorkHoursLogsID INT NOT NULL PRIMARY KEY IDENTITY,
	Date SMALLDATETIME NOT NULL,
	OldData VARCHAR(100),
	NewData VARCHAR(100),
	Command VARCHAR(10)
);

CREATE TRIGGER tr_WorkHoursUpdate ON WorkHours FOR UPDATE
AS
  INSERT INTO WorkHoursLogs(Date, OldData, NewData, Command)
	SELECT GETDATE(), d.Task, i.Task, 'UPDATE'
	FROM Deleted d, Inserted i
	 WHERE d.WorkHoursID = i.WorkHoursID;
GO

CREATE TRIGGER tr_WorkHoursInsert ON WorkHours FOR INSERT
AS
  INSERT INTO WorkHoursLogs(Date, NewData, Command)
	SELECT GETDATE(), i.Task, 'INSERT'
	FROM Inserted i;
GO

CREATE TRIGGER tr_WorkHoursDelete ON WorkHours FOR DELETE
AS
  INSERT INTO WorkHoursLogs(Date, OldData, Command)
	SELECT GETDATE(), d.Task, 'UPDATE'
	FROM Deleted d;
GO

INSERT INTO WorkHours
VALUES(4, '2016-10-01', 'Labs', 5, 'Academy all day');

/* Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables.
At the end rollback the transaction. */

BEGIN TRAN

ALTER TABLE Employees
DROP CONSTRAINT FK_Employees_Employees;

ALTER TABLE Departments
DROP CONSTRAINT FK_Departments_Employees;

ALTER TABLE EmployeesProjects
DROP CONSTRAINT FK_EmployeesProjects_Employees;

DELETE FROM Employees
WHERE EmployeeID IN 
	(SELECT e.EmployeeID
	FROM Employees e 
		JOIN Departments d
	ON d.DepartmentID = e.DepartmentID
	WHERE d.Name = 'Sales');

ROLLBACK TRAN
