USE Library;
GO

CREATE PROCEDURE spCreateBook
  @Author NVARCHAR(200),
  @Title NVARCHAR(200),
  @Quantity INT,
  @NewId UNIQUEIDENTIFIER = NULL OUTPUT
AS
  BEGIN
    SET @NewId = NEWID();
    INSERT Books(Id, Author, Title, Quantity) SELECT @NewId, @Author, @Title, @Quantity;
  END
GO

CREATE PROCEDURE spCreateReader
  @FirstName NVARCHAR(75),
  @LastName NVARCHAR(75),
  @Phone NVARCHAR(50),
  @NewId UNIQUEIDENTIFIER = NULL OUTPUT
AS
  BEGIN
    SET @NewId = NEWID();
    INSERT Readers(Id, FirstName, LastName, Phone) SELECT @NewId, @FirstName, @LastName, @Phone;
  END;
GO

CREATE PROCEDURE spCreateLibraryCard
  @ReaderId UNIQUEIDENTIFIER,
  @BookId UNIQUEIDENTIFIER,
  @NewId UNIQUEIDENTIFIER = NULL OUTPUT
AS
  BEGIN
    SET @NewId = NEWID();
    INSERT LibraryCards(Id, ReaderId, BookId, GivenDate)
    SELECT @NewId, @ReaderId, @BookId, GETDATE();
  END;
GO