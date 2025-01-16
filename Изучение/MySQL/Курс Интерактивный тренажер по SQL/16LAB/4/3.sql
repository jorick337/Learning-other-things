USE books;



SELECT title,author,(amount*price) "total" FROM book WHERE amount*price > 4000;