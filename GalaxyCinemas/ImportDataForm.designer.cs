namespace GalaxyCinemas
{
    partial class ImportDataForm
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
            this.components = new System.ComponentModel.Container();
            this.btnMovieImportStart = new System.Windows.Forms.Button();
            this.btnMovieImportStop = new System.Windows.Forms.Button();
            this.btnSelectMovieFile = new System.Windows.Forms.Button();
            this.opnFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.txtMovieFileName = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSelectSessionFile = new System.Windows.Forms.Button();
            this.txtbxSessionPath = new System.Windows.Forms.TextBox();
            this.btnStopSession = new System.Windows.Forms.Button();
            this.btnImportSession = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMovieImportStart
            // 
            this.btnMovieImportStart.Location = new System.Drawing.Point(17, 84);
            this.btnMovieImportStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMovieImportStart.Name = "btnMovieImportStart";
            this.btnMovieImportStart.Size = new System.Drawing.Size(100, 28);
            this.btnMovieImportStart.TabIndex = 0;
            this.btnMovieImportStart.Text = "Import";
            this.btnMovieImportStart.UseVisualStyleBackColor = true;
            this.btnMovieImportStart.Click += new System.EventHandler(this.btnMovieImportStart_Click);
            // 
            // btnMovieImportStop
            // 
            this.btnMovieImportStop.CausesValidation = false;
            this.btnMovieImportStop.Location = new System.Drawing.Point(18, 84);
            this.btnMovieImportStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMovieImportStop.Name = "btnMovieImportStop";
            this.btnMovieImportStop.Size = new System.Drawing.Size(100, 28);
            this.btnMovieImportStop.TabIndex = 1;
            this.btnMovieImportStop.Text = "Stop";
            this.btnMovieImportStop.UseVisualStyleBackColor = true;
            this.btnMovieImportStop.Visible = false;
            this.btnMovieImportStop.Click += new System.EventHandler(this.btnMovieImportStop_Click);
            // 
            // btnSelectMovieFile
            // 
            this.btnSelectMovieFile.CausesValidation = false;
            this.btnSelectMovieFile.Location = new System.Drawing.Point(17, 16);
            this.btnSelectMovieFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectMovieFile.Name = "btnSelectMovieFile";
            this.btnSelectMovieFile.Size = new System.Drawing.Size(203, 28);
            this.btnSelectMovieFile.TabIndex = 3;
            this.btnSelectMovieFile.Text = "Select Movie File";
            this.btnSelectMovieFile.UseVisualStyleBackColor = true;
            this.btnSelectMovieFile.Click += new System.EventHandler(this.btnSelectMovieFile_Click);
            // 
            // txtMovieFileName
            // 
            this.txtMovieFileName.Location = new System.Drawing.Point(18, 52);
            this.txtMovieFileName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMovieFileName.Name = "txtMovieFileName";
            this.txtMovieFileName.Size = new System.Drawing.Size(428, 22);
            this.txtMovieFileName.TabIndex = 4;
            this.txtMovieFileName.Validating += new System.ComponentModel.CancelEventHandler(this.txtMovieFileName_Validating);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(121, 450);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(325, 28);
            this.progressBar.TabIndex = 5;
            this.progressBar.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnSelectSessionFile
            // 
            this.btnSelectSessionFile.CausesValidation = false;
            this.btnSelectSessionFile.Location = new System.Drawing.Point(17, 134);
            this.btnSelectSessionFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectSessionFile.Name = "btnSelectSessionFile";
            this.btnSelectSessionFile.Size = new System.Drawing.Size(203, 28);
            this.btnSelectSessionFile.TabIndex = 6;
            this.btnSelectSessionFile.Text = "Select Session File";
            this.btnSelectSessionFile.UseVisualStyleBackColor = true;
            this.btnSelectSessionFile.Click += new System.EventHandler(this.BtnSelectSessionFile_Click);
            // 
            // txtbxSessionPath
            // 
            this.txtbxSessionPath.Location = new System.Drawing.Point(18, 180);
            this.txtbxSessionPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtbxSessionPath.Name = "txtbxSessionPath";
            this.txtbxSessionPath.Size = new System.Drawing.Size(428, 22);
            this.txtbxSessionPath.TabIndex = 7;
            // 
            // btnStopSession
            // 
            this.btnStopSession.CausesValidation = false;
            this.btnStopSession.Location = new System.Drawing.Point(18, 210);
            this.btnStopSession.Margin = new System.Windows.Forms.Padding(4);
            this.btnStopSession.Name = "btnStopSession";
            this.btnStopSession.Size = new System.Drawing.Size(100, 28);
            this.btnStopSession.TabIndex = 8;
            this.btnStopSession.Text = "Stop";
            this.btnStopSession.UseVisualStyleBackColor = true;
            this.btnStopSession.Visible = false;
            // 
            // btnImportSession
            // 
            this.btnImportSession.Location = new System.Drawing.Point(18, 210);
            this.btnImportSession.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportSession.Name = "btnImportSession";
            this.btnImportSession.Size = new System.Drawing.Size(100, 28);
            this.btnImportSession.TabIndex = 9;
            this.btnImportSession.Text = "Import";
            this.btnImportSession.UseVisualStyleBackColor = true;
            // 
            // ImportDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 494);
            this.Controls.Add(this.btnImportSession);
            this.Controls.Add(this.btnStopSession);
            this.Controls.Add(this.txtbxSessionPath);
            this.Controls.Add(this.btnSelectSessionFile);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.txtMovieFileName);
            this.Controls.Add(this.btnSelectMovieFile);
            this.Controls.Add(this.btnMovieImportStop);
            this.Controls.Add(this.btnMovieImportStart);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ImportDataForm";
            this.Text = "Import";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMovieImportStart;
        private System.Windows.Forms.Button btnMovieImportStop;
        private System.Windows.Forms.Button btnSelectMovieFile;
        private System.Windows.Forms.OpenFileDialog opnFileDialog;
        private System.Windows.Forms.TextBox txtMovieFileName;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnStopSession;
        private System.Windows.Forms.TextBox txtbxSessionPath;
        private System.Windows.Forms.Button btnSelectSessionFile;
        private System.Windows.Forms.Button btnImportSession;
    }
}