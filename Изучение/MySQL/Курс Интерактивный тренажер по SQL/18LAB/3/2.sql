

SELECT author, COUNT(amount)
"COUNT(amount)" FROM book
GROUP BY author;