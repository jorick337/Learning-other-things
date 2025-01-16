UPDATE book JOIN author ON author.author_id=book.author_id
JOIN supply ON supply.title=book.title AND supply.author=author.name_author
SET book.price=(book.price*book.amount+supply.price*supply.amount)/
(book.amount+supply.amount),book.amount=book.amount+supply.amount,
supply.amount=0 WHERE supply.price<>book.price;

SELECT * FROM book;
SELECT * FROM supply;