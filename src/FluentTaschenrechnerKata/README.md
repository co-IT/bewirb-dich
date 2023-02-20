# Fluent Taschenrechner Kata

Erstelle einen Taschenrechner, welcher durch Aneinanderreihung von Methoden benutzen kann.

## Anforderungen

- Der Taschenrechner kann nur mit ganzen Zahlen (`int`) rechnen
- Eine Berechnung startet immer mit der statischen Methode `Start`
- Mit der Methode `Plus` kann addiert werden
- Mit der Methode `Minus` kann subtrahiert werden
- Mit der Methode `Zurueck` kann die letzte Methode / Aktion rückgängig gemacht werden
- Mit der Methode `Wiederherstellen` kann ein vorangehendes `Zurueck` aufgehoben werden
- Es können beliebig viele dieser Methoden aneinander verkettet werden
- Das Ergebnis wird durch die Methode `Ergebnis` als `int` zurück gegeben
- Alternativ kann das Ergebnis durch eine implizite Konvertierung zu `int` erreicht werden
- Sollte es zu einem arithmetischen Überlauf kommen, wird eine `ArithmeticException` geworfen
- Die Anforderungen sind durch Software-Tests abgesichert

## Beispiele

```csharp
var ergebnis = Taschenrechner
                    .Start(5)
                    .Ergebnis();
// -> ergebnis = 5
```

---

```csharp
var ergebnis = Taschenrechner
                    .Start(5)
                    .Plus(10)
                    .Minus(3)
                    .Ergebnis();
// -> ergebnis = 12
```

---

```csharp
var ergebnis = Taschenrechner
                    .Start(5)
                    .Plus(10)
                    .Minus(3)
                    .Zurueck()
                    .Wiederherstellen()
                    .Zurueck()
                    .Plus(2)
                    .Ergebnis();
// -> ergebnis = 17
```

---

```csharp
var ergebnis = Taschenrechner
                    .Start(5)
                    .Plus(10)
                    .Minus(3)
                    .Zurueck()
                    .Zurueck()
                    .Wiederherstellen()
                    .Ergebnis();
// -> ergebnis = 15
```

---

```csharp
int ergebnis = Taschenrechner
                    .Start(5);
// -> ergebnis = 5

```
