

CREATE VIEW V1_YURIN AS 
SELECT FIO, D_R, dayname(D_R) AS day_week
FROM student_yurin;

SELECT * FROM V1_YURIN;
