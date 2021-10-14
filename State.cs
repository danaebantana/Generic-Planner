using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Planner
{
    interface State
    {
        int GetCost();

        string GetPath();

        void SetPath(string states);

        (T, T) GetState<T>();

        public void SetCost(int c);
    }
}
