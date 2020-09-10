namespace MusicBeePlugin
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDefaultArtistName = new System.Windows.Forms.Label();
            this.txtDefaultArtist = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDefaultTrackTitle = new System.Windows.Forms.Label();
            this.txtDefaultTrackTitle = new System.Windows.Forms.TextBox();
            this.lblDefaultAlbumName = new System.Windows.Forms.Label();
            this.txtDefaultAlbumName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblArtistOutputFile = new System.Windows.Forms.Label();
            this.txtArtistOutputFile = new System.Windows.Forms.TextBox();
            this.lblTrackTitleOutputFile = new System.Windows.Forms.Label();
            this.txtTrackTitleOutputFile = new System.Windows.Forms.TextBox();
            this.lblAlbumOutputFile = new System.Windows.Forms.Label();
            this.txtAlbumOutputFile = new System.Windows.Forms.TextBox();
            this.lblArtworkOutputFile = new System.Windows.Forms.Label();
            this.txtArtworkOutputFile = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDefaultArtistName
            // 
            this.lblDefaultArtistName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDefaultArtistName.AutoSize = true;
            this.lblDefaultArtistName.Location = new System.Drawing.Point(4, 1);
            this.lblDefaultArtistName.Name = "lblDefaultArtistName";
            this.lblDefaultArtistName.Size = new System.Drawing.Size(148, 28);
            this.lblDefaultArtistName.TabIndex = 1;
            this.lblDefaultArtistName.Text = "Default Artist Name";
            this.lblDefaultArtistName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDefaultArtist
            // 
            this.txtDefaultArtist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDefaultArtist.Location = new System.Drawing.Point(159, 4);
            this.txtDefaultArtist.Name = "txtDefaultArtist";
            this.txtDefaultArtist.Size = new System.Drawing.Size(658, 22);
            this.txtDefaultArtist.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.txtDefaultTrackTitle, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDefaultTrackTitle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDefaultArtist, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDefaultArtistName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDefaultAlbumName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDefaultAlbumName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblArtistOutputFile, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtArtistOutputFile, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblTrackTitleOutputFile, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtTrackTitleOutputFile, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtAlbumOutputFile, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblArtworkOutputFile, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblAlbumOutputFile, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtArtworkOutputFile, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 369);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // lblDefaultTrackTitle
            // 
            this.lblDefaultTrackTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDefaultTrackTitle.AutoSize = true;
            this.lblDefaultTrackTitle.Location = new System.Drawing.Point(4, 30);
            this.lblDefaultTrackTitle.Name = "lblDefaultTrackTitle";
            this.lblDefaultTrackTitle.Size = new System.Drawing.Size(148, 28);
            this.lblDefaultTrackTitle.TabIndex = 3;
            this.lblDefaultTrackTitle.Text = "Default Track Title";
            this.lblDefaultTrackTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDefaultTrackTitle
            // 
            this.txtDefaultTrackTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDefaultTrackTitle.Location = new System.Drawing.Point(159, 33);
            this.txtDefaultTrackTitle.Name = "txtDefaultTrackTitle";
            this.txtDefaultTrackTitle.Size = new System.Drawing.Size(658, 22);
            this.txtDefaultTrackTitle.TabIndex = 4;
            // 
            // lblDefaultAlbumName
            // 
            this.lblDefaultAlbumName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDefaultAlbumName.AutoSize = true;
            this.lblDefaultAlbumName.Location = new System.Drawing.Point(4, 59);
            this.lblDefaultAlbumName.Name = "lblDefaultAlbumName";
            this.lblDefaultAlbumName.Size = new System.Drawing.Size(148, 28);
            this.lblDefaultAlbumName.TabIndex = 5;
            this.lblDefaultAlbumName.Text = "Default Album Name";
            this.lblDefaultAlbumName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDefaultAlbumName
            // 
            this.txtDefaultAlbumName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDefaultAlbumName.Location = new System.Drawing.Point(159, 62);
            this.txtDefaultAlbumName.Name = "txtDefaultAlbumName";
            this.txtDefaultAlbumName.Size = new System.Drawing.Size(658, 22);
            this.txtDefaultAlbumName.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(0, 375);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(396, 75);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save and Exit";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.AutoSize = true;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(402, 375);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(396, 75);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit Without Saving";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblArtistOutputFile
            // 
            this.lblArtistOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArtistOutputFile.AutoSize = true;
            this.lblArtistOutputFile.Location = new System.Drawing.Point(4, 88);
            this.lblArtistOutputFile.Name = "lblArtistOutputFile";
            this.lblArtistOutputFile.Size = new System.Drawing.Size(148, 28);
            this.lblArtistOutputFile.TabIndex = 7;
            this.lblArtistOutputFile.Text = "Artist Output File";
            this.lblArtistOutputFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtArtistOutputFile
            // 
            this.txtArtistOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArtistOutputFile.Location = new System.Drawing.Point(159, 91);
            this.txtArtistOutputFile.Name = "txtArtistOutputFile";
            this.txtArtistOutputFile.Size = new System.Drawing.Size(658, 22);
            this.txtArtistOutputFile.TabIndex = 8;
            // 
            // lblTrackTitleOutputFile
            // 
            this.lblTrackTitleOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrackTitleOutputFile.AutoSize = true;
            this.lblTrackTitleOutputFile.Location = new System.Drawing.Point(4, 117);
            this.lblTrackTitleOutputFile.Name = "lblTrackTitleOutputFile";
            this.lblTrackTitleOutputFile.Size = new System.Drawing.Size(148, 28);
            this.lblTrackTitleOutputFile.TabIndex = 9;
            this.lblTrackTitleOutputFile.Text = "Track Title Output File";
            this.lblTrackTitleOutputFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTrackTitleOutputFile
            // 
            this.txtTrackTitleOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTrackTitleOutputFile.Location = new System.Drawing.Point(159, 120);
            this.txtTrackTitleOutputFile.Name = "txtTrackTitleOutputFile";
            this.txtTrackTitleOutputFile.Size = new System.Drawing.Size(658, 22);
            this.txtTrackTitleOutputFile.TabIndex = 10;
            // 
            // lblAlbumOutputFile
            // 
            this.lblAlbumOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlbumOutputFile.AutoSize = true;
            this.lblAlbumOutputFile.Location = new System.Drawing.Point(4, 146);
            this.lblAlbumOutputFile.Name = "lblAlbumOutputFile";
            this.lblAlbumOutputFile.Size = new System.Drawing.Size(148, 28);
            this.lblAlbumOutputFile.TabIndex = 11;
            this.lblAlbumOutputFile.Text = "Album Output File";
            this.lblAlbumOutputFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAlbumOutputFile
            // 
            this.txtAlbumOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlbumOutputFile.Location = new System.Drawing.Point(159, 149);
            this.txtAlbumOutputFile.Name = "txtAlbumOutputFile";
            this.txtAlbumOutputFile.Size = new System.Drawing.Size(658, 22);
            this.txtAlbumOutputFile.TabIndex = 12;
            // 
            // lblArtworkOutputFile
            // 
            this.lblArtworkOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArtworkOutputFile.AutoSize = true;
            this.lblArtworkOutputFile.Location = new System.Drawing.Point(4, 175);
            this.lblArtworkOutputFile.Name = "lblArtworkOutputFile";
            this.lblArtworkOutputFile.Size = new System.Drawing.Size(148, 28);
            this.lblArtworkOutputFile.TabIndex = 13;
            this.lblArtworkOutputFile.Text = "Artwork Output File";
            this.lblArtworkOutputFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtArtworkOutputFile
            // 
            this.txtArtworkOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArtworkOutputFile.Location = new System.Drawing.Point(159, 178);
            this.txtArtworkOutputFile.Name = "txtArtworkOutputFile";
            this.txtArtworkOutputFile.Size = new System.Drawing.Size(658, 22);
            this.txtArtworkOutputFile.TabIndex = 14;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnSave);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDefaultArtistName;
        private System.Windows.Forms.TextBox txtDefaultArtist;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtDefaultTrackTitle;
        private System.Windows.Forms.Label lblDefaultTrackTitle;
        private System.Windows.Forms.TextBox txtDefaultAlbumName;
        private System.Windows.Forms.Label lblDefaultAlbumName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblArtistOutputFile;
        private System.Windows.Forms.TextBox txtArtistOutputFile;
        private System.Windows.Forms.Label lblTrackTitleOutputFile;
        private System.Windows.Forms.TextBox txtTrackTitleOutputFile;
        private System.Windows.Forms.TextBox txtAlbumOutputFile;
        private System.Windows.Forms.Label lblArtworkOutputFile;
        private System.Windows.Forms.Label lblAlbumOutputFile;
        private System.Windows.Forms.TextBox txtArtworkOutputFile;
    }
}