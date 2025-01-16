SELECT name_author,
(SELECT COUNT(title) FROM book 
WHERE author_id=author.author_id) 
AS "Количество" FROM author
ORDER BY name_author