

UPDATE new_books.supply SET price = price * 0.8
WHERE amount>5;
SELECT * FROM new_books.supply;