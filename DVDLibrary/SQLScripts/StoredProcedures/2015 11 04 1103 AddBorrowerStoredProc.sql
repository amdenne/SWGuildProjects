CREATE PROCEDURE AddBorrower
(
	@dvdID int,
	@BorrowerName varchar(50),
	@DateBorrowed date
)AS

INSERT INTO BorrowerInfo(dvdID,BorrowerName,DateBorrowed)
VALUES (@dvdID,@BorrowerName,@DateBorrowed)

