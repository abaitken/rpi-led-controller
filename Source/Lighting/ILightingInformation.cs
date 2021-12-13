namespace Lighting
{
    /// <summary>
    /// Represents read-only information about the lighting
    /// </summary>
    public interface ILightingInformation
    {
        /// <summary>
        /// Gets the number of lights
        /// </summary>
        int LightCount { get; }

        /// <summary>
        /// Gets the default brightness
        /// </summary>
        byte DefaultBrightness { get; }

        /// <summary>
        /// Gets a light for the given index
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Light</returns>
        ILightInformation this[int index] { get; }

        /// <summary>
        /// Gets the current brightness
        /// </summary>
        byte Brightness { get; }
    }
}
