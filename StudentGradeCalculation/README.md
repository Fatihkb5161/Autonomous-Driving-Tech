# Clean Coding – Student Grade Calculation

This project was developed as part of a **Clean Coding** assignment.  
The aim is to design a simple student grade calculation system by applying **clean code principles**, **object-oriented design**, and **unit testing**.

## Project Overview

The system calculates student grades using different averaging strategies and evaluates academic outcomes such as pass/fail status and highest average selection.

The project emphasizes:
- Readable and maintainable code
- Single Responsibility Principle
- Testable design using unit tests

## Key Concepts

- Clean Code principles
- Object-Oriented Programming (OOP)
- Separation of concerns
- Unit testing with xUnit
- Refactoring-friendly design

## Solution Structure

The solution consists of two main projects:

### 1. NotHesapla
Core application logic:
- Grade calculation strategies
- Pass/fail evaluation
- Highest average determination

### 2. Test
Unit test project:
- Validates correctness of each class
- Ensures logic errors are detected through failing tests

## Implemented Components

### Average Calculation
Two different averaging strategies are implemented:
- **BasitOrtalama**: Calculates simple arithmetic mean
- **AgirlikliOrtalama**: Calculates weighted average

Each strategy encapsulates its own responsibility, allowing easy extension or replacement.

### Pass/Fail Control
- **GecisKontrolu** class evaluates whether a student passes based on a threshold average.
- Keeps decision logic isolated and testable.

### Highest Average Selection
- **EnYuksekOrtalama** class determines the student with the highest average from a given collection.
- Demonstrates clean collection handling and comparison logic.

## Unit Tests

Unit tests are written using **xUnit** and cover:
- Correct average calculation
- Detection of incorrect results
- Pass/fail decision logic
- Correct selection of highest average

Some tests are intentionally designed to fail in order to verify that:
- Test cases correctly detect logical errors
- The testing framework is functioning as expected

## Technologies Used

- C#
- .NET
- xUnit
- Visual Studio

## Files

- `StudentGradeCalculation.sln` – Visual Studio solution
- `NotHesapla` – Core grade calculation project
- `Test` – Unit test project
- `UnitTests.cs` – Test cases for all components

## Notes

This project focuses on **code quality rather than complexity**.  
It demonstrates how clean structure, meaningful naming, and unit tests contribute to reliable and maintainable software.
