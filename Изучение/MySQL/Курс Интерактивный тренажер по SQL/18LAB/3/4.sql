

SELECT author, MIN(price) 
"min_price" FROM book
GROUP BY author;