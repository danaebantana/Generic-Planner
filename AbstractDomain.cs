using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Planner
{
    abstract class AbstractDomain
    {
        //private State initialState;
        //private State goalState;
        //private Enum Actions;  https://docs.microsoft.com/en-us/dotnet/api/system.reflection.emit.enumbuilder?view=net-5.0

        public abstract State GetInitialState();
        public abstract State GetGoalState();
        
        //public enum DefineActions(){};

        public abstract string GeneratePlan();

    }
}
