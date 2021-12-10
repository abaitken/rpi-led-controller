namespace Lighting.Patterns
{
    /// <summary>
    /// Represents colours across a lighting strip
    /// </summary>
    public interface IPatternInformation
    {
        /// <summary>
        /// Gets the current colour for the given index
        /// </summary>
        /// <param name="index">Light index</param>
        /// <returns>The current colour</returns>
        Color this[int index] { get; }
    }
}
