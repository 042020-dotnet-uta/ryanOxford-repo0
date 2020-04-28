
--Create a new table dbo.Employee
CREATE TABLE dbo.Employee
(
	ID INT Not Null,
	FirstName NVarChar(50) NOT NULL,
	LastName NVarChar(50) NOT NULL,
	SSN NCHAR(11) NOT NULL,
	DeptID INT NOT NULL,
	CONSTRAINT PK_Employee PRIMARY KEY CLUSTERED (ID)
);
GO

--Create a new table dbo.Department
CREATE TABLE dbo.Department
(
	ID INT NOT NULL,
	[NAME] NVARCHAR(100) NOT NULL,
	[LOCATION] NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Department PRIMARY KEY CLUSTERED (ID)
);
GO

--Create a new table dbo.EmpDetails
CREATE TABLE dbo.EmpDetails
(
	ID INT NOT NULL,
	EmployeeID INT NOT NULL,
	Salary float NOT NULL,
	[Address 1] NVARCHAR(100) NOT NULL,
	[Address 2] NVARCHAR(100),
	City NVARCHAR(50),
	[State] NVARCHAR(50),
	Country NVARCHAR(50),
	CONSTRAINT [PK_EmpDetails] PRIMARY KEY CLUSTERED (ID)
);
GO

--Adding foreign key constraints
ALTER TABLE dbo.Employee ADD CONSTRAINT FK_EmployeeDepartmentID
	FOREIGN KEY (DeptID) REFERENCES dbo.Department (ID) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
ALTER TABLE dbo.EmpDetails ADD CONSTRAINT FK_EmpDetalsEmployeeID
	FOREIGN KEY (EmployeeID) REFERENCES dbo.Employee (ID) ON DELETE NO ACTION ON UPDATE NO ACTION;

	