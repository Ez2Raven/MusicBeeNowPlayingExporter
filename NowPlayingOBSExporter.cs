using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;


namespace MusicBeePlugin
{
    public partial class Plugin
    {
        private MusicBeeApiInterface _mbApiInterface;
        private readonly PluginInfo _about = new PluginInfo();


        public PluginInfo Initialise(IntPtr apiInterfacePtr)
        {
            //TODO: Add Serilog if .NET framework 4.5 can be used.

            _mbApiInterface = new MusicBeeApiInterface();
            _mbApiInterface.Initialise(apiInterfacePtr);
            _about.PluginInfoVersion = PluginInfoVersion;
            _about.Name = "MusicBee Now Playing OBS Exporter";
            _about.Description = "Export Now Playing music Metadata for OBS to consume and display during streaming.";
            _about.Author = "Raven Ng";
            _about.TargetApplication = "";   //  the name of a Plugin Storage device or panel header for a dockable panel
            _about.Type = PluginType.General;
            _about.VersionMajor = 1;  // your plugin version
            _about.VersionMinor = 0;
            _about.Revision = 0;
            _about.MinInterfaceVersion = MinInterfaceVersion;
            _about.MinApiRevision = MinApiRevision;
            _about.ReceiveNotifications = (ReceiveNotificationFlags.PlayerEvents | ReceiveNotificationFlags.TagEvents);
            _about.ConfigurationPanelHeight = 0;   // height in pixels that musicbee should reserve in a panel for config settings. When set, a handle to an empty panel will be passed to the Configure function
            return _about;
        }

        public bool Configure(IntPtr panelHandle)
        {
            // save any persistent settings in a sub-folder of this path
            string dataPath = _mbApiInterface.Setting_GetPersistentStoragePath();
            // panelHandle will only be set if you set about.ConfigurationPanelHeight to a non-zero value
            // keep in mind the panel width is scaled according to the font the user has selected
            // if about.ConfigurationPanelHeight is set to 0, you can display your own popup window
            if (panelHandle != IntPtr.Zero)
            {
                Panel configPanel = (Panel)Panel.FromHandle(panelHandle);
                Label prompt = new Label { AutoSize = true, Location = new Point(0, 0), Text = "prompt:" };
                TextBox textBox = new TextBox();
                textBox.Bounds = new Rectangle(60, 0, 100, textBox.Height);
                configPanel.Controls.AddRange(new Control[] { prompt, textBox });
            }
            return false;
        }

        // called by MusicBee when the user clicks Apply or Save in the MusicBee Preferences screen.
        // its up to you to figure out whether anything has changed and needs updating
        public void SaveSettings()
        {
            // save any persistent settings in a sub-folder of this path
            string dataPath = _mbApiInterface.Setting_GetPersistentStoragePath();
        }

        // MusicBee is closing the plugin (plugin is being disabled by user or MusicBee is shutting down)
        public void Close(PluginCloseReason reason)
        {
        }

        // uninstall this plugin - clean up any persisted files
        public void Uninstall()
        {
        }

        // receive event notifications from MusicBee
        // you need to set about.ReceiveNotificationFlags = PlayerEvents to receive all notifications, and not just the startup event
        public void ReceiveNotification(string sourceFileUrl, NotificationType type)
        {
            // perform some action depending on the notification type
            switch (type)
            {
                case NotificationType.PluginStartup:
                    // perform startup initialisation
                    switch (_mbApiInterface.Player_GetPlayState())
                    {
                        case PlayState.Playing:
                        case PlayState.Paused:
                            // ...
                            break;
                    }
                    break;

                case NotificationType.TrackChanged:
                    string artist = _mbApiInterface.NowPlaying_GetFileTag(MetaDataType.Artist);
                    if (string.IsNullOrWhiteSpace(artist))
                    {
                        artist = "Ask me: Artist Name";
                    }
                    using (StreamWriter sw =
                        new StreamWriter(@"F:\VideoEditing\Source\music-covers\Artist.txt", false))
                    {
                        sw.Write(artist);
                    }

                    string title = _mbApiInterface.NowPlaying_GetFileTag(MetaDataType.TrackTitle);
                    if (string.IsNullOrWhiteSpace(title))
                    {
                        title = "Ask me: Track Title";
                    }
                    using (StreamWriter sw =
                        new StreamWriter(@"F:\VideoEditing\Source\music-covers\Title.txt", false))
                    {
                        sw.Write(title);
                    }

                    string album = _mbApiInterface.NowPlaying_GetFileTag(MetaDataType.Album);
                    if (string.IsNullOrWhiteSpace(album))
                    {
                        album = "Ask me: Album Name";
                    }
                    using (StreamWriter sw =
                        new StreamWriter(@"F:\VideoEditing\Source\music-covers\Album.txt", false))
                    {
                        sw.Write(album);
                    }

                    var artwork = _mbApiInterface.NowPlaying_GetArtwork();
                    if (string.IsNullOrWhiteSpace(artwork))
                    {
                        artwork = "R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw==";
                    }
                    
                    var resizedArtworkImage = ResizedArtworkImage(artwork, 300, 300);
                    resizedArtworkImage.Save(@"F:\VideoEditing\Source\music-covers\Cover.jpg");

                    break;
            }
        }

        /// <summary>
        /// Renders a base64 image and resize it to the required width and height in high quality.
        /// </summary>
        /// <param name="artworkBase64"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private static Bitmap ResizedArtworkImage(string artworkBase64, int width, int height)
        {
            //Convert Base64 to image.
            byte[] imageBytes = Convert.FromBase64String(artworkBase64);

            Image artworkImage;
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                artworkImage = Image.FromStream(ms);
            }

            // now that the image is loaded in memory, we'll resize it.
            
            var destRect = new Rectangle(0, 0, width, height);
            var resizedArtworkImage = new Bitmap(width, height);

            resizedArtworkImage.SetResolution(artworkImage.HorizontalResolution, artworkImage.VerticalResolution);

            using (var graphics = Graphics.FromImage(resizedArtworkImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(artworkImage, destRect, 0, 0, artworkImage.Width, artworkImage.Height,
                        GraphicsUnit.Pixel, wrapMode);
                }
            }

            return resizedArtworkImage;
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