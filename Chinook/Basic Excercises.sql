
-- basic exercises (Chinook database)

-- 1. list all customers (full names, customer ID, and country) who are not in the US

SELECT 
	 FirstName + ' ' + LastName AS 'Full name'
	,CustomerId
	,Country
FROM
	Customer
WHERE
	Country!='USA';

-- 2. list all customers from brazil

SELECT
	*
FROM
	Customer
WHERE
	Country = 'Brazil';

-- 3. list all sales agents

SELECT
	*
FROM
	Employee
WHERE
	Title = 'Sales Support Agent';

-- 4. show a list of all countries in billing addresses on invoices.

SELECT DISTINCT BillingCountry
FROM
	Invoice;


-- 5. how many invoices were there in 2009, and what was the sales total for that year?

SELECT
	 COUNT(InvoiceID) AS 'Invoices'
	,SUM(Total) AS 'Total Sales'
FROM
	Invoice
WHERE
	YEAR(InvoiceDate) = 2009;

-- 6. how many line items were there for invoice #37?

SELECT
	 COUNT(InvoiceID) AS 'Items'
FROM
	InvoiceLine
WHERE
	InvoiceID = 37;

-- 7. how many invoices per country?

SELECT
	 BillingCountry
	,COUNT(InvoiceID) As 'Invoices'
FROM
	Invoice
GROUP BY
	BillingCountry;

-- 8. show total sales per country, ordered by highest sales first.

SELECT
	 BillingCountry
	,SUM(Total) AS 'Total Sales'
FROM
	Invoice
GROUP BY
	BillingCountry
ORDER BY [Total Sales] DESC, BillingCountry;
	