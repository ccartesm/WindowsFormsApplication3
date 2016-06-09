namespace WindowsFormsApplication3.Vistas
{
    partial class Test
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this._id = new System.Windows.Forms.TextBox();
            this._nombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._guardar = new System.Windows.Forms.Button();
            this._weas = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // _id
            // 
            this._id.Location = new System.Drawing.Point(86, 92);
            this._id.Name = "_id";
            this._id.Size = new System.Drawing.Size(100, 20);
            this._id.TabIndex = 1;
            // 
            // _nombre
            // 
            this._nombre.Location = new System.Drawing.Point(86, 118);
            this._nombre.Name = "_nombre";
            this._nombre.Size = new System.Drawing.Size(100, 20);
            this._nombre.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre";
            // 
            // _guardar
            // 
            this._guardar.Location = new System.Drawing.Point(111, 144);
            this._guardar.Name = "_guardar";
            this._guardar.Size = new System.Drawing.Size(75, 23);
            this._guardar.TabIndex = 4;
            this._guardar.Text = "Guardar";
            this._guardar.UseVisualStyleBackColor = true;
            this._guardar.Click += new System.EventHandler(this._guardar_Click);
            // 
            // _weas
            // 
            this._weas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._weas.FormattingEnabled = true;
            this._weas.Location = new System.Drawing.Point(12, 12);
            this._weas.Name = "_weas";
            this._weas.Size = new System.Drawing.Size(121, 21);
            this._weas.TabIndex = 5;
            this._weas.SelectedIndexChanged += new System.EventHandler(this._weas_SelectedIndexChanged);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this._weas);
            this.Controls.Add(this._guardar);
            this.Controls.Add(this._nombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._id);
            this.Controls.Add(this.label1);
            this.Name = "Test";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Test_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _id;
        private System.Windows.Forms.TextBox _nombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _guardar;
        private System.Windows.Forms.ComboBox _weas;
    }
}