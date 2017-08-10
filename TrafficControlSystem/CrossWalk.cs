using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficControlSystem
{
    /// <summary>
    /// This is a usercontrol for a Crosswalk.
    /// </summary>
    public partial class CrossWalk : UserControl
    {
        private bool shortTimeImageToggle = false;

        /// <summary>
        /// Constructor for the Crosswalk usercontrol.
        /// </summary>
        public CrossWalk()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updates the crosswalk signal and countdown label if needed for the Crosswalk usercontrol.
        /// </summary>
        /// <param name="shouldWalk">A boolean that specifies if the crosswalk should toggle through the walk sequence.</param>
        /// <param name="shortTimeRemaining">A boolean that specifies if the crosswalk should show the flashing hand and countdown timer.</param>
        /// <param name="timeRemaining">An integer that specifies the remaining time for the crosswalk light sequence.</param>
        public void Update(bool shouldWalk, bool shortTimeRemaining, int timeRemaining)
        {
            if (shouldWalk)
            {
                if (shortTimeRemaining)
                {
                    if (shortTimeImageToggle)
                    {
                        if (BackgroundImage != Properties.Resources.upraised_hand)
                            BackgroundImage = Properties.Resources.upraised_hand;
                    }
                    else
                    {
                        if (BackgroundImage != Properties.Resources.blank_cw)
                            BackgroundImage = Properties.Resources.blank_cw;
                    }

                    shortTimeImageToggle = !shortTimeImageToggle;
                    TimeLabel.Visible = true;
                }
                else
                {
                    if (BackgroundImage != Properties.Resources.walking_man)
                        BackgroundImage = Properties.Resources.walking_man;
                    TimeLabel.Visible = false;
                }
                TimeLabel.Text = (timeRemaining / 1000).ToString();
            }
            else
            {
                if (BackgroundImage != Properties.Resources.upraised_hand)
                    BackgroundImage = Properties.Resources.upraised_hand;
                TimeLabel.Text = "";
                TimeLabel.Visible = false;
            }            
        }
    }
}
