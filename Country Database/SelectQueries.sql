USE Country;

--SELECT statements from both individual tables
SELECT * FROM Country;

SELECT * FROM State;

--Cross Join from both tables
SELECT *
FROM
	Country
CROSS JOIN
	STATE;

--Inner join from both tables

SELECT *
FROM
	Country c
JOIN
	State s
ON
	c.CountryID = s.CountryID;

--Left outer join (Country is left)
SELECT *
FROM
	Country c
LEFT JOIN
	State s
ON
	c.CountryID = s.CountryID;

--Right outer join (State is right)
SELECT *
FROM
	Country c
Right JOIN
	State s
ON
	c.CountryID = s.CountryID;


