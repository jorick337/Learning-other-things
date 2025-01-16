USE books;



SELECT author, title, (ROUND(price*1.1,2)) "new_price" FROM book WHERE price < 600;