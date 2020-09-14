namespace MusicBeeExporter.Configurations
{
    /// <summary>
    ///     Contains Application constant values.
    /// </summary>
    public static class MusicBeeExporterConstants
    {
        /// <summary>
        ///     Plug-in's name
        /// </summary>
        public const string Name = "MusicBee Now Playing Exporter";

        /// <summary>
        ///     Plug-in's Description
        /// </summary>
        public const string Description =
            "Export Now Playing music Metadata so that they can be display within streaming software.";

        public const string Author = "Raven Ng";

        /// <summary>
        ///     Plug-in's major version number
        /// </summary>
        public const short VersionMajor = 1;

        /// <summary>
        ///     Plug-in's minor version number
        /// </summary>
        public const short VersionMinor = 0;

        /// <summary>
        ///     Plug-in's revision number
        /// </summary>
        public const short Revision = 2;

        /// <summary>
        ///     The name of a Plugin Storage device or panel header for a dockable panel
        /// </summary>
        public const string TargetApplication = "";

        /// <summary>
        ///     Height in pixels that MusicBee should reserve in a panel for config settings.
        ///     When set, a handle to an empty panel will be passed to the Configure function
        /// </summary>
        public const int ConfigurationPanelHeight = 0;
    }
}