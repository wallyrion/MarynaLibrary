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
AS
BEGIN
  SELECT book.*, (book.Quantity - COALESCE(lc.Count, 0)) as AvailableCount
  FROM Books book
  OUTER APPLY(
  SELECT SUM(1) as Count
  FROM LibraryCards lc
  WHERE book.Id = lc.BookId AND lc.ReturnDate IS NULL
  GROUP BY lc.BookId
 ) as lc
  WHERE (book.Quantity - COALESCE(lc.Count, 0)) > 0
  AND (book.Author LIKE(CONCAT('%', @Value, '%')) OR book.Title LIKE(CONCAT('%', @Value, '%')))
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