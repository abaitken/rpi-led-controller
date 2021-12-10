namespace Lighting.Timings
{
    public class TimingConstant : Timing
    {
        public int Milliseconds { get; set; } = 25;

        public override void Delay()
        {
            Sleep(Milliseconds);
        }

        public override void Reset(int totalSteps)
        {
        }
    }
}
