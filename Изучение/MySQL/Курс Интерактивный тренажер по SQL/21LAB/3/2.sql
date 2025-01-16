
UPDATE book, new_books.supply
SET book.price = (book.price+new_books.supply.price)/2
WHERE book.title = new_books.supply.title;
SELECT * FROM book;