using Newtonsoft.Json;

namespace MusicBeeExporter.Configurations
{
    [JsonObject(MemberSerialization.OptIn)]
    public interface IMusicBeeExporterSettings
    {
        /// <summary>
        ///     Default cover art image in Base64 string
        /// </summary>
        [JsonProperty]
        string DefaultCoverArt { get; set; }

        /// <summary>
        ///     Default string value to use if the artist name is missing from MusicBee's tag details
        /// </summary>
        [JsonProperty]
        string DefaultArtistName { get; set; }

        /// <summary>
        ///     Default string value to use if the Track Title is missing from MusicBee's tag details
        /// </summary>
        [JsonProperty]
        string DefaultTrackTitle { get; set; }

        /// <summary>
        ///     Default string value to use if the album name is missing from MusicBee's tag details
        /// </summary>
        [JsonProperty]
        string DefaultAlbumName { get; set; }

        /// <summary>
        ///     Location of the text file where the artist name is captured.
        ///     If undefined, the album name will be stored in OBS Exporter's default output directory
        /// </summary>
        [JsonProperty]
        string ArtistNameOutputPath { get; set; }

        /// <summary>
        ///     Location of the text file where the track title is captured.
        ///     If undefined, the album name will be stored in OBS Exporter's default output directory
        /// </summary>
        [JsonProperty]
        string TrackTitleOutputPath { get; set; }

        /// <summary>
        ///     Location of the text file where the album name is captured.
        ///     If undefined, the album name will be stored in OBS Exporter's default output directory
        /// </summary>
        [JsonProperty]
        string AlbumNameOutputPath { get; set; }

        /// <summary>
        ///     Location of the image file where the Track's artwork is captured.
        /// </summary>
        [JsonProperty]
        string ArtworkOutputPath { get; set; }

        /// <summary>
        ///     Expected height (in pixels) of the artwork after it is resized by this plugin. Defaults to 300px
        /// </summary>
        [JsonProperty]
        int ArtworkOutputHeight { get; set; }

        /// <summary>
        ///     Expected width (in pixels) of the artwork after it is resized by this plugin. Defaults to 300px
        /// </summary>
        [JsonProperty]
        int ArtworkOutputWidth { get; set; }
    }
}