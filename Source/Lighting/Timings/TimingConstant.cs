namespace Lighting.Timings
{
    public class TimingConstant : Timing
    {
        public override void Delay()
        {
            Sleep(25);
        }

        public override void Reset(int totalSteps)
        {
        }
    }
}
