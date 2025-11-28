INSERT INTO Knihy (nazev, rok_vydani, zanr) VALUES
('Pýcha a pøedsudek', 1813, N'Romantický'),
('1984', 1949, N'Dystopie'),
('Malý princ', 1943, N'Dìtská literatura'),
('Hobit', 1937, N'Fantasy'),
('Harry Potter a Kámen mudrcù', 1997, N'Fantasy'),
('Rok 1984', 1948, N'Dystopie'),
('Paní Bovaryová', 1856, N'Romantický'),
('Na západní frontì klid', 1929, N'Váleèný'),
('Sto rokù samoty', 1967, N'Magický realismus'),
('Velký Gatsby', 1925, N'Romantický');
GO
INSERT INTO Autori (jmeno, prijmeni) VALUES
(N'Jane', N'Austen'),
(N'George', N'Orwell'),
(N'Antoine', N'De Saint-Exupéry'),
(N'J.R.R.', N'Tolkien'),
(N'J.K.', N'Rowling'),
(N'Gustave', N'Flaubert'),
(N'Erich', N'Maria Remarque'),
(N'Gabriel', N'García Márquez'),
(N'F. Scott', N'Fitzgerald'),
(N'Leo', N'Tolstoy');
GO
INSERT INTO Recenzenti (uzivatelske_jmeno, email) VALUES
(N'alice', N'alice@email.com'),
(N'bob', N'bob@email.com'),
(N'carol', N'carol@email.com'),
(N'dave', N'dave@email.com'),
(N'eve', N'eve@email.com'),
(N'frank', N'frank@email.com'),
(N'grace', N'grace@email.com'),
(N'heidi', N'heidi@email.com'),
(N'ivan', N'ivan@email.com'),
(N'judy', N'judy@email.com');
GO
INSERT INTO Recenze (id_recenzent, id_knihy, datum, hodnoceni) VALUES
(1, 1, '2025-01-01', 9),
(2, 2, '2025-01-02', 8),
(3, 3, '2025-01-03', 10),
(4, 4, '2025-01-04', 7),
(5, 5, '2025-01-05', 9),
(6, 6, '2025-01-06', 8),
(7, 7, '2025-01-07', 7),
(8, 8, '2025-01-08', 9),
(9, 9, '2025-01-09', 10),
(10, 10, '2025-01-10', 8);
GO
INSERT INTO Autori_knih (id_kniha, id_autor) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 2),
(7, 6),
(8, 7),
(9, 8),
(10, 9),
(5, 4),
(3, 2),
(1, 10);

