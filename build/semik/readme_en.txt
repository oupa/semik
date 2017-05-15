ÈSAV Šemík
-------------------

Instalation:
An up-to-date version is always available at http://www.csavirtual.cz/upload/semik/aktualni/semik.zip
Šemík does not need to install. All you need to do is unpack the archive to any directory. On Windows Vista or Windows 7 is is necessary
that the user has write permissions to this directory.

Šemík needs three things to run:
* FSUIPC library in Flight Simulator. The library is available at http://schiratti.com/dowson.html. No need to buy registered version.
* For X-Plane use XPUIPC instead of FSUIPC (Download available at http://www.tosi-online.de)
* Framework .NET 4.5 from Microsoftu. Most likely you have it, if you use Automatic updates in Windows. If you have doubts, visit http://www.microsoft.com/NET/ and Download.
* Internet connection at all time when using Šemík.

Known bugs:
-------------
1) problems with sound on some systems
2) problems with detecting active window when using ÈSAV TV feature
3) "New flight tracking" not working after finishing flight. For a new flight, turn Šemík off and on again. 

------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------
                                                                                                   
Running:
-----------------------
Recommended - first run Flight Simulator, load up the flight and then start Šemík.
Šemíka is run via csav_semik.exe (no other .exe file is there to run...).
If you run Windows Vista or Windows 7 and Flight Simulator as Administrator, you need also to run Šemík as Administrator.

Description of features:
-------------
* Login
-------------- 
** Log-in with the same credentials that you use for the website. Recommend to select to Remember login (password is not saved in plain text)
** After a successfull login you will get to a screen with Flight Plan. 
 
* Settings
--------------
** Before filling in the Flight Plan, take a look at the settings
** You can set up sound, integrated ÈSAV TV and other options.
** An important option is "FDR Imaging", which will allow to take a snaphot of an incident for future control. 
** FDR imaging uses the same settings as ÈSAV TV.
** You can turn this feature off, if you are concerned about your privacy. Check that ÈSAV TV detects your Flight Simulator window correctly and if positive, you don`t have to worry. This feature is good for future proof in case of an incident detected incorrectly.


* Flight Plan
---------------
** Fill in the fields in Fligh Plan form. Check that Šemík is connected to your Flight Simulator.("Connected to FS" is present on the status bar).
** If you had send a fligh plan to the network, it can be loaded via Load from VATSIM/IVAO button. You should wait about 5 minutes after sending the flight plan to the network.
** If you had created a briefing on CSAV website, click "Load briefing" button and all data from briefing will be loaded.
** On the right side of the screen you can check values that are read from Flight Simulator. 
** If you have a correct aircraft icao set in aircraft.cfg file, it will be automatically filled.
** If you don`t load the fligt plan from network, the form will complete some fields automatically as you fill the values in. Aftere filling in departure and arrival it will automatically fill in IATA code for the flight and offer a couple of alternate airports.
** For altitude fill in the feet - eg. 31000.
** After filling in IATA code and if you have correctly set up airctraft, click "Load PAX" button.
** At this moment, the button "Begin boarding" should become available. Click it to begin flight tracking.
** Šemík  will now wait for the release of a parkign brake and everything will be automatic since that time. During start and taxi you can use parking brake at your discretion.
** Changes of flight modes are displayed in info line in Flight Simulator.

* ACARS
------------
** As you fly, Šemík reports certain events and position. You can check tabs Acars Events (simple Events list), Events Tree (each event is clickable and will display details)
** On Server Messages tab you can check the responses from server and errors if there are any. 


* Finishing the flight
-----------------
** Finishing the flight is triggered by activating a parking brake after "Taxi to gate".
** Upload of all data will begin automatically after parking the aircraft.
** After the flight is completed, switch off Šemík and start it again for your next flight

* Divert
-----------------
** When Šemík detects you didn`t land at destination airport, it will offer you to fill a form with divert report.
** Fill in this form and submit it. Once approved, the time will be added to your account and your location will be changed to an airport, to which you diverted.

* FDR Viewer and incidents
----------------
** Šemík records the flight in two formats: FSACARS compatible format and its own format FDR (Flight Data Recorder). 
** FDR files from your flights are save in "fdr" directory for viewing at any time.
** If Šemík detects an incident, it will record it and add as an event to the FDR. If you have FDR Imaging switched ON in settings, it will make an screenshot of the incidentt.
** FDR files are uploaded on the server to allow checking from flight instructors. 
** Incidents are reported to instructors on a daily basis.

* Incidents
----------------
** Šemík detects and reports these incidents:
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