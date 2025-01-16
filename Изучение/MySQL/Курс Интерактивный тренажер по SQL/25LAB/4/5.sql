DELETE FROM author USING author 
JOIN book ON author.author_id = book.author_id
WHERE book.amount < 3;

SELECT * FROM author;
SELECT * FROM book;
