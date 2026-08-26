<<<<<<< HEAD
﻿-- Create a new database
CREATE DATABASE ProductsDB;
GO

-- Switch to the new database
USE ProductsDB;
GO

-- Create Products table
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL
);
GO
=======
﻿-- Create a new database
CREATE DATABASE ProductsDB;
GO

-- Switch to the new database
USE ProductsDB;
GO

-- Create Products table
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL
);
GO
>>>>>>> f1fd9259c06725f9a30786509326a6e923171712
