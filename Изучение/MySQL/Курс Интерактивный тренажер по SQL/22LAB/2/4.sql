

SELECT * FROM trip
WHERE date_first=(SELECT MIN(date_first) FROM trip)
LIMIT 1;