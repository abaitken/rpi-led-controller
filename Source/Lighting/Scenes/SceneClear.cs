using Lighting.Animations;
using Lighting.Patterns;
using Lighting.Timings;

namespace Lighting.Scenes
{
    /// <summary>
    /// Clears the lighting strip
    /// </summary>
    public class SceneClear : SceneSimple
    {
        public override IAnimation CreateAnimation()
        {
            return new AnimationInstant();
        }

        public override IPattern CreatePattern()
        {
            return new PatternClear();
        }

        public override ITiming CreateTiming()
        {
            return new TimingNone();
        }
    }
}
