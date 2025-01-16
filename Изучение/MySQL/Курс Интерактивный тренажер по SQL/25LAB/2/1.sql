UPDATE book JOIN supply ON supply.title=book.title
SET book.amount=book.amount+supply.amount,
supply.amount=0 WHERE supply.price=book.price;

SELECT * FROM book;
SELECT * FROM supply;