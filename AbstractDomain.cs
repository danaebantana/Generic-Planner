using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Planner
{
    abstract class AbstractDomain
    {
        public abstract void SetParameters(List<int> par);
        public abstract State InitialState();
        public abstract State GoalState();
        public abstract State FindMinimumState(List<State> stateList);
        public abstract bool CheckIfGoalState(State state, State goalState);
        public abstract List<State> GenerateSuccessors(State state);
        public abstract int Heuristic(State state);
        public abstract bool CheckSuccessor(State state, List<State> list);
        public abstract bool CheckIfInList(State state, List<State> list);
        public (string, int) GeneratePlan(State initial, State goal) //A* algorithm 
        {
            List<State> openList = new List<State>();
            List<State> closedList = new List<State>();
            List<State> successors;
            State GoalState = null;

            openList.Add(initial);
            
            while (openList.Any())
            {     
                State q = FindMinimumState(openList); //Find minimun cost State

                int position = openList.FindIndex(s => s.Equals(q));   //Pop state q off the openList
                openList.RemoveAt(position);

                successors = GenerateSuccessors(q);   //Get successors of state q

                foreach (State successor in successors)
                {
                   
                    if (CheckIfGoalState(successor, goal))   //Check if successor is the goal
                    {
                        Console.WriteLine("Solution Found");
                        GoalState = successor; 
                        GoalState.SetPath(q.GetPath());
                        successor.SetSteps(q.GetSteps() + 1);
                        break;
                    }

                    successor.SetCost(q.GetCost() + Heuristic(successor));
                    successor.SetPath(q.GetPath());
                    successor.SetSteps(q.GetSteps() + 1);

                    if (CheckSuccessor(successor, openList))  //Returns true if successor state is already in list but has a smaller cost
                    {
                        openList.Add(successor);
                    }

                    if (CheckSuccessor(successor, closedList))   //Returns true if successor state is already in list but has a smaller cost
                    {
                        openList.Add(successor);
                    }

                    if(!CheckIfInList(successor, openList) && !CheckIfInList(successor, closedList))  //Check if state is already in lists. If not added to openList
                    {
                        openList.Add(successor);
                    }

                }

                closedList.Add(q);

                if (GoalState != null)
                {
                    break;
                }

            }

            return (GoalState.GetPath(), GoalState.GetSteps());

        }
    }
}
