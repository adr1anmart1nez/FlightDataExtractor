# Flight Data Extractor

This project was created and worked on as part of an assignment to demonstrate the coding and problem-solving skills of the team.

The assigment was about reading a given PDF file with flight information and extracting all the relevant data.

## Approach



## Project Structure

The project was structured in such a way that dependencies are kept as simple as possible so that each component can be exchanged without causing many errors. For example, the `App` component can be extended to have a proper GUI without having to change code in the backend which is the `Core` component.

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
|
|--FlightDataExtractor.Tests
    |--CrewTest.cs
    |--FlightTest.cs
```

## Setup and Execution

1. Clone this repository:
```
git clone 
```


## Task List

- [x] Prompting user and reading given PDF file
- [x] Creating interfaces and defining required methods
- [x] Writing simple tests
- [ ] Parsing logic for flight information
- [ ] Parsing logic for crew information

## Problems

- 