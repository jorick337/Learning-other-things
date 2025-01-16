

SELECT city, COUNT(city) 
AS "Количество" FROM trip
GROUP BY city LIMIT 2;