﻿namespace Compact.Routes
{
    public class Link
    {
        /// <summary>
        /// The URL which cmpct.io links too, as provided by the user.
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// The route processor generated page title for the link
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The filename of a screenshot captured by the route processor
        /// </summary>
        public string ScreenshotFileName { get; set; }
    }
}