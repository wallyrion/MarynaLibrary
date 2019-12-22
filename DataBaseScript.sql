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
(NEWID(), '��. �������', '����� ������ � ����������� ������', 2),
(NEWID(), '��. �������', '����� ������ � ������ �������', 3),
(NEWID(), '��. �������', '����� ������ � ����� ����', 1),
(NEWID(), '��. �������', '����� ������ � ����� ��������', 4),
(NEWID(), '��. �������', '����� ������ � ����� �������', 5),
(NEWID(), '��. �������', '����� ������ � ����� ����������', 7),
(NEWID(), '��. �������', '����� ������ � ���� ������', 7)

INSERT INTO Readers(Id, FirstName, LastName, Phone)
VALUES
(NEWID(), '�����', '������','+380509170380'),
(NEWID(), '������', '���������','+38050716670'),
(NEWID(), '��������', '���������','+380506430380'),
(NEWID(), '���', '�����','+380509160450'),
(NEWID(), '�����', '������','+380559160380'),
(NEWID(), '���', '���������','+380509160350'),
(NEWID(), '����', '�����','+380509160760')