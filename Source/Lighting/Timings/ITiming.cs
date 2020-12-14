using System.Collections.Generic;
using System.Text;

namespace Lighting.Timings
{
    public interface ITiming
    {
        void Reset(int totalSteps);
        void Delay();
    }
}
