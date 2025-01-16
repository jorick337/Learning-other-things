

SELECT book.title, genre.name_genre, price FROM book
LEFT JOIN genre ON book.genre_id=genre.genre_id
WHERE book.amount>8 ORDER BY price DESC