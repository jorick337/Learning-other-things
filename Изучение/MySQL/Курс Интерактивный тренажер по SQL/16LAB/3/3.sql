USE books;



SELECT title, amount, price, 
CASE
	WHEN amount < 4 
			THEN ROUND(price*0.5,2)
    ELSE ROUND(price*0.7,2)
END AS "sale"
FROM book;