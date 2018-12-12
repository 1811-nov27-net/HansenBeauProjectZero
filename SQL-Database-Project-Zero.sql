CREATE DATABASE PizzaOrders

CREATE SCHEMA PO

CREATE TABLE PO.Users
(
	UserID INT IDENTITY NOT NULL,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	DefaultAddressID INT NOT NULL,
	CONSTRAINT PK_Users_UserID PRIMARY KEY (UserID)
)

CREATE TABLE PO.Address
(
	AddressID INT IDENTITY NOT NULL,
	UserID INT NOT NULL,
	AddressLine1 NVARCHAR(100) NOT NULL,
	AddressLine2 NVARCHAR(100) NULL,
	City NVARCHAR(100) NOT NULL,
	State NVARCHAR(100) NOT NULL,
	ZIPCode INT NOT NULL
	CONSTRAINT PK_Address_AddressID PRIMARY KEY (AddressID)
)

CREATE TABLE PO.OrderHeader
(
	OrderID INT IDENTITY NOT NULL,
	UserID INT NOT NULL,
	OrderAddressID INT NOT NULL,
	TotalCost INT NOT NULL,
	OrderDate DATETIME2 NOT NULL,
	StoreID INT NOT NULL
	CONSTRAINT PK_OrderHeader_OrderID PRIMARY KEY (OrderID)
)

CREATE TABLE PO.OrderDetail
(
	OrderDetailID INT IDENTITY NOT NULL,
	OrderID INT NOT NULL,
	ProductID INT NOT NULL,
	QtyOrdered INT NOT NULL
	CONSTRAINT PK_OrderDetail_OrderDetailID PRIMARY KEY (OrderDetailID)
)

CREATE TABLE PO.Products
(
	ProductID INT IDENTITY NOT NULL,
	ProductName NVARCHAR(100) NOT NULL,
	UnitPrice INT NOT NULL
	CONSTRAINT PK_Products_ProductID PRIMARY KEY (ProductID)
)

CREATE TABLE PO.Store
(
	StoreID INT IDENTITY NOT NULL,
	SAddressLine1 NVARCHAR(100) NOT NULL,
	SAddressLine2 NVARCHAR(100) NULL,
	SCity NVARCHAR(100) NOT NULL,
	SState NVARCHAR(100) NOT NULL,
	SZIPCode INT NOT NULL
	CONSTRAINT PK_Store_StoreID PRIMARY KEY (StoreID)
)

CREATE TABLE PO.StoreInventory
(
	StoreInventoryID INT IDENTITY NOT NULL,
	ProductID INT NOT NULL,
	StoreID INT NOT NULL,
	QtyRemaining INT NOT NULL
	CONSTRAINT PK_StoreInventory_StoreInventoryID PRIMARY KEY (StoreInventoryID)
)

ALTER TABLE PO.Address
	ADD CONSTRAINT FK_Address_Users_UserID FOREIGN KEY (UserID) REFERENCES PO.Users(UserID)
ALTER TABLE PO.OrderHeader
	ADD CONSTRAINT FK_OrderHeader_Address_AddressID FOREIGN KEY (OrderAddressID) REFERENCES PO.Address(AddressID)
ALTER TABLE PO.OrderHeader
	ADD CONSTRAINT FK_OrderHeader_Store_StoreID FOREIGN KEY (StoreID) REFERENCES PO.Store(StoreID)
ALTER TABLE PO.OrderDetail
	ADD CONSTRAINT FK_OOrderDetail_OrderHeader_OrderDetailID FOREIGN KEY (OrderID) REFERENCES PO.OrderHeader(OrderID)
ALTER TABLE PO.StoreInventory
	ADD CONSTRAINT FK_StoreInventory_Store_StoreID FOREIGN KEY (StoreID) REFERENCES PO.Store(StoreID)
ALTER TABLE PO.OrderDetail
	ADD CONSTRAINT FK_OrderDetail_Products_Product_ID FOREIGN KEY (ProductID) REFERENCES PO.Products(ProductID)
ALTER TABLE PO.StoreInventory
	ADD CONSTRAINT FK_StoreInventory_Products_ProductID FOREIGN KEY (ProductID) REFERENCES PO.Products(ProductID)

INSERT INTO PO.Users (FirstName, LastName, DefaultAddressID)
VALUES 
('Beau', 'Hansen', 1),
('Nick', 'Escalona', 2),
('Papa', 'John', 3),
('login', 'admin', 4),
('Raheem', 'Sterling', 5)

INSERT INTO PO.Address(UserID, AddressLine1, AddressLine2, City, State, ZIPCode)
VALUES 
(1, '1111 Mitchell Circle', 'Unit 1333', 'Arlington', 'Texas', 76019),
(2, '2222 Mitchell Circle', NULL, 'Arlington', 'Texas', 76019),
(3, '1600 S Buckner Boulevard', 'Ste 110', 'Dallas', 'Texas', 75227),
(4, '1600 Pennsylvania Avenue', NULL, 'Washington, DC', 'Virginia', 20500),
(5, '9999 GOAT street', NULL, 'Boston', 'Massachusetts', 02101)

INSERT INTO PO.Products(ProductName, UnitPrice)
VALUES 
('Pepperoni Pizza, L', 18),
('Pepperoni Pizza, M', 15),
('Pepperoni Pizza, S', 12),
('Hawaiian Pizza, L', 18),
('Hawaiian Pizza, M', 15),
('Hawaiian Pizza, S', 12),
('Veggie Pizza, L', 18),
('Veggie Pizza, M', 15),
('Veggie Pizza, S', 12)

INSERT INTO PO.Store(SAddressLine1, SAddressLine2, SCity, SState, SZIPCode)
VALUES 
('0123 A Street', NULL, 'Arlington', 'Texas', 76019),
('1234 B Street', NULL, 'Arlington', 'Texas', 76020),
('2345 C Street', NULL, 'Dallas', 'Texas', 75227),
('3456 D Street', NULL, 'Arlington', 'Virginia', 20330),
('4567 E Street', NULL, 'Boston', 'Massachusetts', 02101)

INSERT INTO PO.OrderHeader(UserID, OrderAddressID, TotalCost, OrderDate, StoreID)
VALUES 
-- (1, 1, 18, GETDATE(), 1),
(1, 1, 30, GETDATE(), 1),
(2, 2, 45, GETDATE(), 2),
(3, 3, 36, GETDATE(), 3),
(4, 4, 135, GETDATE(), 4),
(5, 5, 72, GETDATE(), 5)

INSERT INTO PO.OrderDetail(OrderID, ProductID, QtyOrdered)
VALUES 
--(1, 1, 1)
(2, 2, 2),
(3, 4, 1),
(3, 5, 1),
(3, 6, 1),
(4, 7, 2),
(5, 1, 1),
(5, 1, 1),
(5, 2, 1),
(5, 3, 1),
(5, 4, 1),
(5, 5, 1),
(5, 6, 1),
(5, 7, 1),
(5, 8, 1),
(5, 9, 1),
(6, 1, 2),
(6, 4, 2)

INSERT INTO PO.StoreInventory(ProductID, StoreID, QtyRemaining)
VALUES 
--(1, 1, 20),
--(1, 2, 15),
--(1, 3, 10),
--(1, 4, 20),
--(1, 5, 15),

(2, 1, 20),
(2, 2, 15),
(2, 3, 10),
(2, 4, 20),
(2, 5, 15),

(3, 1, 20),
(3, 2, 15),
(3, 3, 10),
(3, 4, 20),
(3, 5, 15),

(4, 1, 20),
(4, 2, 15),
(4, 3, 10),
(4, 4, 20),
(4, 5, 15),

(5, 1, 20),
(5, 2, 15),
(5, 3, 10),
(5, 4, 20),
(5, 5, 15),

(6, 1, 20),
(6, 2, 15),
(6, 3, 10),
(6, 4, 20),
(6, 5, 15),

(7, 1, 20),
(7, 2, 15),
(7, 3, 10),
(7, 4, 20),
(7, 5, 15),

(8, 1, 20),
(8, 2, 15),
(8, 3, 10),
(8, 4, 20),
(8, 5, 15),

(9, 1, 20),
(9, 2, 15),
(9, 3, 10),
(9, 4, 20),
(9, 5, 15)


SELECT * FROM PO.Users
SELECT * FROM PO.Address
SELECT * FROM PO.OrderHeader
SELECT * FROM PO.OrderDetail
SELECT * FROM PO.Products
SELECT * FROM PO.Store
SELECT * FROM PO.StoreInventory


DELETE FROM PO.OrderHeader
	WHERE OrderID > 6