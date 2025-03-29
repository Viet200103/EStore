USE master
CREATE DATABASE EStore
GO

USE EStore
GO

CREATE TABLE [Member](
    [MemberId] INT PRIMARY KEY IDENTITY(1, 1),
    [Email] VARCHAR(100) NOT NULL,
    [CompanyName] VARCHAR(40) NOT NULL,
    [City] VARCHAR(15) NOT NULL,
    [Country] VARCHAR(15) NOT NULL
);
GO

CREATE TABLE [Product](
    [ProductId] INT PRIMARY KEY IDENTITY(1, 1),
    [CategoryId] INT NOT NULL,
    [ProductName] VARCHAR(40),
    [Weight] VARCHAR(20),
    [UnitPrice] MONEY,
    UnitslnStock INT NOT NULL
);
GO

CREATE TABLE [Order](
    [OrderId] INT PRIMARY KEY IDENTITY(1, 1),
    [MemberId] INT NOT NULL,
    [OrderDate] DATETIME2,
    [RequireDate] DATETIME2,
    [ShippedDate] DATETIME2,
    [Freight] MONEY,
);
GO

CREATE TABLE [OrderDetail](
    [OrderDetailId] INT PRIMARY KEY IDENTITY(1, 1),
    [OrderId] INT ,
    [ProductId] INT NOT NULL,
    [UnitPrice] MONEY NOT NULL,
    [Quantity] INT NOT NULL,
    [Discount] FLOAT NOT NULL
);
GO

CREATE TABLE [Category](
    [CategoryId] INT PRIMARY KEY IDENTITY(1, 1),
    [CategoryName] VARCHAR(40),
    [Description] NVARCHAR(MAX)
);
GO

INSERT INTO [Member] (Email, CompanyName, City, Country) VALUES
('john.doe@example.com', 'Acme Corp', 'New York', 'USA'),
('jane.smith@globex.com', 'Globex Industries', 'London', 'UK'),
('peter.jones@datawise.net', 'DataWise Solutions', 'Paris', 'France'),
('maria.garcia@techforward.org', 'TechForward Inc', 'Madrid', 'Spain'),
('kenji.tanaka@innovate.jp', 'Innovate Systems', 'Tokyo', 'Japan');
GO

INSERT INTO [Category] (CategoryName, [Description]) VALUES
('Electronics', 'Các sản phẩm điện tử như laptop, điện thoại, máy tính bảng, v.v.'),
('Clothing', 'Quần áo, giày dép và các phụ kiện thời trang.'),
('Home Goods', 'Đồ dùng gia đình, nội thất và trang trí nhà cửa.'),
('Books', 'Các loại sách, truyện, tạp chí và tài liệu học tập.'),
('Food & Beverage', 'Thực phẩm, đồ uống và các sản phẩm tiêu dùng nhanh.');
GO

INSERT INTO [Product] (CategoryId, ProductName, [Weight], UnitPrice, UnitslnStock) VALUES
(1, 'Laptop', '2.5 kg', 1200.00, 50),
(1, 'Mouse', '0.15 kg', 25.00, 200),
(2, 'T-Shirt', '0.2 kg', 30.00, 150),
(2, 'Jeans', '0.7 kg', 75.00, 100),
(3, 'Coffee Maker', '3 kg', 50.00, 80),
(3, 'Blender', '2 kg', 40.00, 120);
GO

INSERT INTO [Order] (MemberId, OrderDate, RequireDate, ShippedDate, Freight) VALUES
(1, '2025-03-15 10:00:00', '2025-03-22 12:00:00', '2025-03-17 14:00:00', 15.50),
(2, '2025-03-16 14:30:00', '2025-03-23 18:00:00', '2025-03-18 09:00:00', 22.00),
(3, '2025-03-17 09:15:00', '2025-03-24 11:00:00', NULL, 10.75),
(1, '2025-03-18 16:45:00', '2025-03-25 20:00:00', '2025-03-20 11:30:00', 18.20),
(4, '2025-03-19 11:00:00', '2025-03-26 15:00:00', NULL, 12.90);
GO

INSERT INTO [OrderDetail] (OrderId, ProductId, UnitPrice, Quantity, Discount) VALUES
(1, 1, 1200.00, 1, 0.05),
(1, 2, 25.00, 2, 0.00),
(2, 3, 30.00, 3, 0.10),
(2, 4, 75.00, 1, 0.00),
(3, 5, 50.00, 2, 0.02),
(4, 1, 1200.00, 1, 0.00),
(4, 6, 40.00, 4, 0.15),
(5, 2, 25.00, 5, 0.08);
GO

ALTER TABLE [Order]
    ADD CONSTRAINT FK_Order_Member FOREIGN KEY(MemberId)
    REFERENCES [Member]
GO

ALTER TABLE [OrderDetail]
    ADD CONSTRAINT FK_OrderDetail_Order FOREIGN KEY(OrderId)
    REFERENCES [Order]
GO

ALTER TABLE [OrderDetail]    
    ADD CONSTRAINT FK_OrderDetail_Product FOREIGN KEY(ProductId)
    REFERENCES[Product]
GO

ALTER TABLE [Product]
    ADD CONSTRAINT  FK_Product_Category FOREIGN KEY(CategoryId)
    REFERENCES[Category]
GO
