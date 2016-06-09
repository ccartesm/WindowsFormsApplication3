using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApplication3.Controlador;
using WindowsFormsApplication3.Code;
using System.Collections;

namespace WindowsFormsApplication3
{
    public partial class Ingresos : Form
    {
        private Database Db = new Database(Config.ConnString);
        private Hashtable Parameters = new Hashtable();

        public Ingresos()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Ingresos_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Parameters.Clear();
            Parameters.Add("@diio", _diio.Text.Trim());
            Parameters.Add("@tipo", _tipo.Text.Trim());
            Parameters.Add("@fecha_ingreso", Convert.ToDateTime(_fech_ingreso.Text.Trim()));
            Parameters.Add("@fecha_nacimiento", Convert.ToDateTime(_fech_nac.Text.Trim()));
            Parameters.Add("@origen", _origen.Text.Trim());
            Parameters.Add("@genetica", _genetica.Text.Trim());
            Parameters.Add("@peso", _peso.Text.Trim());
            Parameters.Add("@comentario", _comentario.Text.Trim());

            DataTable Data = Db.ExecuteQuery(@"
                insert into animales(diio, tipo, fecha_ingreso, fecha_nacimiento, origen, genetica, peso, comentario)
                values(@diio, @tipo, @fecha_ingreso, @fecha_nacimiento, @origen, @genetica, @peso, @comentario)
                            
            ", Parameters);

            MessageBox.Show("OK");

            MessageBox.Show("OK");
        }

        private void vacaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.vacaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bdganaderiaDataSet);

        }
    }
}
