using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Planner
{
    class WaterJugState : State 
    {
		private (int Size, int Current) waterJug1;
		private (int Size, int Current) waterJug2;
        private string path;
		private int cost;
        private int steps;

        public WaterJugState(int j1, int j2)  //Constructor for initial state.
        {
            this.waterJug1 = (j1, 0);
            this.waterJug2 = (j2, 0);
            this.cost = 0;
            this.path = "(0 , 0)\n"; //put initial state in path
            this.steps = 0;
        }

        public WaterJugState(int j1, int j2, int waterGoal)  //Constructor for goal state.
        {
            this.waterJug1 = (j1, waterGoal);
            this.waterJug2 = (j2, 0);
            this.cost = Int32.MaxValue;
            this.path = ""; //empty path for goal state
            this.steps = 0;
        }

        public WaterJugState(int j1, int j2, int c1, int c2)   //Constructor for intermediate states
        {
            this.waterJug1 = (j1, c1);
            this.waterJug2 = (j2, c2);
            this.cost = 0;
            this.path = "";
            this.steps = 0;
        }

        public string GetPath()
        {
            return this.path;
        }

        public int GetCost()
        {
            return this.cost;
        }

        public void SetCost(int c)
        {
            this.cost = c;
        }

        public void SetPath(String states)   
        {
            (int C1, int C2) = this.GetState<int>();
            this.path = states + "(" + C1.ToString() + " , " + C2.ToString() + ")\n";
        }

        public (T, T) GetState<T>()   //Returns each of the current water levels of the waterjugs as <int>
        {
            return ((T)Convert.ChangeType(this.waterJug1.Current, typeof(T)), (T)Convert.ChangeType(this.waterJug2.Current, typeof(T)));
        }

        public void SetSteps(int s)
        {
            this.steps = s;
        }

        public int GetSteps()
        {
            return this.steps;
        }
    }
}
