# Virtual power plant coding and design excercise
A virtual powerplant is an aggregation of several battery resources. 
These batteries needs to be orchestrated to supply power to balance the grid from disturbances.
The class PowerCommandSource is an abstraction of a sensor which tells us how much power the grid needs currently.

## Your task
We want you to write code to coordinate the batteries to output what the requested power wants.
Connect a callback method to the PowerCommandSource which distributes the requested power 
among the batteries you have in the BatteryPool. 
Try to keep the battery output as close to the requested power as you can. 

## Goals
Focus on making the code structure nice and something to build upon when more requirements appear, 
while also solving the basic problem of distributing power to the connected batteries.
Make this a codebase you want to work with with a style you are proud of, while solving the problem to your best ability.
Feel free to move code around, but don’t alter the logic in the provided classes. 
We will use your resulting code as the foundation for further discussions in the tech interview.

This is also a quick peek into our problem domain, so we hope you like the task and enjoy solving the problem in a nice way.
The battery pool and battery classes emulates a set of physical batteries with given properties. 
Keep the existing logic, but feel free to extend. 
The PowerCommandSource represents an external control signal with a target value.
The CSV logger saves the data into a temp-file which you can use to graph the result if you want.
It for sure helps to see how well you have solved the problem, we will use it to evaluate how well it performs.

We don't want to steal too much of your spare time, 
so we hope you don't use too much time to complete this test. 
Let's put the ambition level around an hour or two.