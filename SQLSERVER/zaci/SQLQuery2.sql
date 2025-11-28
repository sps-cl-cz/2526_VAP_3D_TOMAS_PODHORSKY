select jmeno, prijmeni, nazev as tridy from Zaci join Osoby on Zaci.id = Osoby.id join Tridy on zaci.trida = Tridy.id;

select jmeno, prijmeni, znamka from Zaci join Znamky on Zaci.id = Znamky.id_zak join Osoby on Zaci.id = Osoby.id where znamky.absence = 0;

select jmeno, prijmeni, nazev as trida from Osoby join Predmety on predmety.vyucujici = Osoby.id;

select distinct jmeno, prijmeni, znamka from Zaci join Znamky on Zaci.id = Znamky.id_zak join Osoby on Zaci.id = Osoby.id where znamky.absence = 0 and Znamky.id_predmet = 1;

select o.jmeno, o.prijmeni from Osoby o join Znamky z on o.id = z.id_zak join Predmety p on z.id_predmet = p.id where p.nazev = 'M';

select t.nazev, o.jmeno, o.prijmeni from Tridy t join Osoby o on t.tridni_ucitel = o.id;

select o.jmeno, o.prijmeni, z.znamka, p.nazev, vy.jmeno, vy.prijmeni
from Znamky z join Zaci za on z.id_zak = za.id join Osoby o on za.id = o.id join Predmety p on z.id_predmet = p.id join Ucitele u on p.vyucujici = u.id join Osoby vy on u.id = vy.id;
