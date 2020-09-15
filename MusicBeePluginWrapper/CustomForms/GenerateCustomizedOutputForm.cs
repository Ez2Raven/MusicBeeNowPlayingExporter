using System;
using System.IO;
using System.Windows.Forms;
using MusicBeeExporter.Configurations;
using MusicBeeExporter.Imaging;

namespace MusicBeePlugin.CustomForms
{
    public partial class GenerateCustomizedOutputForm : Form
    {
        private readonly IMusicBeeExporterSettings _settings;

        public GenerateCustomizedOutputForm(IMusicBeeExporterSettings settings)
        {
            _settings = settings;
            InitializeComponent();
        }

        private void GenerateCustomizedOutputForm_Load(object sender, EventArgs e)
        {
            txtArtist.Text = _settings.DefaultArtistName;
            txtTrackTitle.Text = _settings.DefaultTrackTitle;
            txtAlbumName.Text = _settings.DefaultAlbumName;

            txtArtistOutputFile.Text = _settings.ArtistNameOutputPath;
            txtTrackTitleOutputFile.Text = _settings.TrackTitleOutputPath;
            txtAlbumOutputFile.Text = _settings.AlbumNameOutputPath;
            txtArtworkOutputFile.Text = _settings.ArtworkOutputPath;

            txtArtworkWidth.Text = _settings.ArtworkOutputWidth.ToString();
            txtArtworkHeight.Text = _settings.ArtworkOutputHeight.ToString();
        }

        private void btnGenerateAndExit_Click(object sender, EventArgs e)
        {
            GenerateCustomTrackInfo();
            Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateCustomTrackInfo();
        }

        private void GenerateCustomTrackInfo()
        {
            try
            {
                using (var sw = new StreamWriter(txtArtistOutputFile.Text, false))
                {
                    sw.Write(txtArtist.Text);
                }

                using (var sw = new StreamWriter(txtTrackTitleOutputFile.Text, false))
                {
                    sw.Write(txtTrackTitle.Text);
                }

                using (var sw = new StreamWriter(txtAlbumOutputFile.Text, false))
                {
                    sw.Write(txtAlbumName.Text);
                }

                bool isDefaultSizeUsed = false;
                var isValidWidth = int.TryParse(txtArtworkWidth.Text, out var width);
                var isValidHeight = int.TryParse(txtArtworkHeight.Text, out var height);

                if (!isValidWidth || !isValidHeight)
                {
                    height = _settings.ArtworkOutputHeight;
                    width = _settings.ArtworkOutputWidth;
                    isDefaultSizeUsed = true;
                }
                GenerateDefaultArtwork(width, height, txtArtworkOutputFile.Text);

                string successMessage = "Successfully generated output.";
                if (isDefaultSizeUsed)
                {
                    successMessage =
                        "Successfully generated output: Artwork is using default size due to invalid width and height inputs.";
                }

                UIHelper.DisplayMessageDialog(successMessage);
            }
            catch (Exception ex)
            {
                UIHelper.DisplayExceptionDialog(ex);
            }
        }

        private void GenerateDefaultArtwork(int width, int height, string contentPath)
        {
            var artwork = _settings.DefaultCoverArt;
            var resizedArtworkImage = ImageHelper.ResizedArtworkImage(artwork,
                width,
                height);
            resizedArtworkImage.Save(contentPath);
        }
    }
}