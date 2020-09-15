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
            txtArtworkWidth.Text = _settings.ArtworkOutputWidth.ToString();
            txtArtworkHeight.Text = _settings.ArtworkOutputHeight.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _settings.ArtworkOutputWidth = int.Parse(txtArtworkWidth.Text);
                _settings.ArtworkOutputHeight = int.Parse(txtArtworkHeight.Text);
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
            catch (FormatException)
            {
                UIHelper.DisplayMessageDialog(
                    "Artwork Height & Width must contain numbers only. Please modify them and save again.");

                txtArtworkWidth.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}