# Assecor Assessment Test Solution

## General

This project is a simple API project that manages persons and thier favorite colors. There are multiple datasources (CSV file and database) and it's easy extendable to new datasources. The framework used for this project is Asp.NET Core (C#)

## Solution and projects

The solution (Assecor.sln) contains 5 projects. One API project, 3 class libraries and one testing project.

Projects:
* Assecor.Core (class lib)
* Assecor.API (web api)
* Assecor.API.Tests (xunit project)
* Assecor.CSV (class lib)
* Assecor.EF (class lib)

### Assecor.Core Project

This is the core project of the solution. It contains:
* Domain models - Person and Color
* Data transfer objects (DTOs) - PersonDto
* Service intefaces - IPersonService
* Exceptions that will be used in the app
* Const/Default Data - List of default Colors

### Assecor.API Project

This is an API start project. It contains 
* Controllers - PersonsController and abstract BaseController with shared methods like Handle(Exceiption ex) method that handles all the exceptions on one place.
* Startup configuration
* appsettings.json

### Assecor.API.Tests

This projects contains tests for the API project. It uses XUnit and Moq.

### Assecor.CSV and Assecor.EF

These two projects contain PersonService class that implements IPersonService from the Assecor.Core project on their own way with their custom logic.

Assecor.CSV uses helper classes to read/write data from/to the CSV file.
Assecor.EF uses EF Core to read/write data in the database.

They both have IServiceCollection extension method, where the scopes and dependecies are registered, so they can be easily referenced in the Startup.cs of the API project.

Assecor.CSV registers its implementation of IPersonService, binds FileConnectionsCofiguration file from the appsettings.json's section, registers its AutoMapper Profile.
Assecor.EF registers its implementation of IPersonService, its DbContext and its AutoMapper Profile.

## How to setup the project

### Using CSV file

If you are using a CSV as a datasource, open appsettings.json in the Assecor.API project and set a path to your CSV file in "FileConnections" section. Go to the Startup.cs class in the API project and uncomment the line ```services.AddCsvServices(Configuration);```. Run the app.

### Using database

If you are going to use a database connection, open appsettings.json in the Assecor.API project and set your connection string in "ConnectionStrings" section. Than open the terminal and naviagte to the Assecor.EF project folder. Run "dotnet ef database update" command to create database and apply the migrations. There are two tables in the database (created based on domain models from the Assecor.Core project). The table Colors is already seeded with default colors (using Fluent API and list of default colors from the Core project). Go to the Startup.cs class in the API project and uncomment the line ```services.AddEfServices(options => options.UseSqlServer(Configuration.GetConnectionString("Assecor")));``` where string "Assecor" is the name of your connection in appsettings.json. Run the app.

### Using a third new datasouce

Create a new project. Add a reference to the Assecor.Core project. Implement IPersonService with your custom methods. Register your service interface implemntation in the Startup.cs. Run the app.

### Conclusion

Controllers in the API project depend on interfaces from the Core project and they do not depend on their implementation. So the only thing you have to do is to register your interface implementations in Startup.cs without changing any code in Controllers. 

Note: if you are using vscode, in order to run the app, you need to open Assecor.API project folder in the terminal and run "dotnet run" command

# Assecor Assessment Test (DE)

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
