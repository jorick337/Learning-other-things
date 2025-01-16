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


INSERT INTO k_bill (bill_date,bill_sum,bill_term, bill_peni, k_contract_contract_num) 
VALUES('2011-11-12', 1000, '2011-12-12', null,1);
INSERT INTO k_bill (bill_date,bill_sum,bill_term, bill_peni, k_contract_contract_num) 
VALUES('2011-12-12', 2000, '2012-01-12', null,1);
INSERT INTO k_bill (bill_date,bill_sum,bill_term, bill_peni, k_contract_contract_num) 
VALUES('2012-01-12', 2000, '2012-02-12', null,1);
INSERT INTO k_bill (bill_date,bill_sum,bill_term, bill_peni, k_contract_contract_num) 
VALUES('2011-12-12', 6000, '2012-01-12', null,2);
INSERT INTO k_bill (bill_date,bill_sum,bill_term, bill_peni, k_contract_contract_num) 
VALUES('2012-01-12', 2000, '2012-02-12', null,2);
INSERT INTO k_bill (bill_date,bill_sum,bill_term, bill_peni, k_contract_contract_num) 
VALUES('2012-01-12', 2500, '2012-02-12', null,3);
INSERT INTO k_bill (bill_date,bill_sum,bill_term, bill_peni, k_contract_contract_num) 
VALUES('2011-12-12', 1500, '2012-01-12', null,4);
INSERT INTO k_bill (bill_date,bill_sum,bill_term, bill_peni, k_contract_contract_num) 
VALUES('2011-12-12', 1200, '2012-01-12', null,5);
INSERT INTO k_bill (bill_date,bill_sum,bill_term, bill_peni, k_contract_contract_num) 
VALUES('2012-01-12', 10000, '2012-02-12', null,5);

SELECT * FROM k_bill;

INSERT INTO k_payment (payment_num,payment_date,payment_sum,k_bill_bill_num)
VALUES(1,'2011-12-15',1000,2);
INSERT INTO k_payment (payment_num,payment_date,payment_sum,k_bill_bill_num)
VALUES(1,'2012-01-13',1500,3);
INSERT INTO k_payment (payment_num,payment_date,payment_sum,k_bill_bill_num)
VALUES(1,'2012-01-12',1000,4);
INSERT INTO k_payment (payment_num,payment_date,payment_sum,k_bill_bill_num)
VALUES(1,'2012-01-05',100,7);
INSERT INTO k_payment (payment_num,payment_date,payment_sum,k_bill_bill_num)
VALUES(1,'2011-12-25',1000,8);
INSERT INTO k_payment (payment_num,payment_date,payment_sum,k_bill_bill_num)
VALUES(2,'2012-01-15',500,3);
INSERT INTO k_payment (payment_num,payment_date,payment_sum,k_bill_bill_num)
VALUES(2,'2012-01-12',900,7);

SELECT * FROM k_payment;

INSERT INTO k_price (price_num,price_name,price_sum,price_type)
VALUES(1,'Материализация духов',1000,'У');
INSERT INTO k_price (price_num,price_name,price_sum,price_type)
VALUES(2,'Раздача слонов',100,'У');
INSERT INTO k_price (price_num,price_name,price_sum,price_type)
VALUES(3,'Слоновий бивень',3000,'Т');
INSERT INTO k_price (price_num,price_name,price_sum,price_type)
VALUES(4,'Моржовый клык',1500,'Т');
INSERT INTO k_price (price_num,price_name,price_sum,price_type)
VALUES(5,'Копыто Пегаса',5000,'Т');

SELECT * FROM k_price;

INSERT INTO k_protokol (kolko,price_sum,k_price_price_num,k_bill_bill_num)
VALUES(1,1000,1,1);
INSERT INTO k_protokol (kolko,price_sum,k_price_price_num,k_bill_bill_num)
VALUES(2,1000,1,2);
INSERT INTO k_protokol (kolko,price_sum,k_price_price_num,k_bill_bill_num)
VALUES(1,1000,1,5);
INSERT INTO k_protokol (kolko,price_sum,k_price_price_num,k_bill_bill_num)
VALUES(2,1000,1,6);
INSERT INTO k_protokol (kolko,price_sum,k_price_price_num,k_bill_bill_num)
VALUES(1,1000,1,8);
INSERT INTO k_protokol (kolko,price_sum,k_price_price_num,k_bill_bill_num)
VALUES(20,100,2,3);
INSERT INTO k_protokol (kolko,price_sum,k_price_price_num,k_bill_bill_num)
VALUES(10,100,2,5);
INSERT INTO k_protokol (kolko,price_sum,k_price_price_num,k_bill_bill_num)
VALUES(5,100,2,6);
INSERT INTO k_protokol (kolko,price_sum,k_price_price_num,k_bill_bill_num)
VALUES(2,100,2,8);
INSERT INTO k_protokol (kolko,price_sum,k_price_price_num,k_bill_bill_num)
VALUES(2,3000,3,4);
INSERT INTO k_protokol (kolko,price_sum,k_price_price_num,k_bill_bill_num)
VALUES(1,1500,4,7);
INSERT INTO k_protokol (kolko,price_sum,k_price_price_num,k_bill_bill_num)
VALUES(2,5000,5,9);

SELECT * FROM k_protokol;


