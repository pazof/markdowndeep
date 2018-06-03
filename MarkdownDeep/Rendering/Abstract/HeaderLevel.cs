using System;

namespace MarkdownDeep.Rendering.Abstract
{
    /// <summary>
    /// Header level.
    /// Higher this level is, as int, the less it is important, 
    /// and the less is the positive integer suffixing its name 
    /// </summary>
	public enum HeaderLevel: int
	{
        /// <summary>
        /// The h6 (minimum).
        /// </summary>
        H6, 
        /// <summary>
        /// The minimum (H6).
        /// </summary>
        Min = H6,
        /// <summary>
        /// The h5.
        /// </summary>
        H5, 
        /// <summary>
        /// The h4.
        /// </summary>
        H4, 
        /// <summary>
        /// The h3.
        /// </summary>
        H3, 
        /// <summary>
        /// The h2.
        /// </summary>
        H2, 
        /// <summary>
        /// The h1. (the highest level)
        /// </summary>
        H1, 
        /// <summary>
        /// The max.
        /// </summary>
        Max = H1
	}
}

