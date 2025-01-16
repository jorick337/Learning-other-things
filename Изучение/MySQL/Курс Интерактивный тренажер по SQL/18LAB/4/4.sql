


SELECT author, SUM(price*amount) "Стоимость",
ROUND((((SUM(price*amount)*(18/100)))/(1+(18/100))),2) "НДС",
ROUND((SUM(price*amount)/(1+(18/100))),2) 
"Стоимость_без_НДС"
FROM book GROUP BY author;