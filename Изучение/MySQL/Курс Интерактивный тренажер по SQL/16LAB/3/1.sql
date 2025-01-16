USE books;



SELECT title, price, (ROUND((price*(18/100))/(1+(18/100)),2)) "tax",  (ROUND(price/(1+(18/100)),2)) "price_tax" FROM book;