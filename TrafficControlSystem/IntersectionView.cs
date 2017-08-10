using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficControlSystem
{

    /// <summary>
    /// This is the Graphical User Interface for the Traffic Control System. This gives the user a
    /// bird's eye view of the intersection. It also allows the user to interact with the intersection
    /// by activating the road (preempt) and emergency sensors and pressing the crosswalk buttons.
    /// </summary>
    public partial class IntersectionView : Form
    {
        private UISyncObject syncObject;

        private delegate void UpdateForm(Intersection intersection);

        private Intersection _intersection { get; set; }

        /// <summary>
        /// The constructor for the Traffic Control System graphical user interface.
        /// </summary>
        /// <param name="syncObject">This a UISyncObject passed by the intersection controller. This allows the GUI to subscribe to changes 
        /// in the intersection lights.</param>
        public IntersectionView(UISyncObject syncObject)
        {
            this.syncObject = syncObject;
            this.syncObject.TimeToUpdate += SyncObject_TimeToUpdate;
            this.FormClosing += IntersectionView_FormClosing;
            InitializeComponent();
        }

        private void IntersectionView_FormClosing(object sender, FormClosingEventArgs e)
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

                    this.picbox_left_bot.Invalidate();
                    this.picbox_right_bot.Invalidate();
                    this.picbox_left_top.Invalidate();
                    this.picbox_right_top.Invalidate();

                    crosswalk_universityblvd1.Update(signalGroup.Roadway.CrosswalkOkToWalk, signalGroup.Roadway.SignalShortRemainingTime, signalGroup.Roadway.CrossWalkRemainingDuration);
                    crosswalk_universityblvd2.Update(signalGroup.Roadway.CrosswalkOkToWalk, signalGroup.Roadway.SignalShortRemainingTime, signalGroup.Roadway.CrossWalkRemainingDuration);
                    crosswalk_universityblvd3.Update(signalGroup.Roadway.CrosswalkOkToWalk, signalGroup.Roadway.SignalShortRemainingTime, signalGroup.Roadway.CrossWalkRemainingDuration);
                    crosswalk_universityblvd4.Update(signalGroup.Roadway.CrosswalkOkToWalk, signalGroup.Roadway.SignalShortRemainingTime, signalGroup.Roadway.CrossWalkRemainingDuration);
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

                    this.picbox_turn_top.Invalidate();
                    this.picbox_turn_bot.Invalidate();
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

                    this.picbox_bot_right.Invalidate();
                    this.picbox_top_right.Invalidate();
                    this.picbox_bot_left.Invalidate();
                    this.picbox_top_left.Invalidate();

                    crosswalk_sunriserd1.Update(signalGroup.Roadway.CrosswalkOkToWalk, signalGroup.Roadway.SignalShortRemainingTime, signalGroup.Roadway.CrossWalkRemainingDuration);
                    crosswalk_sunriserd2.Update(signalGroup.Roadway.CrosswalkOkToWalk, signalGroup.Roadway.SignalShortRemainingTime, signalGroup.Roadway.CrossWalkRemainingDuration);
                    crosswalk_sunriserd3.Update(signalGroup.Roadway.CrosswalkOkToWalk, signalGroup.Roadway.SignalShortRemainingTime, signalGroup.Roadway.CrossWalkRemainingDuration);
                    crosswalk_sunriserd4.Update(signalGroup.Roadway.CrosswalkOkToWalk, signalGroup.Roadway.SignalShortRemainingTime, signalGroup.Roadway.CrossWalkRemainingDuration);
                }
            }

            //Refresh();
        }
        
        private void btn_preempt1_Click(object sender, EventArgs e)
        {

        }

        private void btn_preempt2_Click(object sender, EventArgs e)
        {

        }
        
        
        private void universityblvd_crosswalk_Click(object sender, EventArgs e)
        {
            syncObject.OnCrosswalkPressed_NorthSouth();
        }
        
        private void sunriserd_crosswalk_Click(object sender, EventArgs e)
        {
            syncObject.OnCrosswalkPressed_EastWest();
        }

        private void btn_em_top_Click(object sender, EventArgs e)
        {
            syncObject.OnEMTripped(0);
        }

        private void btn_em_r_Click(object sender, EventArgs e)
        {
            syncObject.OnEMTripped(1);
        }

        private void btn_em_bot_Click(object sender, EventArgs e)
        {
            syncObject.OnEMTripped(0);
        }

        private void btn_em_l_Click(object sender, EventArgs e)
        {
            syncObject.OnEMTripped(1);
        }

        private void IntersectionView_Load(object sender, EventArgs e)
        {

        }
        
        

       
    }
}
