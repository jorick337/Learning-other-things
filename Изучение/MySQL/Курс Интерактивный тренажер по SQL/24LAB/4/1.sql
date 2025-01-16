SELECT name_author,
COUNT(title) AS "Количество" 
FROM author JOIN book 
ON author.author_id=book.author_id
GROUP BY name_author
ORDER BY name_author