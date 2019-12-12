using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Forms;

namespace MCC_Mod_Brancher
{
    public partial class failPopup : DarkForm
    {
        public failPopup()
        {
            InitializeComponent();
        }

        private void darkButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
