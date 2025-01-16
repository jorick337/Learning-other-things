CREATE TABLE ordering3
SELECT author,title,amount FROM book
WHERE amount<(SELECT AVG(amount) FROM book);
UPDATE ordering3 SET amount=(SELECT AVG(amount) FROM book);
SELECT * FROM ordering3;