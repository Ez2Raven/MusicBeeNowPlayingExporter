namespace MusicBeeExporter.Configurations
{
    public interface IPersistence
    {
        /// <summary>
        /// Loads the persisted plugin settings json string
        /// </summary>
        string LoadPluginSettings();

        /// <summary>Creates the data persistence folder if it does not exists and save the custom settings into a Json File</summary>
        /// 
        void SavePluginSettings(IMusicBeeExporterSettings pluginSettings);

        /// <summary>
        /// Purges the plugin folder.
        /// </summary>
        void PurgePluginStorageFolder();
    }
}