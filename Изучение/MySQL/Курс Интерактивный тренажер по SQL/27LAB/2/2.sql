DELIMITER //
CREATE PROCEDURE PR4_YURIN(IN N VARCHAR(50))
BEGIN
	SELECT Round(SUM(Stipendiya)) 
    AS "Суммарная_стипендия_группы" 
    FROM student_yurin WHERE Gruppa=N;
END //
DELIMITER ;

CALL PR4_YURIN("3п3");