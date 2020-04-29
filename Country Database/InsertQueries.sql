USE Country;
--Inserting records into the State Table
INSERT INTO State (StateID, CountryID, State) VALUES (1, 1,'Texas');
INSERT INTO State (StateID, CountryID, State) VALUES (2, 2,'Wales');
INSERT INTO State (StateID, CountryID, State) VALUES (3, 3,'Ontario');
INSERT INTO State (StateID, CountryID, State) VALUES (4, 4,'Sao Paolo');
INSERT INTO State (StateID, CountryID, State) VALUES (5, 5,'Wuhan');

INSERT INTO STATE(StateID, State) VALUES (6, 'Bavaria');

--Inserting records into the Country Table
INSERT INTO Country (CountryID, Country) VALUES (1, 'USA');
INSERT INTO Country (CountryID, Country) VALUES (2, 'GB');
INSERT INTO Country (CountryID, Country) VALUES (3, 'Canada');
INSERT INTO Country (CountryID, Country) VALUES (4, 'Brazil');
INSERT INTO Country (CountryID, Country) VALUES (5, 'China');

ALTER TABLE Country ALTER COLUMN Country NVARCHAR(50) Not Null;
ALTER TABLE State ALTER COLUMN State NVARCHAR(50) Not Null;

ALTER TABLE State ALTER COLUMN CountryID INT Null