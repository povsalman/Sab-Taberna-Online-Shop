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


-- Table: PLATFORM_SETTINGS
CREATE TABLE PLATFORM_SETTINGS (
    SettingID INT IDENTITY(1,1) PRIMARY KEY, -- Unique identifier for each setting
    ShopName NVARCHAR(255) NOT NULL,        -- Name of the shop/platform
    ShopEmail NVARCHAR(255) NOT NULL,       -- Email address for customer support
    ShopContactHelpline NVARCHAR(20) NOT NULL, -- Contact helpline number
    TotalBranches INT NOT NULL CHECK (TotalBranches >= 0), -- Total number of branches, non-negative
    LastUpdated DATETIME DEFAULT GETDATE(), -- Timestamp for the last update
    UpdatedBy INT NOT NULL, -- User ID of the admin who last updated the settings
    FOREIGN KEY (UpdatedBy) REFERENCES ISUSER(UserID) -- Linking the admin updating the settings
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

-- Adding Address to ISUSER
ALTER TABLE ISUSER
ADD Country NVARCHAR(100) NULL,
    City NVARCHAR(100) NULL;



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
('Fashion', 'Fancy Wear'),
('Electronics', 'All kinds of electronic gadgets'),
('Home and Living', 'Fashionable accessories'),
('Health and Beauty', 'State of the art products'),
('Food and Beverages', 'Organic products');


---- Table: ISPRODUCT
--INSERT INTO ISPRODUCT (SellerID, CategoryID, Name, Description, Price, StockLevel, IsFlaggedInappropriate, ImageURL)
--VALUES 
--(1, 1, 'Laptop', 'High-end gaming laptop', 1500.00, 10, 0, 'laptop.jpg'),
--(2, 2, 'T-shirt', 'Cotton t-shirt with a cool print', 20.00, 50, 0, 'tshirt.jpg'),
--(3, 3, 'Smartwatch', 'Smartwatch with fitness tracking', 200.00, 25, 0, 'smartwatch.jpg');



-- New Bilal
-- Insert Products
INSERT INTO ISPRODUCT (Name, Price, Description, StockLevel, SellerID, CategoryID, ImageURL, IsFlaggedInappropriate)
VALUES
-- Fashion Products
('Shirt', 19.99, 'Cotton Shirt', 50, 1, 1, 'C:\\Users\\HP\\Desktop\\images\\shirt.png', 0),
('Jeans', 39.99, 'Denim Jeans', 30, 1, 1, 'C:\\Users\\HP\\Desktop\\images\\jeans.png', 0),
('Jacket', 59.99, 'Winter Jacket', 20, 1, 1, 'C:\\Users\\HP\\Desktop\\images\\jacket.png', 0),
('Dress', 29.99, 'Evening Dress', 15, 1, 1, 'C:\\Users\\HP\\Desktop\\images\\dress.png', 0),
('T-shirt', 15.99, 'Casual T-shirt', 40, 1, 1, 'C:\\Users\\HP\\Desktop\\images\\t-shirt.png', 0),
('Shoes', 49.99, 'Running Shoes', 25, 1, 1, 'C:\\Users\\HP\\Desktop\\images\\shoes.png', 0),
('Cap', 9.99, 'Baseball Cap', 60, 1, 1, 'C:\\Users\\HP\\Desktop\\images\\cap.png', 0),
('Socks', 4.99, 'Ankle Socks', 70, 1, 1, 'C:\\Users\\HP\\Desktop\\images\\socks.png', 0),
('Scarf', 14.99, 'Woolen Scarf', 30, 1, 1, 'C:\\Users\\HP\\Desktop\\images\\scarf.png', 0),
('Belt', 19.99, 'Leather Belt', 35, 1, 1, 'C:\\Users\\HP\\Desktop\\images\\belt.png', 0),

-- Electronics Products
('Smartphone', 699.99, 'Latest Smartphone', 10, 2, 2, 'C:\\Users\\HP\\Desktop\\images\\smartphone.png', 0),
('Laptop', 899.99, 'High Performance Laptop', 8, 2, 2, 'C:\\Users\\HP\\Desktop\\images\\laptop.png', 0),
('Headphones', 59.99, 'Noise Cancelling Headphones', 20, 2, 2, 'C:\\Users\\HP\\Desktop\\images\\headphones.png', 0),
('Smartwatch', 199.99, 'Fitness Smartwatch', 15, 2, 2, 'C:\\Users\\HP\\Desktop\\images\\smartwatch.png', 0),
('Camera', 499.99, 'DSLR Camera', 5, 2, 2, 'C:\\Users\\HP\\Desktop\\images\\camera.png', 0),
('Tablet', 299.99, '10-inch Tablet', 12, 2, 2, 'C:\\Users\\HP\\Desktop\\images\\tablet.png', 0),
('Charger', 24.99, 'Fast Charger', 50, 2, 2, 'C:\\Users\\HP\\Desktop\\images\\charger.png', 0),
('Mouse', 19.99, 'Wireless Mouse', 40, 2, 2, 'C:\\Users\\HP\\Desktop\\images\\mouse.png', 0),
('Keyboard', 49.99, 'Mechanical Keyboard', 30, 2, 2, 'C:\\Users\\HP\\Desktop\\images\\keyboard.png', 0),
('Speaker', 79.99, 'Bluetooth Speaker', 25, 2, 2, 'C:\\Users\\HP\\Desktop\\images\\speaker.png', 0),

-- Home and Living Products
('Sofa', 499.99, '3-Seater Sofa', 10, 3, 3, 'C:\\Users\\HP\\Desktop\\images\\sofa.png', 0),
('Dining Table', 399.99, 'Wooden Dining Table', 8, 3, 3, 'C:\\Users\\HP\\Desktop\\images\\dining_table.png', 0),
('Bed', 699.99, 'Queen Size Bed', 5, 3, 3, 'C:\\Users\\HP\\Desktop\\images\\bed.png', 0),
('Curtains', 29.99, 'Window Curtains', 20, 3, 3, 'C:\\Users\\HP\\Desktop\\images\\curtains.png', 0),
('Lamp', 49.99, 'Table Lamp', 15, 3, 3, 'C:\\Users\\HP\\Desktop\\images\\lamp.png', 0),
('Rug', 99.99, 'Area Rug', 12, 3, 3, 'C:\\Users\\HP\\Desktop\\images\\rug.png', 0),
('Shelf', 59.99, 'Wall Shelf', 18, 3, 3, 'C:\\Users\\HP\\Desktop\\images\\shelf.png', 0),
('Chair', 39.99, 'Office Chair', 20, 3, 3, 'C:\\Users\\HP\\Desktop\\images\\chair.png', 0),
('Mirror', 79.99, 'Wall Mirror', 10, 3, 3, 'C:\\Users\\HP\\Desktop\\images\\mirror.png', 0),
('Clock', 19.99, 'Wall Clock', 25, 3, 3, 'C:\\Users\\HP\\Desktop\\images\\clock.png', 0),

-- Health and Beauty Products
('Shampoo', 9.99, 'Herbal Shampoo', 50, 1, 4, 'C:\\Users\\HP\\Desktop\\images\\shampoo.png', 0),
('Conditioner', 9.99, 'Silky Conditioner', 40, 1, 4, 'C:\\Users\\HP\\Desktop\\images\\conditioner.png', 0),
('Cream', 19.99, 'Moisturizing Cream', 30, 1, 4, 'C:\\Users\\HP\\Desktop\\images\\cream.png', 0),
('Lipstick', 14.99, 'Matte Lipstick', 20, 1, 4, 'C:\\Users\\HP\\Desktop\\images\\lipstick.png', 0),
('Perfume', 49.99, 'Floral Perfume', 15, 1, 4, 'C:\\Users\\HP\\Desktop\\images\\perfume.png', 0),
('Sunscreen', 15.99, 'SPF 50 Sunscreen', 30, 1, 4, 'C:\\Users\\HP\\Desktop\\images\\sunscreen.png', 0),
('Makeup Kit', 59.99, 'Complete Makeup Kit', 10, 1, 4, 'C:\\Users\\HP\\Desktop\\images\\makeup_kit.png', 0),
('Deodorant', 9.99, 'Roll-On Deodorant', 40, 1, 4, 'C:\\Users\\HP\\Desktop\\images\\deodorant.png', 0),
('Hair Dryer', 39.99, 'Professional Hair Dryer', 15, 1, 4, 'C:\\Users\\HP\\Desktop\\images\\hair_dryer.png', 0),
('Straightener', 29.99, 'Hair Straightener', 12, 1, 4, 'C:\\Users\\HP\\Desktop\\images\\straightener.png', 0),

-- Food and Beverages Products
('Chocolates', 4.99, 'Milk Chocolates', 60, 2, 5, 'C:\\Users\\HP\\Desktop\\images\\chocolates.png', 0),
('Cookies', 3.99, 'Butter Cookies', 50, 2, 5, 'C:\\Users\\HP\\Desktop\\images\\cookies.png', 0),
('Chips', 2.99, 'Potato Chips', 70, 2, 5, 'C:\\Users\\HP\\Desktop\\images\\chips.png', 0),
('Juice', 1.99, 'Orange Juice', 80, 2, 5, 'C:\\Users\\HP\\Desktop\\images\\juice.png', 0),
('Coffee', 9.99, 'Premium Coffee', 40, 2, 5, 'C:\\Users\\HP\\Desktop\\images\\coffee.png', 0),
('Tea', 4.99, 'Herbal Tea', 50, 2, 5, 'C:\\Users\\HP\\Desktop\\images\\tea.png', 0),
('Cereal', 6.99, 'Breakfast Cereal', 30, 2, 5, 'C:\\Users\\HP\\Desktop\\images\\cereal.png', 0),
('Candy', 1.99, 'Fruit Candy', 90, 2, 5, 'C:\\Users\\HP\\Desktop\\images\\candy.png', 0),
('Ice Cream', 4.99, 'Vanilla Ice Cream', 25, 2, 5, 'C:\\Users\\HP\\Desktop\\images\\ice_cream.png', 0),
('Snacks', 3.99, 'Assorted Snacks', 60, 2, 5, 'C:\\Users\\HP\\Desktop\\images\\snacks.png', 0);




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



-- Insert initial data into PLATFORM_SETTINGS
INSERT INTO PLATFORM_SETTINGS (ShopName, ShopEmail, ShopContactHelpline, TotalBranches, UpdatedBy)
VALUES
('SABTaberna', 'support@sabtaberna.com', '+123456789', 10, 4);



---------




SELECT * FROM LOGIN_HISTORY;
SELECT * FROM ISUSER;
SELECT * FROM ADMIN;
SELECT * FROM CUSTOMER;
SELECT * FROM SELLER;
SELECT * FROM CATEGORY;
SELECT * FROM ISPRODUCT;
SELECT * FROM CART;
SELECT * FROM ISORDER;
SELECT * FROM ORDER_ITEM;
SELECT * FROM PAYMENT;
SELECT * FROM REVIEW;
SELECT * FROM SHIPMENT;
SELECT * FROM LOGISTICS_PROVIDER;
SELECT * FROM WISHLIST;
SELECT * FROM WISHLIST_ITEM;
SELECT * FROM ISRETURN;
SELECT * FROM PLATFORM_SETTINGS


--DROP TABLE IF EXISTS WISHLIST_ITEM;
--DROP TABLE IF EXISTS WISHLIST;
--DROP TABLE IF EXISTS ISRETURN;
--DROP TABLE IF EXISTS LOGISTICS_PROVIDER;
--DROP TABLE IF EXISTS SHIPMENT;
--DROP TABLE IF EXISTS REVIEW;
--DROP TABLE IF EXISTS PAYMENT;
--DROP TABLE IF EXISTS ORDER_ITEM;
--DROP TABLE IF EXISTS ISORDER;
--DROP TABLE IF EXISTS CART;
--DROP TABLE IF EXISTS ISPRODUCT;
--DROP TABLE IF EXISTS CATEGORY;
--DROP TABLE IF EXISTS SELLER;
--DROP TABLE IF EXISTS CUSTOMER;
--DROP TABLE IF EXISTS ADMIN;
--DROP TABLE IF EXISTS LOGIN_HISTORY;
--DROP TABLE IF EXISTS ISUSER;
--DROP TABLE IF EXISTS PLATFORM_SETTINGS;
