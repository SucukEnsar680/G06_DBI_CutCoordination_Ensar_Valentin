# Friseurtermin Planer

## Idee
 Ein Terminplaner für Friseure. D.h.: Friseure können die Termine von Kunden in unserer Anwendungen eingeben. Kundenname (Vorname, Nachname), Telefonnummer, Datum, Uhrzeit, Zeit (wie lange der Kunde da ist), DienstleistungID (was will der Kunde haben(Haarschnitt, Bart, ...)).

## Must-Haves:
 - Eine zweite Tabelle wo die Dienstleistungen sind

## Nice-to-Have:
 - Kalender Api-Anbindung 
 - eine Anzeige die anzeigt wie viel Umsatz gemacht wurde

## Verwendete Abfragen
```sql
```
## Wer macht was
### Ensar
- hinzufügen Fenster
### Valentin
 - Hauptfenster

## Wer hat an was gearbeitet
### Ensar
| Datum      | Arbeit                                        |
|------------|-----------------------------------------------|
| 21.05.2024 |Dokumentation                                  |
|            |                                               |

### Valentin

| Datum      | Arbeit                                        |
|------------|-----------------------------------------------|
| 04.06.2024 |MainWindow designed und connection zu AddTerminWindow gemacht.|
| 11.06.2024 |File-Struktur richtig gestellt sowie verlangt.|
| 11.06.2024 |Angefangen damit das wenn das Programm startet alle Termine aus der Datenbank in eine Listbox geladen werden.|
| 13.06.2024 |Vollendet das alle Termine geladen werden und zusaetzlich noch hinzugefuegt das die Termine zuvor noch nach Datum und Uhrzeit sortiert werden.|
| 15.06.2024 |Richtig gestellt das nun Termine hinzugefuegt werden sowie entfernt werden koennen.|
| 15.06.2024 |Alte Struktur (Listbox) sowie neue Kalender Idee fuer das MainWindow geloescht.|
| 15.06.2024 |Einen kleinen Kalender nun hinzugefuegt danach eine Gridview fuer denn aktuellen Tag erstellt sowie dabei das alte Daten Design auf das neue angewandt.|
| 16.06.2024 |Ein besseres Design der Anwendung hinzugefuegt sowie das Removen der Termine nicht nur grafisch gemacht sondern nun auch Datenbank technisch.|
| 16.06.2024 |Code schoener strukturiert sowie das editieren der bestehenden Termine funktional gemacht sprich das man nun den Erfolg vom editieren eines Termins sofort sieht.|
| 16.06.2024 |Eine Join-Abfrage hinzugefuegt fuer die Dienstleistungen beim einlesen sowie im Code dazu die richtige Darstellung.|