INSERT INTO Osoby (Jmeno, Prijmeni) VALUES
(N'Jan', N'Novák'),
(N'Petr', N'Svoboda'),
(N'Lucie', N'Dvořáková'),
(N'Karel', N'Černý'),
(N'Eva', N'Procházková'),
(N'Tomáš', N'Beneš'),
(N'Marie', N'Králová'),
(N'Josef', N'Fiala'),
(N'Anna', N'Machová'),
(N'Martin', N'Pokorný'),
(N'Barbora', N'Veselá'),
(N'David', N'Mareš'),
(N'Lenka', N'Horáková'),
(N'Filip', N'Kučera'),
(N'Adéla', N'Bláhová'),
(N'Radek', N'Kříž'),
(N'Klára', N'Sedláčková'),
(N'Roman', N'Urban'),
(N'Ivana', N'Holubová'),
(N'Ondřej', N'Růžička');

INSERT INTO Ucitele (id) VALUES (1), (2), (3), (11), (12), (13); 

INSERT INTO Tridy (id, nazev, tridni_ucitel) VALUES
(1, '1.A', 1),
(2, '2.A', 2),
(3, '3.A', 3);

INSERT INTO Zaci (id, Trida) VALUES
(4, 1),
(5, 1),
(6, 2),
(7, 2),
(8, 3),
(9, 3),
(10, 1),
(14, 2), 
(15, 3), 
(16, 1), 
(17, 2), 
(18, 3),
(19, 1),
(20, 2);

INSERT INTO Predmety (nazev, vyucujici) VALUES
('M', 1),
('ČJ', 2),
('AJ', 3),
('FY', 1),
('CH', 2),
('BIO', 11),  
('ZEM', 12), 
('D', 13),  
('INF', 11),  
('HV', 12); 

INSERT INTO Znamky (id_zak, absence, znamka, vaha, id_predmet) VALUES
(4, 0, 1, 5, 1),
(4, 0, 2, 5, 2),
(5, 0, 3, 4, 3),
(6, 0, 5, 2, 1),
(7, 1, 0, 1, 2),
(8, 0, 2, 3, 3),
(9, 0, 4, 5, 4),
(10, 0, 1, 5, 5),
(5, 0, 3, 5, 1),
(6, 0, 2, 5, 2),
(4, 0, 5, 3, 6),
(5, 0, 2, 5, 6),
(6, 1, 0, 5, 7),
(7, 0, 3, 4, 7),
(8, 0, 4, 5, 8),
(9, 0, 1, 2, 8),
(10, 0, 5, 5, 9),
(14, 0, 3, 4, 9),
(15, 1, 0, 5, 9),
(16, 0, 2, 3, 10),
(17, 0, 4, 5, 10),
(18, 1, 0, 5, 10);

INSERT INTO Tel_cisla (cislo, id_osoby) VALUES
(777111222, 1),
(602123456, 1), 
(777222333, 2),
(603654321, 2), 
(777333444, 3),
(604987654, 3), 
(777444555, 4),
(777555666, 5),
(605456789, 5), 
(777666777, 6),
(777777888, 7),
(777888999, 8),
(777999000, 9),
(606123456, 10);
