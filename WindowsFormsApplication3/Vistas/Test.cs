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
using WindowsFormsApplication3.Controlador;

namespace WindowsFormsApplication3.Vistas
{
    public partial class Test : Form
    {
        private Database Db = new Database(Config.ConnString);
        private Hashtable Parameters = new Hashtable();

        public Test()
        {
            InitializeComponent();
        }
        
        private void _guardar_Click(object sender, EventArgs e)
        {
            Parameters.Clear();
            Parameters.Add("@id", _id.Text.Trim());
            Parameters.Add("@nombre", _nombre.Text.Trim());

            DataTable Data = Db.ExecuteQuery(@"
                insert into prueba(Id, Nombre)
                values(@id, @nombre)
                
                select 'pico' as pico
            
            ", Parameters);

            MessageBox.Show(Data.Rows[0][0].ToString());
        }

        private void Test_Load(object sender, EventArgs e)
        {
            //DataTable Data = 

            _weas.DataSource = Db.ExecuteQuery(@"select * from prueba"); ;
            _weas.DisplayMember = "Nombre";
            _weas.ValueMember = "Id";
        }

        private void _weas_SelectedIndexChanged(object sender, EventArgs e)
        {
            _nombre.Text = _weas.Text;
            _id.Text = _weas.SelectedValue.ToString();
        }
    }
}
