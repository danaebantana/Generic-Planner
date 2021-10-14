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

        (int, int) GetState();

        public void SetCost(int c);
    }
}
