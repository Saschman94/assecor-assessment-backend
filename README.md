# Project Setup

## Prerequisites
1. A running SQL Server (locally or in a container) if you want to run the project with a connected DB
2. A CSV File you want to read in the defined format and place it in the 'Data' folder of the project root

**HINT: The Service runs in Database Mode by default, so if you want to run it in the CSV Reader Mode, please skip the DB Setup and ensure there is no default connection entered in the appsettings.json file** 

## DB Setup
1. Open a console in the project root directory (same as .sln file)

2. Add you DB connection string to the appsettings.json as you can see below
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_DB_CONNECTION_STRING"
  }
}
```

3. Create a migrations file by typing the following:

```pwsh
    dotnet ef migrations add InitialCreate --project Assecor.Assessment.Backend.Database --startup-project Assecor.Assessment.Backend.Api
```


4. Navigate into Assecor.Assessment.Backend.Api and run the project with

```pwsh
    dotnet run
```

## CSV Setup
1. Enter the relative path to your CSV File to the appsettings.json file like below
```json
{
  "CsvModule": {
    "FileLocation": "YOUR_RELATIVE_CSV_PATH"
  },
}
```
2. Just to make sure: Ensure you have no DefaultConnection added to the 'ConnectionStrings' segment of the appsettings.json
3. Navigate into Assecor.Assessment.Backend.Api and run the project with

```pwsh
    dotnet run
```

#

## Zielsetzung

Das Ziel ist es ein REST – Interface zu implementieren, Bei den möglichen Frameworks stehen .NET(C#) oder Java zur Auswahl. Dabei sind die folgenden Anforderungen zu erfüllen:

* Es soll möglich sein, Personen und ihre Lieblingsfarbe über das Interface zu verwalten
* Die Daten sollen aus einer CSV Datei lesbar sein, ohne dass die CSV angepasst werden muss
* Alle Personen mit exakten Lieblingsfarben können über das Interface identifiziert werden

Einige Beispieldatensätze finden sich in `sample-input.csv`. Die Zahlen der ersten Spalte sollen den folgenden Farben entsprechen:

| ID | Farbe |
| --- | --- |
| 1 | blau |
| 2 | grün |
| 3 | violett |
| 4 | rot |
| 5 | gelb |
| 6 | türkis |
| 7 | weiß |

Das Ausgabeformat der Daten ist als `application/json` festgelegt. Die Schnittstelle soll folgende Endpunkte anbieten:

**GET** /persons
```json
[{
"id" : 1,
"name" : "Hans",
"lastname": "Müller",
"zipcode" : "67742",
"city" : "Lauterecken",
"color" : "blau"
},{
"id" : 2,
...
}]
```

**GET** /persons/{id}

*Hinweis*: als **ID** kann hier die Zeilennummer verwendet werden.
```json
{
"id" : 1,
"name" : "Hans",
"lastname": "Müller",
"zipcode" : "67742",
"city" : "Lauterecken",
"color" : "blau"
}
```

**GET** /persons/color/{color}
```json
[{
"id" : 1,
"name" : "Hans",
"lastname": "Müller",
"zipcode" : "67742",
"city" : "Lauterecken",
"color" : "blau"
},{
"id" : 2,
...
}]
```

## Akzeptanzkriterien

1. Die CSV Datei wurde eingelesen, und wird programmintern durch eine dem Schema entsprechende Modellklasse repräsentiert.
2. Der Zugriff auf die Datensätze so abstrahiert, dass eine andere Datenquelle angebunden werden kann, ohne den Aufruf anpassen zu müssen.
3. Die oben beschriebene REST-Schnittstelle wurde implementiert und liefert die korrekten Antworten.
4. Der Zugriff auf die Datensätze, bzw. auf die zugreifende Klasse wird über Dependency Injection gehandhabt.
5.  Die REST-Schnittstelle ist mit Unit-Tests getestet. 
6.  Die `sample-input.csv` wurde nicht verändert 

## Bonuspunkte
* Implementierung als MSBuild Projekt für kontinuierliche Integration auf TFS (C#/.NET) oder als Maven/Gradle Projekt (Java)
* Implementieren Sie eine zusätzliche Methode POST/ Personen, die eine zusätzliche Aufzeichnung zur Datenquelle hinzufügen
* Anbindung einer zweiten Datenquelle (z.B. Datenbank via Entity Framework)

Denk an deine zukünftigen Kollegen, und mach es ihnen nicht zu einfach, indem du deine Lösung öffentlich zur Schau stellst. Danke!

# Assecor Assessment Test (EN)

## goal

You are to implement a RESTful web interface. The choice of framework and stack is yours between .NET (C#) or Java. It has to fulfull the following criteria:

* You should be able to manage persons and their favourite colour using the interface
* The application should be able to read the date from the CSV source, without modifying the source file
* You can identify people with a common favourite colour using the interface

A set of sample data is contained within `sample-input.csv`. The number in the first column represents one of the following colours:

| ID | Farbe |
|---|---|
| 1 | blau |
| 2 | grün |
| 3 | violett |
| 4 | rot |
| 5 | gelb |
| 6 | türkis |
| 7 | weiß |

the return content type is `application/json`. The interface should offer the following endpoints:

**GET** /persons
```json
[{
"id" : 1,
"name" : "Hans",
"lastname": "Müller",
"zipcode" : "67742",
"city" : "Lauterecken",
"color" : "blau"
},{
"id" : 2,
...
}]
```

**GET** /persons/{id}

*HINT*: use the csv line number as your **ID**.
```json
{
"id" : 1,
"name" : "Hans",
"lastname": "Müller",
"zipcode" : "67742",
"city" : "Lauterecken",
"color" : "blau"
}
```

**GET** /persons/color/{color}
```json
[{
"id" : 1,
"name" : "Hans",
"lastname": "Müller",
"zipcode" : "67742",
"city" : "Lauterecken",
"color" : "blau"
},{
"id" : 2,
...
}]
```

## acceptance criteria

1. The csv file is read and represented internally by a suitable model class.
2. File access is done with an interface, so the implementation can be easily replaced for other data sources.
3. The REST interface is implemented according to the above specifications.
4. Data access is done using a dependency injection mechanism
5. Unit tests for the REST interface are available.
6. `sample-input.csv` has not been changed.

## bonus points are awarded for the following
* implement the project with MSBuild in mind for CI using TFS/DevOps when using .NET, or as a Maven/Gradle project in Java
* Implement an additional **POST** /persons to add new people to the dataset
* Add a secondary data source (e.g. database via EF or JPA)

Think about your potential future colleagues, and do not make it too easy for them by posting your solution publicly. Thank you!
