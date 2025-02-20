# Dotnet - entity framework core - API
Repot innehåller en Api med Crud skapad i Dotnet entity framework core. Backend-lösningen ansluter till en Sqlite-databas.

## Uppgiftens grundkrav
Skapa ett API med ASP.net Core som hanterar en låtlista (en uppsättning med musik) med musik. Denna låtlista ska innehålla följande data:

* Artist
* Låt-titel
* Spel-längd (i sekunder)
* Kategori/Kategorier (exempelvis "rock", "pop", "trance", "dragspel")

För godkänt genomförande av laboration ska ni i ert API visa på följande:

* Att ni skapat ett API i ASP.net Core med CRUD.
* Att det går att lägga till, läsa ut, radera och uppdatera data i låtlistan via exempelvis Postman, Advanced REST-client eller liknande program. (Ni behöver ej skapa en applikation som konsumerar API'et).
* Data för låtlistan lagras i valfri databas-server (ej In Memory DB).

## Uppgiftkrav för överbetyg
* API'et ska inte vara ett minimalt API, utan använda controller.
* Databasen i din lösning ska innehålla minst två stycken tabeller - Du väljer själv hur du vill struktrera ditt data, om du till exempel vill göra kategorier i egen tabell, göra olika skivor som tillhör en artist eller kanske göra kommentarer/recension till respektive album? .
* Returnerat data skall erbjuda god kvalitet och struktur. Undvik att returnera enbart id för data i relationer, utan försök att returnera hela objektet.

## Min Lösning
Mitt Api innehåller tre modeller/tabeller. Tabell för artister, sånger samt album. Dessa har relationer till varandra. ArtistId från tabellen artist används som FK i de andra två tabellerna. AlbumId från tabellen album används som FK i song-tabellen. Song-tabellen har en navigeringsegenskap i vid utläsning av data för att lista relaterade albums id samt artist-objekt. Även Album-tabellen använder navigeringsegenskaper för att läsa ut artist-objekt samt lista alla relaterade song-objekt.

### Dto
Data transfer object är skapade för att styra vilka värden som behövs vid sparande av nya rader i tabellerna. Dto's är även skapade för put-anrop. En förbättring av visningsdatan hade kunnat göras om även Dto fanns för returdata.

### POST
Inga konstigheter.

### PUT
Putanrop kräver endast att de värden som ska ändras skickas med och inte hela objekt.

### GET
Vid Get-anrop skickas hela relaterade artist-objekt alltid med. Vid Get-anrop till album skickas alla relaterade låtar med. Vid Get-anrop till Song skickas albumId samt artist-objekt med. En förbättring här hade kunnat varit fler routes för att skicka med relaterad data med annan struktur.

### DELETE
Vid delete av artist så skickas ett returmeddelande om den fortfarande är FK i annan tabell.


### Tabeller

```bash
CREATE TABLE "Artists" (
    "ArtistId" INTEGER NOT NULL CONSTRAINT "PK_Artists" PRIMARY KEY AUTOINCREMENT,
    "ArtistName" TEXT NOT NULL
)
```

```bash
CREATE TABLE "Songs" (
	"SongId"	INTEGER NOT NULL,
	"Title"	TEXT NOT NULL,
	"Length"	INTEGER NOT NULL,
	"Category"	TEXT,
	"ArtistId"	INTEGER NOT NULL,
	"AlbumId"	INTEGER,
	CONSTRAINT "PK_Songs" PRIMARY KEY("SongId" AUTOINCREMENT),
	CONSTRAINT "FK_Songs_Albums_AlbumId" FOREIGN KEY("AlbumId") REFERENCES "Albums"("AlbumId"),
	CONSTRAINT "FK_Songs_Artists_ArtistId" FOREIGN KEY("ArtistId") REFERENCES "Artists"("ArtistId") ON DELETE CASCADE
)
```

```bash
CREATE TABLE "Albums" (
    "AlbumId" INTEGER NOT NULL CONSTRAINT "PK_Albums" PRIMARY KEY AUTOINCREMENT,
    "AlbumName" TEXT NOT NULL,
    "ReleaseYear" TEXT NOT NULL,
    "ArtistId" INTEGER NOT NULL,
    CONSTRAINT "FK_Albums_Artists_ArtistId" FOREIGN KEY ("ArtistId") REFERENCES "Artists" ("ArtistId") ON DELETE CASCADE
)
```

### Routes

#### Artist
Krav vid post för artist är endast att artistnamn skickas med i JSON-format.

|Metod  |Ändpunkt           |Beskrivning                                                                 |
|-------|-------------------|----------------------------------------------------------------------------|
|GET    |/api/artist        |Hämtar alla lagrade artister.                                               |
|GET    |/api/artist/:ID    |Hämtar en specifik artist med angivet ID.                                   |
|POST   |/api/artist/       |Lagrar en ny artist.                                                        |
|PUT    |/api/artist/:ID    |Uppdaterar en artist med angivet ID. Skicka med artistnamn samt id.         |
|DELETE |/api/artist/:ID    |Raderar en artist med angivet ID.                                           |

#### Song
Krav vid post för song är att artistId samt titel skickas med i JSON-format.

|Metod  |Ändpunkt           |Beskrivning                                                                 |
|-------|-------------------|----------------------------------------------------------------------------|
|GET    |/api/song          |Hämtar alla lagrade sånger med relaterade artister samt albumId             |
|GET    |/api/song/:ID      |Hämtar en specifik sång med angivet ID.                                     |
|POST   |/api/song/         |Lagrar en ny sång.                                                          |
|PUT    |/api/song/:ID      |Uppdaterar en sång med angivet ID. Skicka med de parametrar du vill ändra.  |
|DELETE |/api/song/:ID      |Raderar en sång med angivet ID.                                             |

#### Album
Krav vid post för album är att artistId samt albumname skickas med i JSON-format.

|Metod  |Ändpunkt           |Beskrivning                                                                 |
|-------|-------------------|----------------------------------------------------------------------------|
|GET    |/api/album         |Hämtar alla lagrade album med relaterade song och artister.                 |
|GET    |/api/album/:ID     |Hämtar ett specifikt album med angivet ID.                                  |
|POST   |/api/album/        |Lagrar ett nytt album.                                                      |
|PUT    |/api/album/:ID     |Uppdaterar ett album med angivet ID. Skicka med de parametrar du vill ändra.|
|DELETE |/api/album/:ID     |Raderar ett album med angivet ID.                                           |
 


### Skapad av MARKUS VICKMAN (MAVI2302) 