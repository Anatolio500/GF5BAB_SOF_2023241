# Szerveroldali fejlesztés féléves feladat

## Csapat
- Zsiros Ádám Gábor - GF5BAB
- Prokkály Dávid - CMY8C0

## A Feladat leírása
A féléves feladat témáját és funkcióit nektek kell megtervezni! Az elvárás az alábbi táblázat 
szerint minél több elem felhasználása!
A feladatot githubon kell fejleszteni és meg kell hívni rá az oenikprog usert! A repository 
elnevezése: ABC123_SOF_2022231
(ABC123 egy példa neptunkód, SOF a szerveroldali fejlesztés rövidítése, 2022231 a jelenlegi 
szemeszterkód). Több fős munka esetén a csapattagok listáját (név és neptunkód) a 
repository gyökerében egy szöveges fájlban kell elhelyezni! Ekkor a csapatvezető 
neptunkódja szerepeljen a repó nevében!

Az alkalmazást MVC minta segítségével kell elkészíteni, a feladat teljesítéséhez szükséges 
modulok: 2-6 és 9-10. Az API alapú fejlesztés (8) és Authorizáció API környezetben (9) 
modulok a „Kliensoldali fejlesztés” tantárgy szerveroldali ismereteit tartalmazzák. Majd ezen 
a ráépülő tárgyon kell API végpontot és kliensalkalmazást fejleszteni! 
Kötelező elemek, melyek nélkül a feladat nem fogadható el (összesen 50 pont)

## Az alkalmazás...

- az MVC tervezési minta segítségével készült, legalább 2 Controllert és összesen 
legalább 10 Actiont tartalmaz

- legalább SQL adatbázisra vagy valamilyen NOSQL adatbázisra épül - ✅

- legalább lokálisan tárolt felhasználó és szerepkörkezelést tartalmaz - ✅

- adatbázisában seedelt adatok találhatóak - ✅ 

- adatbázisában (az identity táblákon felül) legalább 2 táblát tartalmaz

- publikusan elérhető egy domain címen keresztül bárki számára (nem szükséges saját 
domain, azure-os is megfelelő)

- tartalmaz a template-ben biztosítotton felül valamilyen alapvető formázásokat CSSel (saját vagy library)

- validációkat tartalmaz mind kliens – mind szerveroldalon 

- a controller rétegtől elválasztott logic réteget tartalmaz (de ez egybeolvadhat a 
repository réteggel is)

- githubon készült el - ✅ 

## Bónusz

- rendelkezik API végponttal is
  
- rendelkezik API kliensalkalmazással is, amelyen valamilyen rész-adatok megjelennek 
(pl. aggregált adat, statisztika)

- az API kliensalkalmazás signalR segítségével folyamatosan frissíti a felületét
  
- tartalmaz kép kezelést (feltöltés/listázás) - ✅ 
  
- használ valamilyen SQL-től eltérő adatbázist (is) pl. cassandra, mongodb, blob 
storage, stb.

- használ email küldést a regisztrációk megerősítésére és/vagy bizonyos események 
teljesülésekor a felhasználók értesítésére

- időzített feladatot is tartalmaz Azure Functions vagy valamilyen alternatív 
megoldással (pl. crontab). pl: akciók beállítása pontban éjfélkor

- használ social login providert is a belépéshez
  
- profilkép kezelést tartalmaz, social login provider esetén letölti onnan a képet
  
- használ valamilyen külső CSS library-t (pl. bootstrap) és az oldal felépítése során 
legalább 3 különböző komponenst vett onnan igénybe

- a logic rétegben használ valamilyen tanult tervezési mintát 3p/pattern
  
- valamelyik view-ban használ önállóan írt JS kódot (pl. egy űrlapelemhez 
autocomplete szerveroldalról letöltött adatokkal)

- ModelBinderbe szervezi a modellek legyártását a form adatokból
  
- reszponzívan jelenik meg telefonról nézve
  
- logic rétegében használ valamilyen haladó algoritmust (pl. gráf, backtrack, 
optimalizáció, mohó algoritmus)

- valamilyen hosszan futó feladatot úgy old meg, hogy adatbázisban tárolja az input 
adatokat és egy worker (pl .virtuális gép, azure functions) valamikor kiszámolja az 
eredményt és visszaírja az adatbázisba

- használ valamilyen CI/CD megoldást. Pl. githubon masterre mergelve elindul egy 
folyamat (pl. github actions), amely az éles szerveren cseréli a buildet (lásd: Azure 
App Service)

- elérhető docker hubon image formájában is
  
- virtuális gépen/felhőben és azon belül docker engine-en van futtatva
  
- használ valamilyen terheléselosztást/replica setet (pl. kubernetes)



