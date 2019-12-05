CREATE DATABASE [Library]
GO

USE Library;

CREATE TABLE Reader(
Id int IDENTITY NOT NULL PRIMARY KEY,
FirstName VARCHAR(75) NOT NULL,
LastName VARCHAR(75) NOT NULL,
Phone Varchar(50) NOT NULL UNIQUE);

CREATE TABLE Book(
Id INT IDENTITY NOT NULL PRIMARY KEY,
Author VARCHAR(200) NOT NULL,
Title VARCHAR(200) NOT NULL,
Quantity INT NOT NULL);

CREATE TABLE LibraryCard(
Id INT IDENTITY NOT NULL PRIMARY KEY,
ReaderId INT FOREIGN KEY REFERENCES Reader(Id) NOT NULL,
BookId INT FOREIGN KEY REFERENCES Book(Id) NOT NULL,
GivenDate DATETIME NOT NULL,
ScheduleReturnDate DATETIME NOT NULL,
ReturnDate DATETIME NULL);

INSERT INTO Book(Author, Title, Quantity)
VALUES
('Дж. Роулинг', 'Гарри Поттер и Философский камень', 2),
('Дж. Роулинг', 'Гарри Поттер и Тайная комната', 3),
('Дж. Роулинг', 'Гарри Поттер и Кубок Огня', 1),
('Дж. Роулинг', 'Гарри Поттер и узник Азкабана', 4),
('Дж. Роулинг', 'Гарри Поттер и Орден Феникса', 5),
('Дж. Роулинг', 'Гарри Поттер и Принц Полукровка', 7),
('Дж. Роулинг', 'Гарри Поттер и Дары Смерти', 7)

INSERT INTO Reader(FirstName, LastName, Phone)
VALUES
('Гарри', 'Поттер','+380509170380'),
('Генрих', 'Четвертый','+38050716670'),
('Гермиона', 'Грейнджер','+380506430380'),
('Рон', 'Уизли','+380509160450'),
('Драко', 'Малфой','+380559160380'),
('Кот', 'Матроскин','+380509160350'),
('Дядя', 'Федор','+380509160760')