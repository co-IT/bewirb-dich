# TimeFrame Kata

Schreibe eine Anwendung in einer Technologie deiner Wahl, mit welcher du Zeitabschnitte speichern und visualisieren kannst.

## Anforderungen

- Der Benutzer kann Zeitabschnitte erstellen.
  - Ein Zeitabschnitt besteht aus einem Start- und Endpunkt.
  - Ein Zeitpunkt setzt sich aus einem Datum und einer Uhrzeit auf die Minute genau zusammen.
  - Der Startzeitpunkt muss immer vor dem Endzeitpunkt liegen.
  - Wenn sich Zeitabschnitte überschneiden, sollen diese zusammengelegt werden. Das heißt, falls ein Abschnitt `17.02.2023 10:00 - 17.02.2023 12:30` vorhanden ist und ein neuer Abschnitt `17.02.2023 12:30 - 17.02.2023 15:00` hinzugefügt wird, werden beide Einträge zu einem Eintrag `17.02.2023 10:00 - 17.02.2023 15:00` zusammengelegt.
- Die Zeitabschnitte sollen nach dem Tag gruppiert angezeigt werden können.
- Für die Anwendung sollen Softwaretests geschrieben werden.
