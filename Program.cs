using System;
using System.Collections.Generic;

namespace Generic_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            PlannerProducer pp = new PlannerProducer();
            AbstractDomain planner = null;

            Console.WriteLine("Games:\n1. Water Pouring Problem \n2. Blocks World\n3. Exit\nEnter choice:");
            
            int choice = Int32.Parse(Console.ReadLine());
            while (choice < 1 || choice > 3){
                Console.WriteLine("Need to choose one of the above choice numbers!");
                choice = Int32.Parse(Console.ReadLine());
            }
           
            while(choice != 3)
            {
                if (choice == 1)
                {
                    Console.WriteLine("Water Pouring Problem:\nEnter liter amount for Jug1:");
                    int liter1 = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter liter amount for Jug2:");
                    int liter2 = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter goal liter amount for Jug1:");
                    int goalLiter = Int32.Parse(Console.ReadLine());
                    planner = pp.CreateDomain("WaterPouringProblem");
                    planner.SetParameters(new List<int>() { liter1, liter2, goalLiter });
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Blocks World:\nEnter number of blocks:");
                    int blocks = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter number of stacks for initial state:\n!Note: Number of stacks needs to be smaller or equal to number of blocks.");
                    int stacks = Int32.Parse(Console.ReadLine());
                    planner = pp.CreateDomain("BlocksWorld");
                    planner.SetParameters(new List<int>() { blocks, stacks });
                    Console.WriteLine("Blocks World:\n");
                }

                State initalState = planner.InitialState();
                State goalState = planner.GoalState();
                string solution = planner.GeneratePlan(initalState, goalState);
                Console.WriteLine("Solution:\n" + solution);
            }
            Console.WriteLine("Exit");

        }
    }
}
