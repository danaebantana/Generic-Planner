using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Planner
{
    class PlannerProducer
    {
        public AbstractDomain CreateDomain(String domain)
        {
            if (domain == null)
            {
                return null;
            }
            if (domain.Equals("WaterPouringProblem"))
            {
                return new WaterPouringProblem();
            }
            else if (domain.Equals("BlocksWorld"))
            {
                return new BlocksWorld();
            }
            return null;
        }
    }
}
