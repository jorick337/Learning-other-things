


SELECT title,author.author_id,price,amount FROM supply
JOIN author ON author.name_author=supply.author
