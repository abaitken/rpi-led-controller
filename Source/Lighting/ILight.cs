namespace Lighting
{
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
