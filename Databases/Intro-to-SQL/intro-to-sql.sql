USE TelerikAcademy

/* Write a SQL query to find all information about all departments (use "TelerikAcademy" database). */

SELECT d.DepartmentID, d.Name AS 'Department name', em.FirstName + em.LastName AS 'Manager name'
FROM Departments d
	JOIN Employees em
		ON d.ManagerID = em.EmployeeID

/* Write a SQL query to find all department names */

SELECT Name
FROM Departments

/* Write a SQL query to find the salary of each employee. */

SELECT EmployeeID, FirstName, LastName, Salary
FROM Employees

/* Write a SQL to find the full name of each employee. */
SELECT FirstName + ' ' + LastName AS 'Full name'
FROM Employees

/* Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses". */

SELECT FirstName + '.' + LastName + '@telerik.com' AS 'Full Email Address'
FROM Employees

/* Write a SQL query to find all different employee salaries. */

SELECT DISTINCT Salary
FROM Employees

/* Write a SQL query to find all information about the employees whose job title is “Sales Representative“. */

SELECT em.EmployeeID, em.FirstName, em.LastName, em.JobTitle, em.HireDate, em.Salary, d.DepartmentID, d.Name AS 'Department name'
FROM Employees em
	JOIN Departments d
	ON em.DepartmentID = d.DepartmentID
WHERE em.JobTitle = 'Sales Representative'

/* Write a SQL query to find the names of all employees whose first name starts with "SA". */

SELECT EmployeeID, FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'SA%'

/* Write a SQL query to find the names of all employees whose last name contains "ei". */

SELECT EmployeeID, FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

/* Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000]. */

SELECT EmployeeID, FirstName + ' ' + LastName AS 'Full Name', Salary
FROM Employees
WHERE Salary >= 20000 AND Salary <= 30000

/* Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600 */

SELECT EmployeeID, FirstName, LastName
FROM Employees
WHERE Salary IN (25000, 14000, 12500 , 23600)

/* Write a SQL query to find all employees that do not have manager. */

SELECT EmployeeID, FirstName, LastName
FROM Employees
WHERE ManagerID IS NULL

/* Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary. */

SELECT EmployeeID, FirstName, LastName, Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

/* Write a SQL query to find the top 5 best paid employees */

SELECT TOP 5 EmployeeID, FirstName, LastName, Salary
FROM Employees
ORDER BY Salary DESC

/* Write a SQL query to find all employees along with their address. Use inner join with ON clause */

SELECT em.EmployeeID, em.FirstName, em.LastName, ad.AddressID, ad.AddressText, t.TownID, t.Name
FROM Employees em
	JOIN Addresses ad
		ON em.AddressID = ad.AddressID
	JOIN Towns t
		ON ad.AddressID = t.TownID

/* Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause). */

SELECT em.EmployeeID, em.FirstName, em.LastName, em.AddressID, ad.AddressID, ad.AddressText
FROM Employees em, Addresses ad, Towns t
WHERE em.AddressID = ad.AddressID

/* Write a SQL query to find all employees along with their manager. */

SELECT em.FirstName + ' ' + em.LastName AS 'Employee name', m.FirstName + ' ' + m.LastName AS 'Manager name'
FROM Employees em
	JOIN Employees m
		ON em.ManagerID = m.EmployeeID

/* Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a. */

SELECT em.FirstName + ' ' + em.LastName AS 'Employee name', a.AddressText AS 'Employee''s address', m.FirstName + ' ' + m.LastName AS 'Manager name'
FROM Employees em
	JOIN Employees m
		ON em.ManagerID = m.EmployeeID
	JOIN Addresses a
		ON em.AddressID = a.AddressID

/* Write a SQL query to find all departments and all town names as a single list. Use UNION */

SELECT d.Name AS 'Departments and Addresses'
FROM Departments d
UNION
SELECT a.AddressText
FROM Addresses a

/* Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join. */

SELECT e.FirstName + ' ' + e.LastName AS 'Employee name', m.FirstName + ' ' + m.LastName AS 'Manager name'
FROM Employees e
	LEFT JOIN Employees m
		ON e.ManagerID = m.EmployeeID

SELECT e.FirstName + ' ' + e.LastName AS 'Employee name', m.FirstName + ' ' + m.LastName AS 'Manager name'
FROM Employees e
	RIGHT JOIN Employees m
		ON e.ManagerID = m.EmployeeID

/* Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005. */

SELECT e.FirstName, e.LastName, e.HireDate
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	WHERE d.Name IN ('Sales', 'Finance')
	AND e.HireDate BETWEEN '1995' AND '2005'