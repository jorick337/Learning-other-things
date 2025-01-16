

DELETE FROM supply
WHERE title=(SELECT title FROM books.book WHERE title=supply.title);
SELECT * FROM supply;