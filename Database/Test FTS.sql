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
alter function fts_termSearch
      (@keywords nvarchar(256))
returns table
as
return (SELECT headword FROM [Entry]
WHERE FREETEXT(headword,@keywords))
  --return (select * from freetexttable([Entry],HeadWord,@keywords))
  
SELECT * FROM dbo.fts_termSearch ('dung');

SELECT * FROM [Entry]
WHERE FREETEXT(headword,'bao moi')