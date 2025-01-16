SELECT DISTINCT NumOfGood AS "Номер_изделия",
goods.Name AS  "Название",
providers.NumProvider AS "Номер_поставщика" 
FROM supplies
JOIN goods ON goods.NumGood=supplies.NumOfGood 
JOIN providers ON providers.NumProvider=supplies.NumOfProvider
ORDER BY supplies.NumOfGood ASC;


