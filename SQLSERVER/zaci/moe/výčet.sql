select k.nazev, r.hodnoceni from Knihy k join Recenze r on k.id = r.id_knihy;
select k.nazev, a.jmeno, a.prijmeni from Knihy k join Autori_knih ak on k.id = ak.id_kniha join Autori a on ak.id_autor = a.id;
select r.hodnoceni from Recenze r join Autori_knih ak on r.id_knihy = ak.id_kniha where ak.id_autor = 3;
select rec.uzivatelske_jmeno, k.nazev, r.hodnoceni from Recenze r join Recenzenti rec on r.id_recenzent = rec.id join Knihy k on r.id_knihy = k.id;




