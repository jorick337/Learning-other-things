USE books;

SELECT author, title, (ROUND(price*1.1,2)) "new_price" FROM book WHERE author = "Булгаков М.А."
UNION
SELECT author, title, (ROUND(price*1.05,2)) "new_price" FROM book WHERE author = "Есенин С.А."
UNION
SELECT author, title, (ROUND(price,2)) "new_price" FROM book WHERE author = "Достоевский Ф.М."