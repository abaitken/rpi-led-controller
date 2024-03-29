﻿namespace Lighting
{
    /// <summary>
    /// Represents a single light
    /// </summary>
    public interface ILight : ILightInformation
    {
        /// <summary>
        /// Gets or sets the colour of the light
        /// </summary>
        new Color Color { get; set; }
    }
}
