using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Planner
{
    class WaterJugState : State
    {
		private WaterJug waterJug1;
		private WaterJug waterJug2;
        private List<WaterJugState> path;
		private int cost;  //or steps

        public WaterJugState(WaterJug j1, WaterJug j2)  //Constructor for initial state.
        {
            this.waterJug1 = j1;
            this.waterJug2 = j2;
            this.cost = 0;
            this.path = new List<WaterJugState>();
            Console.WriteLine("WaterJugState created with Jug1: "+ waterJug1.GetCapacity() + " and Jug2: " + waterJug2.GetCapacity());
        }

        public WaterJugState(WaterJug j1, WaterJug j2, int waterGoal)  //Constructor for goal state.
        {
            this.waterJug1 = j1;
            this.waterJug2 = j2;   
            this.waterJug1.SetWaterLevel(waterGoal);
            this.cost = 0;
            this.path = new List<WaterJugState>();
            Console.WriteLine("WaterJugState created with Jug1: " + waterJug1.GetCapacity() + " and Jug2: " + waterJug2.GetCapacity() + " and WaterGoalLevel: "+
                waterJug1.GetWaterLevel());
        }

		public int GetCost()
        {
            return this.cost;
        }
    }
}
