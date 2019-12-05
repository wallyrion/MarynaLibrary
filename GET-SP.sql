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