using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class KryptonExeptionDialogTestForm : KryptonForm
    {
        public KryptonExeptionDialogTestForm()
        {
            InitializeComponent();
        }

        private void kbtnTriggerException_Click(object sender, EventArgs e)
        {
            try
                {
                throw new InvalidOperationException("This is a test exception for demonstration purposes.");
            }
            catch (Exception ex)
            {
                KryptonExceptionDialog.Show(ex, kcbShowCopyButton.Checked, kcbShowSearchBox.Checked);
            }
        }
    }
}
