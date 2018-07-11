﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TimeBeam.Timing
{
    public class TimeBeamClockImpl : IClock
    {
        public double Value { get; set; }

        private Stopwatch _stopwatch = new Stopwatch();

        private bool _isRunning;

        public bool IsRunning { get { return _isRunning; } }

        public void Pause()
        {
            _stopwatch.Stop();
            _isRunning = false;
        }

        public void Play()
        {
            _stopwatch.Start();
            _isRunning = true;
        }

        public void Reset()
        {
            _stopwatch.Reset();
            _isRunning = false;
        }

        public void Update()
        {
            if (IsRunning)
            {
                Value += _stopwatch.ElapsedMilliseconds;
                _stopwatch.Reset();
                _stopwatch.Start();
                _isRunning = true;
            }
        }
    }
}