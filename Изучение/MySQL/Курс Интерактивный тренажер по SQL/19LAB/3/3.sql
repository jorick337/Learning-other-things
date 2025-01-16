
SELECT  author, MIN(price) "Минимальная_цена", 
MAX(price) "Максимальная_цена" FROM book
WHERE author!="Есенин С.А." GROUP BY author
HAVING SUM(amount)>10