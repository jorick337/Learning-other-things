USE office;

INSERT INTO k_firm (firm_name, firm_addr)
VALUES('Альфа', 'Москва');
INSERT INTO k_firm (firm_name, firm_addr)
VALUES('Бета', 'Казань');
INSERT INTO k_firm (firm_name, firm_addr)
VALUES('Гамма', 'Париж');
INSERT INTO k_firm (firm_name, firm_addr)
VALUES('Дельта', 'Лондон');
INSERT INTO k_firm (firm_name, firm_addr)
VALUES('Омега', 'Токио');

SELECT * FROM k_firm;

INSERT INTO k_dept (dept_short_name, dept_full_name)
VALUES('Sales', 'Отдел продаж');
INSERT INTO k_dept (dept_short_name, dept_full_name)
VALUES('Mart', 'Отдел маркетинга');
INSERT INTO k_dept (dept_short_name, dept_full_name)
VALUES('Cust', 'Отдел гарантийного обслуживания');

SELECT * FROM k_dept;

INSERT INTO k_staff (staff_name, K_dept_dept_num, staff_hiredate, staff_post)
VALUES('Иванов', 1, '1999-01-01', 'Менеджер');
INSERT INTO k_staff (staff_name, K_dept_dept_num, staff_hiredate, staff_post)
VALUES('Петров', 2, '2010-10-13', 'Менеджер');
INSERT INTO k_staff (staff_name, K_dept_dept_num, staff_hiredate, staff_post)
VALUES('Сидоров', 3, '2005-12-01', 'Менеджер');
INSERT INTO k_staff (staff_name, K_dept_dept_num, staff_hiredate, staff_post)
VALUES('Семенов', 1, '1990-01-01', 'Директор');
INSERT INTO k_staff (staff_name, K_dept_dept_num, staff_hiredate, staff_post)
VALUES('Григорьев', 3, '2008-12-19', 'Программист');
SELECT * FROM k_staff;

INSERT INTO k_contract (contract_type, k_firm_firm_num, k_staff_staff_num, contract_date) 
VALUES('A', 1, 1,'2011-11-01');
INSERT INTO k_contract (contract_type, k_firm_firm_num, k_staff_staff_num, contract_date) 
VALUES('B', 1, 2,'2011-10-01');
INSERT INTO k_contract (contract_type, k_firm_firm_num, k_staff_staff_num, contract_date) 
VALUES('C', 1, 1,'2011-09-01');
INSERT INTO k_contract (contract_type, k_firm_firm_num, k_staff_staff_num, contract_date) 
VALUES('A', 2, 2,'2011-11-15');
INSERT INTO k_contract (contract_type, k_firm_firm_num, k_staff_staff_num, contract_date) 
VALUES('B', 2, 2,'2011-08-01');
INSERT INTO k_contract (contract_type, k_firm_firm_num, k_staff_staff_num, contract_date) 
VALUES('C', 3, 1,'2011-07-15');
INSERT INTO k_contract (contract_type, k_firm_firm_num, k_staff_staff_num, contract_date) 
VALUES('A', 4, 1,'2011-11-12');

SELECT * FROM k_contract;
