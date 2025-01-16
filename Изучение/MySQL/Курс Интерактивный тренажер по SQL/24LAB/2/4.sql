

SELECT name_genre FROM genre
LEFT JOIN book ON book.genre_id=genre.genre_id
WHERE book.title IS NULL