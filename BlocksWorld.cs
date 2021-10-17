using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Planner
{
    class BlocksWorld : AbstractDomain
    {
        private int blocks, stacks;   //number of blocks. Number of stacks of initial state.
        private State initialState, goalState;
        private Random random= new Random();
        private string data = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";  //English Alphabet
        private List<char> datalist = new List<char>();      //contains the letters of the english alphabet in a form of a list.
        private List<char> dataBlocks = new List<char>();    //contains the block characters depending on the number of blocks given by the user. 

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
            if (stacks == 1)
            {
                elements.Add(Blocks.ToArray());  //{ [ ... ] } -> one stack
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
            Console.WriteLine("Initial State: " + initialState.GetPath());
            return initialState;
        }

        public override State GoalState()
        {
            List<char[]> elements = new List<char[]> { dataBlocks.ToArray() };
            goalState = new BlockState(elements);
            Console.WriteLine("Goal State: " + goalState.GetPath());
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
            State child;
            List<char[]> temp = new List<char[]>();
            //Actions
            foreach (char[] ch in elements)  //Examine each stack in comparison to other stacks of the state.
            {
                foreach(char[] c in elements)  
                {
                    if( ch != c)
                    {   //ADD BLOCK ON TOP OF ANOTHER BLOCK
                        char[] t = NewBlockStateTop(c, ch.Last());
                        List<char[]> e = PlaceOnTop(ch, c, t, elements);
                        child = new BlockState(e);
                        successors.Add(child);
                        //ADD BLOCK ON TOP OF TABLE
                        if(ch.Length != 1)
                        {
                            List<char[]> p = PlaceOnTable(ch, elements);
                            child = new BlockState(p);
                            successors.Add(child);
                        }
                    }
                }
            } 

            return successors;
        }

        public char[] NewBlockStateTop(char[] arr, char elem)   //Add element to a stack
        {
            string lastElement = elem.ToString();
            string str = new string(arr);
            str += lastElement;
            arr = str.ToCharArray();
            return arr;
        }
        
        public List<char[]> PlaceOnTop(char[] sR, char[] sA, char[] arr, List<char[]> list)   //Creates the new state for the action: Move block on top of another block
        {
            //sR = the stack the element is going to be removed from
            //sA = the stack the element is going to be added to
            //arr = the new stack that will replace the sA
            //list = contains the elements of the state
            List<char[]> newList = new List<char[]>();
            foreach (char[] ch in list)   //foreach stack
            {
                if (ch.Equals(sR))
                {
                    if (!(sR.Length == 1))  //If sR length == 1 we want to remove the stack so we ignore it
                    {
                        char[] newSE = RemoveElement(sR, sR.Last());
                        newList.Add(newSE);
                    }
                }
                else if (ch.Equals(sA)) //sA gets replaced in new state by the arr.
                {
                    newList.Add(arr);
                }
                else   //stack that is not getting changed
                {
                    newList.Add(ch);
                }
            }
            
            return newList;
        }

        public char[] RemoveElement(char[] arr, char elem)  //Remove element from stack
        {
            string str = new string(arr);
            int index = str.IndexOf(elem);
            str = str.Remove(index, 1);
            arr = str.ToCharArray();
            return arr;
        }

        public List<char[]> PlaceOnTable(char[] sR, List<char[]> list)   //Creates the new state for the action: Move block on table
        {
            //sR = the stack the element is going to be removed from
            List<char[]> newList = new List<char[]>();
            foreach (char[] ch in list)
            {
                if (ch.Equals(sR))
                {
                    char[] newSE = RemoveElement(sR, sR.Last());
                    newList.Add(newSE);
                    char[] newCh = new Char[] { sR.Last() };  //Makes stack with the removed element
                    newList.Add(newCh);
                }
                else   //stack that is not getting changed
                {
                    newList.Add(ch);
                }
            }

            return newList;
        }
        
        public override bool CheckIfGoalState(State state, State goalState)   
        {
            (List<char[]> elements, List<char[]> _null) = state.GetState<List<char[]>>();
            int stateCost = state.GetCost();
            (List<char[]> goalElements, List<char[]> __null) = goalState.GetState<List<char[]>>();
            int goalCost = goalState.GetCost();
            int count = 0;
            if (elements.Count == goalElements.Count)  //Same number of stacks  
            {
                for (int i=0; i<elements.Count; i++)  //Counts how many elements of the two sequences are the same
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
            if(count == elements.Count)   //Same sequence
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int Heuristic(State state)   //Heuristic Function
        {
            (List<char[]> elements, List<char[]> _null) = state.GetState<List<char[]>>();
            (List<char[]> goalElements, List<char[]> __null) = goalState.GetState<List<char[]>>();
            int cost = 0;
            if(elements.Count == 1)  //One stack in current state
            {
                for(int i = 0; i < elements.ElementAt(0).Length; i++)
                {
                    if (!elements.ElementAt(0).ElementAt(i).Equals(goalElements.ElementAt(0).ElementAt(i)))   //For each different element add 1
                    {
                        cost += 1;
                    }
                }
            } 
            else   //More stacks than one.
            {
                for(int i = 0; i < elements.Count; i++)
                {
                    char[] temp = elements.ElementAt(i);
                    if(temp.Length == 1)  //For each stack with one element add 1
                    {
                        cost += 1;
                    }
                    else
                    {
                        for(int j = 0; j < temp.Length; j++)
                        {
                            if (!temp.ElementAt(j).Equals(goalElements.ElementAt(0).ElementAt(j)))  //For each element of stack in different order than the goalState sequence add 2
                            {
                                cost += 2;
                            }
                        }
                    }
                }   
            }

            return cost;
        }

        public override bool CheckSuccessor(State state, List<State> list)   //Return true if state is already in list in has a smaller cost value
        {
            (List<char[]> elements, List<char[]> _null) = state.GetState<List<char[]>>();
            foreach (State s in list)
            {
                (List<char[]> e, List<char[]> __null) = s.GetState<List<char[]>>();;
                if (elements.Count == e.Count)
                {
                    int count = 0;
                    for (int i = 0; i < elements.Count; i++)
                    {
                        if (elements.ElementAt(i).SequenceEqual(e.ElementAt(i)))  
                        {
                            count++;
                        }
                    }
                    if(count == elements.Count)  //Same sequence
                    {
                        if (state.GetCost() < s.GetCost())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


        public override bool CheckIfInList(State state, List<State> list)     //Return true if state is already in list
        {
            (List<char[]> elements, List<char[]> _null) = state.GetState<List<char[]>>();
            foreach (State s in list)
            {
                (List<char[]> e, List<char[]> __null) = s.GetState<List<char[]>>(); ;
                if (elements.Count == e.Count)
                {
                    int count = 0;
                    for (int i = 0; i < elements.Count; i++)
                    {
                        if (elements.ElementAt(i).SequenceEqual(e.ElementAt(i)))
                        {
                            count++;
                        }
                    }
                    if (count == elements.Count)  //Same sequence
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
