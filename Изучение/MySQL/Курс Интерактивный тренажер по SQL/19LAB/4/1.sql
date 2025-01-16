

SELECT  title, author, 
price, amount FROM book
WHERE price=(SELECT MIN(price) FROM book);