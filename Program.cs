using System;

namespace Generic_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            PlannerProducer pp = new PlannerProducer();

            AbstractDomain planner = pp.CreateDomain("WaterPouringProblem");
            planner.SetParameters(4, 3, 2);
            State initalState = planner.InitialState();
            State goalState = planner.GoalState();
            //planner.GeneratePlan();
            //Console.WriteLine("Hello World!");
        }
    }
}
