

SELECT  title, author, amount FROM book
WHERE amount>((SELECT AVG(amount) FROM book)+3)
OR amount<((SELECT AVG(amount) FROM book)-3);