# Sensor Fusion and State Estimation

This project was developed within the **Autonomous Driving Technologies Specialization Program** as part of the **Sensor Fusion and State Estimation** coursework.  
The objective is to demonstrate how data from multiple sensors can be combined to obtain a more accurate and reliable estimate of a system state.

## Project Overview

In autonomous systems, relying on a single sensor often leads to inaccurate or noisy measurements.  
This project implements a **basic sensor fusion approach** in the **MATLAB Simulink** environment by combining measurements from two different sensor models observing the same trajectory.

Each sensor is deliberately modeled with different imperfections such as noise, bias, and scale errors.  
The sensor outputs are then fused to reduce individual sensor errors and improve estimation accuracy. :contentReference[oaicite:0]{index=0}

## Key Concepts

- Sensor Fusion
- State Estimation
- Measurement noise and bias
- Multi-sensor systems
- Simulink-based modeling

## System Architecture

The overall system consists of the following stages:

1. **Reference Trajectory Generation**  
   A reference route is defined using the Signal Editor block.

2. **Sensor Modeling**  
   Two independent sensor models are created:
   - Each sensor applies different scale factors
   - Bias terms are added
   - Random noise is injected to simulate real-world sensor behavior

3. **Sensor Fusion**  
   The sensor outputs are combined using a simple arithmetic mean:
   - Sensor 1 output + Sensor 2 output
   - Result divided by 2

4. **Visualization**  
   Raw sensor outputs and fused output are visualized using Scope blocks for comparison.

## Sensor Models

### Sensor 1
- Applies a scale factor greater than 1
- Includes a positive bias
- Adds random noise to simulate measurement uncertainty

### Sensor 2
- Uses different scale and bias parameters
- Includes independent noise characteristics
- Represents a second, independent measurement source

These differences allow observation of how fusion reduces individual sensor errors.

## Fusion Method

A **simple averaging method** is used for sensor fusion.  
Although basic, this approach:
- Reduces random noise
- Mitigates individual sensor bias effects
- Requires very low computational cost

This method is commonly used as an introductory approach before applying more advanced techniques such as Kalman Filters.

## Files

- `untitled.slx` – Simulink sensor fusion model  
- `untitled.mat` – Simulation data  
- `Sensör Füzyonu ve Durum Kestirimi.pdf` – Project report

## Tools and Technologies

- MATLAB
- Simulink
- Signal Editor
- Scope-based data visualization

## Notes

This project focuses on **fundamental sensor fusion concepts** rather than advanced probabilistic filters.  
It provides a clear baseline for understanding how multi-sensor systems improve robustness and accuracy in autonomous driving applications.
