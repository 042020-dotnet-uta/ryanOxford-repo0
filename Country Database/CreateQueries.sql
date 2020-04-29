USE Country;
--Create a new table dbo.Employee
CREATE TABLE State
(
	StateID INT Not Null,
	CountryID INT Not Null,
	State NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_State PRIMARY KEY CLUSTERED (StateID)
);
GO

--Create a new table dbo.Department
CREATE TABLE Country
(
	CountryID INT NOT NULL,
	Country NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Country PRIMARY KEY CLUSTERED (CountryID)
);
GO



--Adding foreign key constraints
ALTER TABLE State ADD CONSTRAINT FK_StateCountryID
	FOREIGN KEY (CountryID) REFERENCES Country (CountryID) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO


	