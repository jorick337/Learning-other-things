CREATE DATABASE fines;
USE fines;

CREATE TABLE fine (
		fine_id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
		name VARCHAR(50) NOT NULL,
		number_plate VARCHAR(45) NOT NULL,
        violation VARCHAR(45) NOT NULL,
        sum_fine INT DEFAULT 0,
        date_violation DATE,
        date_payment DATE
);

INSERT INTO fine(name,number_plate,violation,sum_fine,
date_violation,date_payment)
VALUES ("Баранов П.Е.","Р523ВТ","Превышение скорости
(от 40 до 60)",500.00,"2020-01-12","2020-01-17"),
("Абрамова К.А.","О111АВ","Проезд на
запрещающий сигнал",1000.00,"2020-01-14","2020-02-27"),
("Яковлев Г.Р.","Т330ТТ","Превышение скорости
(от 20 до 40)",500.00,"2020-01-23","2020-02-23"),
("Яковлев Г.Р.","Т330ТТ","Превышение скорости
(от 20 до 40)",NULL,"2020-02-12",NULL),
("Колесов С.П.","К892АХ","Превышение скорости
(от 20 до 40)",NULL,"2020-02-21",NULL);

SELECT * FROM fine;
