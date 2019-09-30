using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Common;

namespace GalaxyCinemas
{
    public partial class MainForm : Form
    {
        private List<ISpecialPlugin> specialPlugins = new List<ISpecialPlugin>();

        public MainForm()
        {
            InitializeComponent();

            try
            {
                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);

                foreach (FileInfo file in dir.GetFiles("Plugin*.dll"))
                {
                    string name = Path.GetFileNameWithoutExtension(file.Name);
                    Assembly pluginAssesmbly = Assembly.Load(name);

                    var plugins = from type in pluginAssesmbly.GetTypes()
                                  where typeof(ISpecialPlugin).IsAssignableFrom(type) && !type.IsInterface
                                  select type;

                    foreach (Type pluginType in plugins)
                    {
                        ISpecialPlugin plugin = Activator.CreateInstance(pluginType) as ISpecialPlugin;
                        specialPlugins.Add(plugin);
                    }
                }
            }
            //catch exceptions and show message box if caught - question 45
            catch (Exception)
            {
                MessageBox.Show("An error occured while loading special pricing plugins", "Plugin Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChildFormClosed(object sender, FormClosedEventArgs e)
        {
            // To ensure the main form has focus after a child form is closed.
            this.Focus();
        }

        //Import button click actions
        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportDataForm idf = new ImportDataForm();
            idf.FormClosed += ChildFormClosed;
            idf.Show();
        }

        //export button clicked actions 
       private void btnExportData_Click(object sender, EventArgs e)
        {
            ExportDataForm edf = new ExportDataForm();
            edf.FormClosed += ChildFormClosed;
            edf.Show();
        }

        //booking button clicked actions
        private void btnBookings_Click(object sender, EventArgs e)
        {
            BookingForm bf = new BookingForm(specialPlugins);
            bf.FormClosed += ChildFormClosed;
            bf.Show();

        }

        //close button clicked action
        private void btnClose_Click(EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

    }
}
