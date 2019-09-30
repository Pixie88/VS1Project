namespace GalaxyCinemas
{
    partial class BookingForm
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
            this.SuspendLayout();
            // 
            // BookingForm
            // 
            this.ClientSize = new System.Drawing.Size(520, 439);
            this.Name = "BookingForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cboMovie;
        private System.Windows.Forms.ComboBox cboSession;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpSessionDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSpecialName;
        private System.Windows.Forms.Label lblOriginalPrice;
        private System.Windows.Forms.Label lblFinalPrice;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnBack;
    }
}

