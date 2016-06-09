namespace WindowsFormsApplication3
{
    partial class Ingresos
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.bdganaderiaDataSet = new WindowsFormsApplication3.bdganaderiaDataSet();
            this.vacaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vacaTableAdapter = new WindowsFormsApplication3.bdganaderiaDataSetTableAdapters.VacaTableAdapter();
            this.tableAdapterManager = new WindowsFormsApplication3.bdganaderiaDataSetTableAdapters.TableAdapterManager();
            this._fech_nac = new System.Windows.Forms.DateTimePicker();
            this._tipo = new System.Windows.Forms.ComboBox();
            this._diio = new System.Windows.Forms.TextBox();
            this._fech_ingreso = new System.Windows.Forms.DateTimePicker();
            this._origen = new System.Windows.Forms.ComboBox();
            this._genetica = new System.Windows.Forms.ComboBox();
            this._peso = new System.Windows.Forms.TextBox();
            this._comentario = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdganaderiaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vacaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingresar Animal";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication3.Properties.Resources.vak;
            this.pictureBox1.Location = new System.Drawing.Point(726, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(804, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(568, 482);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(216, 59);
            this.button3.TabIndex = 5;
            this.button3.Tag = "SALIR";
            this.button3.Text = "CANCELAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(21, 482);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 59);
            this.button1.TabIndex = 5;
            this.button1.Tag = "";
            this.button1.Text = "GUARDAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(101, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "TIPO DE ANIMAL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(194, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "DIIO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(94, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "FECHA INGRESO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(70, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "FECHA NACIMIENTO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(164, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "ORIGEN";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(146, 351);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "GENETICA";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(184, 385);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "PESO";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(121, 418);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "COMENTARIO";
            // 
            // bdganaderiaDataSet
            // 
            this.bdganaderiaDataSet.DataSetName = "bdganaderiaDataSet";
            this.bdganaderiaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vacaBindingSource
            // 
            this.vacaBindingSource.DataMember = "Vaca";
            this.vacaBindingSource.DataSource = this.bdganaderiaDataSet;
            // 
            // vacaTableAdapter
            // 
            this.vacaTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = WindowsFormsApplication3.bdganaderiaDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsuarioTableAdapter = null;
            this.tableAdapterManager.VacaTableAdapter = this.vacaTableAdapter;
            // 
            // _fech_nac
            // 
            this._fech_nac.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.vacaBindingSource, "fech_nac_vaca", true));
            this._fech_nac.Location = new System.Drawing.Point(267, 280);
            this._fech_nac.Name = "_fech_nac";
            this._fech_nac.Size = new System.Drawing.Size(211, 20);
            this._fech_nac.TabIndex = 26;
            // 
            // _tipo
            // 
            this._tipo.FormattingEnabled = true;
            this._tipo.Location = new System.Drawing.Point(267, 170);
            this._tipo.Name = "_tipo";
            this._tipo.Size = new System.Drawing.Size(151, 21);
            this._tipo.TabIndex = 30;
            // 
            // _diio
            // 
            this._diio.Location = new System.Drawing.Point(267, 208);
            this._diio.Name = "_diio";
            this._diio.Size = new System.Drawing.Size(151, 20);
            this._diio.TabIndex = 31;
            // 
            // _fech_ingreso
            // 
            this._fech_ingreso.Location = new System.Drawing.Point(267, 247);
            this._fech_ingreso.Name = "_fech_ingreso";
            this._fech_ingreso.Size = new System.Drawing.Size(211, 20);
            this._fech_ingreso.TabIndex = 32;
            // 
            // _origen
            // 
            this._origen.FormattingEnabled = true;
            this._origen.Location = new System.Drawing.Point(267, 313);
            this._origen.Name = "_origen";
            this._origen.Size = new System.Drawing.Size(151, 21);
            this._origen.TabIndex = 33;
            // 
            // _genetica
            // 
            this._genetica.FormattingEnabled = true;
            this._genetica.Location = new System.Drawing.Point(267, 350);
            this._genetica.Name = "_genetica";
            this._genetica.Size = new System.Drawing.Size(151, 21);
            this._genetica.TabIndex = 34;
            // 
            // _peso
            // 
            this._peso.Location = new System.Drawing.Point(267, 385);
            this._peso.Name = "_peso";
            this._peso.Size = new System.Drawing.Size(151, 20);
            this._peso.TabIndex = 35;
            // 
            // _comentario
            // 
            this._comentario.Location = new System.Drawing.Point(267, 417);
            this._comentario.Name = "_comentario";
            this._comentario.Size = new System.Drawing.Size(271, 20);
            this._comentario.TabIndex = 36;
            // 
            // Ingresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(804, 561);
            this.Controls.Add(this._comentario);
            this.Controls.Add(this._peso);
            this.Controls.Add(this._genetica);
            this.Controls.Add(this._origen);
            this.Controls.Add(this._fech_ingreso);
            this.Controls.Add(this._diio);
            this.Controls.Add(this._tipo);
            this.Controls.Add(this._fech_nac);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Ingresos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Administrador";
            this.Load += new System.EventHandler(this.Ingresos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdganaderiaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vacaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private bdganaderiaDataSet bdganaderiaDataSet;
        private System.Windows.Forms.BindingSource vacaBindingSource;
        private bdganaderiaDataSetTableAdapters.VacaTableAdapter vacaTableAdapter;
        private bdganaderiaDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DateTimePicker _fech_nac;
        private System.Windows.Forms.ComboBox _tipo;
        private System.Windows.Forms.TextBox _diio;
        private System.Windows.Forms.DateTimePicker _fech_ingreso;
        private System.Windows.Forms.ComboBox _origen;
        private System.Windows.Forms.ComboBox _genetica;
        private System.Windows.Forms.TextBox _peso;
        private System.Windows.Forms.TextBox _comentario;
    }
}

