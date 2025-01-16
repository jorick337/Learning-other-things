


SELECT author,ROUND((AVG(price)),2) FROM book
GROUP BY author;