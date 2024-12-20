namespace Lighting.Palette
{
    public class PaletteFixed : Palette
    {
        private readonly Color[] _colors;

        public PaletteFixed(params Color[] colors)
        {
            _colors = colors;
        }

        public override Color[] Colors => _colors;
    }
}
