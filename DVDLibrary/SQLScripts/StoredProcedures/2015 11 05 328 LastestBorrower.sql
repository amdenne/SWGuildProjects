CREATE PROCEDURE LatestBorrower
(
	@dvdID int
)
AS

WITH LatestBorrower AS
(
	SELECT TOP(1) * FROM BorrowerInfo
	WHERE @dvdID = BorrowerInfo.dvdID
	ORDER BY BorrowerID desc
)
SELECT *
FROM DVDInfo d
LEFT JOIN LatestBorrower b ON d.dvdID = b.dvdID
Where d.dvdID = @dvdID