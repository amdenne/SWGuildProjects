CREATE PROCEDURE ReturnDVD
(
	@dvdID int,
	@BorrowerName varchar(50),
	@DateReturned date
)AS

INSERT INTO BorrowerInfo(dvdID,BorrowerName,DateReturned)
VALUES(@dvdID,@BorrowerName,@DateReturned)