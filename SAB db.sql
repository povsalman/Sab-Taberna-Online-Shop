CREATE DATABASE SABTaberna;

-- drop database SABTaberna;

USE SABTaberna;

-- Table: ISUSER
CREATE TABLE ISUSER (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(100) NOT NULL UNIQUE,          -- Ensuring UserName is unique
    Password NVARCHAR(100) NOT NULL,                 -- Password must not be null
    Age INT DEFAULT 0 CHECK (Age >= 0),               -- Ensure Age cannot be negative
    Gender NVARCHAR(10) CHECK (Gender IN ('Male', 'Female', 'Other')),  -- Restrict Gender values
    RegistrationDate DATE NOT NULL,
    Contact NVARCHAR(20) NOT NULL UNIQUE             -- Ensuring Contact is unique (e.g., phone number)
);

-- Table: LOGIN_HISTORY
CREATE TABLE LOGIN_HISTORY (
    LoginID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    LoginDate DATE NOT NULL,
    CategoryName NVARCHAR(50) NOT NULL,
    FOREIGN KEY (UserID) REFERENCES ISUSER(UserID) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT chk_LoginDate CHECK (LoginDate <= GETDATE())  -- Ensures LoginDate is not in the future
);

-- Table: ADMIN
CREATE TABLE ADMIN (
    AdminID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    Role NVARCHAR(50) NOT NULL CHECK (Role IN ('SuperAdmin', 'Admin', 'Moderator')),  -- Role should be restricted
    FOREIGN KEY (UserID) REFERENCES ISUSER(UserID) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Table: CUSTOMER
CREATE TABLE CUSTOMER (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    PaymentPreferences NVARCHAR(50) CHECK (PaymentPreferences IN ('Credit Card', 'Debit Card', 'PayPal', 'Cash')), -- Restrict payment options
    FOREIGN KEY (UserID) REFERENCES ISUSER(UserID) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Table: SELLER
CREATE TABLE SELLER (
    SellerID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    StoreName NVARCHAR(100) NOT NULL,
    StoreAddress NVARCHAR(200),
    VerificationStatus NVARCHAR(50) CHECK (VerificationStatus IN ('Pending', 'Verified', 'Rejected')),  -- Restrict possible verification statuses
    AccountStatus NVARCHAR(50) CHECK (AccountStatus IN ('Active', 'Suspended', 'Closed')),  -- Restrict possible account statuses
    FOREIGN KEY (UserID) REFERENCES ISUSER(UserID) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Table: CATEGORY
CREATE TABLE CATEGORY (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL UNIQUE,          -- Ensuring unique category names
    Description NVARCHAR(500) -- Optional description, no constraints
);

-- Table: ISPRODUCT
CREATE TABLE ISPRODUCT (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    SellerID INT NOT NULL,
    CategoryID INT NOT NULL,
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(1000),
    Price DECIMAL(10, 2) NOT NULL CHECK (Price >= 0),      -- Price must be non-negative
    StockLevel INT NOT NULL CHECK (StockLevel >= 0), -- StockLevel must be non-negative
	IsFlaggedInappropriate BIT DEFAULT 0 NOT NULL,
    ImageURL NVARCHAR(500) DEFAULT NULL,                               -- Optional field for product images
    FOREIGN KEY (SellerID) REFERENCES SELLER(SellerID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (CategoryID) REFERENCES CATEGORY(CategoryID) ON DELETE CASCADE ON UPDATE CASCADE
);


---- Table: CART
--CREATE TABLE CART (
--    CartID INT IDENTITY(1,1) PRIMARY KEY,
--    CustomerID INT NOT NULL,
--    DateCreated DATE NOT NULL,
--    DateModified DATE,
--    CartStatus NVARCHAR(50) DEFAULT 'Active',
--    FOREIGN KEY (CustomerID) REFERENCES CUSTOMER(CustomerID)
--);



---- Table: CART_ITEM
--CREATE TABLE CART_ITEM (
--    Cart_ItemID INT IDENTITY(1,1) PRIMARY KEY,
--    CartID INT NOT NULL,
--    ProductID INT NOT NULL,
--    Quantity INT NOT NULL,
--    FOREIGN KEY (CartID) REFERENCES CART(CartID) ON DELETE NO ACTION ON UPDATE CASCADE,
--    FOREIGN KEY (ProductID) REFERENCES ISPRODUCT(ProductID) ON DELETE NO ACTION ON UPDATE CASCADE
--);

-- NEW BILAL

CREATE TABLE CART (
    CartID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    FOREIGN KEY (UserID) REFERENCES ISUSER(UserID) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (ProductID) REFERENCES ISPRODUCT(ProductID) ON DELETE CASCADE ON UPDATE CASCADE
);




-- Table: ISORDER
CREATE TABLE ISORDER (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    OrderDate DATE NOT NULL,
    ShippingStatus NVARCHAR(50) CHECK (ShippingStatus IN ('Pending', 'Shipped', 'Delivered', 'Cancelled')),  -- Restrict order statuses
    TotalAmount DECIMAL(10, 2) NOT NULL CHECK (TotalAmount >= 0),  -- TotalAmount must be non-negative
    ShippingAddress NVARCHAR(200),
    PaymentStatus NVARCHAR(50) CHECK (PaymentStatus IN ('Pending', 'Completed', 'Failed')),  -- Restrict payment statuses
    FOREIGN KEY (CustomerID) REFERENCES CUSTOMER(CustomerID) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Table: ORDER_ITEM
CREATE TABLE ORDER_ITEM (
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    ProductID INT,
    Quantity INT NOT NULL CHECK (Quantity > 0),           -- Quantity must be positive
    Price DECIMAL(10, 2) NOT NULL CHECK (Price >= 0),      -- Price must be non-negative
    FOREIGN KEY (OrderID) REFERENCES ISORDER(OrderID) ,
    FOREIGN KEY (ProductID) REFERENCES ISPRODUCT(ProductID) ON DELETE SET NULL
);

-- Table: PAYMENT
CREATE TABLE PAYMENT (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    PaymentDate DATE NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL CHECK (Amount >= 0),  -- Payment amount must be non-negative
    PaymentMethod NVARCHAR(50) CHECK (PaymentMethod IN ('Credit Card', 'Debit Card', 'PayPal', 'Bank Transfer')), -- Restrict payment methods
    PaymentStatus NVARCHAR(50) CHECK (PaymentStatus IN ('Pending', 'Completed', 'Failed')), -- Restrict payment status
    FOREIGN KEY (OrderID) REFERENCES ISORDER(OrderID) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Table: REVIEW
CREATE TABLE REVIEW (
    ReviewID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL,
    CustomerID INT NOT NULL,
    Rating INT CHECK (Rating >= 1 AND Rating <= 5),  -- Rating should be between 1 and 5
    Comment NVARCHAR(1000),
    ReviewDate DATE NOT NULL,
    FOREIGN KEY (ProductID) REFERENCES ISPRODUCT(ProductID) ON DELETE CASCADE,
    FOREIGN KEY (CustomerID) REFERENCES CUSTOMER(CustomerID) ON DELETE NO ACTION
);


-- Table: LOGISTICS_PROVIDER (Create without foreign keys for now)
CREATE TABLE LOGISTICS_PROVIDER (
    LogisticsProviderID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
	UserID INT NOT NULL,
    ShipmentID INT NOT NULL,
    AssignedArea NVARCHAR(100) NOT NULL,
    ProviderName NVARCHAR(100) NOT NULL
	FOREIGN KEY (UserID) REFERENCES ISUSER(UserID) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Table: SHIPMENT (Create without foreign keys for now)
CREATE TABLE SHIPMENT (
    ShipmentID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    SellerID INT NOT NULL,
    TrackingNumber NVARCHAR(50) UNIQUE,
    DeliveryStatus NVARCHAR(50) CHECK (DeliveryStatus IN ('Pending', 'Shipped', 'Delivered', 'Cancelled')),
    EstimatedDeliveryDate DATE NOT NULL,
    PickupDate DATE,
    DeliveryDate DATE,
    LogisticsProviderID INT NOT NULL,
    LabelGenerated BIT DEFAULT 0
);

-- ADDING FKs to above Tables
-- Add Foreign Key Constraint to LOGISTICS_PROVIDER for OrderID
ALTER TABLE LOGISTICS_PROVIDER
ADD CONSTRAINT FK_LOGISTICS_PROVIDER_ORDER
FOREIGN KEY (OrderID) REFERENCES ISORDER(OrderID) 


-- Add Foreign Key Constraint to SHIPMENT for OrderID
ALTER TABLE SHIPMENT
ADD CONSTRAINT FK_SHIPMENT_ORDER
FOREIGN KEY (OrderID) REFERENCES ISORDER(OrderID) 


-- Add Foreign Key Constraint to SHIPMENT for SellerID
ALTER TABLE SHIPMENT
ADD CONSTRAINT FK_SHIPMENT_SELLER
FOREIGN KEY (SellerID) REFERENCES SELLER(SellerID) 
ON DELETE CASCADE ON UPDATE CASCADE;

-- Add Foreign Key Constraint to SHIPMENT for LogisticsProviderID
ALTER TABLE SHIPMENT
ADD CONSTRAINT FK_SHIPMENT_LOGISTICS_PROVIDER
FOREIGN KEY (LogisticsProviderID) REFERENCES LOGISTICS_PROVIDER(LogisticsProviderID)




-- Table: WISHLIST
CREATE TABLE WISHLIST (
    WishlistID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES CUSTOMER(CustomerID) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Table: WISHLIST_ITEM
CREATE TABLE WISHLIST_ITEM (
    WishlistItemID INT IDENTITY(1,1) PRIMARY KEY,
    WishlistID INT NOT NULL,
    ProductID INT NOT NULL,
    FOREIGN KEY (WishlistID) REFERENCES WISHLIST(WishlistID) ON DELETE NO ACTION,
    FOREIGN KEY (ProductID) REFERENCES ISPRODUCT(ProductID) ON DELETE CASCADE
);

-- Table: ISRETURN
CREATE TABLE ISRETURN (
    ReturnID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    ProductID INT NULL, -- Allow NULL for deleted products
    ReturnDate NVARCHAR(50),
    Reason NVARCHAR(255),
    RefundAmount INT,
    FOREIGN KEY (CustomerID) REFERENCES CUSTOMER(CustomerID) ON DELETE NO ACTION, 
    FOREIGN KEY (ProductID) REFERENCES ISPRODUCT(ProductID) ON DELETE SET NULL 
);



------
-- ALTER CODE

ALTER TABLE CUSTOMER
ADD AccountStatus NVARCHAR(50) CHECK (AccountStatus IN ('Active', 'Suspended', 'Closed')) DEFAULT 'Active';

ALTER TABLE ISUSER
ADD AccountType NVARCHAR(20) NOT NULL DEFAULT 'Customer' 
CHECK (AccountType IN ('Customer', 'Admin', 'Seller', 'Logistics'));

ALTER TABLE ISPRODUCT
ADD IsApproved NVARCHAR(3) DEFAULT 'No' NOT NULL;



------

-- Table: ISUSER
INSERT INTO ISUSER (UserName, Password, Age, Gender, RegistrationDate, Contact, AccountType)
VALUES 
-- Customers
('john_doe', 'password123', 30, 'Male', '2023-01-01', '123-456-7890', 'Customer'),
('jane_smith', 'password456', 25, 'Female', '2023-02-01', '987-654-3210', 'Customer'),
('bob_jones', 'password789', 40, 'Male', '2023-03-01', '555-555-5555', 'Customer'),

-- Admins
('alice_williams', 'password101', 35, 'Female', '2023-04-01', '111-222-3333', 'Admin'),
('michael_brown', 'password234', 45, 'Male', '2023-05-01', '222-333-4444', 'Admin'),
('susan_clark', 'password567', 50, 'Female', '2023-06-01', '333-444-5555', 'Admin'),

-- Sellers
('emma_green', 'password890', 28, 'Female', '2023-07-01', '444-555-6666', 'Seller'),
('oliver_white', 'password321', 34, 'Male', '2023-08-01', '555-666-7777', 'Seller'),
('noah_black', 'password654', 29, 'Male', '2023-09-01', '666-777-8888', 'Seller'),

-- Logistics
('ava_blue', 'password987', 26, 'Female', '2023-10-01', '777-888-9999', 'Logistics'),
('william_gray', 'password111', 33, 'Male', '2023-11-01', '888-999-0000', 'Logistics'),
('mia_red', 'password222', 31, 'Female', '2023-12-01', '999-000-1111', 'Logistics');

-- Table: LOGIN_HISTORY
INSERT INTO LOGIN_HISTORY (UserID, LoginDate, CategoryName)
VALUES 
(1, '2023-01-10', 'Login'),
(2, '2023-02-15', 'Login'),
(3, '2023-03-20', 'Login'),
(4, '2023-04-25', 'Login'),
(5, '2023-05-10', 'Login'),
(6, '2023-06-15', 'Login'),
(7, '2023-07-20', 'Login'),
(8, '2023-08-25', 'Login'),
(9, '2023-09-10', 'Login'),
(10, '2023-10-15', 'Login'),
(11, '2023-11-20', 'Login'),
(12, '2023-12-25', 'Login');

-- Table: ADMIN
INSERT INTO ADMIN (UserID, Role)
VALUES 
(4, 'SuperAdmin'),
(5, 'Admin'),
(6, 'Moderator');

-- Table: CUSTOMER
INSERT INTO CUSTOMER (UserID, Name, PaymentPreferences)
VALUES 
(1, 'John Doe', 'Credit Card'),
(2, 'Jane Smith', 'PayPal'),
(3, 'Bob Jones', 'Debit Card');

-- Table: SELLER
INSERT INTO SELLER (UserID, StoreName, StoreAddress, VerificationStatus, AccountStatus)
VALUES 
(7, 'Green Electronics', '123 Market St, City A', 'Verified', 'Active'),
(8, 'White Apparel', '456 Elm St, City B', 'Pending', 'Active'),
(9, 'Black Gadgets', '789 Oak St, City C', 'Verified', 'Closed');



-- Table: CATEGORY
INSERT INTO CATEGORY (CategoryName, Description)
VALUES 
('Electronics', 'All kinds of electronic gadgets'),
('Apparel', 'Fashionable clothing and accessories'),
('Gadgets', 'Small electronic devices'),
('Books', 'Wide range of books across various genres');

-- Table: ISPRODUCT
INSERT INTO ISPRODUCT (SellerID, CategoryID, Name, Description, Price, StockLevel, IsFlaggedInappropriate, ImageURL)
VALUES 
(1, 1, 'Laptop', 'High-end gaming laptop', 1500.00, 10, 0, 'laptop.jpg'),
(2, 2, 'T-shirt', 'Cotton t-shirt with a cool print', 20.00, 50, 0, 'tshirt.jpg'),
(3, 3, 'Smartwatch', 'Smartwatch with fitness tracking', 200.00, 25, 0, 'smartwatch.jpg');

-- Table: ISORDER
INSERT INTO ISORDER (CustomerID, OrderDate, ShippingStatus, TotalAmount, ShippingAddress, PaymentStatus)
VALUES 
(1, '2023-01-10', 'Shipped', 1500.00, '123 Main St, City A', 'Completed'),
(2, '2023-02-15', 'Pending', 20.00, '456 Oak St, City B', 'Pending'),
(3, '2023-03-20', 'Delivered', 200.00, '789 Pine St, City C', 'Completed');

-- Table: ORDER_ITEM
INSERT INTO ORDER_ITEM (OrderID, ProductID, Quantity, Price)
VALUES 
(1, 1, 1, 1500.00),
(2, 2, 1, 20.00),
(3, 3, 1, 200.00);


---- Insert records into CART table
--INSERT INTO CART (CustomerID, DateCreated, DateModified, CartStatus)
--VALUES
--(1, '2024-01-01', '2024-01-02', 'Active'),
--(2, '2024-02-01', '2024-02-03', 'Active'),
--(3, '2024-03-01', NULL, 'Active');


---- Insert records into CART_ITEM table
--INSERT INTO CART_ITEM (CartID, ProductID, Quantity)
--VALUES
--(1, 1, 2), -- Customer 1 has 2 Laptops in their cart
--(2, 2, 3), -- Customer 2 has 3 T-shirts in their cart
--(3, 3, 1); -- Customer 3 has 1 Smartwatch in their cart

-- NEW BILAL

-- Insert records into the CART table
INSERT INTO CART (UserID, ProductID, Quantity)
VALUES
(1, 1, 2), -- User 1 has 2 items of Product ID 1
(2, 2, 3), -- User 2 has 3 items of Product ID 2
(3, 3, 1); -- User 3 has 1 item of Product ID 3


-- Table: PAYMENT
INSERT INTO PAYMENT (OrderID, PaymentDate, Amount, PaymentMethod, PaymentStatus)
VALUES 
(1, '2023-01-12', 1500.00, 'Credit Card', 'Completed'),
(2, '2023-02-17', 20.00, 'PayPal', 'Pending'),
(3, '2023-03-22', 200.00, 'Debit Card', 'Completed');

-- Table: REVIEW
INSERT INTO REVIEW (ProductID, CustomerID, Rating, Comment, ReviewDate)
VALUES 
(1, 1, 1, 'Amazing laptop, great performance!', '2023-01-15'),
(2, 2, 2, 'Comfortable t-shirt, good quality.', '2023-02-18'),
(3, 3, 3, 'Love the smartwatch, perfect for workouts!', '2023-03-25');

-- Table: LOGISTICS_PROVIDER
INSERT INTO LOGISTICS_PROVIDER (UserID, OrderID, ShipmentID, AssignedArea, ProviderName)
VALUES 
(10, 1, 101, 'Area A', 'FastShip'),
(11, 2, 102, 'Area B', 'QuickTransport'),
(12, 3, 103, 'Area C', 'ShipMaster');

-- Table: SHIPMENT
INSERT INTO SHIPMENT (OrderID, SellerID, TrackingNumber, DeliveryStatus, EstimatedDeliveryDate, PickupDate, DeliveryDate, LogisticsProviderID, LabelGenerated)
VALUES 
(1, 1, 'TRACK12345', 'Shipped', '2023-01-20', '2023-01-18', '2023-01-19', 1, 1),
(2, 2, 'TRACK23456', 'Pending', '2023-02-20', '2023-02-18', NULL, 2, 0),
(3, 3, 'TRACK34567', 'Delivered', '2023-03-25', '2023-03-23', '2023-03-24', 2, 1);

-- Table: WISHLIST
INSERT INTO WISHLIST (CustomerID)
VALUES 
(1),
(2),
(3);

-- Table: WISHLIST_ITEM
INSERT INTO WISHLIST_ITEM (WishlistID, ProductID)
VALUES 
(1, 1),
(2, 2),
(3, 3);

-- Table: ISRETURN
INSERT INTO ISRETURN (CustomerID, ReturnDate, Reason, RefundAmount)
VALUES 
(1, '2023-01-20', 'Damaged product', 1500),
(2, '2023-02-20', 'Wrong size', 20),
(3, '2023-03-30', 'Defective item', 200);


---------




SELECT * FROM LOGIN_HISTORY;
SELECT * FROM ISUSER;
SELECT * FROM ADMIN;
SELECT * FROM CUSTOMER;
SELECT * FROM SELLER;
SELECT * FROM CATEGORY;
SELECT * FROM ISPRODUCT;
SELECT * FROM CART;
SELECT * FROM CART_ITEM;
SELECT * FROM ISORDER;
SELECT * FROM ORDER_ITEM;
SELECT * FROM PAYMENT;
SELECT * FROM REVIEW;
SELECT * FROM SHIPMENT;
SELECT * FROM LOGISTICS_PROVIDER;
SELECT * FROM WISHLIST;
SELECT * FROM WISHLIST_ITEM;
SELECT * FROM ISRETURN;


--DROP TABLE IF EXISTS WISHLIST_ITEM;
--DROP TABLE IF EXISTS WISHLIST;
--DROP TABLE IF EXISTS ISRETURN;
--DROP TABLE IF EXISTS LOGISTICS_PROVIDER;
--DROP TABLE IF EXISTS SHIPMENT;
--DROP TABLE IF EXISTS REVIEW;
--DROP TABLE IF EXISTS PAYMENT;
--DROP TABLE IF EXISTS ORDER_ITEM;
--DROP TABLE IF EXISTS ISORDER;
--DROP TABLE IF EXISTS CART_ITEM;
--DROP TABLE IF EXISTS CART;
--DROP TABLE IF EXISTS ISPRODUCT;
--DROP TABLE IF EXISTS CATEGORY;
--DROP TABLE IF EXISTS SELLER;
--DROP TABLE IF EXISTS CUSTOMER;
--DROP TABLE IF EXISTS ADMIN;
--DROP TABLE IF EXISTS LOGIN_HISTORY;
--DROP TABLE IF EXISTS ISUSER;
