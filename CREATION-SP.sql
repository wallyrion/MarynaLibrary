USE Library;
GO

CREATE PROCEDURE spCreateBook
  @Author NVARCHAR(200),
  @Title NVARCHAR(200),
  @Quantity INT,
  @NewId INT = NULL OUTPUT
AS
  BEGIN
    INSERT Books(Author, Title, Quantity) SELECT @Author, @Title, @Quantity;
    SET @NewId = SCOPE_IDENTITY();
  END
GO

CREATE PROCEDURE spCreateReader
  @FirstName NVARCHAR(75),
  @LastName NVARCHAR(75),
  @Phone NVARCHAR(50),
  @NewId INT = NULL OUTPUT
AS
  BEGIN
    INSERT Readers(FirstName, LastName, Phone) SELECT @FirstName, @LastName, @Phone;
    SET @NewId = SCOPE_IDENTITY();
  END;
GO

CREATE PROCEDURE spCreateLibraryCard
  @ReaderId INT,
  @BookId INT,
  @Quantity INT,
  @NewId INT = NULL OUTPUT
AS
  BEGIN
    INSERT LibraryCards(ReaderId, BookId, GivenDate, Quantity)
    SELECT @ReaderId, @BookId, GETDATE(), @Quantity;
    SET @NewId = SCOPE_IDENTITY();
  END;
GO