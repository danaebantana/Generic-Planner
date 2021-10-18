# Generic-Planner

## Introduction

Developed a Generic Planner which implements the 'Abstract Factory' design pattern in order to produce a sequence of actions from an initial state to a goal state for a variety of problems.

The two problems that were adjusted to the Generic Planner were the 'Water Pouring Puzzle' problem and the 'Blocks World' problem.

## Key Implementation Elements

### PlannerProducer:
Returns to the main program the corresponding problem that the user has selected, by returning an object of the abstract class 'AbstractDomain'.

### AbstractDomain: 
Constitutes an abstract class that defines the basic structure of the projects problem. It contains all the methods which have to be implemented by the classes who inherit it. Thus, each problem has an implemented version of those methods, according to its own specific features. The above justifies the execution of the 'GeneratePlan' method, which constructs the action plan, independently from each problem.

### Interface State: 
Determines the behaviour of the problems state. The states have to implement all the methods of the interface, so that they contain the necessary methods in order for them to be used by the corresponding problems classes.

### A* algorithm: 
One of the best techniques used to find the optimal path between an initial and a goal state. It is implemented by the 'GeneratePlan' method and it is common for all problems. The heuristic function needed by the algorithm is different for each program and is specified in the programs class. 

## Technologies

* Visual Studio 2019
* .ΝΕΤ desktop development workload
