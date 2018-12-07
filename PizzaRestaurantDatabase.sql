CREATE SCHEMA PR;
GO

-- Stores Users
CREATE TABLE PR.Users(
	UserID INT NOT NULL PRIMARY KEY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	LastOrderTime DATETIME2 NULL
	)

-- Stores Orders
CREATE TABLE PR.Orders(
	OrderID INT NOT NULL PRIMARY KEY,
	UserID INT NOT NULL FOREIGN KEY REFERENCES PR.Users(UserID),
	LocationID INT NOT NULL,
	TimePlaced DATETIME2 NOT NULL,
)

-- Keeps track of what items were ordered in each order
CREATE TABLE ItemsOrdered(
	ItemID INT NOT NULL PRIMARY KEY

)
	
