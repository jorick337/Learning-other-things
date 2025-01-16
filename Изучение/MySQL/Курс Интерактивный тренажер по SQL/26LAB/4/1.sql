
UPDATE fine
SET sum_fine=sum_fine/2
WHERE DATEDIFF(date_payment+1,date_violation)<20;
SELECT * FROM fine;

