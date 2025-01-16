

UPDATE new_books.supply SET price = price * 1.1
WHERE amount>=5 AND amount<=10;
SELECT * FROM new_books.supply;