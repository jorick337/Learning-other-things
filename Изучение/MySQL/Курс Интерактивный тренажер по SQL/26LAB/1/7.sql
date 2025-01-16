CREATE TABLE Student_Yurin (
		N_stud INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
		FIO VARCHAR(50),
        D_R DATE,
        Kod_uz INT,
        Gruppa VARCHAR(50),
        Stipendiya DECIMAL(8,2),
        Kod_spec INT NOT NULL PRIMARY KEY,
        Ind_Kod_spec INT,
        Ind_Kod_uz INT
);