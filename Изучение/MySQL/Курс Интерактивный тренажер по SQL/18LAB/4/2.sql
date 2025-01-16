

SELECT author, 
SUM(price*amount) FROM book
GROUP BY author;