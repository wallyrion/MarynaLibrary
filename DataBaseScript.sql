CREATE DATABASE [Library]
GO

USE Library;

CREATE TABLE Readers(
Id int IDENTITY NOT NULL PRIMARY KEY,
FirstName NVARCHAR(75) NOT NULL,
LastName NVARCHAR(75) NOT NULL,
Phone NVARCHAR(50) NOT NULL);

CREATE TABLE Books(
Id INT IDENTITY NOT NULL PRIMARY KEY,
Author NVARCHAR(200) NOT NULL,
Title NVARCHAR(200) NOT NULL,
Quantity INT NOT NULL);

CREATE TABLE LibraryCards(
Id INT IDENTITY NOT NULL PRIMARY KEY,
ReaderId INT FOREIGN KEY REFERENCES Readers(Id) NOT NULL,
BookId INT FOREIGN KEY REFERENCES Books(Id) NOT NULL,
GivenDate DATETIME NOT NULL,
ScheduleReturnDate DATETIME NOT NULL,
ReturnDate DATETIME NULL,
Quantity INT NOT NULL);

INSERT INTO Books(Author, Title, Quantity)
VALUES
('Дж. Роулинг', 'Гарри Поттер и Философский камень', 2),
('Дж. Роулинг', 'Гарри Поттер и Тайная комната', 3),
('Дж. Роулинг', 'Гарри Поттер и Кубок Огня', 1),
('Дж. Роулинг', 'Гарри Поттер и узник Азкабана', 4),
('Дж. Роулинг', 'Гарри Поттер и Орден Феникса', 5),
('Дж. Роулинг', 'Гарри Поттер и Принц Полукровка', 7),
('Дж. Роулинг', 'Гарри Поттер и Дары Смерти', 7)

INSERT INTO Readers(FirstName, LastName, Phone)
VALUES
('Гарри', 'Поттер','+380509170380'),
('Генрих', 'Четвертый','+38050716670'),
('Гермиона', 'Грейнджер','+380506430380'),
('Рон', 'Уизли','+380509160450'),
('Драко', 'Малфой','+380559160380'),
('Кот', 'Матроскин','+380509160350'),
('Дядя', 'Федор','+380509160760')