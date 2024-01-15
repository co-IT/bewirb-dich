# TimeFrame Kata
## Kontext
Ein Arbeitgeber hat auf Hybrid-Office umgestellt und seine Bürofläche reduziert, um Kosten zu sparen. Die verbleibenden Arbeitsplätze müssen von den Angestellten vorab reserviert werden, da nicht mehr für alle genügend freie Arbeitsplätze zur Verfügung stehen. Die Lösung, um freie Zeitabschnitte anzuzeigen und neue Reservierungen zu tätigen, soll von dir realisiert werden.

Schreibe eine entsprechende Anwendung in einer Technologie deiner Wahl.

![Reservierungen](https://github.com/co-IT/bewirb-dich/blob/main/src/Katas/TimeFrameKata/assets/overview.png)

## Hinweise
- Versuche iterativ vorzugehen, indem du dir noch keine Gedanken um Edge Cases, Oberfläche, Persistenz und Co. machst
- Ignoriere Problemfelder wie Sommer-/Winterzeit oder Zeitzonen
- Verzichte auf Optimierungen des Ressourcenverbrauchs und der Performance
- Versuche so schnell als möglich einen Durchstich umzusetzen, um das Problem besser durchdringen zu können
- Vielleicht kannst du dir Zeit sparen, indem du auf nativen Datentypen setzt (z.B. mit Dictionary, HashSet, Tuple und Co.)

## Anforderungen
### Iteration 1
- Ziel: Der/Die Anwender:in kann Zeitabschnitt auswählen/erzeugen 
  - Ein Zeitabschnitt bezieht sich immer auf einen Tag, der sich nicht über mehrere Tage erstrecken kann, und zwei Zeitpunkte, Beginn und Ende.
  - Die Uhrzeitangaben der Zeitpunkte sollen im Minutentakt erfolgen.
  - Der Startzeitpunkt muss immer vor dem Endzeitpunkt liegen.
  - Ein Zeitabschnitt muss mindesten 15 Minuten dauern.
- Akzeptanztests
  - Wenn als Beginn der 1. Juli 23:45 Uhr und als Ende der 2. Juli 00:15 Uhr eingegeben werden, wird ein entsprechender Fehler gemeldet
  - Wenn als Beginn der 1. Juli 15:00 Uhr und als Ende der 1. Juli 15:14 Uhr eingegeben werden, wird ein entsprechender Fehler gemeldet
  - Wenn als Beginn der 1. Juli 15:00 Uhr und als Ende der 2. Juli 15:15 Uhr eingegeben werden, ist ein gültiger Zeitabschnitt erstellt worden

### Iteration 2
- Ziel: Der/Die Anwender:in kann Zeitabschnitte über Reservierungssystem buchen
  - Wenn es bereits existierende Reservierungen gibt, die ganz oder teilweise mit dem Zeitabschnitt der neuen Reservierungsanfrage überlappen, kann die Reservierung nicht durchgeführt werden
  - Wenn es keine existierende Reservierungen gibt, die mit dem Zeitabschnitt der neuen Reservierungsanfrage überlappen, wird die Reservierung durchgeführt
- Akzeptanztests
  - Wenn das Programm startet, existieren keine Reservierungen
  - Wenn für den Zeitabschnitt 1. Juli 15:00 - 15:30 eine Reservierung vorliegt und für 1. Juli 15:29 - 16:00 eine Reservierungsanfrage platziert wird, wird die Anfrage abgelehnt
  - Wenn für den Zeitabschnitt 1. Juli 15:00 - 15:30 eine Reservierung vorliegt und für 1. Juli 14:45 - 15:01 eine Reservierungsanfrage platziert wird, wird die Anfrage abgelehnt
  - Wenn für den Zeitabschnitt 1. Juli 15:00 - 15:30 eine Reservierung vorliegt und für 1. Juli 15:05 - 15:25 eine Reservierungsanfrage platziert wird, wird die Anfrage abgelehnt
  - Wenn für den Zeitabschnitt 1. Juli 15:00 - 15:30 eine Reservierung vorliegt und für 1. Juli 15:30 - 16:00 eine Reservierungsanfrage platziert wird, wird die Anfrage akzeptiert

### Iteration 3
- Ziel: Der/Die Anwender:in soll sich einen Überblick über alle existierenden Reservierungen verschaffen können
  - Wenn es keine Reservierungen gibt, wird nichts angezeigt
  - Die Ausgabe sortiert zunächst absteigend und wird gruppiert nach Tag ausgegeben
  - Innerhalb des Tages werden die einzelnen Zeitabschnitte früh nach spät sortiert ausgegeben

### Iteration 4
- Ziel: Die Darstellung aller existierender Reservierungen soll vereinfacht werden
  - Dazu soll die Funktionalität aus Iteration 3 überarbeitet werden
  - Direkt nacheinander folgende Reservierungen sollen als eine Reservierung dargestellt werden
- Akzeptanzkriterien
  - Existieren für den gleichen Tag die vier Zeitabschnitte 10:00 - 10:30, 10:30 - 11:15, 17:00-17:30 und 17:30 - 18:00, dann werden zwei Zeitabschnitte von 10:00 - 11:15 und 17:00 - 18:00 angezeigt.
