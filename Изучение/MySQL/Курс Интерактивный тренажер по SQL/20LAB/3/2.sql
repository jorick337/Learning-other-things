INSERT INTO book(title,author,price,amount,buy)
SELECT title,author,price,amount,buy
FROM new_books.supply 
WHERE title NOT IN (SELECT title FROM book);
SELECT * FROM book;