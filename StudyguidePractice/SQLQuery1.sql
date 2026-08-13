-- Create the Products table
CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    Price DECIMAL(18, 2) NOT NULL,
    StockQuantity INT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Insert sample data
INSERT INTO Products (Name, Description, Price, StockQuantity)
VALUES 
('Laptop', 'High-performance gaming laptop', 1200.00, 10),
('Wireless Mouse', 'Ergonomic 2.4GHz mouse', 25.50, 50),
('Mechanical Keyboard', 'RGB backlit mechanical keys', 85.00, 30);

