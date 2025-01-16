SELECT DISTINCT NumOfGood AS "Номер_изделия",goods.Name AS  "Название",
providers.NumProvider AS "Номер_поставщика",providers.FIO AS "Фамилия",
providers.Rating AS "Рейтинг",providers.City AS "Город" FROM supplies
JOIN goods ON goods.NumGood=supplies.NumOfGood 
JOIN providers ON providers.NumProvider=supplies.NumOfProvider
WHERE NumOfGood="J2"