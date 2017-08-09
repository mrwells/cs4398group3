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
        public CrossWalk()
        {
            InitializeComponent();
        }

        public void SetWalk()
        {
            this.BackgroundImage = TrafficControlSystem.Properties.Resources.walking_man;
        }

        public void SetDontWalk()
        {
            this.BackgroundImage = TrafficControlSystem.Properties.Resources.upraised_hand;
        }

        public void SetDisplay(string displayText)
        {
            this.TimeLabel.Text = displayText;
        }
    }
}
