
SELECT  author, MIN(price) "Минимальная_цена",
MAX(price) "Максимальная_цена"
FROM book GROUP BY author
HAVING SUM(price*amount) > 5000;