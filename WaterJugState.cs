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
		private int cost;  //number of steps

        public WaterJugState(int j1, int j2)  //Constructor for initial state.
        {
            this.waterJug1 = (j1, 0);
            this.waterJug2 = (j2, 0);
            this.cost = 0;
            this.path = "(0 , 0)\n"; //put initial state in path
        }

        public WaterJugState(int j1, int j2, int waterGoal)  //Constructor for goal state.
        {
            this.waterJug1 = (j1, waterGoal);
            this.waterJug2 = (j2, 0);
            this.cost = Int32.MaxValue;
            this.path = ""; //empty path for goal state
        }

        public WaterJugState(int j1, int j2, int c1, int c2)   //Constructor for intermediate states
        {
            this.waterJug1 = (j1, c1);
            this.waterJug2 = (j2, c2);
            this.cost = 0;
            this.path = "";
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

        public (int,int) GetState()
        {
            return (this.waterJug1.Current, this.waterJug2.Current);
        }

        public void SetPath(String states)
        {
            this.path = states + "(" + this.GetState().Item1 + " , " + this.GetState().Item2 + ")\n";
        }

        
    }
}
