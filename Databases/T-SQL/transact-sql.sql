USE TransactSQL;
GO

-- Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
--	Insert few records for testing.
--	Write a stored procedure that selects the full names of all persons

CREATE TABLE Persons(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
);
GO

CREATE TABLE Accounts(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Balance MONEY NOT NULL,
	PersonId INT NOT NULL,
	CONSTRAINT FK_Accounts_Persons FOREIGN KEY(PersonId) REFERENCES Persons(Id)
);
GO

INSERT INTO Persons(FirstName, LastName)
VALUES('Peter', 'Petrov'),
('Georgi', 'Georgiev'),
('Ivan', 'Ivanov'),
('Dimityr', 'Dimitrov'),
('Aleksandyr', 'Aleksandrov');

INSERT INTO Accounts(Balance, PersonId)
VALUES(20000, 1),
(5000, 1),
(12300, 2),
(31200, 3),
(8899, 4);
GO

CREATE PROC usp_SelectPersonsFullName
AS
	SELECT FirstName + ' ' + LastName AS [Full name]
	FROM Persons;
GO

-- Create a stored procedure that accepts a number as a parameter and returns all persons 
-- who have more money in their accounts than the supplied number.

CREATE PROC usp_SelectPersonsWithMoneyMoreThan(@money MONEY = 0)
AS
	SELECT FirstName, LastName, A.Balance
	FROM Persons p, Accounts a
	WHERE p.Id = a.PersonId 
	AND a.Balance > @money;
GO

-- Create a function that accepts as parameters – sum, yearly interest rate and number of months.
--	It should calculate and return the new sum.
--  Write a SELECT to test whether the function works as expected.

/* TODO */
CREATE FUNCTION ufn_Calculate(@sum MONEY, @interest FLOAT, @months INT)
RETURNS MONEY
AS
BEGIN
	DECLARE @result MONEY;
END;
GO

-- Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
--   It should take the AccountId and the interest rate as parameters.

/* TODO */

-- Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money) that operate in transactions.

CREATE PROC usp_WithdrawMoney(@AccountId INT, @money MONEY)
AS
	BEGIN TRAN
	DECLARE @currentBalance INT = 
		(SELECT Balance FROM Accounts WHERE Id = @AccountId)

	IF(EXISTS(SELECT * FROM Accounts WHERE Id = @AccountId)
		AND @currentBalance >= @money)
	BEGIN
		DECLARE @newBalance MONEY = @currentBalance - @money

		UPDATE Accounts
		SET Balance = @newBalance
		WHERE Id = @AccountId;

		COMMIT TRAN;
	END
	ELSE
		ROLLBACK TRAN
GO

CREATE PROC usp_DepositMoney(@AccountId INT, @money MONEY)
AS
	BEGIN TRAN
	IF(EXISTS(SELECT * FROM Accounts WHERE Id = @AccountId))
	BEGIN
	DECLARE @currentBalance INT = (SELECT Balance FROM Accounts WHERE Id = @AccountId);
	DECLARE @newBalance MONEY = @currentBalance + @money

		UPDATE Accounts
		SET Balance = @newBalance
		WHERE Id = @AccountId;

		COMMIT TRAN;
	END
	ELSE
		ROLLBACK TRAN
GO

-- Create another table – Logs(LogID, AccountID, OldSum, NewSum).
--	 Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.

CREATE TABLE Logs(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	AccountId INT NOT NULL,
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
);
GO

CREATE TRIGGER tr_BalanceUpdate ON Accounts FOR UPDATE
AS
	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT d.Id, d.Balance, i.Balance
	FROM Deleted d, Inserted i
	WHERE d.Id = i.Id;
GO

-- Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) 
-- and all town's names that are comprised of given set of letters.

USE TelerikAcademy;
GO

CREATE FUNCTION ufn_GetNamesAndTows(@letters VARCHAR(20))
RETURNS @tb_Result TABLE 
	(Id INT NOT NULL PRIMARY KEY IDENTITY,
	 Name VARCHAR(100))
AS
BEGIN

	DECLARE empCursor CURSOR READ_ONLY FOR
		SELECT FirstName, MiddleName, LastName FROM Employees;

		OPEN empCursor
		DECLARE @firstName NVARCHAR(50), @midName NVARCHAR(50), @lastName NVARCHAR(50)
		FETCH NEXT FROM empCursor INTO @firstName, @midName, @lastName

		-- NOT FINISHED!!!
	RETURN
END
GO