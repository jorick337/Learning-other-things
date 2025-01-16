SELECT 
ROUND((AVG(price)),2) "Средняя_цена",
SUM(price*amount) "Стоимость"
FROM book
WHERE amount >= 5 and amount <=14;