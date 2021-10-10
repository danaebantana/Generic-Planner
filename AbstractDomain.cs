using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Planner
{
    abstract class AbstractDomain
    {
        //private State initialState;
        //private State goalState;
        //private Enum Actions;  https://docs.microsoft.com/en-us/dotnet/api/system.reflection.emit.enumbuilder?view=net-5.0

        public abstract void SetParameters(int sizeJug1, int sizeJug2, int goal);
        public abstract State InitialState();
        public abstract State GoalState();

        public abstract State FindMinimumState(List<State> stateList);

        //public enum DefineActions(){};

        public List<State> GeneratePlan(State initial, State goal, Action heuristic) //A* algorithm 
        {
            List<State> openList = new List<State>();
            List<State> closedList = new List<State>();

            openList.Add(initial);

            while (openList.Any())
            {
                State q = FindMinimumState(openList);
                
            }

            return null;
        }

    }
}
