CREATE TABLE Images 
(
 ID int PRIMARY KEY IDENTITY(1,1),
 FileName varchar(256) not null,
 FileData varbinary(MAX) not null,
 Description varchar(MAX) not null,
 Timestamp datetime default(getdate())
)
GO
CREATE PROCEDURE Images_GetList
AS
SELECT ID, FileName, Description
FROM Images
ORDER BY Timestamp DESC;
GO
CREATE PROCEDURE Images_Insert
(
	@FileName varchar(256),
	@FileData varbinary(MAX),
	@Description varchar(MAX)
)
AS
INSERT INTO Images(FileName, FileData, Description)
VALUES(@FileName, @FileData, @Description)
GO
CREATE PROCEDURE Images_GetDataByID
(
	@ID int
)
AS
SELECT FileData
FROM Images
WHERE ID=@ID;