using System;
using System.Collections.Generic;
using System.Text;

namespace Generic_Planner
{
    class WaterJug
    {
        private int capacity;  //Capacity of the jug
        private int current;   //Current water level

        public WaterJug(int cap)
        {
            this.capacity = cap;
            this.current = 0;
        }

        public int GetCapacity()
        {
            return this.capacity;
        }

        public void SetWaterLevel(int l)
        {
            this.current = l;
        }

        public int GetWaterLevel()
        {
            return this.current;
        }
    }
}
