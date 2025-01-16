

SELECT author, SUM(amount) 
"SUM(amount)" FROM book
GROUP BY author;