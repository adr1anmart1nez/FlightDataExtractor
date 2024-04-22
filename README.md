# Flight Data Extractor

This project was created and worked on as part of an assignment to demonstrate the coding and problem-solving skills of the team.

The assigment was about reading a given PDF file with flight information and extracting all the relevant data.

## Approach

After reading the assignment thoroughly and analyzing the problem, I searched for a modern and reliable .NET library for reading and extracting PDF files. Since `itext` seemed to be very popular, I read some usage examples and decided to use it.

After creating a simple .NET 8.0 project in JetBrains Rider, I started to create basic classes, such as `Flight` and `Crew` to represent the data, and interfaces to define the behavior and functionality the program should have. During that, I oriented myself on the single responsibility principle and other architecture patterns that allow for modularity and scalability of the software. Once I created the interfaces and defined the methods, I created simple unit tests using the NUnit framework to ensure that my program had the required functionality. I oriented myself on the given example to see which values were expected for what field.

Once I created a bunch of tests, I started with the proper implementation of the interfaces and methods. For the parsing of the extracted text, I decided to use regex expressions as those allow for flexible parsing of dynamic text. This part of the project was a trial and error and took most of the available time. I used https://regex101.com/ as support to see whether the patterns I defined actually worked.

Unfortunately, the time was running short, so I had to skip some parts such as the navigation points of each flight where my regex pattern didn't work as intended. Furthermore, the table with the crew members was a challenge. I described the problems that I encountered in the [Problems](#problems) section. As such, the tests for the information about the crew will fail.

All in one, this was a fun project and challenge :)

## Project Structure

The project was structured in such a way that dependencies are kept as simple as possible so that each component can be exchanged without causing many errors. For example, the `App` component can be extended to have a proper GUI without having to change code in the backend which is the `Core` component. Furthermore, the functionality of the text extraction can be easily changed or extended by implementing the interfaces.

```
FlightDataExtractor
|
|--FlightDataExtractor.App
|   |--Program.cs
|
|--FlightDataExtractor.Core
|   |--Models/
|   |   |--Crew.cs
|   |   |--Flight.cs
|   |   
|   |--Interfaces/
|   |   |--IPdfExtractor.cs
|   |   |--IPdfParser.cs
|   |   
|   |--Services/
|       |--FlightDataExtractor.cs
|       |--FlightDataParser.cs
|       |--Formatter.cs
|
|--FlightDataExtractor.Tests
    |--CrewTest.cs
    |--FlightTest.cs
```

## Running the project

### Setup

1. Clone this repository:
```
git clone https://github.com/adr1anmart1nez/FlightDataExtractor.git
```
2. Navigate to the repository directory:
```
cd FlightDataExtractor
```
3. Restore NuGet packages:
```
dotnet restore
```
4. Open the project in an IDE, in my case JetBrains Rider was used. Navigate to `FlightDataExtractor.App` and run `Program.cs`.

### Usage

After running `Program.cs`, the user will be prompted in the terminal to provide the path to a PDF file with the flight information. After entering the path, the flights that were read and parsed will be shown.

For integrating this software and using the flight extraction functionality, simply use:
```csharp
        IPdfExtractor extractor = new FlightDataExtractor();
        var flights = extractor.ExtractFlightData(filepath);
```
The `filepath` is the path to the PDF file with the flight information.

## Task List

- [x] Prompting user and reading given PDF file
- [x] Creating interfaces and defining required methods
- [x] Writing simple tests
- [x] Parsing logic for flight information (Mostly done, except the navigation points)
- [ ] Parsing logic for crew information

## Problems

- For some reason, my regex expression for parsing the navigation points of a flight wouldn't work as intended, even though I tested it on https://regex101.com/ using the extracted text from the PDF.
- I encountered another problem with parsing the PDF page with the crew data. Since some crew members had multiple names, their name was displayed in multiple lines. This was problematic for tables since the `itext` library would read as a separate lines and thus scramble the data. Overall, the tables made the parsing pretty challenging.