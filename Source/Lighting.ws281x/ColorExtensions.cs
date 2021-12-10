using Lighting;

namespace LightingConsole
{
    static class ColorExtensions
    {
        public static System.Drawing.Color ToColor(this Color color)
        {
            return System.Drawing.Color.FromArgb(color.R, color.G, color.B);
        }
        public static Color ToColor(this System.Drawing.Color color)
        {
            return new Color(color.R, color.G, color.B);
        }
    }
}