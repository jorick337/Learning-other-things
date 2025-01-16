
SELECT name,city,date_first,
DATEDIFF(date_last+1,date_first)*per_diem AS "Сумма" 
FROM trip WHERE MONTH(date_first) IN (2,3)
ORDER BY NAME ASC,DATEDIFF(date_last+1,date_first)*per_diem DESC;