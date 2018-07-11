using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using TimeBeam;

namespace TimeBeamTest.TestObjects
{
    class AdjustMyLength : ITimelineTrack
    {
        public AdjustMyLength()
        {
            BackgroundColor = Color.LightBlue;
            ForeColor = Color.White;
            Font = new Font("宋体",12);
            DisplayText = "哈哈";
            //DisplayIcon = System.Drawing.Image.FromFile("c:\\a.png");
        }

        public float Start { get; set; }
        public float End { get; set; }
        public string ID { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, End: {1}, Start: {2}", ID, End, Start);
        }

        public System.Drawing.Color BackgroundColor { get; set; }

        public System.Drawing.Color ForeColor { get; set; }

        public System.Drawing.Font Font { get; set; }

        public string DisplayText { get; set; }

        public Image DisplayIcon { get; set; }
    }
}