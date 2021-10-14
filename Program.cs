using System;
using System.Collections.Generic;

namespace Generic_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            PlannerProducer pp = new PlannerProducer();

            AbstractDomain planner = pp.CreateDomain("WaterPouringProblem");
            planner.SetParameters(new List<int>() { 4, 3, 2});
            State initalState = planner.InitialState();
            State goalState = planner.GoalState();
            string solution = planner.GeneratePlan(initalState,goalState);
            Console.WriteLine("Solution:\n" + solution);

            

        }
    }
}
