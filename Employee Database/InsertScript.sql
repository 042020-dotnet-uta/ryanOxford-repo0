
--Inserting records into the Department Table
INSERT INTO dbo.Department (ID, Name, Location) VALUES (1, 'Marketing','Main Office');
INSERT INTO dbo.Department (ID, Name, Location) VALUES (2, 'Management', 'Main Office');
INSERT INTO dbo.Department (ID, Name, Location) VALUES (3, 'Finance','Satellite Office');

--Inserting records into the Employee Table
INSERT INTO dbo.Employee (ID, FirstName, LastName, SSN, DeptID) VALUES (1, 'Tina','Smith', '123-45-6789', 1);
INSERT INTO dbo.Employee (ID, FirstName, LastName, SSN, DeptID) VALUES (2, 'Liza','Hall', '321-43-9876', 1);
INSERT INTO dbo.Employee (ID, FirstName, LastName, SSN, DeptID) VALUES (3, 'Tony','Sharp', '098-76-5432', 2);

--Inserting records into the EmpDetails Table
INSERT INTO dbo.EmpDetails (ID, EmployeeID, Salary, [Address 1], [Address 2], City, State, Country) VALUES (1,1,50000,'123 Birch Street', 'APT 32', 'Seattle', 'WA', 'USA');
INSERT INTO dbo.EmpDetails (ID, EmployeeID, Salary, [Address 1], [Address 2], City, State, Country) VALUES (2,2,65000,'123 Salmon Street', 'APT 401', 'Seattle', 'WA', 'USA');
INSERT INTO dbo.EmpDetails (ID, EmployeeID, Salary, [Address 1], [Address 2], City, State, Country) VALUES (3,3,45000,'123 Potter Street', 'APT 56', 'New York', 'NY', 'USA');

--Updating the salary of the employee "Tina Smith"
UPDATE dbo.EmpDetails SET Salary = 90000 WHERE ID = (SELECT [ID] FROM dbo.Employee WHERE FirstName = 'Tina' and LastName = 'Smith');
