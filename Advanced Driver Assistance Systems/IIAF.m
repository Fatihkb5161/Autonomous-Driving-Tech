Cs = 100; % Cruise speed = 100km/h
Ac = 2; % Aggresitivity coefficient
T = 1.5; % Time-gap
S0 = 2; % Jam distance (distance between vehicles when stopped)
a = 2; % Maximum acceleration (~2 m/s)
b = 2; % Minimum deceleration, (~-2m/s)
sim('IIAFunction.slx')