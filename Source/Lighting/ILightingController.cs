namespace Lighting
{

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
}
