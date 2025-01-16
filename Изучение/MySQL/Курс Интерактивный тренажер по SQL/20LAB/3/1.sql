INSERT INTO book(title,author,price,amount,buy)
SELECT title,author,price,amount,buy
FROM new_books.supply 
WHERE author NOT IN ("Булгаков М.А.","Достоевский Ф.М.");
SELECT * FROM book;