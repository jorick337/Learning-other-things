
SELECT name,city, (date_last-date_first+1) 
AS "Длительность" FROM trip
WHERE city NOT IN ("Москва","Санкт-Петербург")
ORDER BY (date_last-date_first+1) DESC;