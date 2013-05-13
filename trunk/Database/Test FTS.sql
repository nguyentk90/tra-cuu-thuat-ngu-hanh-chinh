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
ALTER FUNCTION fts_termSearch
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
WHERE (CONTAINS(HeadWord,'"phu"') OR FREETEXT(HeadWord,'chinh phu'))
AND HeadWord NOT IN (N'chính phủ')