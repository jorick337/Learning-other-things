

SELECT title, author, price, amount FROM book 
WHERE price < 500  AND price*amount >= 5000
OR price > 600 AND price*amount >= 5000;