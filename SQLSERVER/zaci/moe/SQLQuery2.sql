CREATE TABLE [Knihy] (
	[id] INTEGER NOT NULL IDENTITY,
	[nazev] NVARCHAR(100) NOT NULL,
	[rok_vydani] INTEGER NOT NULL,
	[zanr] NVARCHAR(50) NOT NULL,
	PRIMARY KEY([id])
);
GO

CREATE TABLE [Recenze] (
	[id] INTEGER NOT NULL IDENTITY,
	[id_recenzent] INTEGER,
	[id_knihy] INTEGER NOT NULL,
	[datum] DATE NOT NULL DEFAULT getdate(),
	[hodnoceni] INTEGER NOT NULL CHECK(hodnoceni >= 0 and hodnoceni <= 10),
	PRIMARY KEY([id])
);
GO

CREATE INDEX [Recenze_index_0]
ON [Recenze] ([id_recenzent]);
GO

CREATE INDEX [Recenze_index_1]
ON [Recenze] ([id_knihy]);
GO

CREATE TABLE [Autori] (
	[id] INTEGER NOT NULL IDENTITY,
	[jmeno] NVARCHAR(100) NOT NULL,
	[prijmeni] NVARCHAR(100) NOT NULL,
	PRIMARY KEY([id])
);
GO

CREATE TABLE [Recenzenti] (
	[id] INTEGER NOT NULL IDENTITY,
	[uzivatelske_jmeno] NVARCHAR(100) NOT NULL,
	[email] NVARCHAR(100) NOT NULL,
	PRIMARY KEY([id])
);
GO

CREATE TABLE [Autori_knih] (
	[id_kniha] INTEGER NOT NULL,
	[id_autor] INTEGER NOT NULL,
	PRIMARY KEY([id_kniha], [id_autor])
);
GO

CREATE INDEX [Autori_knih_index_0]
ON [Autori_knih] ([id_autor]);
GO


ALTER TABLE [Recenze]
ADD FOREIGN KEY([id_knihy])
REFERENCES [Knihy]([id])
ON UPDATE CASCADE ON DELETE CASCADE;
GO
ALTER TABLE [Autori_knih]
ADD FOREIGN KEY([id_kniha])
REFERENCES [Knihy]([id])
ON UPDATE CASCADE ON DELETE CASCADE;
GO
ALTER TABLE [Autori_knih]
ADD FOREIGN KEY([id_autor])
REFERENCES [Autori]([id])
ON UPDATE CASCADE ON DELETE CASCADE;
GO
ALTER TABLE [Recenze]
ADD FOREIGN KEY([id_recenzent])
REFERENCES [Recenzenti]([id])
ON UPDATE CASCADE ON DELETE SET NULL;
GO