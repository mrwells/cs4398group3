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
    public partial class CrossWalk : UserControl
    {
        private bool shortTimeImageToggle = false;

        public CrossWalk()
        {
            InitializeComponent();
        }

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
