using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Planner
{
    class BlocksWorld : AbstractDomain
    {
        private int blocks, stacks;   //number of blocks and number of stacks of initial state.
        private State initialState, goalState;
        private Random random= new Random();
        private string data = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private List<char> datalist = new List<char>();
        private List<char> dataBlocks = new List<char>();   //contains the block characters depending on the number of blocks given by the user. 

        public override void SetParameters(List<int> par)
        {
            this.blocks = par.ElementAt(0);
            this.stacks = par.ElementAt(1);

            datalist.AddRange(data);
            int b = 0;
            foreach (char c in datalist)
            {
                if (b < blocks)
                {
                    dataBlocks.Add(c);
                }
                b++;
            }
        }   

        public override State InitialState()  //Create random initial state based on the number of blocks and stacks given by the user.
        {
            //Determine random blocks
            List<char> Blocks = dataBlocks.OrderBy(b => random.Next()).ToList();
            List<char[]> elements = new List<char[]>();
            if (stacks == 0)
            {
                throw new Exception("The number of stacks can't be zero");
            }
            else if (stacks == 1)
            {
                elements.Add(Blocks.ToArray());  //{ [ ... ] } -> one stack
                //Console.WriteLine(elements.ElementAt(0).Length.ToString());
                //Console.WriteLine(elements.Count.ToString());
            }
            else if (stacks > blocks)
            {
                throw new Exception("The number of stacks needs to be smaller or equal to the number of blocks");
            }
            else
            {
                for(int i = 1; i <= stacks; i++)
                {
                    if(i == stacks)
                    {
                        elements.Add(Blocks.ToArray());
                        Blocks.Clear();
                    }
                    else
                    {
                        string characters = Blocks.First().ToString();
                        char[] charArr = characters.ToCharArray();
                        elements.Add(charArr);
                        Blocks.Remove(Blocks.First());
                    }
                }
            }
            initialState = new BlockState(elements);
            return initialState;
        }

        public override State GoalState()
        {
            List<char[]> elements = new List<char[]> { dataBlocks.ToArray() };
            goalState = new BlockState(elements);
            return goalState;
        }

        public override State FindMinimumState(List<State> stateList)
        {
            State minState = stateList.ElementAt(0);
            foreach (State state in stateList)
            {
                if (state.GetCost() < minState.GetCost())
                {
                    minState = state;
                }
            }
            return minState;
        }

        public override List<State> GenerateSuccessors(State state)
        {
            List<State> successors = new List<State>();
            (List<char[]> elements, List<char[]> _null) = state.GetState<List<char[]>>();
            State child = new BlockState(elements);
            //Actions
            int numberOfStacks = elements.Count;
            for(int i = 0; i < numberOfStacks; i++)
            {
                int e = elements.ElementAt(i).Length;
                if (e == 1)
                {
                    char[] element = elements.ElementAt(i);
                    elements.Remove(element);
                    foreach(char[] ch in elements)
                    {
                        ch.Append(element.ElementAt(0));
                    }
                }
                else
                {

                }
            }
            successors.Add(child);
            return successors;
        }












        public override bool CheckIfGoalState(State state, State goalState)   //WORKS
        {
            (List<char[]> elements, List<char[]> _null) = state.GetState<List<char[]>>();
            int stateCost = state.GetCost();
            (List<char[]> goalElements, List<char[]> __null) = goalState.GetState<List<char[]>>();
            int goalCost = goalState.GetCost();
            int count = 0;
            if (elements.Count == goalElements.Count && stateCost <= goalCost)
            {
                for (int i=0; i<elements.Count; i++)
                {
                    if (elements.ElementAt(i).SequenceEqual(goalElements.ElementAt(i)))
                    {
                        count++;
                    }
                }
            }
            else
            {
                return false;
            }
            if(count == elements.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool CheckIfInList(State state, List<State> list)
        {
            return true;
        }

        public override bool CheckSuccessor(State state, List<State> openlist)
        {
            return false;
        }

        

        
        

        public override int Heuristic()
        {
            return 1;
        }

        

        

        public override void UpdateState(State state, List<State> list)
        {
            throw new NotImplementedException();
        }
    }
}
