using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MusicBeePlugin
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, System.EventArgs e)
        {
            txtDefaultArtist.Text = CustomSettings.TrackDetails.Instance.DefaultArtistName;
            txtDefaultTrackTitle.Text = CustomSettings.TrackDetails.Instance.DefaultTrackTitle;
            txtDefaultAlbumName.Text = CustomSettings.TrackDetails.Instance.DefaultAlbumName;
            
            txtArtistOutputFile.Text = CustomSettings.TrackDetails.Instance.ArtworkOutputPath;
            txtTrackTitleOutputFile.Text = CustomSettings.TrackDetails.Instance.TrackTitleOutputPath;
            txtAlbumOutputFile.Text = CustomSettings.TrackDetails.Instance.AlbumNameOutputPath;
            txtArtworkOutputFile.Text = CustomSettings.TrackDetails.Instance.ArtworkOutputPath;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CustomSettings.TrackDetails.Instance.DefaultArtistName = txtDefaultArtist.Text;
            CustomSettings.TrackDetails.Instance.DefaultTrackTitle = txtDefaultTrackTitle.Text;
            CustomSettings.TrackDetails.Instance.DefaultAlbumName = txtDefaultAlbumName.Text;

            CustomSettings.TrackDetails.Instance.ArtistNameOutputPath = txtArtistOutputFile.Text;
            CustomSettings.TrackDetails.Instance.TrackTitleOutputPath = txtTrackTitleOutputFile.Text;
            CustomSettings.TrackDetails.Instance.AlbumNameOutputPath = txtAlbumOutputFile.Text;
            CustomSettings.TrackDetails.Instance.ArtworkOutputPath = txtArtworkOutputFile.Text;

            CustomSettings.Persistence.SavePluginSettings();
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
