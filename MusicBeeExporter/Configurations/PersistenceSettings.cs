using System.IO;

namespace MusicBeeExporter.Configurations
{
    public interface IPersistenceSettings
    {
        string PluginStorageDirectory { get; }
        string MusicBeeExporterSettingsFilePath { get; }

        /// <summary>
        ///     Gets or sets the storage path allocated by MusicBee
        /// </summary>
        /// <value>
        ///     The allocated storage absolute path.
        /// </value>
        string MusicBeeAllocatedStoragePath { get; set; }

        string DefaultArtistOutputPath { get; }
        string DefaultTrackTitleOutputPath { get; }
        string DefaultAlbumNameOutputPath { get; }
        string DefaultArtworkOutputPath { get; }
    }

    public class PersistenceSettings : IPersistenceSettings
    {
        public const string FolderName = "ObsExporterPlugin";
        public const string TrackDetailFilename = "MusicBeeExporterSettings.json";

        private const string DefaultArtworkOutputFilename = "cover.png";
        private const string DefaultArtistNameOutputFilename = "artist.txt";
        private const string DefaultAlbumNameOutputFilename = "album.txt";
        private const string DefaultTrackTitleOutputFilename = "title.txt";

        private string _musicBeeAllocatedStoragePath = string.Empty;
        public string DefaultArtworkOutputPath => Path.Combine(PluginStorageDirectory, DefaultArtworkOutputFilename);

        public string DefaultArtistOutputPath => Path.Combine(PluginStorageDirectory, DefaultArtistNameOutputFilename);

        public string DefaultTrackTitleOutputPath =>
            Path.Combine(PluginStorageDirectory, DefaultTrackTitleOutputFilename);

        public string DefaultAlbumNameOutputPath =>
            Path.Combine(PluginStorageDirectory, DefaultAlbumNameOutputFilename);

        public string PluginStorageDirectory { get; private set; } = string.Empty;
        public string MusicBeeExporterSettingsFilePath { get; private set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the storage path allocated by MusicBee
        /// </summary>
        /// <value>
        ///     The allocated storage absolute path.
        /// </value>
        public string MusicBeeAllocatedStoragePath
        {
            get => _musicBeeAllocatedStoragePath;
            set
            {
                _musicBeeAllocatedStoragePath = value;

                // atomically update plugin storage path
                PluginStorageDirectory = Path.Combine(MusicBeeAllocatedStoragePath, FolderName);

                // atomically update track detail configuration path
                MusicBeeExporterSettingsFilePath = Path.Combine(PluginStorageDirectory, TrackDetailFilename);
            }
        }
    }
}