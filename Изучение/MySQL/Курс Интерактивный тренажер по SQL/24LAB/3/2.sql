SELECT title,author.name_author,genre.name_genre,price,amount
FROM book 
JOIN author ON author.author_id=book.author_id
JOIN genre ON genre.genre_id=book.genre_id
WHERE price>=500 AND price<=700