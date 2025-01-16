
SELECT supply.author FROM author
RIGHT JOIN supply 
ON author.name_author=supply.author
WHERE name_author IS NULL