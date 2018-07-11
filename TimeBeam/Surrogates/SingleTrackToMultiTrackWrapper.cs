using System;
using System.Collections.Generic;
using TimeBeam.Helper;

namespace TimeBeam.Surrogates
{
    /// <summary>
    ///   Wraps a single <see cref="ITimelineTrack" /> into an
    ///   <see cref="IMultiPartTimelineTrack" />.
    /// </summary>
    internal class SingleTrackToMultiTrackWrapper : IMultiPartTimelineTrack
    {
        /// <summary>
        ///   The elements within this track.
        /// </summary>
        public IEnumerable<ITimelineTrack> TrackElements
        {
            get { return _wrappedTrack.Yield(); }
        }

        /// <summary>
        ///   The wrapped timeline track.
        /// </summary>
        private readonly ITimelineTrack _wrappedTrack;

        /// <summary>
        ///   The name of the track.
        ///   This will be displayed alongside the track in the timeline.
        /// </summary>
        public string ID
        {
            get { return _wrappedTrack.ID; }
            set { _wrappedTrack.ID = value; }
        }

        /// <summary>
        ///   Construct a new SingleTrackToMultiTrackWrapper.
        /// </summary>
        /// <param name="track">The timeline track that should be wrapped.</param>
        public SingleTrackToMultiTrackWrapper(ITimelineTrack track)
        {
            _wrappedTrack = track;
            DisplayText = _wrappedTrack.DisplayText;
            ID = "DeviceParts_" + Guid.NewGuid().ToString();
        }

        public string DisplayText { get; set; }
    }
}