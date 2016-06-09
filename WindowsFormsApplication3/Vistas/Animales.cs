using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Animales : Form
    {
        public Animales()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Animales_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ingresos ing = new Ingresos();
            ing.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modificar mod = new Modificar();
            mod.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Eliminar eli = new Eliminar();
            eli.ShowDialog();
        }
    }
}
