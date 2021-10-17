using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Planner
{
    class BlockState : State
    {
        private List<char[]> elements = new List<char[]>();  //Each char[] represents a stack of blocks. The List<char[]> represents the state of the BlockState
        private int cost;
        private string path;
        private int steps;

        public BlockState(List<char[]> elem)  //Constructor for all states
        {
            this.elements = elem;
            this.cost = 0;
            this.path = CharListToString(elements);
            this.steps = 0;
        }

        public int GetCost()
        {
            return this.cost;
        }

        public string GetPath()
        {
            return this.path;
        }

        public (T, T) GetState<T>()   //Returns the elements of the state as List<char[]>
        {
            return ((T)Convert.ChangeType(this.elements, typeof(T)), (T)Convert.ChangeType(null, typeof(T)));
        }

        public void SetCost(int c)
        {
            this.cost = c;
        }

        public void SetPath(string states)
        {
            this.path = states + "\n" + CharListToString(this.elements);
        }

        public string CharListToString(List<char[]> list)  //Returns the state elements in a form of a sequence for a nicer representation in the console
        {
            string sequence = "";
            int k = list.Count;
            for (int i = 0; i < k; i++)
            {
                sequence += " [ ";
                int l = list.ElementAt(i).Length;
                for (int j = 0; j < l; j++)
                {
                    if (j == l - 1)
                    {
                        sequence = sequence + list.ElementAt(i).ElementAt(j).ToString() + " ] ";
                    }
                    else
                    {
                        sequence = sequence + list.ElementAt(i).ElementAt(j).ToString() + " , ";
                    }
                }
                if (i != k - 1)
                {
                    sequence += " , ";
                }
            }
            return sequence;
        }

        public void SetSteps(int s)
        {
            this.steps = s++;
        }

        public int GetSteps()
        {
            return this.steps;
        }
    }
}
