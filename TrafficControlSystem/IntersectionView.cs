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


    public partial class IntersectionView : Form
    {
        UISyncObject syncObject;

        private delegate void UpdateForm(Intersection intersection);

        public IntersectionView(UISyncObject syncObject)
        {
            this.syncObject = syncObject;
            this.syncObject.OnTimeToUpdate += SyncObject_TimeToUpdate;
            this.FormClosing += Form1_FormClosing;
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.syncObject.OnTimeToUpdate -= SyncObject_TimeToUpdate;
        }
        
        private void btn_preempt1_Click(object sender, EventArgs e)
        {

        }

        private void btn_preempt2_Click(object sender, EventArgs e)
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

                if (signalGroup.Id.Contains("universityblvd"))
                {
                    if (newLightColor == LightColor.Green)
                    {
                        this.picbox_left_bot.Image = TrafficControlSystem.Properties.Resources.green_circle;
                        this.picbox_right_bot.Image = TrafficControlSystem.Properties.Resources.green_circle;
                        this.picbox_left_top.Image = TrafficControlSystem.Properties.Resources.green_circle;
                        this.picbox_right_top.Image = TrafficControlSystem.Properties.Resources.green_circle;
                        Refresh();
                    }
                    if (newLightColor == LightColor.Yellow)
                    {
                        this.picbox_left_bot.Image = TrafficControlSystem.Properties.Resources.yellow_circle;
                        this.picbox_right_bot.Image = TrafficControlSystem.Properties.Resources.yellow_circle;
                        this.picbox_left_top.Image = TrafficControlSystem.Properties.Resources.yellow_circle;
                        this.picbox_right_top.Image = TrafficControlSystem.Properties.Resources.yellow_circle;
                        Refresh();
                    }
                    if (newLightColor == LightColor.Red)
                    {
                        this.picbox_left_bot.Image = TrafficControlSystem.Properties.Resources.red_circle;
                        this.picbox_right_bot.Image = TrafficControlSystem.Properties.Resources.red_circle;
                        this.picbox_left_top.Image = TrafficControlSystem.Properties.Resources.red_circle;
                        this.picbox_right_top.Image = TrafficControlSystem.Properties.Resources.red_circle;
                        Refresh();
                    }
                }

                if (signalGroup.Id == "universityblvd_turnlanes")
                {
                    if (newLightColor == LightColor.GreenArrow)
                    {
                        this.picbox_turn_top.Image = TrafficControlSystem.Properties.Resources.green_arrow_alt;
                        this.picbox_turn_bot.Image = TrafficControlSystem.Properties.Resources.green_arrow;
                        Refresh();
                    }
                    if (newLightColor == LightColor.YellowArrow)
                    {
                        this.picbox_turn_top.Image = TrafficControlSystem.Properties.Resources.yellow_arrow_alt;
                        this.picbox_turn_bot.Image = TrafficControlSystem.Properties.Resources.yellow_arrow;
                        Refresh();
                    }
                    if (newLightColor == LightColor.RedArrow)
                    {
                        this.picbox_turn_top.Image = TrafficControlSystem.Properties.Resources.red_arrow_alt;
                        this.picbox_turn_bot.Image = TrafficControlSystem.Properties.Resources.red_arrow;
                        Refresh();
                    }
                }

                if (signalGroup.Id.Contains("sunrise"))
                {
                    if (newLightColor == LightColor.Green)
                    {
                        this.picbox_bot_right.Image = TrafficControlSystem.Properties.Resources.green_circle_alt;
                        this.picbox_top_right.Image = TrafficControlSystem.Properties.Resources.green_circle_alt;
                        this.picbox_bot_left.Image = TrafficControlSystem.Properties.Resources.green_circle_alt;
                        this.picbox_top_left.Image = TrafficControlSystem.Properties.Resources.green_circle_alt;
                        Refresh();
                    }
                    if (newLightColor == LightColor.Yellow)
                    {
                        this.picbox_bot_right.Image = TrafficControlSystem.Properties.Resources.yellow_circle_alt;
                        this.picbox_top_right.Image = TrafficControlSystem.Properties.Resources.yellow_circle_alt;
                        this.picbox_bot_left.Image = TrafficControlSystem.Properties.Resources.yellow_circle_alt;
                        this.picbox_top_left.Image = TrafficControlSystem.Properties.Resources.yellow_circle_alt;
                        Refresh();
                    }
                    if (newLightColor == LightColor.Red)
                    {
                        this.picbox_bot_right.Image = TrafficControlSystem.Properties.Resources.red_circle_alt;
                        this.picbox_top_right.Image = TrafficControlSystem.Properties.Resources.red_circle_alt;
                        this.picbox_bot_left.Image = TrafficControlSystem.Properties.Resources.red_circle_alt;
                        this.picbox_top_left.Image = TrafficControlSystem.Properties.Resources.red_circle_alt;
                        Refresh();
                    }
                }
            }
        }

        private void picbox_crosswalk_1r_Click(object sender, EventArgs e)
        {
            picbox_crosswalk_1r.Image = TrafficControlSystem.Properties.Resources.walking_man;
            Refresh();
            System.Threading.Thread.Sleep(5000);

            int i = 10;
            label1.Text = i.ToString();
            label1.Visible = true;
           
            while (i > 0)
            {
                picbox_crosswalk_1r.Image = TrafficControlSystem.Properties.Resources.upraised_hand;
                Refresh();
                System.Threading.Thread.Sleep(500);
                picbox_crosswalk_1r.Image = TrafficControlSystem.Properties.Resources.blank_cw;
                Refresh();
                System.Threading.Thread.Sleep(500);
                --i;
                label1.Text = i.ToString();
            }

            picbox_crosswalk_1r.Image = TrafficControlSystem.Properties.Resources.upraised_hand;
            label1.Visible = false;
            Refresh();
        }

        private void picbox_crosswalk_1l_Click(object sender, EventArgs e)
        {
          
        }

        private void picbox_crosswalk_2b_Click(object sender, EventArgs e)
        {
           
        }

        private void picbox_crosswalk_2t_Click(object sender, EventArgs e)
        {
          

        }

        private void picbox_crosswalk_3l_Click(object sender, EventArgs e)
        {
          
        }

        private void picbox_crosswalk_3r_Click(object sender, EventArgs e)
        {
           
        }

        private void picbox_crosswalk_4t_Click(object sender, EventArgs e)
        {
            
        }

        private void picbox_crosswalk_4b_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_em_r_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_em_l_Click(object sender, EventArgs e)
        {
           
        }
    }
}
