using System;

namespace Lighting.Timings
{
    public class TimingSlowDown : Timing
    {
        public int StartDelay { get; set; } = 10;
        public int EndDelay { get; set; } = 300;

        private int _currentDelay;
        private int _timingChange;

        public override void Delay()
        {
            Sleep(_currentDelay);

            if (_currentDelay < EndDelay)
            {
                _currentDelay += _timingChange;
                if (_currentDelay > EndDelay)
                    _currentDelay = EndDelay;
            }
        }

        public override void Reset(int totalSteps)
        {
            _currentDelay = StartDelay;
            _timingChange = (int)Math.Ceiling((double)(EndDelay - StartDelay) / totalSteps);
        }
    }
}
