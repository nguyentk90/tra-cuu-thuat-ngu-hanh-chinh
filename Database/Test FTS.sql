SELECT * FROM Accounts
WHERE fullname like '%khanh%'

SELECT * FROM SearchHistory
WHERE FREETEXT(Keyword,'khanh nguyen yeu')
SELECT * FROM SearchHistory
WHERE CONTAINS(Keyword,'"kha*"')

SELECT * FROM Phone_details
WHERE name like '%a%'

SELECT * FROM customers
WHERE username like 'kha%'

SELECT * FROM Accounts
WHERE fullname like '%e%'

SELECT * FROM Accounts
WHERE FREETEXT(fullname,'khanh nguyen trần')


----------------------------------------
--FUNCTION
ALTER FUNCTION [dbo].[fts_termSearch]
      (@keywords NVARCHAR(256))
RETURNS @WordIndex TABLE
(
	HeadWord nvarchar(256),
	WordType varchar(1)
)
AS
BEGIN
	DECLARE @SearchWord NVARCHAR(256)
	SET @SearchWord ='"'+@keywords+'"'
	INSERT @WordIndex
	SELECT TOP(10) * FROM WordIndex
	WHERE CONTAINS(HeadWord,@SearchWord) OR FREETEXT(HeadWord,@keywords)
	RETURN
END

  --return (select * from freetexttable([Entry],HeadWord,@keywords))
  
SELECT * FROM dbo.fts_termSearch ('chinh phu dien tu');

SELECT * FROM [Entry]
WHERE FREETEXT(headword,'bao moi')


SELECT * FROM WordIndex
WHERE FREETEXT(HeadWord,'chinh phu')

SELECT * FROM WordIndex
WHERE CONTAINS(HeadWord,'"ch*"')

------ auto complete
--FUNCTION
ALTER FUNCTION [dbo].[fts_AutoCompelte_SearchHistory]
      (@keywords NVARCHAR(256))
RETURNS @AutoComplete TABLE
(
	Keyword nvarchar(256)
)
AS
BEGIN
	DECLARE @SearchWord NVARCHAR(256)
	SET @SearchWord ='"'+@keywords+'*"'
	INSERT @AutoComplete
	SELECT TOP(10) Keyword FROM SearchHistory
	WHERE CONTAINS(Keyword,@SearchWord)AND IsExist = 1 ORDER BY [Counter] DESC
	RETURN
END

----------------------
--********************
----------------------

ALTER FUNCTION [dbo].[fts_AutoCompelte]
      (@keywords NVARCHAR(256),@top INT)
      
RETURNS @AutoComplete TABLE
(
	Keyword nvarchar(256)
)
AS
BEGIN
	DECLARE @SearchWord NVARCHAR(256)
	SET @SearchWord ='"'+@keywords+'*"'
	INSERT @AutoComplete
	SELECT TOP(@top) HeadWord FROM WordIndex
	WHERE CONTAINS(HeadWord,@SearchWord)AND HeadWord NOT IN (SELECT TOP(10) Keyword FROM SearchHistory
	WHERE CONTAINS(Keyword,@SearchWord))		
	RETURN
END

-- get from SearchHistory (A)
-- if return >= 10 => get all
-- else
-- get from WordIndex top 10 - A.count NOT IN (A)



SELECT * FROM [fts_AutoCompelte_SearchHistory] ('bo')