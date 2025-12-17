# Motion Planning and Control in Autonomous Vehicles

This project was developed within the scope of the **Autonomous Driving Technologies Specialization Program**.  
The study focuses on **motion planning and control strategies** for autonomous vehicles, with particular emphasis on **lane changing** and **intelligent speed assistance** functions.

## Project Overview

The project investigates how an autonomous vehicle plans and controls its motion under different driving scenarios.  
Three main aspects are addressed:
- Emergency braking and avoidance
- Trajectory generation for lane change maneuvers
- Speed planning based on road geometry and traffic constraints

All models and analyses are implemented using **MATLAB** and **Simulink**.  
Detailed explanations and results are provided in the project report. :contentReference[oaicite:0]{index=0}

## Key Concepts

- Motion planning
- Longitudinal and lateral vehicle control
- Lane change trajectory generation
- Emergency braking dynamics
- Intelligent Speed Assistance (ISA)

## Emergency Braking and Avoidance

An emergency braking scenario is modeled using a constant longitudinal deceleration:
- Longitudinal acceleration: **ax = −5 m/s²**
- Lateral acceleration is assumed to be zero during full braking

The braking distance and stopping time are calculated analytically and modeled in Simulink.  
Different road friction coefficients are evaluated, and safe operation is ensured by selecting an appropriate friction value.

## Trajectory Generation for Lane Change

Lane change motion is generated using a **polynomial trajectory** that satisfies boundary conditions for:
- Initial and final lateral position
- Velocity and acceleration constraints
- Desired lane offset

The trajectory ensures smooth lateral motion while maintaining vehicle stability.  
Cost-based evaluation is applied to select the most suitable trajectory among alternatives.

## Lateral Control Strategy

A simple control law is implemented to follow the reference trajectory:
- Lateral position error
- Heading angle error

These errors are combined using proportional gains to compute the desired curvature command.  
This approach demonstrates basic path tracking behavior used in autonomous driving systems.

## Intelligent Speed Assistance (ISA)

Speed planning is performed by considering:
- Road curvature–based speed limits
- Traffic speed limits
- Passenger comfort constraints (lateral and longitudinal acceleration)

The final target speed is selected as the minimum of road-based and traffic-based limits.  
Additionally, the required deceleration distance is calculated to ensure smooth and safe speed transitions.

## Tools and Technologies

- MATLAB
- Simulink
- Control-oriented modeling
- Analytical vehicle dynamics

## Files

- `Motion Planning and Control in Autonomous Vehicles Report.pdf` – Detailed project report
- MATLAB scripts for trajectory generation, control, and speed planning

## Notes

This project emphasizes **conceptual motion planning and control logic** rather than full vehicle dynamics simulation.  
It provides a strong foundation for understanding how autonomous vehicles:
- Generate safe trajectories
- Control lateral and longitudinal motion
- Adapt speed based on environmental constraints
