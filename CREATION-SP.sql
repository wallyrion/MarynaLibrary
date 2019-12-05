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
  END;
GO