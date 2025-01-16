SELECT genre.name_genre,title,author.name_author
FROM book 
JOIN author ON author.author_id=book.author_id
JOIN genre ON genre.genre_id=book.genre_id
WHERE genre.name_genre="Роман" ORDER BY title ASC