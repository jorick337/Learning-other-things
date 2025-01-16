USE books;



SELECT title, amount, price, ROUND(price*0.5,2) "sale", ("скидка 50%") "Ваша_скидка" FROM book WHERE amount<4
UNION
SELECT title, amount, price, ROUND(price*0.7,2) "sale", ("скидка 30%") "Ваша_скидка" FROM book WHERE 4<amount AND amount<11
UNION
SELECT title, amount, price, ROUND(price*0.9,2) "sale", ("скидка 10%") "Ваша_скидка" FROM book WHERE amount>11;