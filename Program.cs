using System;
using System.Collections.Generic;

namespace Generic_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            PlannerProducer pp = new PlannerProducer();

            /*AbstractDomain planner = pp.CreateDomain("WaterPouringProblem");
            planner.SetParameters(new List<int>() { 4, 3, 2});
            State initalState = planner.InitialState();
            State goalState = planner.GoalState();
            string solution = planner.GeneratePlan(initalState,goalState);
            Console.WriteLine("Solution:\n" + solution);*/

            AbstractDomain planner = pp.CreateDomain("BlocksWorld");
            planner.SetParameters(new List<int>() { 4, 4 });
            State initalState = planner.InitialState();
            Console.WriteLine("Initial State: " + initalState.GetPath());
            State goalState = planner.GoalState();
            Console.WriteLine("Goal State: " + goalState.GetPath());
            string solution = planner.GeneratePlan(initalState, goalState);
            Console.WriteLine("Solution:\n" + solution);
        }
    }
}
