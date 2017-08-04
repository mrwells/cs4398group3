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

        private Intersection _intersection;

        public Form1(UISyncObject syncObject)
        {
            this.syncObject = syncObject;
            this.syncObject.TimeToUpdate += SyncObject_TimeToUpdate;
            this.FormClosing += Form1_FormClosing;
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.syncObject.TimeToUpdate -= SyncObject_TimeToUpdate;
        }

        private void SyncObject_TimeToUpdate(Intersection intersection)
        {
            this.Invoke(new UpdateForm(Update), intersection);
            _intersection = intersection;
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
                    }
                    else if (newLightColor == LightColor.Yellow)
                    {
                        this.picbox_left_bot.Image = TrafficControlSystem.Properties.Resources.yellow_circle;
                        this.picbox_right_bot.Image = TrafficControlSystem.Properties.Resources.yellow_circle;
                        this.picbox_left_top.Image = TrafficControlSystem.Properties.Resources.yellow_circle;
                        this.picbox_right_top.Image = TrafficControlSystem.Properties.Resources.yellow_circle;
                    }
                    else if (newLightColor == LightColor.Red)
                    {
                        this.picbox_left_bot.Image = TrafficControlSystem.Properties.Resources.red_circle;
                        this.picbox_right_bot.Image = TrafficControlSystem.Properties.Resources.red_circle;
                        this.picbox_left_top.Image = TrafficControlSystem.Properties.Resources.red_circle;
                        this.picbox_right_top.Image = TrafficControlSystem.Properties.Resources.red_circle;
                    }

                    if (signalGroup.Roadway.CrosswalkOkToWalk)
                    {
                        crosswalk_universityblvd1.SetWalk();
                        crosswalk_universityblvd2.SetWalk();
                        crosswalk_universityblvd3.SetWalk();
                        crosswalk_universityblvd4.SetWalk();
                        crosswalk_universityblvd1.SetDisplay(signalGroup.Roadway.CrossWalkRemainingDuration.ToString());
                        crosswalk_universityblvd2.SetDisplay(signalGroup.Roadway.CrossWalkRemainingDuration.ToString());
                        crosswalk_universityblvd3.SetDisplay(signalGroup.Roadway.CrossWalkRemainingDuration.ToString());
                        crosswalk_universityblvd4.SetDisplay(signalGroup.Roadway.CrossWalkRemainingDuration.ToString());
                    }
                    else
                    {
                        crosswalk_universityblvd1.SetDontWalk();
                        crosswalk_universityblvd2.SetDontWalk();
                        crosswalk_universityblvd3.SetDontWalk();
                        crosswalk_universityblvd4.SetDontWalk();
                        crosswalk_universityblvd1.SetDisplay("");
                        crosswalk_universityblvd2.SetDisplay("");
                        crosswalk_universityblvd3.SetDisplay("");
                        crosswalk_universityblvd4.SetDisplay("");
                    }
                }

                if (signalGroup.Id == "universityblvd_turnlanes")
                {
                    if (newLightColor == LightColor.GreenArrow)
                    {
                        this.picbox_turn_top.Image = TrafficControlSystem.Properties.Resources.green_arrow_alt;
                        this.picbox_turn_bot.Image = TrafficControlSystem.Properties.Resources.green_arrow;
                    }
                    else if (newLightColor == LightColor.YellowArrow)
                    {
                        this.picbox_turn_top.Image = TrafficControlSystem.Properties.Resources.yellow_arrow_alt;
                        this.picbox_turn_bot.Image = TrafficControlSystem.Properties.Resources.yellow_arrow;
                    }
                    else if (newLightColor == LightColor.RedArrow)
                    {
                        this.picbox_turn_top.Image = TrafficControlSystem.Properties.Resources.red_arrow_alt;
                        this.picbox_turn_bot.Image = TrafficControlSystem.Properties.Resources.red_arrow;
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
                    }
                    else if (newLightColor == LightColor.Yellow)
                    {
                        this.picbox_bot_right.Image = TrafficControlSystem.Properties.Resources.yellow_circle_alt;
                        this.picbox_top_right.Image = TrafficControlSystem.Properties.Resources.yellow_circle_alt;
                        this.picbox_bot_left.Image = TrafficControlSystem.Properties.Resources.yellow_circle_alt;
                        this.picbox_top_left.Image = TrafficControlSystem.Properties.Resources.yellow_circle_alt;
                    }
                    else if (newLightColor == LightColor.Red)
                    {
                        this.picbox_bot_right.Image = TrafficControlSystem.Properties.Resources.red_circle_alt;
                        this.picbox_top_right.Image = TrafficControlSystem.Properties.Resources.red_circle_alt;
                        this.picbox_bot_left.Image = TrafficControlSystem.Properties.Resources.red_circle_alt;
                        this.picbox_top_left.Image = TrafficControlSystem.Properties.Resources.red_circle_alt;
                    }

                    if (signalGroup.Roadway.CrosswalkOkToWalk)
                    {
                        crosswalk_sunriserd1.SetWalk();
                        crosswalk_sunriserd2.SetWalk();
                        crosswalk_sunriserd3.SetWalk();
                        crosswalk_sunriserd4.SetWalk();
                        crosswalk_sunriserd1.SetDisplay(signalGroup.Roadway.CrossWalkRemainingDuration.ToString());
                        crosswalk_sunriserd2.SetDisplay(signalGroup.Roadway.CrossWalkRemainingDuration.ToString());
                        crosswalk_sunriserd3.SetDisplay(signalGroup.Roadway.CrossWalkRemainingDuration.ToString());
                        crosswalk_sunriserd4.SetDisplay(signalGroup.Roadway.CrossWalkRemainingDuration.ToString());
                    }
                    else
                    {
                        crosswalk_sunriserd1.SetDontWalk();
                        crosswalk_sunriserd2.SetDontWalk();
                        crosswalk_sunriserd3.SetDontWalk();
                        crosswalk_sunriserd4.SetDontWalk();
                        crosswalk_sunriserd1.SetDisplay("");
                        crosswalk_sunriserd2.SetDisplay("");
                        crosswalk_sunriserd3.SetDisplay("");
                        crosswalk_sunriserd4.SetDisplay("");
                    }
                }
            }

            Refresh();
        }

        //private void Crosswalk()
        //{
        //   picbox_crosswalk_1r.Image = TrafficControlSystem.Properties.Resources.walking_man;
        //   Refresh();
        //   System.Threading.Thread.Sleep(5000);

        //   int i = 25;
        //   label1.Text = i.ToString();
        //   label1.Visible = true;

        //   while (i > 0)
        //   {
        //       picbox_crosswalk_1r.Image = TrafficControlSystem.Properties.Resources.upraised_hand;
        //       Refresh();
        //       System.Threading.Thread.Sleep(500);
        //       picbox_crosswalk_1r.Image = TrafficControlSystem.Properties.Resources.blank_cw;
        //       Refresh();
        //       System.Threading.Thread.Sleep(500);
        //       --i;
        //       label1.Text = i.ToString();
        //   }

        //   picbox_crosswalk_1r.Image = TrafficControlSystem.Properties.Resources.upraised_hand;
        //   label1.Visible = false;
        //   Refresh();
        //}
        
        private void btn_preempt1_Click(object sender, EventArgs e)
        {

        }

        private void btn_preempt2_Click(object sender, EventArgs e)
        {

        }
        
        private void universityblvd_crosswalk_Click(object sender, EventArgs e)
        {
            syncObject.OnCrosswalkPressed(_intersection.SignalGroups[0].Roadway);
        }
        
        private void sunriserd_Click(object sender, EventArgs e)
        {
            syncObject.OnCrosswalkPressed(_intersection.SignalGroups[3].Roadway);
        }
        
        private void btn_em_r_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_em_l_Click(object sender, EventArgs e)
        {
           
        }
    }
}
