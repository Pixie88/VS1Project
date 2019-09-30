using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Common;

namespace GalaxyCinemas
{
    public partial class BookingForm : Form
    {
        // Base ticket price used for calculations
        public const decimal BASETICKETPRICE = 14.0m;
        Booking booking = new Booking();
        List<ISpecialPlugin> specialPlugins = new List<ISpecialPlugin>();

        public BookingForm(List<ISpecialPlugin> plugins)
        {
            // Create a Booking object. We will set the properties of this as we progress through the form, and save when the form is submitted.
            Booking booking = new Booking();
            // We are provided the loaded plugins from the main application because loading plugins using reflection is very expensive and should not be done often.
            specialPlugins = plugins;
            InitializeComponent();
            // Populate the movies dropdown with a list of movies.
            PopulateMovies();
            // Ensure the user can't select a date in the past.
            dtpSessionDate.MinDate = DateTime.Today;
            this.FormClosing += BookingForm_FormClosing;       
        }

        /// <summary>
        /// Populate the movies dropdown with a list of Movies from the database, sorted by title.
        /// </summary>
        public void PopulateMovies()
        {
            cboMovie.DisplayMember = "Title";
            cboMovie.ValueMember = "MovieID";
            // Call method GetAllMovies using Result.
            List<Movie> movies = DataLayer.DataLayer.GetAllMovies().OrderBy(m => m.Title).ToList();
            cboMovie.DataSource = movies;
            cboMovie.SelectedIndex = -1;
        }

        /// <summary>
        /// Populate the sessions dropdown with a list of Sessions from the database, filtering by a selected movie and date.
        /// </summary>
        public void PopulateSessions(int MovieID, DateTime date)
        {
            cboSession.DisplayMember = "ShortFormat";
            cboSession.ValueMember = "SessionID";
            List<Session> sessions = DataLayer.DataLayer.GetAllSessionsForMovie(MovieID, date).OrderBy(s => s.SessionDate).ToList();
            cboSession.DataSource = sessions;
        }

        /// <summary>
        /// When the selected movie is changed, update the options in the sessions dropdown.
        /// </summary>
        private void cboMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtpSessionDate.Value != null && cboMovie.SelectedValue != null)
            {
                // Populate the sessions dropdown with values based on the newly selected movie.
                PopulateSessions((int)cboMovie.SelectedValue, dtpSessionDate.Value);
                // Clear errors on the datepicker and the session dropdown as they are no longer relevant.
                errorProvider.SetError(dtpSessionDate, "");
                errorProvider.SetError(cboSession, "");
            }
            else
            {
                // Clear out the sessions dropdown if prerequesite fields aren't filled in.
                cboSession.DataSource = null;
            }
        }

        /// <summary>
        /// When the selected date is changed, update the options in the sessions dropdown.
        /// </summary>
        private void dtpSessionDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpSessionDate.Value != null && cboMovie.SelectedValue != null)
            {
                // Populate the sessions dropdown with values based on the newly selected date.
                PopulateSessions((int)cboMovie.SelectedValue, dtpSessionDate.Value);
                // Clear errors on the session dropdown as they are no longer relevant.
                errorProvider.SetError(cboSession, "");
            }
            else
            {
                // Clear out the sessions dropdown if prerequesite fields aren't filled in.
                cboSession.DataSource = null;
            }
        }

        /// <summary>
        /// When a session is selected, set the SessionID for the Booking and update the price on the form.
        /// </summary>
        private void cboSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSession.SelectedValue != null)
            {
                booking.SessionID = (int)cboSession.SelectedValue;
                Session session = DataLayer.DataLayer.GetSessionByID(booking.SessionID);
                booking.SessionDate = session.SessionDate;
            }
            else booking.SessionID = 0;

            if (!string.IsNullOrEmpty(txtQuantity.Text) && booking.SessionID > 0)
            {
                UpdatePrice();
            }
        }

        /// <summary>
        /// When the quantity is changed, update the price on the form if the quantity is valid and a session is selected.
        /// </summary>
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQuantity.Text) && cboSession.SelectedValue != null)
            {
                booking.Quantity = int.Parse(txtQuantity.Text);
                UpdatePrice();
            }
        }

        /// <summary>
        /// Update the price to match the selected values.
        /// </summary>
        private void UpdatePrice()
        {
            // Calculate the original (full) price.
            decimal originalPrice = booking.Quantity * booking.OriginalPrice;
            // Prepare to compare original price to special prices.
            decimal finalPrice = originalPrice;
            booking.OriginalPrice = originalPrice;
            string specialName = "";
            // Record pricing and special information in the Booking.
            foreach (ISpecialPlugin plugin in specialPlugins)
            {
                decimal currentSpecialPrice = originalPrice;
                string currentSpecialName = "";

                if (plugin.CalculateSpecial(booking, ref currentSpecialName, ref currentSpecialPrice))
                {
                    if (currentSpecialPrice < finalPrice)
                    {
                        finalPrice = currentSpecialPrice;
                        specialName = currentSpecialName;
                    }
                }

                booking.FinalPrice = finalPrice;
                booking.Special = specialName;
                booking.Discount = originalPrice - finalPrice;
            }

            // Display pricing and special information on the form.
            lblFinalPrice.Text = finalPrice.ToString();
            lblOriginalPrice.Text = originalPrice.ToString();
            lblSpecialName.Text = specialName;

        }
       
        //action when back button pressed
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

