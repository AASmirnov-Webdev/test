WITH t1 AS
  (SELECT country_code,
          avg(funding_total) AS avg_amount
   FROM company
   WHERE extract(YEAR
                 FROM founded_at) = 2011
   GROUP BY country_code),
     t2 AS
  (SELECT country_code,
          avg(funding_total) AS avg_amount
   FROM company
   WHERE extract(YEAR
                 FROM founded_at) = 2012
   GROUP BY country_code),
     t3 AS
  (SELECT country_code,
          avg(funding_total) AS avg_amount
   FROM company
   WHERE extract(YEAR
                 FROM founded_at) = 2013
   GROUP BY country_code)
SELECT t1.country_code,
       t1.avg_amount,
       t2.avg_amount,
       t3.avg_amount
FROM t1
JOIN t2 ON t1.country_code = t2.country_code
JOIN t3 ON t1.country_code = t3.country_code
ORDER BY t1.avg_amount DESC
