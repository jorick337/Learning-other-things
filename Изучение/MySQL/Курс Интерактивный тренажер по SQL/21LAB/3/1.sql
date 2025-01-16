
UPDATE book, new_books.supply
SET book.amount = book.amount + new_books.supply.amount
WHERE book.title = new_books.supply.title;
SELECT * FROM book;