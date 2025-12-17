# Intelligent Improved Acceleration (IIA) – ADAS Model

This project was developed as part of the **Autonomous Driving Technologies / Advanced Driver Assistance Systems (ADAS)** coursework.  
The aim is to model the **Intelligent Improved Acceleration (IIA)** function in the **MATLAB Simulink** environment and analyze vehicle longitudinal behavior under different driving conditions.

## Project Overview

In this study, an **Intelligent Improved Acceleration (IIA)** model is implemented to compute the desired acceleration of an ego vehicle by considering:
- Ego vehicle velocity
- Relative distance to the leading vehicle
- Relative velocity (Δv)
- Cruise speed and safety constraints

The model represents a simplified **adaptive longitudinal control logic**, commonly used in Adaptive Cruise Control (ACC) systems.

The implementation and results are documented in detail in the accompanying report. :contentReference[oaicite:0]{index=0}

## Key Concepts

- Advanced Driver Assistance Systems (ADAS)
- Longitudinal vehicle control
- Adaptive Cruise Control (ACC) principles
- Safe distance and time-gap modeling
- Velocity-dependent acceleration limits

## Model Components

### 1. Parameter Definitions
The following parameters are defined in the MATLAB environment:
- **Cruise Speed (Cs):** Desired cruising velocity
- **Aggressivity Coefficient (Ac):** Controls responsiveness
- **Time Gap (T):** Desired time headway between vehicles
- **Jam Distance (S0):** Minimum standstill distance
- **Maximum Acceleration (a)**
- **Minimum Deceleration (b)**

These parameters directly influence vehicle behavior and safety margins.

### 2. afree(v) Function
This function determines the **free-road acceleration** based on ego vehicle velocity.
- Limits acceleration when approaching cruise speed
- Prevents unnecessary acceleration at high speeds

### 3. s\*(v, Δv) Function
The desired safe distance is calculated as a function of:
- Ego vehicle speed
- Relative velocity to the leading vehicle

This ensures collision avoidance and realistic following behavior.

### 4. Desired Acceleration Logic
The final acceleration command is computed by combining:
- Free-road acceleration
- Interaction with leading vehicle
- Cruise speed constraints

Separate logic blocks handle:
- Ego speed greater than cruise speed
- Ego speed less than or equal to cruise speed

## Inputs and Outputs

### Inputs
- Ego vehicle velocity
- Relative distance
- Relative velocity (Δv)

### Outputs
- Desired acceleration
- Velocity and distance response plots

Simulation results are visualized through time-based graphs to validate system behavior.

## Technologies Used

- **MATLAB**
- **Simulink**
- Control-oriented block modeling
- Data visualization using scopes

## Files

- `IIAFunction.slx` – Simulink model of the IIA function  
- `actual_distance.mat` – Distance data  
- `ego_vehicle_velocity.mat` – Velocity data  
- `Rapor.pdf` – Detailed project report

## Notes

This project focuses on **conceptual ADAS modeling** rather than real-time deployment.  
It provides a clear foundation for understanding longitudinal control strategies used in modern autonomous and semi-autonomous vehicles.
