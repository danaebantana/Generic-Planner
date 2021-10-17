using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Planner
{
    interface State
    {
        public void SetCost(int c);
        int GetCost();
        void SetPath(string states);
        string GetPath();
        (T, T) GetState<T>();  //Returns elements of the class that implements the interface.
        public void SetSteps(int s);
        public int GetSteps();
    }
}
