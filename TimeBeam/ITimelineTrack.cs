using System.Drawing;
namespace TimeBeam
{
    /// <summary>
    ///   Describes an item that can be placed on a track in the timeline.
    /// </summary>
    public interface ITimelineTrack : ITimelineTrackBase
    {
        /// <summary>
        ///   The beginning of the item.
        /// </summary>
        float Start { get; set; }

        /// <summary>
        ///   The end of the item.
        /// </summary>
        float End { get; set; }

        /// <summary>
        /// Track Background
        /// </summary>
        Color BackgroundColor { get; set; }

        /// <summary>
        /// Track Font Color
        /// </summary>
        Color ForeColor { get; set; }

        /// <summary>
        /// Track Font
        /// </summary>
        Font Font { get; set; }

        /// <summary>
        /// Track Text
        /// </summary>
        string Text { get; set; }
    }
}