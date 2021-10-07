using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Planner
{
    class WaterPouringProblem : AbstractDomain
    {
        private State initialState;
        private State goalState;

        public override State GetInitialState()
        {
            initialState = new WaterJugState();
            return initialState;
        }

        public override State GetGoalState()
        {
            goalState = new WaterJugState();
            return goalState;
        }

        public override string GeneratePlan()
        {
            return "Plan Generated for WaterPouringProblem";
        }

    }
}
