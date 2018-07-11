﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimeBeam;
using TimeBeam.Events;
using TimeBeam.Timing;
using TimeBeamTest.TestObjects;

namespace TimeBeamTest
{
    public partial class TimeBeamDemoForm : Form
    {
        private TimeBeamClockImpl _clock = new TimeBeamClockImpl();

        public TimeBeamDemoForm()
        {
            InitializeComponent();
        }

        private void TimeBeamDemoForm_Load(object sender, EventArgs e)
        {
            List<AdjustMyLength> tracks = new List<AdjustMyLength> {
        new AdjustMyLength{Start=0,  End=50, ID="Position X"},
        new AdjustMyLength{Start=20, End=150,ID="Position Y"},
        new AdjustMyLength{Start=220,End=550,ID="Position Z"},
        new AdjustMyLength{Start=520,End=650,ID="Rotation X"},
        new AdjustMyLength{Start=100,End=150,ID="Position Y"},
        new AdjustMyLength{Start=120,End=250,ID="Position Z"},
        new AdjustMyLength{Start=320,End=650,ID="Alpha"}
      };

            foreach (AdjustMyLength track in tracks)
            {
                timeline1.AddTrack(track);
            }

            timeline1.AddTrack(new AdjustMyParts(20) { ID = "Visible" });
            timeline1.AddTrack(new AdjustMyParts(0) { ID = "Visible" });

            timeline1.SelectionChanged += TimelineSelectionChanged;

            // Register the clock with the timeline
            timeline1.Clock = _clock;
            // Activate the timer that invokes the clock to update.
            timer1.Enabled = true;
        }

        private void TimelineSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            if (null != selectionChangedEventArgs.Deselected)
            {
                foreach (ITimelineTrackBase track in selectionChangedEventArgs.Deselected)
                {
                    Debug.WriteLine("Deselected: " + track);
                }
            }
            if (null != selectionChangedEventArgs.Selected)
            {
                foreach (ITimelineTrackBase track in selectionChangedEventArgs.Selected)
                {
                    Debug.WriteLine("Selected: " + track);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _clock.Update();
            timeline1.Tick();
        }

        private void TimeBeamDemoForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (_clock.IsRunning)
                {
                    _clock.Pause();
                    Debug.WriteLine("Clock paused.");
                }
                else
                {
                    _clock.Play();
                    Debug.WriteLine("Clock running.");
                }
            }
        }
    }
}