using Newtonsoft.Json;

namespace MusicBeeExporter.Configurations
{
    public class MusicBeeExporterSettings : IMusicBeeExporterSettings
    {
        private const string DefaultArtWork =
            @"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";

        private string _albumNameOutputPath;
        private string _artistNameOutputPath;
        private string _artworkOutputPath;
        private IPersistenceSettings _persistenceSettings;
        private string _trackTitleOutputPath;

        public MusicBeeExporterSettings(IPersistenceSettings persistenceSettings)
        {
            _persistenceSettings = persistenceSettings;
        }

        /// <summary>
        ///     Default cover art image in Base64 string
        /// </summary>
        public string DefaultCoverArt { get; set; } = DefaultArtWork;


        /// <summary>
        ///     Default string value to use if the artist name is missing from MusicBee's tag details
        /// </summary>
        public string DefaultArtistName { get; set; } = "Ask in chat - Artist Name";

        /// <summary>
        ///     Default string value to use if the Track Title is missing from MusicBee's tag details
        /// </summary>
        public string DefaultTrackTitle { get; set; } = "Ask in chat - Music Title";

        /// <summary>
        ///     Default string value to use if the album name is missing from MusicBee's tag details
        /// </summary>
        public string DefaultAlbumName { get; set; } = "Ask in chat - Album Name";

        /// <summary>
        ///     Location of the text file where the artist name is captured.
        ///     If undefined, the album name will be stored in OBS Exporter's default output directory
        /// </summary>
        public string ArtistNameOutputPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_artistNameOutputPath))
                    _artistNameOutputPath = _persistenceSettings.DefaultArtistOutputPath;


                return _artistNameOutputPath;
            }
            set => _artistNameOutputPath = value;
        }

        /// <summary>
        ///     Location of the text file where the track title is captured.
        ///     If undefined, the album name will be stored in OBS Exporter's default output directory
        /// </summary>
        public string TrackTitleOutputPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_trackTitleOutputPath))
                    _trackTitleOutputPath = _persistenceSettings.DefaultTrackTitleOutputPath;
                return _trackTitleOutputPath;
            }
            set => _trackTitleOutputPath = value;
        }

        /// <summary>
        ///     Location of the text file where the album name is captured.
        ///     If undefined, the album name will be stored in OBS Exporter's default output directory
        /// </summary>
        public string AlbumNameOutputPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_albumNameOutputPath))
                    _albumNameOutputPath = _persistenceSettings.DefaultAlbumNameOutputPath;
                return _albumNameOutputPath;
            }
            set => _albumNameOutputPath = value;
        }

        /// <summary>
        ///     Location of the image file where the Track's artwork is captured.
        /// </summary>
        [JsonProperty]
        public string ArtworkOutputPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_artworkOutputPath))
                    _artworkOutputPath = _persistenceSettings.DefaultArtworkOutputPath;
                return _artworkOutputPath;
            }
            set => _artworkOutputPath = value;
        }

        /// <summary>
        ///     Expected height (in pixels) of the artwork after it is resized by this plugin. Defaults to 300px
        /// </summary>
        public int ArtworkOutputHeight { get; set; } = 300;

        /// <summary>
        ///     Expected width (in pixels) of the artwork after it is resized by this plugin. Defaults to 300px
        /// </summary>
        public int ArtworkOutputWidth { get; set; } = 300;
    }
}