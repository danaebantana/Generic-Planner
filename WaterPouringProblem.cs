using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Planner
{
    class WaterPouringProblem : AbstractDomain
    {
        private int sizeJug1, sizeJug2, goalWaterLevel;
        private State initialState, goalState;

        public override void SetParameters(List<int> par)
        {
            this.sizeJug1 = par.ElementAt(0);
            this.sizeJug2 = par.ElementAt(1);
            this.goalWaterLevel = par.ElementAt(2);
        }

        public override State InitialState()   //InitialState jugs have 0 in current level of water.
        {
            initialState = new WaterJugState(sizeJug1, sizeJug2);
            //initialState.AddToPath(initialState);   
            return initialState;
        }

        public override State GoalState()
        {
            goalState = new WaterJugState(sizeJug1, sizeJug2, goalWaterLevel);        
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

        public override List<State> GenerateSuccessors(State state)
        {
            List<State> successors = new List<State>();
            int J1 = sizeJug1, J2 = sizeJug2;
            (int C1, int C2) = state.GetState<int>();
            //Console.WriteLine("Generate Successors of state + ("+ C1 + " , " + C2 +")");
            State child;
            //Actions
            if (C1 < J1) //Fill Jug1
            {
                child = new WaterJugState(J1, J2, J1, C2);
                successors.Add(child);

            }
            if (C2 < J2)  //Fill Jug2
            {
                child = new WaterJugState(J1, J2, C1, J2);
                successors.Add(child);
            }
            if (C1 > 0)  //Empty Jug1
            {
                child = new WaterJugState(J1, J2, 0, C2);
                successors.Add(child);
            }
            if (C2 > 0)  //Empty Jug2
            {
                child = new WaterJugState(J1, J2, C1, 0);
                successors.Add(child);
            }
            //Problem
            if (C1 != J1)
            {
                if (C2 > J1 - C1 && C2 > 0)   //Pour Jug2 to Fill Jug1
                {
                    child = new WaterJugState(J1, J2, J1, C2 - J1 + C1);
                    successors.Add(child);
                }
                if (C2 <= J1 - C1 && C2 > 0)   //Empty Jug2 to Fill Jug1
                {
                    child = new WaterJugState(J1, J2, C1 + C2, 0);
                    successors.Add(child);
                }
            }
            if (C2 != J2)
            {
                if (C1 > J2 - C2 && C1 > 0)   //Pour Jug1 to Fill Jug2
                {
                    child = new WaterJugState(J1, J2, C1 - J2 + C2, J2);
                    successors.Add(child);
                }
                if (C1 <= J2 - C2 && C1 > 0)   //Empty Jug1 to Fill Jug2
                {
                    child = new WaterJugState(J1, J2, 0, C1 + C2);
                    successors.Add(child);
                }
            }
            return successors;
        }

        public override bool CheckIfGoalState(State state, State goalState)
        {
            (int C1, int C2) = state.GetState<int>();
            int stateCost = state.GetCost();
            (int GC1, int GC2) = goalState.GetState<int>();
            int goalCost = goalState.GetCost();
            if (C1==GC1 && stateCost <= goalCost)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }

        public override int Heuristic()
        {
            return 1;
        }

        public override bool CheckSuccessor(State state, List<State> list)
        {
            foreach (State s in list)
            {
                if (state.GetState<int>().Equals(s.GetState<int>()))
                {
                    if (state.GetCost() < s.GetCost())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override bool CheckIfInList(State state, List<State> list)
        {
            foreach (State s in list)
            {
                if (state.GetState<int>().Equals(s.GetState<int>()))
                {
                    return true;
                }
            }
            return false;
        }

        public override void UpdateState(State state, List<State> list)
        {
            throw new NotImplementedException();
        }
    }
}
