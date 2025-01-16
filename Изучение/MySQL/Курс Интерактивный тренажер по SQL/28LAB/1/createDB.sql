CREATE DATABASE BD_Yurin_2024;
USE BD_Yurin_2024;

CREATE TABLE S_Spec (
		Kod_spec INT NOT NULL PRIMARY KEY,
		Name_Spec VARCHAR(50)
);

CREATE TABLE S_Kolleges (
		Kod_uz INT NOT NULL PRIMARY KEY,
		Name_Kollege VARCHAR(50)
);

CREATE TABLE Student_Yurin (
		N_stud INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
		FIO VARCHAR(50),
        D_R DATE,
        Kod_uz INT,
        Gruppa VARCHAR(50),
        Stipendiya DECIMAL(8,2),
        Kod_spec INT
);

INSERT INTO S_Spec(Kod_spec, Name_Spec)
VALUES
(3322,"Программирование"),
(8811,"Бухгалтерский учёт"),
(4466,"Менеджер"),
(7755,"Парикмахер");

INSERT INTO S_Kolleges(Kod_uz, Name_Kollege)
VALUES
(1111,"Колледж экономики и информатики"),
(2222,"Индустриальный колледж"),
(3333,"Технологический колледж");

INSERT INTO Student_Yurin(N_stud, FIO, D_R, 
Kod_uz, Gruppa, Stipendiya, Kod_spec)
VALUES
(1,"Сидоров","2000-07-23",1111,"3п1",800,3322),
(2,"Петров","2002-11-07",1111,"3п3",NULL,4466),
(3,"Григорьев","2000-01-19",2222,"3п2",800,3322),
(4,"Данилова","2001-06-11",1111,"3п2",1200,8811),
(5,"Андреев","1999-11-06",1111,"3п1",NULL,3322),
(6,"Серова","1999-02-25",2222,"3п1",NULL,3322),
(7,"Коробкова","2000-12-20",2222,"3п2",800,8811),
(8,"Смирнов","2001-07-16",3333,"3п2",800,8811),
(9,"Подгорнова","2001-09-25",3333,"3п3",1200,4466),
(10,"Лебедев","1999-07-26",2222,"3п3",800,4466),
(11,"Гришина","2000-08-09",1111,"3п1",1200,3322),
(12,"Воробьёв","2000-07-04",2222,"3п2",NULL,8811),
(13,"Лисичкин","2002-05-12",3333,"3п1",800,7755),
(14,"Сашин","1999-02-25",3333,"3п2",1200,3322),
(15,"Подоплелов","2001-06-14",2222,"3п1",800,7755);