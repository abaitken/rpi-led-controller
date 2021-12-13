namespace Lighting
{
    public abstract class LightingController : ILightingController
    {
        public abstract ILight this[int index] { get; }

        ILightInformation ILightingInformation.this[int index] => this[index];

        public abstract byte Brightness { get; set; }
        public abstract int LightCount { get; }
        public abstract byte DefaultBrightness { get; }

        byte ILightingInformation.Brightness => Brightness;

        public abstract void Update();
    }
}
