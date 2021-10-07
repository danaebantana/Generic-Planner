using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generic_Planner
{
    public partial class StartForm : Form
    {
        PlannerProducer pp = new PlannerProducer();

        public StartForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbstractDomain planner = pp.CreateDomain("WaterPouringProblem");
            label1.Text = planner.GetInitialState().GetName();
            label2.Text = planner.GetGoalState().GetName();
            label3.Text = planner.GeneratePlan();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbstractDomain planner = pp.CreateDomain("BlocksWorld");
            label1.Text = planner.GetInitialState().GetName();
            label2.Text = planner.GetGoalState().GetName();
            label3.Text = planner.GeneratePlan();
        }
    }
}
