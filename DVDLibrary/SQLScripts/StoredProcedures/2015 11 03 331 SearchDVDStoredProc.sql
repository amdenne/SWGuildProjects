CREATE PROCEDURE SearchDVDs
(
   @Title varchar(50)
)AS

SELECT *
FROM DVDInfo
WHERE Title LIKE '%'+@Title+'%';