CREATE DATABASE new_books;
USE new_books;

CREATE TABLE supply (
		supply_id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
		title VARCHAR(50) NOT NULL,
		author VARCHAR(45) NOT NULL,
        price decimal(5,2),
        amount INT DEFAULT 0,
        buy INT DEFAULT 0
);

INSERT INTO supply (title,author,price,amount,buy)
VALUES ("Лирика", "Пастернак Б.Л.", 518.99,2,1),
("Черный человек", "Есенин С.А.", 570.20,6,2),
("Белая гвардия", "Булгаков М.А.", 540.50,7,3),
("Идиот", "Достоевский Ф.М.",460.00,3,1),
("Собачье сердце", "Булгаков М.А", 550.45,10,1),
("Анна Каренина", "Толстой Л.Н.", 480.90,9,10);

SELECT * FROM supply;