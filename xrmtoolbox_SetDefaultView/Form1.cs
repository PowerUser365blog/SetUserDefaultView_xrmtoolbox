using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xrmtoolbox_SetDefaultView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string EntraID { get; set; }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            EntraID = tbEntraID.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
