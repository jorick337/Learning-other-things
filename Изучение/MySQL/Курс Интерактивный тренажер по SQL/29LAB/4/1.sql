CREATE VIEW V1 AS 
SELECT DISTINCT providers.NumProvider AS "Номер_поставщика",
providers.FIO AS "Фамилия",providers.Rating AS "Рейтинг",
providers.City AS "Город",details.NumDetail AS "Номер_детали",
details.Name AS "Название",details.Color AS "Цвет", 
details.Weight AS "Вес" FROM supplies
JOIN details ON details.NumDetail=supplies.NumOfDetail
JOIN providers ON providers.NumProvider=supplies.NumOfProvider
ORDER BY providers.NumProvider ASC;

SELECT * FROM v1;