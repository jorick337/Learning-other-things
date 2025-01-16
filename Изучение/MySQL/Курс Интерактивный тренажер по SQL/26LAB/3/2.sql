
CREATE VIEW V2_YURIN AS 
SELECT FIO, D_R, dayname(D_R) AS day_week
FROM student_yurin WHERE Gruppa="3п2";

SELECT * FROM V2_YURIN;