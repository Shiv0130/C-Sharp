-- Create a new database
CREATE DATABASE SchoolDB;
GO

-- Switch to the new database
USE SchoolDB;
GO

-- Create Students table
CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Age INT NOT NULL,
    Email NVARCHAR(100)
);
GO

-- Insert sample data
INSERT INTO Students (Name, Age, Email)
VALUES 
('Alice Johnson', 19, 'alice.johnson@example.com'),
('Brian Smith', 21, 'brian.smith@example.com'),
('Carla Mendes', 22, 'carla.mendes@example.com');
GO

-- Verify data
SELECT * FROM Students;
GO
