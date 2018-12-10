CREATE DATABASE PizzaOrders
GO

CREATE SCHEMA PizzaOrders
GO 

DROP TABLE PizzaOrders.Users
ALTER TABLE PizzaOrders.Orders
	ADD CONSTRAINT FK_Orders_Users_UserID FOREIGN KEY (UserID) REFERENCES PizzaOrders.Users(UserID)
CREATE TABLE PizzaOrders.Users
(
	UserID INT IDENTITY NOT NULL,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	LastOrderTime DATETIME2 NULL,
	CONSTRAINT PK_User_UserID PRIMARY KEY (UserID)
)

CREATE TABLE PizzaOrders.Orders
(
	OrderID INT IDENTITY NOT NULL,
	UserID INT NOT NULL,
	StoreID INT NOT NULL,
	OrderTime DATETIME2 NOT NULL,
	SubTotal MONEY NOT NULL,
	NetTotal MONEY NOT NULL,
	DeliveryAddressID INT NOT NULL,
	CONSTRAINT PK_Orders_OrderID PRIMARY KEY (OrderID)
)

ALTER TABLE PizzaOrders.Orders
	ADD DeliveryAddressID INT NOT NULL

ALTER TABLE PizzaOrders.Orders
ADD CONSTRAINT FK_Orders_Users_UserID FOREIGN KEY (UserID) REFERENCES PizzaOrders.Users(UserID)

CREATE TABLE PizzaOrders.OrdersDescription
(
	OrderID INT NOT NULL,
	ItemID INT NOT NULL,
	QtyOrdered INT NOT NULL
	CONSTRAINT PK_OrdersDescription_OrderIDItemID PRIMARY KEY (OrderID, ItemID)
)

ALTER TABLE PizzaOrders.OrdersDescription
	ADD CONSTRAINT PK_OrdersDescription_OrderID PRIMARY KEY (OrderID)

CREATE TABLE PizzaOrders.Menu
(
	ItemID INT IDENTITY NOT NULL,
	ItemName NVARCHAR(100) NOT NULL,
	ItemCost MONEY NOT NULL,
	ItemSize NVARCHAR(50) NULL,
	ItemTypeID INT NOT NULL
	CONSTRAINT PK_Menu_ItemID PRIMARY KEY (ItemID)
)

CREATE TABLE PizzaOrders.InventoryType
(
	ItemTypeID INT IDENTITY NOT NULL,
	TypeName NVARCHAR(100) NOT NULL
	CONSTRAINT PK_InventoryType_ItemTypeID PRIMARY KEY (ItemTypeID)
)

ALTER TABLE PizzaOrders.InventoryType
	ADD ItemClassID INT NOT NULL

ALTER TABLE PizzaOrders.InventoryClass
	DROP COLUMN ItemTypeID

CREATE TABLE PizzaOrders.InventoryClass
(
	ItemClassID INT IDENTITY NOT NULL,
	ItemTypeID INT NOT NULL,
	ClassName NVARCHAR(100)
	CONSTRAINT PK_InventoryClass_ItemClassID PRIMARY KEY (ItemClassID)
)

CREATE TABLE PizzaOrders.DeliveryLocations
(
	DeliveryLocID INT IDENTITY NOT NULL,
	AddressLine1 NVARCHAR(100) NOT NULL,
	AddressLine2 NVARCHAR(100) NULL,
	City NVARCHAR(100) NOT NULL,
	State NVARCHAR(100) NOT NULL,
	ZIPCode INT NOT NULL
	CONSTRAINT PK_DeliveryLocations_DeliveryLocID PRIMARY KEY (DeliveryLocID)
)

CREATE TABLE PizzaOrders.StoreLocations
(
	StoreLocID INT IDENTITY NOT NULL,
	StoreName NVARCHAR(100) NOT NULL,
	AddressLine1 NVARCHAR(100) NOT NULL,
	AddressLine2 NVARCHAR(100) NULL,
	City NVARCHAR(100) NOT NULL,
	State NVARCHAR(100) NOT NULL,
	ZIPCode INT NOT NULL
	CONSTRAINT PK_StoreLocation_StoreLocID PRIMARY KEY (StoreLocID)
)

-- ALTER TABLE PizzaOrders.Orders
	-- ADD CONSTRAINT FK_Orders_StoreLocations_StoreLocID FOREIGN KEY (StoreID) REFERENCES PizzaOrders.StoreLocations(StoreLocID)
	-- ADD CONSTRAINT KF_Orders_DeliveryLocations_DeliveryAddressID FOREIGN KEY (DeliveryAddressID) REFERENCES PizzaOrders.DeliveryLocations(DeliveryLocID)
	-- ADD CONSTRAINT FK_Orders_OrdersDescription_OrderID FOREIGN KEY (OrderID) REFERENCES PizzaOrders.OrdersDescription(OrderID)

-- ALTER TABLE PizzaOrders.OrdersDescription
	-- ADD CONSTRAINT FK_OrdersDescription_Menu_ItemID FOREIGN KEY (ItemID) REFERENCES PizzaOrders.Menu(ItemID)

-- ALTER TABLE PizzaOrders.Menu
	-- ADD CONSTRAINT FK_Menu_InventoryType_ItemTypeID FOREIGN KEY (ItemTypeID) REFERENCES PizzaOrders.InventoryType(ItemTypeID)

ALTER TABLE PizzaOrders.InventoryType
	ADD CONSTRAINT FK_InventoryType_InventoryClass_ItemClassID FOREIGN KEY (ItemClassID) REFERENCES PizzaOrders.InventoryClass(ItemClassID)



SELECT * FROM PizzaOrders.Users
SELECT * FROM PizzaOrders.Orders
SELECT 