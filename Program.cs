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

            Console.WriteLine("Welcome to Generic Planner");
            int choice;

            while (true)
            {
                Console.WriteLine("Games:\n1. Water Pouring Problem \n2. Blocks World\n3. Exit\n\nEnter choice:");

                choice = Int32.Parse(Console.ReadLine());
                while (choice < 1 || choice > 3)
                {
                    Console.WriteLine("Need to choose one of the above choice numbers!");
                    choice = Int32.Parse(Console.ReadLine());
                }

                if (choice == 1)
                {
                    Console.WriteLine("\nWater Pouring Problem:");
                    int liter1, liter2, goalLiter;

                    do    //liter1 needs to be a positive number 
                    {
                        Console.WriteLine("Enter liter amount for Jug1:\n!Note: Liter must be a positive number.");
                        liter1 = Int32.Parse(Console.ReadLine());
                    } while (liter1 < 0);

                    do    //liter2 needs to be a positive number 
                    {
                        Console.WriteLine("Enter liter amount for Jug2:\n!Note: Liter must be a positive number.");
                        liter2 = Int32.Parse(Console.ReadLine());
                    } while (liter2 < 0);
                    
                    do    //goalLiter needs to be a positive number and smaller than the water capacity of jug1 
                    {
                        Console.WriteLine("Enter goal liter amount for Jug1:\n!Note: Liter must be a positive number and smaller than the water capacity of jug1.");
                        goalLiter = Int32.Parse(Console.ReadLine());
                    } while (goalLiter > liter1 || goalLiter < 0);
                    
                    planner = pp.CreateDomain("WaterPouringProblem");
                    planner.SetParameters(new List<int>() { liter1, liter2, goalLiter });
                }
                else if (choice == 2)
                {
                    Console.WriteLine("\nBlocks World:");
                    int blocks, stacks;

                    do    //blocks number needs to be smaller than 26 and a positive number
                    {
                        Console.WriteLine("Enter number of blocks:\n!Note: Number of blocks need to be smaller or equal to 26 and positive");
                        blocks = Int32.Parse(Console.ReadLine());
                    } while (blocks > 26 || blocks < 0);

                    do    //stacks number needs to be smaller of equal to number of blocks and a positive number
                    {
                        Console.WriteLine("Enter number of stacks for initial state:\n!Note: Number of stacks needs to be smaller or equal to number of blocks and positive.");
                        stacks = Int32.Parse(Console.ReadLine());
                    } while (stacks > blocks || stacks < 0);

                    planner = pp.CreateDomain("BlocksWorld");
                    planner.SetParameters(new List<int>() { blocks, stacks });
                }
                else
                {
                    Console.WriteLine("Exit");
                    break;
                }

                State initalState = planner.InitialState();
                State goalState = planner.GoalState();
                (string solution, int steps) = planner.GeneratePlan(initalState, goalState);
                Console.WriteLine("Solution:\n" + solution);
                Console.WriteLine("Number of Steps:\n" + steps + "\n");
            }
        }
    }
}
