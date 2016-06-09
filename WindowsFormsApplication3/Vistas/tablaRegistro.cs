using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3.Reportes
{
    public partial class tablaRegistro : Form
    {
        public tablaRegistro()
        {
            InitializeComponent();
        }

        private void tablaRegistro_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
