
--Query to report a list of all employees in the department named "Marketing"
SELECT 
	 [FirstName] + ' ' + [LastName] AS [Full name]
FROM
	dbo.Employee e
INNER JOIN
	dbo.Department d
ON
	e.DeptID = d.ID
WHERE
	d.[Name] = 'Marketing';


--Query to report the total salary of all employees in the department named "Marketing"
SELECT
	 d.Name AS [Department]
	,SUM([Salary]) AS [Total Salary]
FROM
	dbo.EmpDetails e
INNER JOIN
(
--Using a subquery to return a table of employee IDs and Department names to join
	SELECT
		 e.ID
		,d.Name
	FROM
		dbo.Employee e
	INNER JOIN	
		dbo.Department d
	ON
		e.DeptID = d.ID
	WHERE
		d.Name = 'Marketing'
) d
ON
	e.ID = d.ID
GROUP BY
	d.[name];



--Query to report the to employee counts of the different departments
SELECT
	 d.Name as [Department]
	,COUNT(e.ID) AS [Employee Count]
FROM
	dbo.Department d
INNER JOIN
	dbo.Employee e
ON
	d.ID = e.DeptID
GROUP BY
	d.Name
ORDER BY
	d.Name;

