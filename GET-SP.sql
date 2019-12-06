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
  SELECT b.*, SUM(lc.Quantity) as AvailableCount 
  FROM Books b
  LEFT JOIN LibraryCards lc ON lc.BookId = b.Id
  WHERE b.Author LIKE(CONCAT('%', @Value, '%')) OR b.Title LIKE(CONCAT('%', @Value, '%'))
  GROUP BY b.Id, lc.Quantity;
END
GO

CREATE PROCEDURE spSearchReader
@Value NVARCHAR(200)
AS BEGIN
  SELECT r.*, SUM(lc.Quantity) as AvailableCount 
  FROM Readers r
  LEFT JOIN LibraryCards lc ON lc.ReaderId = r.Id
  WHERE r.FirstName LIKE(CONCAT('%', @Value, '%')) OR r.LastName LIKE(CONCAT('%', @Value, '%'))
  GROUP BY r.Id;
END
GO