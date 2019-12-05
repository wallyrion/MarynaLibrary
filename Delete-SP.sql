USE Library;
GO

CREATE PROCEDURE spDeleteBook
  @Id int
AS
BEGIN
  DELETE FROM Books
  WHERE Id = @Id
END
GO

CREATE PROCEDURE spDeleteReader
  @Id int
AS
BEGIN
  DELETE FROM Readers
  WHERE Id = @Id
END
GO