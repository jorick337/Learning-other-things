SELECT  author, 
SUM(price*amount) "Стоимость" FROM book
WHERE title!="Идиот" AND title!="Белая гвардия" 
GROUP BY author HAVING SUM(price*amount)>5000
ORDER BY author DESC;