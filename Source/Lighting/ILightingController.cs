namespace Lighting
{
    public interface ILightingController
    {
        int LightCount { get; }
        void Update();

        ILight this[int index] { get; }

        byte DefaultBrightness { get; }
        byte Brightness { get; set; }
    }

    public interface ILight
    {
        Color Color { get; set; }
    }
}
