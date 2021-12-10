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
        /// Gets the current brightness
        /// </summary>
        byte Brightness { get; }
    }

    /// <summary>
    /// Represents a lighting controller
    /// </summary>
    public interface ILightingController : ILightingInformation
    {
        /// <summary>
        /// Updates the state of the lights
        /// </summary>
        void Update();

        /// <summary>
        /// Gets a light for the given index
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Light</returns>
        ILight this[int index] { get; }

        /// <summary>
        /// Gets or sets the current brightness
        /// </summary>
        new byte Brightness { get; set; }
    }

    /// <summary>
    /// Represents a single light
    /// </summary>
    public interface ILight
    {
        /// <summary>
        /// Gets or sets the colour of the light
        /// </summary>
        Color Color { get; set; }
    }
}
