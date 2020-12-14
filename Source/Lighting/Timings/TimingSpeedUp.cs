using System;

namespace Lighting.Timings
{
    public class TimingSpeedUp : Timing
    {
        const int TIMING_SLOWEST = 300;
        const int TIMING_FASTEST = 10;
        private int _currentDelay;
        private int _timingChange;

        public override void Delay()
        {
            Sleep(_currentDelay);

            if (_currentDelay > TIMING_FASTEST)
            {
                _currentDelay -= _timingChange;
                if (_currentDelay < TIMING_FASTEST)
                    _currentDelay = TIMING_FASTEST;
            }
        }

        public override void Reset(int totalSteps)
        {
            _currentDelay = TIMING_SLOWEST;
            _timingChange = (int)Math.Ceiling((double)(TIMING_SLOWEST - TIMING_FASTEST) / totalSteps);
        }
    }
}
