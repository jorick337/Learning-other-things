CREATE TABLE ordering1 
SELECT author,title,amount FROM supply
WHERE amount<4;
UPDATE ordering1 SET amount=5;
SELECT * FROM ordering1;


