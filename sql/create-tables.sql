USE test_react;

CREATE TABLE [test_react].[dbo].[user] (
	id NVARCHAR(250) PRIMARY KEY,
	pseudo NVARCHAR(250),
	mail NVARCHAR(250) NOT NULL,
	password NVARCHAR(250) NOT NULL,
	salt VARBINARY(MAX),
	registration_date DATE
)

CREATE TABLE [test_react].[dbo].[refresh_token] (
	id INT PRIMARY KEY IDENTITY(1, 1),
	token NVARCHAR(250) NOT NULL,
	username NVARCHAR(250) NOT NULL,
	date DATETIME NOT NULL
)

CREATE TABLE [test_react].[dbo].[article] (
    id INT PRIMARY KEY IDENTITY(1, 1),
	author NVARCHAR(250) NOT NULL,
    title NVARCHAR(250) NOT NULL,
    content TEXT NOT NULL,
    date DATE NOT NULL
)

CREATE TABLE [test_react].[dbo].[comment] (
	id INT PRIMARY KEY IDENTITY(1, 1),
	article INT NOT NULL,
	pseudo NVARCHAR(250) NOT NULL,
	comment TEXT NOT NULL
)