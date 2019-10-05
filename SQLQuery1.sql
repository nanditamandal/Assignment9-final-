CREATE DATABASE Customerdetail
USE Customerdetail
CREATE TABLE Customers(
Id INT IDENTITY(1,1) PRIMARY KEY,
Code VARCHAR(4) UNIQUE,
Name VARCHAR(50),
Address VARCHAR(50),
Contact VARCHAR(11) UNIQUE,
DistrictName VARCHAR(50) FOREIGN KEY REFERENCES District(DistrictName)
)

CREATE TABLE District(
Id INT IDENTITY(1,1) PRIMARY KEY,
DistrictName VARCHAR(50) UNIQUE,

)
INSERT INTO District(DistrictName) VALUES ('Faridpur')
INSERT INTO District(DistrictName) VALUES ('Gazipur')
INSERT INTO District(DistrictName) VALUES ('Gopalganj')
INSERT INTO District(DistrictName) VALUES ('Kishoreganj')
INSERT INTO District(DistrictName) VALUES ('Madaripur')
INSERT INTO District(DistrictName) VALUES ('Manikganj ')
INSERT INTO District(DistrictName) VALUES ('Munshiganj ')
INSERT INTO District(DistrictName) VALUES ('Narayanganj ')
INSERT INTO District(DistrictName) VALUES ('Narsingdi ')
INSERT INTO District(DistrictName) VALUES ('Rajbari')
INSERT INTO District(DistrictName) VALUES ('Tangail ')

SELECT *FROM District
SELECT * FROM Customers
UPDATE District SET DistrictName='' WHERE Id=1

