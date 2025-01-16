SELECT author.name_author,SUM(amount) AS "Количество"
FROM book 
RIGHT JOIN author ON author.author_id=book.author_id
GROUP BY author.name_author
HAVING SUM(amount)<10 OR SUM(amount) IS NULL
ORDER BY SUM(amount) ASC
