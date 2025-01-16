
SELECT name, SUM(DATEDIFF(date_last+1,
date_first)*per_diem) AS "Сумма" FROM trip
GROUP BY name
HAVING COUNT(city)>3;