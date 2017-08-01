using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace TrafficControlSystem
{
    class LightGroup
    {
        private enum light_color { red, green, yellow};
        private light_color color;
        private List<int> lanes;
        private int green_time;
        private int yellow_time;
        private int walk_time;
        private int countdown_hand_time;

        public LightGroup(int groupid, Configuration config)
        {
            //get initial light color: light_color = start color from config
            //get initial time for this group to have a green light: green_time = green time from config
            //get the time for this group to have a yellow light: yellow_time = yellow time from config
            //get 
        }




    }
}
