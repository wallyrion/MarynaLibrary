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
('��. �������', '����� ������ � ����������� ������', 2),
('��. �������', '����� ������ � ������ �������', 3),
('��. �������', '����� ������ � ����� ����', 1),
('��. �������', '����� ������ � ����� ��������', 4),
('��. �������', '����� ������ � ����� �������', 5),
('��. �������', '����� ������ � ����� ����������', 7),
('��. �������', '����� ������ � ���� ������', 7)

INSERT INTO Readers(FirstName, LastName, Phone)
VALUES
('�����', '������','+380509170380'),
('������', '���������','+38050716670'),
('��������', '���������','+380506430380'),
('���', '�����','+380509160450'),
('�����', '������','+380559160380'),
('���', '���������','+380509160350'),
('����', '�����','+380509160760')