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
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablaRegistro tr = new tablaRegistro();
            tr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Grafico gra = new Grafico();
            gra.ShowDialog();
        }
    }
}
