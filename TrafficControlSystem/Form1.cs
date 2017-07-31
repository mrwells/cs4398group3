using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrafficControlSystem.Models;

namespace TrafficControlSystem
{
    public partial class Form1 : Form
    {
        UISyncObject syncObject;

        private delegate void UpdateForm(Intersection intersection);

        public Form1(UISyncObject syncObject)
        {
            this.syncObject = syncObject;
            this.syncObject.OnTimeToUpdate += SyncObject_TimeToUpdate;
            
            InitializeComponent();
        }
        
        private void btn_preempt1_Click(object sender, EventArgs e)
        {

        }

        private void btn_preempt2_Click(object sender, EventArgs e)
        {

        }

        private void btn_walk1_Click(object sender, EventArgs e)
        {

        }

        private void btn_walk2_Click(object sender, EventArgs e)
        {

        }

        private void btn_walk3_Click(object sender, EventArgs e)
        {

        }

        private void btn_walk4_Click(object sender, EventArgs e)
        {

        }

        private void btn_walk5_Click(object sender, EventArgs e)
        {

        }

        private void btn_walk6_Click(object sender, EventArgs e)
        {

        }

        private void btn_walk7_Click(object sender, EventArgs e)
        {

        }

        private void btn_walk8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SyncObject_TimeToUpdate(Intersection intersection)
        {
            this.Invoke(new UpdateForm(Update), intersection);
        }

         private void Update(Intersection intersection)
         { 
            foreach (var signalGroup in intersection.SignalGroups)
            {
                var newLightColor = signalGroup.Signals.First().CurrentLight;

                if (signalGroup.Id == "universityblvd_east" || signalGroup.Id == "universityblvd_east")
                {
                    if (newLightColor == LightColor.Green)
                    {
                        label21.Visible = true;
                        label18.Visible = true;
                        label27.Visible = true;
                        label30.Visible = true;
                        label17.Visible = false;
                        label20.Visible = false;
                        label26.Visible = false;
                        label29.Visible = false;
                        label16.Visible = false;
                        label19.Visible = false;
                        label25.Visible = false;
                        label28.Visible = false;
                        Refresh();
                    }
                    if (newLightColor == LightColor.Yellow)
                    {
                        label21.Visible = false;
                        label18.Visible = false;
                        label27.Visible = false;
                        label30.Visible = false;
                        label17.Visible = true;
                        label20.Visible = true;
                        label26.Visible = true;
                        label29.Visible = true;
                        label16.Visible = false;
                        label19.Visible = false;
                        label25.Visible = false;
                        label28.Visible = false;
                        Refresh();
                    }
                    if (newLightColor == LightColor.Red)
                    {
                        label21.Visible = false;
                        label18.Visible = false;
                        label27.Visible = false;
                        label30.Visible = false;
                        label17.Visible = false;
                        label20.Visible = false;
                        label26.Visible = false;
                        label29.Visible = false;
                        label16.Visible = true;
                        label19.Visible = true;
                        label25.Visible = true;
                        label28.Visible = true;
                        Refresh();
                    }
                }

                if (signalGroup.Id == "universityblvd_turnlanes")
                {
                    if (newLightColor == LightColor.GreenArrow)
                    {
                        label13.Visible = false;
                        label14.Visible = false;
                        label15.Visible = true;
                        label34.Visible = false;
                        label35.Visible = false;
                        label36.Visible = true;
                        Refresh();
                    }
                    if (newLightColor == LightColor.YellowArrow)
                    {
                        label13.Visible = false;
                        label14.Visible = true;
                        label15.Visible = false;
                        label34.Visible = false;
                        label35.Visible = true;
                        label36.Visible = false;
                        Refresh();
                    }
                    if (newLightColor == LightColor.RedArrow)
                    {
                        label13.Visible = true;
                        label14.Visible = false;
                        label15.Visible = false;
                        label34.Visible = true;
                        label35.Visible = false;
                        label36.Visible = false;
                        Refresh();
                    }
                }

                if (signalGroup.Id.Contains("sunrise"))
                {
                    if (newLightColor == LightColor.Green)
                    {
                        label3.Visible = true;
                        label4.Visible = true;
                        label7.Visible = true;
                        label31.Visible = true;
                        label2.Visible = false;
                        label5.Visible = false;
                        label8.Visible = false;
                        label32.Visible = false;
                        label1.Visible = false;
                        label6.Visible = false;
                        label9.Visible = false;
                        label33.Visible = false;
                        Refresh();
                    }
                    if (newLightColor == LightColor.Yellow)
                    {
                        label3.Visible = false;
                        label4.Visible = false;
                        label7.Visible = false;
                        label31.Visible = false;
                        label2.Visible = true;
                        label5.Visible = true;
                        label8.Visible = true;
                        label32.Visible = true;
                        label1.Visible = false;
                        label6.Visible = false;
                        label9.Visible = false;
                        label33.Visible = false;
                        Refresh();
                    }
                    if (newLightColor == LightColor.Red)
                    {
                        label3.Visible = false;
                        label4.Visible = false;
                        label7.Visible = false;
                        label31.Visible = false;
                        label2.Visible = false;
                        label5.Visible = false;
                        label8.Visible = false;
                        label32.Visible = false;
                        label1.Visible = true;
                        label6.Visible = true;
                        label9.Visible = true;
                        label33.Visible = true;
                        Refresh();
                    }
                }
            }
        }
    }
}
