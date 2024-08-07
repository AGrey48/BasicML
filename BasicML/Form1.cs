using System.Diagnostics.Metrics;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

[assembly: InternalsVisibleTo("BasicMLTests")]

namespace BasicML
{
    // This file contains the functions that are used to control the form
    // Large portions relating to specific sections of the form have been moved to other files
    public partial class FormBasicML : Form
    {
        /* - - - - - - - - - - Variables! - - - - - - - - - - */

		// These are used to access the form's controls from other classes
		public static RichTextBox? _formLoggingBox;             // The box labeled "Log" in the form
		public static RichTextBox? _formProgramOutputBox;       // The box labeled "ProgramOutput" in the form



        /* - - - - - - - - - - Constructor - - - - - - - - - - */

        // Constructor
        public FormBasicML()
        {
            // Initializes the form
            InitializeComponent();

            InstanceHandler.AddInstance();

            // Sets the variables for the logging objects
            _formLoggingBox = loggingBox;
            _formProgramOutputBox = programOutputBox;

            // Sets up the memory grid
            MemoryGrid_Initialize();

            // Sets the initial colors for the form
            SetColors(UVU_GREEN, UVU_WHITE);

            // Updates the display so it is ready for use
            RefreshMemory();
        }



        /* - - - - - - - - - - Display Functions - - - - - - - - - - */

        // Updates the display so it shows the current state of the memory
        private void RefreshMemory()
        {
            MemoryGrid_Refresh();

            Buttons_Refresh();

            accumulatorTextBox.Text = InstanceHandler.GetCpu(0).Accumulator.ToString(true);
        }



        /* - - - - - - - - - - Event Functions - - - - - - - - - - */

		// Runs when enter is pressed in the accumulator text box
		private void AccumulatorTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				InstanceHandler.GetCpu(0).Accumulator.SetValue(accumulatorTextBox.Text);
				accumulatorTextBox.Text = InstanceHandler.GetCpu(0).Accumulator.ToString(true);
			}
		}

	}
}
