DELIMITER //
CREATE FUNCTION Funct3(G VARCHAR(50))
RETURNS INT
DETERMINISTIC
BEGIN
	RETURN (SELECT SUM(Stipendiya) FROM student_yurin 
    WHERE Gruppa=G);
END //
DELIMITER ;

SELECT Funct3("3п1");