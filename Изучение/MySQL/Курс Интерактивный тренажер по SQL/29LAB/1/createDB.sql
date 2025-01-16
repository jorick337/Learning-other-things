CREATE DATABASE BD_NEW_YURIN;
USE BD_NEW_YURIN;

CREATE TABLE Providers (
		NumProvider VARCHAR(50) PRIMARY KEY NOT NULL,
		FIO VARCHAR(50),
        Rating INT,
        City VARCHAR(30)
);

CREATE TABLE Details (
		NumDetail VARCHAR(50) PRIMARY KEY,
		Name VARCHAR(50),
        Color ENUM("Красный","Голубой","Зеленый"),
        Weight INT,
        City VARCHAR(30)
);

CREATE TABLE Goods (
		NumGood VARCHAR(50) PRIMARY KEY,
		Name VARCHAR(50),
        City VARCHAR(30)
);

CREATE TABLE Supplies (
		NumOfProvider VARCHAR(50) NOT NULL,
		NumOfDetail VARCHAR(50) NOT NULL,
        NumOfGood VARCHAR(50) NOT NULL,
		FOREIGN KEY(NumOfProvider)  REFERENCES Providers(NumProvider),
        FOREIGN KEY(NumOfDetail)  REFERENCES Details(NumDetail),
        FOREIGN KEY(NumOfGood)  REFERENCES Goods(NumGood),
        Amount INT
);

INSERT INTO Providers(NumProvider,FIO,Rating,City)
VALUES
("S1","Смит",20,"Лондон"),
("S2","Джонс",10,"Париж"),
("S3","Блейк",30,"Париж"),
("S4","Кларк",20,"Лондон"),
("S5","Адамс",30,"Афины");

INSERT INTO Details(NumDetail,Name,Color,Weight,City)
VALUES
("P1","Гайка","Красный",12,"Лондон"),
("P2","Болт","Зеленый",17,"Париж"),
("P3","Винт","Голубой",17,"Рим"),
("P4","Винт","Красный",14,"Лондон"),
("P5","Кулачок","Голубой",12,"Париж"),
("P6","Блюм","Красный",19,"Лондон");

INSERT INTO Goods(NumGood,Name,City)
VALUES
("J1","Жесткий диск","Париж"),
("J2","Перфоратор","Рим"),
("J3","Считыватеь","Афины"),
("J4","Принтер","Афины"),
("J5","Флоппи-диск","Лондон"),
("J6","Терминал","Осло"),
("J7","Лента","Лондон");

INSERT INTO Supplies(NumOfProvider,NumOfDetail,NumOfGood,Amount)
VALUES
("S1","P1","J1",200),
("S1","P1","J4",700),
("S2","P3","J1",400),
("S2","P3","J2",200),
("S2","P3","J3",200),
("S2","P3","J4",500),
("S2","P3","J5",600),
("S2","P3","J6",400),
("S2","P3","J7",800),
("S2","P5","J2",100),
("S3","P3","J1",200),
("S3","P4","J2",500),
("S4","P6","J3",300),
("S4","P6","J7",300),
("S5","P2","J2",200),
("S5","P2","J4",100),
("S5","P5","J5",500),
("S5","P5","J7",100),
("S5","P6","J2",200),
("S5","P1","J4",100),
("S5","P3","J4",200),
("S5","P4","J4",800),
("S5","P5","J4",400),
("S5","P6","J4",500);