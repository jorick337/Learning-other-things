USE books;USE books;



SELECT title, author, amount, (ROUND(price*0.7,2))"new_price" FROM book;