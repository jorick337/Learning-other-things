CREATE TABLE traffic_violation (
		violation_id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
        violation VARCHAR(45) NOT NULL,
        sum_fine INT DEFAULT 0
);

INSERT INTO traffic_violation(violation,sum_fine)
VALUES ("Превышение скорости(от 20 до 40)",500.00),
("Превышение скорости(от 40 до 60)",1000.00),
("Проезд на запрещающий сигнал",1000.00);

SELECT * FROM traffic_violation;