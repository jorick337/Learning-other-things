INSERT INTO book(title,author_id,genre_id,price,amount)
SELECT title,author.author_id,NULL,price,amount FROM supply
JOIN author ON author.name_author=supply.author WHERE amount<>0;

SELECT * FROM book;