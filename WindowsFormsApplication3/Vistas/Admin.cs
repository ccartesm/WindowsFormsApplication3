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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Animales anim = new Animales();
            anim.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reportes.Reportes repo = new Reportes.Reportes();
            repo.ShowDialog();
        }

        private void nuevoAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
