SELECT MONTHNAME(date_first) AS "Месяц",
COUNT(date_first) AS "Количество" 
FROM trip GROUP BY MONTHNAME(date_first)
ORDER BY COUNT(date_first) DESC, 
MONTHNAME(date_first) ASC;


