CREATE DATABASE [Library]
GO

USE Library;

CREATE TABLE Readers(
Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
FirstName NVARCHAR(75) NOT NULL,
LastName NVARCHAR(75) NOT NULL,
Phone NVARCHAR(50) NOT NULL);

CREATE TABLE Books(
Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
Author NVARCHAR(200) NOT NULL,
Title NVARCHAR(200) NOT NULL,
Quantity INT NOT NULL);

CREATE TABLE LibraryCards(
Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
ReaderId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Readers(Id) NOT NULL,
BookId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Books(Id) NOT NULL,
GivenDate DATETIME NOT NULL,
ReturnDate DATETIME NULL);

INSERT INTO Books(Id, Author, Title, Quantity)
VALUES
(NEWID(), 'Дж. Роулинг', 'Гарри Поттер и Философский камень', 2),
(NEWID(), 'Дж. Роулинг', 'Гарри Поттер и Тайная комната', 3),
(NEWID(), 'Дж. Роулинг', 'Гарри Поттер и Кубок Огня', 1),
(NEWID(), 'Дж. Роулинг', 'Гарри Поттер и узник Азкабана', 4),
(NEWID(), 'Дж. Роулинг', 'Гарри Поттер и Орден Феникса', 5),
(NEWID(), 'Дж. Роулинг', 'Гарри Поттер и Принц Полукровка', 7),
(NEWID(), 'Дж. Роулинг', 'Гарри Поттер и Дары Смерти', 7)

INSERT INTO Readers(Id, FirstName, LastName, Phone)
VALUES
(NEWID(), 'Гарри', 'Поттер','+380509170380'),
(NEWID(), 'Генрих', 'Четвертый','+38050716670'),
(NEWID(), 'Гермиона', 'Грейнджер','+380506430380'),
(NEWID(), 'Рон', 'Уизли','+380509160450'),
(NEWID(), 'Драко', 'Малфой','+380559160380'),
(NEWID(), 'Кот', 'Матроскин','+380509160350'),
(NEWID(), 'Дядя', 'Федор','+380509160760')