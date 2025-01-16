CREATE DATABASE books;
USE books;

CREATE TABLE book (
		book_id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
		title VARCHAR(50) NOT NULL,
		author VARCHAR(45) NOT NULL,
        price decimal(5,2),
        amount INT DEFAULT 0,
        buy INT DEFAULT 0
);

INSERT INTO book (title,author,price,amount,buy)
VALUES ("Мастер и Маргарита", "Булгаков М.А.", 670.99,3,0),
("Белая гвардия", "Булгаков М.А.", 540.50,5,3),
("Идиот", "Достоевский Ф.М.", 460,10,8),
("Братья Карамазовы", "Достоевский Ф.М.", 799.01,2,0),
("Стихотворения и поэмы", "Есенин С.А.", 650,15,10);

SELECT * FROM book;
