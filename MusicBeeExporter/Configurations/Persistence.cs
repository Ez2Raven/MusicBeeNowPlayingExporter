using System.IO;
using Newtonsoft.Json;

namespace MusicBeeExporter.Configurations
{
    /// <summary>
    ///     Encapsulate MusicBee specific implementation of storage persistence away from plugin development.
    /// </summary>
    /// <seealso cref="MusicBeeExporter.Configurations.IPersistence" />
    public class Persistence : IPersistence
    {
        private readonly IPersistenceSettings _persistenceSettings;

        public Persistence(IPersistenceSettings persistenceSettings)
        {
            _persistenceSettings = persistenceSettings;
        }


        /// <summary>
        ///     Loads the persisted plugin settings json string from <see cref="PersistenceSettings.PluginStorageDirectory" />
        /// </summary>
        /// <returns></returns>
        public string LoadPluginSettings()
        {
            var pluginSettingJsonString = string.Empty;
            if (File.Exists(_persistenceSettings.MusicBeeExporterSettingsFilePath))
                using (var sr = new StreamReader(_persistenceSettings.MusicBeeExporterSettingsFilePath))
                {
                    pluginSettingJsonString = sr.ReadToEnd();
                }

            return pluginSettingJsonString;
        }

        /// <summary>
        ///     Saves the plugin settings json string into <see cref="PersistenceSettings.PluginStorageDirectory" />
        /// </summary>
        public void SavePluginSettings(IMusicBeeExporterSettings settings)
        {
            var customSettingJson = JsonConvert.SerializeObject(settings, Formatting.Indented);

            using (var sw = new StreamWriter(_persistenceSettings.MusicBeeExporterSettingsFilePath, false))
            {
                sw.Write(customSettingJson);
            }
        }

        /// <summary>
        ///     Purges the plugin folder.
        /// </summary>
        public void PurgePluginStorageFolder()
        {
            if (Directory.Exists(_persistenceSettings.PluginStorageDirectory))
                Directory.Delete(_persistenceSettings.PluginStorageDirectory, true);
        }
    }
}