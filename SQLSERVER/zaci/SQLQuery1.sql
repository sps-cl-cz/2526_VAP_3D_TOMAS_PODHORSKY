SELECT * FROM  (SELECT
    TOP 1
    Predmety.nazev,
    Osoby.jmeno,
    Osoby.prijmeni,
    Znamky.znamka,
    Znamky.vaha
FROM
    Predmety
JOIN
    Znamky ON Znamky.id_predmet = Predmety.id
JOIN
    Osoby ON Osoby.id = Znamky.id_zak
WHERE
    Znamky.absence = 0
ORDER BY
    Znamky.znamka DESC,
    Znamky.vaha DESC) as min_znamka

UNION

SELECT * FROM  (SELECT
    TOP 1
    Predmety.nazev,
    Osoby.jmeno,
    Osoby.prijmeni,
    Znamky.znamka,
    Znamky.vaha
FROM
    Predmety
JOIN
    Znamky ON Znamky.id_predmet = Predmety.id
JOIN
    Osoby ON Osoby.id = Znamky.id_zak
WHERE
    Znamky.absence = 0
ORDER BY
    Znamky.znamka ASC,
    Znamky.vaha DESC) as MAX_znamka

----------------------------------------------------------

SELECT
    o.jmeno,
    o.prijmeni,
    SUM(CAST(z.absence AS INT)) AS pocet_absenci
FROM
    Osoby o
JOIN
    Znamky z ON o.id = z.id_zak
GROUP BY
    o.jmeno,
    o.prijmeni
HAVING SUM(CAST(z.absence AS INT)) > 0;

---------------------------------------------------------

SELECT
    o.jmeno,
    o.prijmeni,
    COUNT(p.id) AS pocet_predmetu
FROM
    Osoby o
JOIN
    Predmety p ON p.id_ucitele = o.id
GROUP BY
    o.jmeno,
    o.prijmeni
ORDER BY
    pocet_predmetu DESC;




