

SELECT book.title, author.name_author
FROM book LEFT JOIN author 
ON author.author_id=book.author_id