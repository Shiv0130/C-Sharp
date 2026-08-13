USE LibraryDB;
GO

-- 3. DROP CHILD TABLE FIRST (Books holds the Foreign Key)
DROP TABLE IF EXISTS Books;

-- 4. DROP PARENT TABLE SECOND (Safe to drop now that the link is gone)
DROP TABLE IF EXISTS Categories;
GO

-- 5. Create Categories (Parent)
CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(500) NULL
);

-- 6. Create Books (Child)
CREATE TABLE Books (
    BookId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    ISBN NVARCHAR(20) NOT NULL UNIQUE,
    PublishedYear INT NULL,
    CategoryId INT NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId) ON DELETE CASCADE
);


