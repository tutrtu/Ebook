-- Create the database
CREATE DATABASE eBookStore;
GO

-- Use the newly created database
USE eBookStore;
GO

-- Create the Publisher table
CREATE TABLE Publisher (
    pub_id INT IDENTITY(1,1) PRIMARY KEY,
    publisher_name NVARCHAR(100) NOT NULL,
    city NVARCHAR(100),
    state NVARCHAR(50),
    country NVARCHAR(50)
);
GO

-- Create the Author table
CREATE TABLE Author (
    author_id INT IDENTITY(1,1) PRIMARY KEY,
    last_name NVARCHAR(50) NOT NULL,
    first_name NVARCHAR(50) NOT NULL,
    phone NVARCHAR(20),
    address NVARCHAR(200),
    city NVARCHAR(100),
    state NVARCHAR(50),
    zip NVARCHAR(10),
    email_address NVARCHAR(100) NOT NULL
);
GO

-- Create the Book table
CREATE TABLE Book (
    book_id INT IDENTITY(1,1) PRIMARY KEY,
    title NVARCHAR(200) NOT NULL,
    type NVARCHAR(50),
    pub_id INT FOREIGN KEY REFERENCES Publisher(pub_id),
    price DECIMAL(18, 2),
    advance DECIMAL(18, 2),
    royalty DECIMAL(18, 2),
    ytd_sales INT,
    notes NVARCHAR(MAX),
    published_date DATE
);
GO

-- Create the User table
CREATE TABLE [User] (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    email_address NVARCHAR(100) NOT NULL,
    password NVARCHAR(200) NOT NULL,
    source NVARCHAR(100),
    first_name NVARCHAR(50),
    middle_name NVARCHAR(50),
    last_name NVARCHAR(50),
    role_id INT,
    pub_id INT,
    hire_date DATE,
    FOREIGN KEY (role_id) REFERENCES Role(role_id),
    FOREIGN KEY (pub_id) REFERENCES Publisher(pub_id)
);
GO

-- Create the Role table
CREATE TABLE Role (
    role_id INT IDENTITY(1,1) PRIMARY KEY,
    role_desc NVARCHAR(100) NOT NULL
);
GO

-- Create the BookAuthor table
CREATE TABLE BookAuthor (
    author_id INT,
    book_id INT,
    author_order INT,
    royalty_percentage DECIMAL(5, 2),
    PRIMARY KEY (author_id, book_id),
    FOREIGN KEY (author_id) REFERENCES Author(author_id),
    FOREIGN KEY (book_id) REFERENCES Book(book_id)
);
GO

-- Insert initial data into the Role table
INSERT INTO Role (role_desc) VALUES 
('Admin'),
('User');

-- Insert initial data into the Publisher table
INSERT INTO Publisher (publisher_name, city, state, country) VALUES 
('Publisher 1', 'City1', 'State1', 'Country1'),
('Publisher 2', 'City2', 'State2', 'Country2');

-- Insert initial data into the Author table
INSERT INTO Author (last_name, first_name, phone, address, city, state, zip, email_address) VALUES 
('Smith', 'John', '123-456-7890', '123 Street', 'City1', 'State1', '12345', 'john.smith@example.com'),
('Doe', 'Jane', '234-567-8901', '456 Avenue', 'City2', 'State2', '67890', 'jane.doe@example.com');

-- Insert initial data into the Book table
INSERT INTO Book (title, type, pub_id, price, advance, royalty, ytd_sales, notes, published_date) VALUES 
('Book 1', 'Fiction', 1, 19.99, 5000, 10, 1000, 'Notes about Book 1', '2020-01-01'),
('Book 2', 'Non-Fiction', 2, 29.99, 7000, 15, 500, 'Notes about Book 2', '2019-05-15');

-- Insert initial data into the User table
INSERT INTO [User] (email_address, password, source, first_name, middle_name, last_name, role_id, pub_id, hire_date) VALUES 
('admin@example.com', 'hashedpassword1', 'internal', 'Admin', '', 'User', 1, NULL, '2020-01-01'),
('user@example.com', 'hashedpassword2', 'external', 'Normal', 'Middle', 'User', 2, 1, '2021-06-01');

-- Insert initial data into the BookAuthor table
INSERT INTO BookAuthor (author_id, book_id, author_order, royalty_percentage) VALUES 
(1, 1, 1, 50),
(2, 2, 1, 60);

ALTER TABLE Author
ALTER COLUMN email_address NVARCHAR(100) NULL;
GO
