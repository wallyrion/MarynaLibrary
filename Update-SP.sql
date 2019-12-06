USE Library;
GO

CREATE PROCEDURE spUpdateBook
  @Id INT,
  @Author NVARCHAR(200),
  @Title NVARCHAR(200),
  @Quantity INT
AS
  BEGIN
    UPDATE Books
    SET
    Author = @Author,
    Title = @Title,
    Quantity= @Quantity
    WHERE Id = @Id;
  END
GO

CREATE PROCEDURE spUpdateReader
  @Id INT,
  @FirstName NVARCHAR(75),
  @LastName NVARCHAR(75),
  @Phone NVARCHAR(50)
AS
  BEGIN
    UPDATE Readers
    SET
    FirstName = @FirstName,
    LastName = @LastName,
    Phone= @Phone
    WHERE Id = @Id;
  END
GO

CREATE PROCEDURE spReturnBook
  @Id INT
AS
  BEGIN
  UPDATE LibraryCards
  SET ReturnDate = GETDATE()
  WHERE Id = @Id;
  END
GO