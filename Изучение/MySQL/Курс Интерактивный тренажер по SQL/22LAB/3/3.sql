

SELECT name,city,date_last,date_first FROM trip
WHERE MONTH(date_last)=MONTH(date_first)
ORDER BY city ASC, name ASC;