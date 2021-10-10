using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Planner
{
    class WaterPouringProblem : AbstractDomain
    {
        private WaterJug waterJug1, waterJug2;
        private int goal;
        private State initialState;
        private State goalState;
        private enum Actions {Empty, Fill, Transfer};

        public override void SetParameters(int sizeJug1, int sizeJug2, int waterGoal)
        {
            waterJug1 = new WaterJug(sizeJug1);  //initializing water jugs capacity.
            waterJug2 = new WaterJug(sizeJug2);
            this.goal = waterGoal;
        }

        public override State InitialState()   //InitialState jugs have 0 in current level of water.
        {
            initialState = new WaterJugState(waterJug1, waterJug2);
            return initialState;
        }

        public override State GoalState()
        {
            goalState = new WaterJugState(waterJug1, waterJug2, goal);
            return goalState;
        }

        public override State FindMinimumState(List<State> stateList)
        {
            State minState = stateList.ElementAt(0);
            foreach (State state in stateList)
            {
                if(state.GetCost() < minState.GetCost())
                {
                    minState = state;
                }
            }
            return minState;
        }
    }
}
