using System;

namespace Lighting.Timings
{
    public class TimingSlowDown : Timing
    {
        const int TIMING_SLOWEST = 300;
        const int TIMING_FASTEST = 10;
        private int _currentDelay;
        private int _timingChange;

        public override void Delay()
        {
            Sleep(_currentDelay);

            if (_currentDelay < TIMING_SLOWEST)
            {
                _currentDelay += _timingChange;
                if (_currentDelay > TIMING_SLOWEST)
                    _currentDelay = TIMING_SLOWEST;
            }
        }

        public override void Reset(int totalSteps)
        {
            _currentDelay = TIMING_FASTEST;
            _timingChange = (int)Math.Ceiling((double)(TIMING_SLOWEST - TIMING_FASTEST) / totalSteps);
        }
    }
}
