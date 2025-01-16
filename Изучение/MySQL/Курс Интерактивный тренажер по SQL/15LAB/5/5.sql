USE institute;

INSERT INTO students(idStudents,FIOStudent,NumGroup)
VALUE(1,'Антонов Дмитрий Леонидович','ИСП23');
INSERT INTO students(idStudents,FIOStudent,NumGroup)
VALUE(2,'Жовчак Максим Сергеевич','ИСП23');
INSERT INTO students(idStudents,FIOStudent,NumGroup)
VALUE(3,'Зеленков Артем Иванович','ИСП23');
INSERT INTO students(idStudents,FIOStudent,NumGroup)
VALUE(4,'Иванский Степан Артемович','ИСП24');
INSERT INTO students(idStudents,FIOStudent,NumGroup)
VALUE(5,'Климов Тарас Максимович','ИСП24');
INSERT INTO students(idStudents,FIOStudent,NumGroup)
VALUE(6,'Краевой Денис Сергеевич','ИСП24');
INSERT INTO students(idStudents,FIOStudent,NumGroup)
VALUE(7,'Луганский Антон Николаевич','ИСП25');

SELECT * FROM students;

INSERT INTO departments(idDepartments,TitleDepartment,PhoneDepartment)
VALUE(1,'Экономики и маркетинга','8(495)1231345');
INSERT INTO departments(idDepartments,TitleDepartment,PhoneDepartment)
VALUE(2,'Математических дисциплин','8(495)1231346');
INSERT INTO departments(idDepartments,TitleDepartment,PhoneDepartment)
VALUE(3,'Технологии машиностроения','8(495)1231347');
INSERT INTO departments(idDepartments,TitleDepartment,PhoneDepartment)
VALUE(4,'Информационных технологий ','8(495)1231348');

SELECT * FROM departments;

INSERT INTO teachers(idTeachers,FIOTeacher,StaffTeacher,Departments_idDepartments)
VALUE(1,'Тарасов Семен Николаевич','Зав. кафедрой',1);
INSERT INTO teachers(idTeachers,FIOTeacher,StaffTeacher,Departments_idDepartments)
VALUE(2,'Дорохина Александра Ивановна','Преподаватель',1);
INSERT INTO teachers(idTeachers,FIOTeacher,StaffTeacher,Departments_idDepartments)
VALUE(3,'Степанов Анатолий Петрович','Преподаватель',1);
INSERT INTO teachers(idTeachers,FIOTeacher,StaffTeacher,Departments_idDepartments)
VALUE(4,'Ильинская Наталья Ивановна','Преподаватель',1);

SELECT * FROM teachers;

INSERT INTO subjects(idSubject,TitleSubject)
VALUE(1,'Экономика отрасли');
INSERT INTO subjects(idSubject,TitleSubject)
VALUE(2,'Основы проектирования баз данных');
INSERT INTO subjects(idSubject,TitleSubject)
VALUE(3,'Стандартизация и сертификация');
INSERT INTO subjects(idSubject,TitleSubject)
VALUE(4,'Численные методы');
INSERT INTO subjects(idSubject,TitleSubject)
VALUE(5,'Компьютерные сети');
INSERT INTO subjects(idSubject,TitleSubject)
VALUE(6,'Менеджмент');
INSERT INTO subjects(idSubject,TitleSubject)
VALUE(7,'Основы предпринимательства');

SELECT * FROM subjects;

INSERT INTO sessions(NumGroup,NumSemestr,Zach_Ezam,Subjects_idSubjects,Teachers_idTeachers)
VALUE('ИСП23',1,'зачет',1,1);
INSERT INTO sessions(NumGroup,NumSemestr,Zach_Ezam,Subjects_idSubjects,Teachers_idTeachers)
VALUE('ИСП23',2,'зачет',2,2);
INSERT INTO sessions(NumGroup,NumSemestr,Zach_Ezam,Subjects_idSubjects,Teachers_idTeachers)
VALUE('ИСП23',3,'зачет',3,3);
INSERT INTO sessions(NumGroup,NumSemestr,Zach_Ezam,Subjects_idSubjects,Teachers_idTeachers)
VALUE('ИСП24',5,'зачет',4,1);
INSERT INTO sessions(NumGroup,NumSemestr,Zach_Ezam,Subjects_idSubjects,Teachers_idTeachers)
VALUE('ИСП24',6,'экзамен',5,2);
INSERT INTO sessions(NumGroup,NumSemestr,Zach_Ezam,Subjects_idSubjects,Teachers_idTeachers)
VALUE('ИСП25',7,'экзамен',6,4);

SELECT * FROM sessions;

INSERT INTO results(Balls,DateExam,Students_idStudents,idSubject,idTeacher,NumSemestr,Mark)
VALUE(66,'2022-02-20',1,1,1,1,3);
INSERT INTO results(Balls,DateExam,Students_idStudents,idSubject,idTeacher,NumSemestr,Mark)
VALUE(76,'2022-02-22',2,2,1,5,4);
INSERT INTO results(Balls,DateExam,Students_idStudents,idSubject,idTeacher,NumSemestr,Mark)
VALUE(95,'2022-02-24',3,2,1,5,5);
INSERT INTO results(Balls,DateExam,Students_idStudents,idSubject,idTeacher,NumSemestr,Mark)
VALUE(78,'2022-02-25',4,2,2,5,4);

SELECT * FROM results;

INSERT INTO marks(idMarks,LowBalls,HightBall)
VALUE(1,0,24);
INSERT INTO marks(idMarks,LowBalls,HightBall)
VALUE(2,25,59);
INSERT INTO marks(idMarks,LowBalls,HightBall)
VALUE(3,60,74);
INSERT INTO marks(idMarks,LowBalls,HightBall)
VALUE(4,75,94);
INSERT INTO marks(idMarks,LowBalls,HightBall)
VALUE(5,95,100);

SELECT * FROM marks;