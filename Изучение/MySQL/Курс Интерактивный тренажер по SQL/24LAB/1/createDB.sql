CREATE DATABASE library;
USE library;

CREATE TABLE author (
		author_id INTEGER AUTO_INCREMENT PRIMARY KEY,
		name_author VARCHAR(50)
);

CREATE TABLE genre (
		genre_id INTEGER AUTO_INCREMENT PRIMARY KEY,
		name_genre VARCHAR(50)
);

CREATE TABLE book (
		book_id INTEGER AUTO_INCREMENT PRIMARY KEY,
		title VARCHAR(50),
        author_id INT,
        genre_id INT,
        price DECIMAL(8,2),
        amount INT,
        FOREIGN KEY(author_id)  REFERENCES author(author_id),
        FOREIGN KEY(genre_id)  REFERENCES genre(genre_id)
);

INSERT INTO author(name_author)
VALUES
("Булгаков М.А."),
("Достоевский Ф.М."),
("Есенин С.А."),
("Пастернак Б.Л."),
("Лермонтов М.Ю.");

INSERT INTO genre(name_genre)
VALUES
("Роман"),
("Поэзия"),
("Приключения");

INSERT INTO book(title,author_id,genre_id,price,amount)
VALUES
("Мастер и Маргарита",1,1,670.99,3),
("Белая Гвардия",1,1,540.50,5),
("Идиот",2,1,460.00,10),
("Братья Карамазовы",2,1,799.01,3),
("Игрок",2,1,480.50,10),
("Стихотворения и поэмы",3,2,650.00,15),
("Черный человек",3,2,570.20,6),
("Лирика",4,2,518.99,2);