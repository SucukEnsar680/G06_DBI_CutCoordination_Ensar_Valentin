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
SELECT t.ID, t.Vorname, t.Nachname, t.Telefonnummer, t.Datum, t.Uhrzeit, t.Dauer, t.DienstId, d.Dienstname 
                                FROM Termine t JOIN Dienstleistungen d ON t.DienstID = d.DienstID;
```

```sql
DELETE FROM Termine WHERE Id = @Id
```

```sql
UPDATE Termine SET Vorname = @Vorname, Nachname = @Nachname, Telefonnummer = @Telefonnummer, Datum = @Datum, Uhrzeit = @Uhrzeit, Dauer = @Dauer, DienstID = @DienstID WHERE Id = @Id
```

```sql
INSERT INTO Termine (Vorname, Nachname, Telefonnummer, Datum, Uhrzeit, Dauer, DienstID) VALUES (@Vorname, @Nachname, @Telefonnummer, @Datum, @Uhrzeit, @Dauer, @DienstID)
```


## Wer macht was
### Ensar
- hinzufügen Fenster
### Valentin
- Hauptfenster

## Wer hat an was gearbeitet
### Ensar
| Datum      | Arbeit                                                                                       |
|------------|----------------------------------------------------------------------------------------------|
| 21.05.2024 |Dokumentation                                                                                 |
| 04.06.2024 |AddWindow gestyltet                                                                           |
| 12.06.2024 |neue Termine werden in Datenbank hinzugefügt                                                  |
| 13.06.2024 |Datepicker in AddWindow                                                                       |
| 16.06.2024 |Einträge können nun editiert werden * eigene schließen bar designed                           |

### Valentin

| Datum      | Arbeit                                        |
|------------|----------------------------------------------------------------------------------------------|
| 04.06.2024 |MainWindow designed und connection zu AddTerminWindow gemacht.|
| 11.06.2024 |File-Struktur richtig gestellt sowie verlangt.|
| 11.06.2024 |Angefangen damit das wenn das Programm startet alle Termine aus der Datenbank in eine Listbox geladen werden.|
| 13.06.2024 |Vollendet das alle Termine geladen werden und zusaetzlich noch hinzugefuegt das die Termine zuvor noch nach Datum und Uhrzeit sortiert werden.|
| 15.06.2024 |Richtig gestellt das nun Termine hinzugefuegt werden sowie entfernt werden koennen.|
| 15.06.2024 |Alte Struktur (Listbox) sowie neue Kalender Idee fuer das MainWindow geloescht.|
| 15.06.2024 |Einen kleinen Kalender nun hinzugefuegt danach eine Gridview fuer denn aktuellen Tag erstellt sowie dabei das alte Daten Design auf das neue angewandt.|