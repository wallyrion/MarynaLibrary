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
('��. �������', '����� ������ � ����������� ������', 2),
('��. �������', '����� ������ � ������ �������', 3),
('��. �������', '����� ������ � ����� ����', 1),
('��. �������', '����� ������ � ����� ��������', 4),
('��. �������', '����� ������ � ����� �������', 5),
('��. �������', '����� ������ � ����� ����������', 7),
('��. �������', '����� ������ � ���� ������', 7)

INSERT INTO Reader(FirstName, LastName, Phone)
VALUES
('�����', '������','+380509170380'),
('������', '���������','+38050716670'),
('��������', '���������','+380506430380'),
('���', '�����','+380509160450'),
('�����', '������','+380559160380'),
('���', '���������','+380509160350'),
('����', '�����','+380509160760')