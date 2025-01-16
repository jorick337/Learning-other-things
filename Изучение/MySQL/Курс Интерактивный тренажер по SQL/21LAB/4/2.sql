CREATE TABLE ordering2
SELECT author,title,amount FROM book
WHERE amount<5;
UPDATE ordering2 SET amount=(SELECT AVG(amount) FROM book);
SELECT * FROM ordering2;