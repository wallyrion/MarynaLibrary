USE Library;
GO

CREATE PROCEDURE spGetAllBooks
AS BEGIN
   SELECT * FROM Books;
END
GO

CREATE PROCEDURE spGetAllReaders
AS BEGIN
   SELECT * FROM Readers;
END
GO

CREATE PROCEDURE spGetLibraryCard
AS BEGIN
   SELECT lc.*, r.FirstName, r.LastName, r.Phone, b.Author, b.Quantity as BookQuantity, b.Title FROM LibraryCards lc
   INNER JOIN Readers r ON r.Id = lc.ReaderId
   INNER JOIN Books b ON b.Id = lc.BookId
END
GO

CREATE PROCEDURE spSearchBook
@Value NVARCHAR(200)
AS BEGIN
  SELECT b.*, b.Quantity - COALESCE(AvailableCount, 0)
  FROM Books b
  OUTER APPLY(
  SELECT COUNT(lc.Id) as AvailableCount
  FROM LibraryCards lc
  INNER JOIN Books b ON b.Id = lc.BookId 
  WHERE lc.BookId = b.Id
  GROUP BY lc.BookId) as lc
  WHERE b.Author LIKE(CONCAT('%', @Value, '%')) OR b.Title LIKE(CONCAT('%', @Value, '%'))
END
GO

CREATE PROCEDURE spSearchReader
@Value NVARCHAR(200)
AS BEGIN
  SELECT r.*
  FROM Readers r
  WHERE r.FirstName LIKE(CONCAT('%', @Value, '%')) OR r.LastName LIKE(CONCAT('%', @Value, '%'))
END
GO