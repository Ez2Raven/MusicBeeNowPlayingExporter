using System;
using System.Windows.Forms;
using MusicBeeExporter.Configurations;

namespace MusicBeePlugin
{
    public partial class SettingsForm : Form
    {
        private readonly IPersistence _repo;
        private readonly IMusicBeeExporterSettings _settings;

        public SettingsForm(IMusicBeeExporterSettings settings, IPersistence repo)
        {
            _settings = settings;
            _repo = repo;
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            txtDefaultArtist.Text = _settings.DefaultArtistName;
            txtDefaultTrackTitle.Text = _settings.DefaultTrackTitle;
            txtDefaultAlbumName.Text = _settings.DefaultAlbumName;

            txtArtistOutputFile.Text = _settings.ArtistNameOutputPath;
            txtTrackTitleOutputFile.Text = _settings.TrackTitleOutputPath;
            txtAlbumOutputFile.Text = _settings.AlbumNameOutputPath;
            txtArtworkOutputFile.Text = _settings.ArtworkOutputPath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _settings.DefaultArtistName = txtDefaultArtist.Text;
            _settings.DefaultTrackTitle = txtDefaultTrackTitle.Text;
            _settings.DefaultAlbumName = txtDefaultAlbumName.Text;

            _settings.ArtistNameOutputPath = txtArtistOutputFile.Text;
            _settings.TrackTitleOutputPath = txtTrackTitleOutputFile.Text;
            _settings.AlbumNameOutputPath = txtAlbumOutputFile.Text;
            _settings.ArtworkOutputPath = txtArtworkOutputFile.Text;

            _repo.SavePluginSettings(_settings);
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}