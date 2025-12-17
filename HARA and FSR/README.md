# HARA and FSR – Hazard Analysis & Functional Safety Requirements

This project was prepared within the scope of **Autonomous Driving Technologies / ADAS** education.  
The objective is to perform **Hazard Analysis and Risk Assessment (HARA)** and derive corresponding **Functional Safety Requirements (FSR)** in accordance with **ISO 26262** principles.

## Project Overview

In this study, potential hazardous events related to an automotive system are systematically analyzed.  
Each hazard is evaluated based on:
- Severity (S)
- Exposure (E)
- Controllability (C)

Using these parameters, **Automotive Safety Integrity Level (ASIL)** ratings are determined, and **Functional Safety Requirements (FSR)** are defined to mitigate identified risks.

The analysis is structured and documented in an Excel-based HARA–FSR table.

## Key Concepts

- Functional Safety
- ISO 26262
- Hazard Analysis and Risk Assessment (HARA)
- Automotive Safety Integrity Level (ASIL)
- Functional Safety Requirements (FSR)

## HARA Methodology

For each identified hazard:
1. **Hazard Description** is defined
2. **Operational Situation** is specified
3. Severity (S), Exposure (E), and Controllability (C) values are assigned
4. **ASIL level** is calculated
5. Safety goals are determined based on risk level

This structured approach ensures traceability from hazards to safety goals.

## Functional Safety Requirements (FSR)

Based on the derived safety goals:
- High-level **Functional Safety Requirements** are specified
- Each FSR directly addresses one or more hazards
- Requirements focus on system-level behavior rather than implementation details

FSRs form the foundation for later technical safety concepts and system design decisions.

## File Description

- `HARA and FSR.xlsx`
  - Hazard leading to risk identification
  - S / E / C classification
  - ASIL determination
  - Safety goals
  - Functional Safety Requirements mapping

## Tools Used

- Microsoft Excel
- ISO 26262 safety lifecycle concepts
- Risk-based analysis methodology

## Notes

This work focuses on **conceptual functional safety analysis** rather than software or hardware implementation.  
It demonstrates the ability to:
- Systematically identify hazards
- Perform ASIL classification
- Translate risks into functional safety requirements

The study provides a solid basis for further steps such as **Technical Safety Requirements (TSR)** and system architecture design.
