using System;
using System.IO;
using MusicBeeExporter.Configurations;
using MusicBeeExporter.ImageProcessing;
using Newtonsoft.Json;

namespace MusicBeePlugin
{
    public partial class Plugin
    {
        private readonly PluginInfo _about = new PluginInfo();
        private MusicBeeApiInterface _mbApiInterface;
        private IMusicBeeExporterSettings _pluginSettings;
        private IPersistence _repo;

        public PluginInfo Initialise(IntPtr apiInterfacePtr)
        {
            try
            {
                _mbApiInterface = new MusicBeeApiInterface();
                _mbApiInterface.Initialise(apiInterfacePtr);
                _about.PluginInfoVersion = PluginInfoVersion;
                _about.Name = MusicBeeExporterConstants.Name;
                _about.Description = MusicBeeExporterConstants.Description;
                _about.Author = MusicBeeExporterConstants.Author;
                _about.TargetApplication =
                    MusicBeeExporterConstants
                        .TargetApplication;
                _about.Type = PluginType.General;
                _about.VersionMajor = MusicBeeExporterConstants.VersionMajor;
                _about.VersionMinor = MusicBeeExporterConstants.VersionMinor;
                _about.Revision = MusicBeeExporterConstants.Revision;
                _about.MinInterfaceVersion = MinInterfaceVersion;
                _about.MinApiRevision = MinApiRevision;
                _about.ReceiveNotifications =
                    ReceiveNotificationFlags.PlayerEvents | ReceiveNotificationFlags.TagEvents;
                _about.ConfigurationPanelHeight =
                    MusicBeeExporterConstants.ConfigurationPanelHeight;

                // Initialize the plugin after music bee api interface is initialized and the PersistentStoragePath is accessible
                IPersistenceSettings persistenceSettings = new PersistenceSettings
                {
                    MusicBeeAllocatedStoragePath = _mbApiInterface.Setting_GetPersistentStoragePath()
                };


                // Create Plugin Storage folder
                Directory.CreateDirectory(persistenceSettings.PluginStorageDirectory);

                _repo = new Persistence(persistenceSettings);

                // Load exporter settings if it exists, otherwise create a new settings file.
                var settingJson = _repo.LoadPluginSettings();

                if (!string.IsNullOrWhiteSpace(settingJson))
                {
                    _pluginSettings = JsonConvert.DeserializeObject<MusicBeeExporterSettings>(settingJson);
                }
                else
                {
                    _pluginSettings = new MusicBeeExporterSettings(persistenceSettings);
                    _repo.SavePluginSettings(_pluginSettings);
                }
            }
            catch (Exception ex)
            {
                UIHelper.DisplayExceptionDialog(ex);
            }

            return _about;
        }

        public bool Configure(IntPtr panelHandle)
        {
            // panelHandle will only be set if you set about.ConfigurationPanelHeight to a non-zero value
            // keep in mind the panel width is scaled according to the font the user has selected
            // if about.ConfigurationPanelHeight is set to 0, you can display your own popup window
            if (panelHandle == IntPtr.Zero)
            {
                // show a windows form for configuration, since we initialize configuration panel height to 0.
                var settingsForm = new SettingsForm(_pluginSettings, _repo);
                settingsForm.Show();
            }

            return false;
        }

        // called by MusicBee when the user clicks Apply or Save in the MusicBee Preferences screen.
        // its up to you to figure out whether anything has changed and needs updating
        public void SaveSettings()
        {
            // plugin settings state is handled by the settings form
        }

        // MusicBee is closing the plugin (plugin is being disabled by user or MusicBee is shutting down)
        public void Close(PluginCloseReason reason)
        {
        }

        // uninstall this plugin - clean up any persisted files
        public void Uninstall()
        {
            _repo.PurgePluginStorageFolder();
        }

        // receive event notifications from MusicBee
        // you need to set about.ReceiveNotificationFlags = PlayerEvents to receive all notifications, and not just the startup event
        public void ReceiveNotification(string sourceFileUrl, NotificationType type)
        {
            // perform some action depending on the notification type
            switch (type)
            {
                case NotificationType.TrackChanged:
                    try
                    {
                        var artist = _mbApiInterface.NowPlaying_GetFileTag(MetaDataType.Artist);
                        if (string.IsNullOrWhiteSpace(artist))
                            artist = _pluginSettings.DefaultArtistName;

                        using (var sw =
                            new StreamWriter(_pluginSettings.ArtistNameOutputPath, false))
                        {
                            sw.Write(artist);
                        }

                        var title = _mbApiInterface.NowPlaying_GetFileTag(MetaDataType.TrackTitle);
                        if (string.IsNullOrWhiteSpace(title))
                            title = _pluginSettings.DefaultTrackTitle;
                        using (var sw =
                            new StreamWriter(_pluginSettings.TrackTitleOutputPath, false))
                        {
                            sw.Write(title);
                        }

                        var album = _mbApiInterface.NowPlaying_GetFileTag(MetaDataType.Album);
                        if (string.IsNullOrWhiteSpace(album))
                            album = _pluginSettings.DefaultAlbumName;
                        using (var sw =
                            new StreamWriter(_pluginSettings.AlbumNameOutputPath, false))
                        {
                            sw.Write(album);
                        }

                        var artwork = _mbApiInterface.NowPlaying_GetArtwork();
                        if (string.IsNullOrWhiteSpace(artwork))
                            artwork = _pluginSettings.DefaultCoverArt;

                        var resizedArtworkImage = ImageHelper.ResizedArtworkImage(artwork,
                            _pluginSettings.ArtworkOutputWidth,
                            _pluginSettings.ArtworkOutputHeight);
                        resizedArtworkImage.Save(_pluginSettings.ArtworkOutputPath);
                    }
                    catch (UnauthorizedAccessException unauthorizedAccessException)
                    {
                        UIHelper.DisplayExceptionDialog(unauthorizedAccessException,
                            "Plugin does not have permission to store files in defined output folder.");
                    }
                    catch (DirectoryNotFoundException directoryNotFoundException)
                    {
                        UIHelper.DisplayExceptionDialog(directoryNotFoundException,
                            "Invalid output file path, Please check plugin settings.");
                    }
                    catch (IOException ioException)
                    {
                        UIHelper.DisplayExceptionDialog(ioException,
                            @"Invalid output file, Please check plugin settings");
                    }
                    catch (Exception ex)
                    {
                        UIHelper.DisplayExceptionDialog(ex);
                    }

                    break;
            }
        }

        // return an array of lyric or artworkBase64 provider names this plugin supports
        // the providers will be iterated through one by one and passed to the RetrieveLyrics/ RetrieveArtwork function in order set by the user in the MusicBee Tags(2) preferences screen until a match is found
        //public string[] GetProviders()
        //{
        //    return null;
        //}

        // return lyrics for the requested artist/title from the requested provider
        // only required if PluginType = LyricsRetrieval
        // return null if no lyrics are found
        //public string RetrieveLyrics(string sourceFileUrl, string artist, string trackTitle, string album, bool synchronisedPreferred, string provider)
        //{
        //    return null;
        //}

        // return Base64 string representation of the artworkBase64 binary data from the requested provider
        // only required if PluginType = ArtworkRetrieval
        // return null if no artworkBase64 is found
        //public string RetrieveArtwork(string sourceFileUrl, string albumArtist, string album, string provider)
        //{
        //    //Return Convert.ToBase64String(artworkBinaryData)
        //    return null;
        //}

        //  presence of this function indicates to MusicBee that this plugin has a dockable panel. MusicBee will create the control and pass it as the panel parameter
        //  you can add your own controls to the panel if needed
        //  you can control the scrollable area of the panel using the mbApiInterface.MB_SetPanelScrollableArea function
        //  to set a MusicBee header for the panel, set about.TargetApplication in the Initialise function above to the panel header text
        //public int OnDockablePanelCreated(Control panel)
        //{
        //  //    return the height of the panel and perform any initialisation here
        //  //    MusicBee will call panel.Dispose() when the user removes this panel from the layout configuration
        //  //    < 0 indicates to MusicBee this control is resizable and should be sized to fill the panel it is docked to in MusicBee
        //  //    = 0 indicates to MusicBee this control resizeable
        //  //    > 0 indicates to MusicBee the fixed height for the control.Note it is recommended you scale the height for high DPI screens(create a graphics object and get the DpiY value)
        //    float dpiScaling = 0;
        //    using (Graphics g = panel.CreateGraphics())
        //    {
        //        dpiScaling = g.DpiY / 96f;
        //    }
        //    panel.Paint += panel_Paint;
        //    return Convert.ToInt32(100 * dpiScaling);
        //}

        // presence of this function indicates to MusicBee that the dockable panel created above will show menu items when the panel header is clicked
        // return the list of ToolStripMenuItems that will be displayed
        //public List<ToolStripItem> GetHeaderMenuItems()
        //{
        //    List<ToolStripItem> list = new List<ToolStripItem>();
        //    list.Add(new ToolStripMenuItem("A menu item"));
        //    return list;
        //}

        //private void panel_Paint(object sender, PaintEventArgs e)
        //{
        //    e.Graphics.Clear(Color.Red);
        //    TextRenderer.DrawText(e.Graphics, "hello", SystemFonts.CaptionFont, new Point(10, 10), Color.Blue);
        //}
    }
}