CREATE PROCEDURE CreateDVD
(
	@Title Varchar(50),
	@ReleaseDate Date,
	@MPAARating Varchar(50),
	@DirectorsName varchar(50),
	@Studio varchar(50),
	@UserRating varchar(50),
	@UserNotes varchar(50),
	@ActorsInMovie varchar(50)
)AS 

INSERT INTO DVDInfo (Title,ReleaseDate,MPAARating,DirectorsName,Studio,UserRating,UserNotes,ActorsInMovie)
VALUES (@Title , @ReleaseDate, @MPAARating,@DirectorsName,@Studio,@UserRating,@UserNotes,@ActorsInMovie)