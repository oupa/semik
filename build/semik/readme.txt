ČSAV Šemík
-------------------

Instalace:
Aktuální verze ke stažení vždy na adrese http://www.csavirtual.cz/upload/semik/aktualni/semik.zip
Šemík nemá instalátor a možná nikdy mít nebude, pro naše účely to není to nejnutnější.
Stačí rozbalit zip do adresáře podle vaší potřeby. V systémech Windows Vista a 7 je nutné, aby přihlášený uživatel měl do tohoto adresáře vždy práva zápisu.

Šemík potřebuje k běhu 3 věci:
* Knihovnu FSUIPC. Tu zřejmě máte pokud používáte FSACARS. Neuškodí update ze stránek http://schiratti.com/dowson.html. Registrovaná verze není zapotřebí.
* Pro X-Plane namísto FSUIPC použijte XPUIPC, kterou najdete na adrese www.tosi-online.de
* Framework .NET 4.5 od Microsoftu. Opět zřejmě máte, např. pokud používáte třeba Vroute a máte zaplé aktualizace ve Windows. V případě pochybností http://www.microsoft.com/NET/ a Download.
* Internetové připojení od spuštění Šemíka po ukončení letu.

Testování a reporting:
-----------------------
Testujte normální lety jako obyčejně, jak jste zvyklí létat.
Reportuje e-mailem na oupicky@gmail.com, v předmětu uveďte "semik testing".
Přiložte semik.log, případně výpis z letu (adresář logs a poslední soubor).

Známé chyby:
-------------
1) nefunkční zvuk, reportováno 1x
2) nefunkční detekce okna pro ČSAV TV, reportování 1x
3) nefunkční funkce "New flight tracking" po dokončení letu. Pro nový let vypněte a zapněte Šemíka. 

------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------
                                                                                                   
Spuštění:
-----------------------
Doporučený postup je nejdříve spustis FSku, nahrát let a pak spustit Šemíka.
Šemíka spustťe csav_semik.exe (jiný exe soubor tam není).
Pokud spouštíte ve Windows Vista nebo 7 FSku jako administrátor, je potřeba totéž provést i u Šemíka. V opačném případě to není zapotřebí.

Popis funkcí:
-------------
* Login
-------------- 
** Zalogujte se údaji jako na webu, doporučuji zakliknout, aby si vás pamatoval. (pozn. heslo se nikam neukládá)
** Po loginu pokud je úspěšný se dostanete na stránku s vyplnění letového plánu. 
 
* Nastavení
--------------
** Před vyplnění FPL se podívejte do Nastavení. Jednotlivé položky ovládají zvuky v Šemíkovi, integrovanou ČSAV TV a další volby.
** Z nich je důležitá volba "FDR Imaging", která povolí záznam screenshotu na FDR souboru. 
** Nastavení pro FDR imaging se bere z ČSAV TV.
** Tuto volbu máte možnost vypnout pokud se obáváte o své soukromí, nicméně po ověření funkčnosti ČSAV TV (hlavně toho, že zaznamená pouze FSku a ne váš Internet Banking) doporučuji zapnout. Jde totiž o ověření, za jakých okolností k incidentu došlo.

* Flight Plan
---------------
** Vyplníte flight plan podobně jako v FSACARS. Ověříte, že se Šemík připojil k FSce ("Connected to FS" dole na liště).
** Pokud jste odeslali FPL již z FSky a uplynuly cca 3 - 5 minut, bude plán dostupný přes tlačítko Load from VATSIM/IVAO. Jinak vyplňte ručně.
** V pravé části ověřte údaje z FSky. Pokud máte správně nastaveno icao letadla v aircraft.cfg, načte se to a spáruje s políčkem pro vyplnění letadla.
** Formulář, pokud se nenačítá ze sítě, se částečně sám doplňuje. Po vyplnění místa odletu a příletu hledá IATA kód letu a nabídne pár záložních letišť.
** Letovou hladinu pro let vyplňujte v tisících stop.
** Po vyplnění IATA kódu a máte li vybrané správné letadlo, naložte pasažéry "Load PAX"
** V tuto chvíli byste měli mít k dispozici tlačítko "Begin boarding", které započne záznam letu.
** Šemík nyní bude čekat na odbrždění parkovací brzdy a od té doby kontroluje vše automaticky. V průběhu pojíždení na start tedy můžete používat parkovací brzdu libovolně.
** Změny letových režimů vám bude vypisovat v okně FSky.

* Acars
------------
** Nyní probíhá let a Šemík reportuje události. K dispozici jsou záložky Acars Events (jednoduchý seznam událostí), Events Tree (každá událost jde rozkliknout a zobrazit detaily)
** Na záložce Server Messages lze zkontrolovat odpovědi ze serveru a případné chybové hlášky. 
** Na záložce Pokusy lze zkoušet různé věci. Doporučuji zkoušet pouze na zemi.

* Ukončení letu
-----------------
** Ukončení letu proběhne po zabrždění parkovací brzdy v režimu "Taxi to gate".
** Upload všech potřebných dat na server proběhne automaticky ihned po zaparkování.
** Po ukončení letu Šemíka vypněte a znovu spusťte před dalším letem

* Divert
-----------------
** Pokud Šemík detekuje, že jste nepřistáli na cílovém letišti, nabídne vám formulář pro vyplnění a odeslání zápisu o divertu.
** Formulář vyplňte a odešlete. Po jeho schválení vám bude připsán čas letu a vaše lokace bude odpovídat letišti, kam jste divertovali.


* FDR Viewer a incidenty
----------------
** Šemík zaznamenává let v několika formátech. Kromě FSACARS kompatibilního souboru je to formát FDR (Flight Data Recorder). 
** FDR soubory z vašich letů se ukládají do podadresáře "fdr" a lze je kdykoliv otevřít a prohlédnout.
** Pokud Šemík odhalí nějaký incident, zaznamená jej a zařadí jako událost do FDR. V případě, že máte zaplé FDR Imaging, udělá obrazový záznam.
** FDR soubory se uploadují na server a slouží pro kontrolu ze strany revizní komise. 
** Incidenty se reportují revizní komisi k posouzení.

* Incidenty
----------------
** Šemík rozeznává a reportuje tyto incidenty
* Paused
* SimRateChange
* Slewed
* Refueling
* SinkRate
* AbnormalLanding
* LandingOffRunway
* TakeOffOverweight
* LandingOverweight
* TakeOffOverRotate
* PositivePitchLimit
* NegativePitchLimit
* BankLimit
* FuelReserveLow
* FuelReserveHigh
* AltimeterNotStd
* ParkingBrakeWhileMoving
* CriticalPause