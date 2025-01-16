

SELECT name,city,date_first,date_last FROM trip
WHERE (date_last-date_first+1)=
(SELECT MIN(date_last-date_first+1) FROM trip);