namespace TimeBeam
{
    /// <summary>
    ///   Common interface members for elements that can serve as timeline tracks.
    /// </summary>
    public interface ITimelineTrackBase
    {
        /// <summary>
        ///   The ID of the track.
        ///   This will be displayed alongside the track in the timeline.
        /// </summary>
        string ID { get; set; }
    }
}