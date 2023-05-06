"Verseny" vizsgamunka

Az alkalmazás elindítása:

Adatbázis:
- Indítsuk el az adatbázis szervert (pl XAMPP)
- Hozzunk létre egy adatbázist "verseny" néven

Backend service-ek (API):
- Navigáljunk a verseny-api mappába
- Hozzuk létre a szükséges táblákat: php artisan migrate:fresh
- Szükség esetén töltsük be a tesztadatokat a TestAdat.sql fájlból
- Indítsuk el az API-kat: php artisan serve

Webalkalmazás (Diákoknak):
- Navigáljunk a verseny-api mappába
- Szükség esetén telepítsük a szükséges package-eket: npm install
- Indítsuk el a webalkalmazást: npm start

Desktop alkalmazás (Tanároknak):
TBA