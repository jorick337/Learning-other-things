CREATE DATABASE books;

USE books;

CREATE TABLE book (
		book_id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
		title VARCHAR(50) NOT NULL,
		author VARCHAR(45) NOT NULL,
        price decimal(5,2),
        amount INT DEFAULT 0
);

INSERT INTO book (title,author,price,amount)
VALUES ("Мастер и Маргарита", "Булгаков М.А.", 670.99,3),
("Белая гвардия", "Булгаков М.А.", 540.50,5),
("Идиот", "Достоевский Ф.М.", 460,10),
("Братья Карамазовы", "Достоевский Ф.М.", 799.01,2),
("Стихотворения и поэмы", "Есенин С.А.", 650,15);

SELECT author, title, price FROM book;

