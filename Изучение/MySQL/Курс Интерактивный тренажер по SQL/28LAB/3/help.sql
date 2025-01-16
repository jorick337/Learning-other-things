CREATE TABLE ARHIV_1(
	EntryNumber INT AUTO_INCREMENT PRIMARY KEY,
    NumStud INT,
    FIO VARCHAR(50),
    SumStipendiaAndPremia DECIMAL(8,2)
);

DELIMITER //
CREATE TRIGGER TR3 AFTER DELETE
ON student_yurin FOR EACH ROW
BEGIN
	INSERT INTO arhiv_1(NumStud,FIO,SumStipendiaAndPremia)
    VALUE(OLD.N_stud,OLD.FIO,COALESCE(OLD.PREMIYA,0)+
    COALESCE(OLD.Stipendiya,0));
END//
DELIMITER ;

INSERT INTO `bd_yurin_2024`.`student_yurin` (`N_stud`, `FIO`, `D_R`, `Kod_uz`, `Gruppa`, `Stipendiya`, `Kod_spec`, `PREMIYA`) VALUES ('5', 'Андреев', '1999-11-06', '1111', '3п1', '1200.00', '3322', '2200.00');
INSERT INTO `bd_yurin_2024`.`student_yurin` (`N_stud`, `FIO`, `D_R`, `Kod_uz`, `Gruppa`, `Kod_spec`, `PREMIYA`) VALUES ('6', 'Серова', '1999-02-25', '2222', '3п1', '3322', '500.00');