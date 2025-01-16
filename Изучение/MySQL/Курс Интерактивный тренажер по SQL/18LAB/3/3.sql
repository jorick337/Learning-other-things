

SELECT author, COUNT(title) "Различные_книги", 
SUM(amount) "Количество_экземпляров" FROM book
GROUP BY author;