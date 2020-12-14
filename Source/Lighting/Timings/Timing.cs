using System.Threading;

namespace Lighting.Timings
{
    public abstract class Timing : ITiming
    {
        public abstract void Delay();
        public abstract void Reset(int totalSteps);

        protected void Sleep(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
    }
}
