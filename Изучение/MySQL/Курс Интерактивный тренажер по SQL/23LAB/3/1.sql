

UPDATE fine,traffic_violation
SET fine.sum_fine=traffic_violation.sum_fine
WHERE fine.sum_fine iS NULL;SELECT * FROM fine;