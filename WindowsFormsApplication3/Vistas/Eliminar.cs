using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication3.Code;

namespace WindowsFormsApplication3
{
    public partial class Eliminar : Form
    {
        private Database Db = new Database(Config.ConnString);
        private Hashtable Parameters = new Hashtable();

        public Eliminar()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Eliminar_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bdganaderiaDataSet.Vaca' Puede moverla o quitarla según sea necesario.
            this.vacaTableAdapter.Fill(this.bdganaderiaDataSet.Vaca);

        }

        private void vacaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.vacaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bdganaderiaDataSet);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            Parameters.Clear();
            Parameters.Add("@diio", _diio.Text.Trim());

            DataTable Data = Db.ExecuteQuery(@"delete from animales where diio = '@diio'", Parameters);

            //MessageBox.
        }

        private Boolean validar()
        {
            Boolean ok =true;
            String mens = null;

            if (){
        
        }
        }
    

        private void _diio_Validating()
        {
        
        }
}
