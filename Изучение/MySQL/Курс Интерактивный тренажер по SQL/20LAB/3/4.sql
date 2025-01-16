INSERT INTO new_books.supply(title,author,price,amount,buy)
SELECT title,author,price,amount,buy
FROM book
WHERE author NOT IN (SELECT author FROM new_books.supply);
SELECT * FROM new_books.supply;