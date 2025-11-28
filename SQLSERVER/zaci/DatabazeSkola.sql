SELECT COUNT(*) AS pocet_zaku FROM Zaci;
--
SELECT
    t.nazev AS NazevTridy,
    COUNT(z.id) AS PocetZaku
FROM
    Zaci z
JOIN
    Tridy t ON z.trida = t.id
GROUP BY
    t.nazev
ORDER BY
    t.nazev;

--

SELECT
    p.nazev AS NazevPredmetu,
    SUM(CAST(z.znamka AS FLOAT) * z.vaha) / SUM(z.vaha) AS VazenyPrumer
FROM
    Znamky z
JOIN
    Predmety p ON z.id_predmet = p.id
WHERE
    z.absence = 0
GROUP BY
    p.nazev
ORDER BY
    p.nazev;


--
SELECT
    p.nazev AS NazevPredmetu,
    MAX(z.znamka) AS MaximalniZnamka,
    MIN(z.znamka) AS MinimalniZnamka
FROM
    Znamky z
JOIN
    Predmety p ON z.id_predmet = p.id
WHERE
    z.absence = 0
GROUP BY
    p.nazev
ORDER BY
    p.nazev;
