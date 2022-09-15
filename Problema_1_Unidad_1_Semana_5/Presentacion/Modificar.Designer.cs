namespace Problema_1_Unidad_1.Presentacion
{
    partial class frmModificar
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.lblMaterias = new System.Windows.Forms.Label();
            this.txtNombreCarrera = new System.Windows.Forms.TextBox();
            this.lblNombreCarrera = new System.Windows.Forms.Label();
            this.lstCarreras = new System.Windows.Forms.ListBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cboMaterias = new System.Windows.Forms.ComboBox();
            this.lblAñoCursado = new System.Windows.Forms.Label();
            this.txtAnioCursado = new System.Windows.Forms.TextBox();
            this.lblMateria = new System.Windows.Forms.Label();
            this.rbnPrimerCuatrimestre = new System.Windows.Forms.RadioButton();
            this.rbnSegundoCuatrimestre = new System.Windows.Forms.RadioButton();
            this.lstMaterias = new System.Windows.Forms.ListBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(681, 394);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(82, 37);
            this.btnSalir.TabIndex = 19;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(342, 394);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(82, 37);
            this.btnAceptar.TabIndex = 18;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(256, 394);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(80, 37);
            this.btnModificar.TabIndex = 17;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // lblMaterias
            // 
            this.lblMaterias.AutoSize = true;
            this.lblMaterias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterias.Location = new System.Drawing.Point(38, 84);
            this.lblMaterias.Name = "lblMaterias";
            this.lblMaterias.Size = new System.Drawing.Size(82, 20);
            this.lblMaterias.TabIndex = 14;
            this.lblMaterias.Text = "Materias";
            // 
            // txtNombreCarrera
            // 
            this.txtNombreCarrera.Location = new System.Drawing.Point(166, 20);
            this.txtNombreCarrera.Name = "txtNombreCarrera";
            this.txtNombreCarrera.Size = new System.Drawing.Size(247, 22);
            this.txtNombreCarrera.TabIndex = 9;
            // 
            // lblNombreCarrera
            // 
            this.lblNombreCarrera.AutoSize = true;
            this.lblNombreCarrera.Location = new System.Drawing.Point(39, 20);
            this.lblNombreCarrera.Name = "lblNombreCarrera";
            this.lblNombreCarrera.Size = new System.Drawing.Size(121, 16);
            this.lblNombreCarrera.TabIndex = 10;
            this.lblNombreCarrera.Text = "Nombre de carrera";
            // 
            // lstCarreras
            // 
            this.lstCarreras.FormattingEnabled = true;
            this.lstCarreras.ItemHeight = 16;
            this.lstCarreras.Location = new System.Drawing.Point(784, 23);
            this.lstCarreras.Name = "lstCarreras";
            this.lstCarreras.Size = new System.Drawing.Size(316, 404);
            this.lstCarreras.TabIndex = 22;
            this.lstCarreras.SelectedIndexChanged += new System.EventHandler(this.lstCarreras_SelectedIndexChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(430, 394);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(82, 37);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cboMaterias
            // 
            this.cboMaterias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaterias.FormattingEnabled = true;
            this.cboMaterias.Location = new System.Drawing.Point(166, 180);
            this.cboMaterias.Name = "cboMaterias";
            this.cboMaterias.Size = new System.Drawing.Size(247, 24);
            this.cboMaterias.TabIndex = 12;
            this.cboMaterias.SelectedIndexChanged += new System.EventHandler(this.cboMaterias_SelectedIndexChanged);
            // 
            // lblAñoCursado
            // 
            this.lblAñoCursado.AutoSize = true;
            this.lblAñoCursado.Location = new System.Drawing.Point(77, 130);
            this.lblAñoCursado.Name = "lblAñoCursado";
            this.lblAñoCursado.Size = new System.Drawing.Size(83, 16);
            this.lblAñoCursado.TabIndex = 16;
            this.lblAñoCursado.Text = "Año cursado";
            // 
            // txtAnioCursado
            // 
            this.txtAnioCursado.Location = new System.Drawing.Point(166, 130);
            this.txtAnioCursado.Name = "txtAnioCursado";
            this.txtAnioCursado.Size = new System.Drawing.Size(247, 22);
            this.txtAnioCursado.TabIndex = 11;
            this.txtAnioCursado.TextChanged += new System.EventHandler(this.txtAnioCursado_TextChanged);
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Location = new System.Drawing.Point(77, 180);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(52, 16);
            this.lblMateria.TabIndex = 21;
            this.lblMateria.Text = "Materia";
            // 
            // rbnPrimerCuatrimestre
            // 
            this.rbnPrimerCuatrimestre.AutoSize = true;
            this.rbnPrimerCuatrimestre.Location = new System.Drawing.Point(443, 132);
            this.rbnPrimerCuatrimestre.Name = "rbnPrimerCuatrimestre";
            this.rbnPrimerCuatrimestre.Size = new System.Drawing.Size(143, 20);
            this.rbnPrimerCuatrimestre.TabIndex = 13;
            this.rbnPrimerCuatrimestre.TabStop = true;
            this.rbnPrimerCuatrimestre.Text = "Primer cuatrimestre";
            this.rbnPrimerCuatrimestre.UseVisualStyleBackColor = true;
            this.rbnPrimerCuatrimestre.CheckedChanged += new System.EventHandler(this.rbnPrimerCuatrimestre_CheckedChanged);
            // 
            // rbnSegundoCuatrimestre
            // 
            this.rbnSegundoCuatrimestre.AutoSize = true;
            this.rbnSegundoCuatrimestre.Location = new System.Drawing.Point(594, 132);
            this.rbnSegundoCuatrimestre.Name = "rbnSegundoCuatrimestre";
            this.rbnSegundoCuatrimestre.Size = new System.Drawing.Size(159, 20);
            this.rbnSegundoCuatrimestre.TabIndex = 15;
            this.rbnSegundoCuatrimestre.TabStop = true;
            this.rbnSegundoCuatrimestre.Text = "Segundo cuatrimestre";
            this.rbnSegundoCuatrimestre.UseVisualStyleBackColor = true;
            // 
            // lstMaterias
            // 
            this.lstMaterias.FormattingEnabled = true;
            this.lstMaterias.ItemHeight = 16;
            this.lstMaterias.Location = new System.Drawing.Point(80, 234);
            this.lstMaterias.Name = "lstMaterias";
            this.lstMaterias.Size = new System.Drawing.Size(683, 148);
            this.lstMaterias.TabIndex = 24;
            this.lstMaterias.SelectedIndexChanged += new System.EventHandler(this.lstMaterias_SelectedIndexChanged);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(80, 388);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(80, 26);
            this.btnBorrar.TabIndex = 25;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // frmModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 440);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.lstMaterias);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lstCarreras);
            this.Controls.Add(this.rbnSegundoCuatrimestre);
            this.Controls.Add(this.rbnPrimerCuatrimestre);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.lblMateria);
            this.Controls.Add(this.txtAnioCursado);
            this.Controls.Add(this.lblAñoCursado);
            this.Controls.Add(this.lblMaterias);
            this.Controls.Add(this.txtNombreCarrera);
            this.Controls.Add(this.cboMaterias);
            this.Controls.Add(this.lblNombreCarrera);
            this.Name = "frmModificar";
            this.Text = "Modificar";
            this.Load += new System.EventHandler(this.frmModificar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label lblMaterias;
        private System.Windows.Forms.TextBox txtNombreCarrera;
        private System.Windows.Forms.Label lblNombreCarrera;
        private System.Windows.Forms.ListBox lstCarreras;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cboMaterias;
        private System.Windows.Forms.Label lblAñoCursado;
        private System.Windows.Forms.TextBox txtAnioCursado;
        private System.Windows.Forms.Label lblMateria;
        private System.Windows.Forms.RadioButton rbnPrimerCuatrimestre;
        private System.Windows.Forms.RadioButton rbnSegundoCuatrimestre;
        private System.Windows.Forms.ListBox lstMaterias;
        private System.Windows.Forms.Button btnBorrar;
    }
}