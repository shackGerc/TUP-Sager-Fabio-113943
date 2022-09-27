namespace RecetasSLN.presentación
{
    partial class FrmAltaRecetas
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
            this.lblNroReceta = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCheff = new System.Windows.Forms.TextBox();
            this.cboTiposRecetas = new System.Windows.Forms.ComboBox();
            this.cboIngredientes = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.NUPIngredientes = new System.Windows.Forms.NumericUpDown();
            this.dgvIngredientes = new System.Windows.Forms.DataGridView();
            this.colCodIngrediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIngrediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcciones = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblIngredientesTotales = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxDetalle = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.NUPIngredientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNroReceta
            // 
            this.lblNroReceta.AutoSize = true;
            this.lblNroReceta.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroReceta.Location = new System.Drawing.Point(115, 9);
            this.lblNroReceta.Name = "lblNroReceta";
            this.lblNroReceta.Size = new System.Drawing.Size(152, 32);
            this.lblNroReceta.TabIndex = 0;
            this.lblNroReceta.Text = "Receta #: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cheff:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tipo de receta:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(121, 71);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(404, 22);
            this.txtNombre.TabIndex = 0;
            // 
            // txtCheff
            // 
            this.txtCheff.Location = new System.Drawing.Point(121, 99);
            this.txtCheff.Name = "txtCheff";
            this.txtCheff.Size = new System.Drawing.Size(404, 22);
            this.txtCheff.TabIndex = 1;
            // 
            // cboTiposRecetas
            // 
            this.cboTiposRecetas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTiposRecetas.FormattingEnabled = true;
            this.cboTiposRecetas.Location = new System.Drawing.Point(121, 127);
            this.cboTiposRecetas.Name = "cboTiposRecetas";
            this.cboTiposRecetas.Size = new System.Drawing.Size(251, 24);
            this.cboTiposRecetas.TabIndex = 2;
            // 
            // cboIngredientes
            // 
            this.cboIngredientes.FormattingEnabled = true;
            this.cboIngredientes.Location = new System.Drawing.Point(20, 190);
            this.cboIngredientes.Name = "cboIngredientes";
            this.cboIngredientes.Size = new System.Drawing.Size(251, 24);
            this.cboIngredientes.TabIndex = 3;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(490, 186);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(126, 29);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // NUPIngredientes
            // 
            this.NUPIngredientes.Location = new System.Drawing.Point(277, 191);
            this.NUPIngredientes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUPIngredientes.Name = "NUPIngredientes";
            this.NUPIngredientes.Size = new System.Drawing.Size(198, 22);
            this.NUPIngredientes.TabIndex = 4;
            this.NUPIngredientes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dgvIngredientes
            // 
            this.dgvIngredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodIngrediente,
            this.ColIngrediente,
            this.colCantidad,
            this.colAcciones});
            this.dgvIngredientes.Location = new System.Drawing.Point(20, 232);
            this.dgvIngredientes.Name = "dgvIngredientes";
            this.dgvIngredientes.RowHeadersWidth = 51;
            this.dgvIngredientes.RowTemplate.Height = 24;
            this.dgvIngredientes.Size = new System.Drawing.Size(596, 150);
            this.dgvIngredientes.TabIndex = 6;
            this.dgvIngredientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIngredientes_CellContentClick);
            // 
            // colCodIngrediente
            // 
            this.colCodIngrediente.HeaderText = "colCodIngrediente";
            this.colCodIngrediente.MinimumWidth = 6;
            this.colCodIngrediente.Name = "colCodIngrediente";
            this.colCodIngrediente.Visible = false;
            this.colCodIngrediente.Width = 125;
            // 
            // ColIngrediente
            // 
            this.ColIngrediente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColIngrediente.HeaderText = "Ingrediente";
            this.ColIngrediente.MinimumWidth = 6;
            this.ColIngrediente.Name = "ColIngrediente";
            this.ColIngrediente.ReadOnly = true;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.MinimumWidth = 6;
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            this.colCantidad.Width = 125;
            // 
            // colAcciones
            // 
            this.colAcciones.HeaderText = "Acciones";
            this.colAcciones.MinimumWidth = 6;
            this.colAcciones.Name = "colAcciones";
            this.colAcciones.Text = "Eliminar";
            this.colAcciones.ToolTipText = "Eliminar";
            this.colAcciones.UseColumnTextForButtonValue = true;
            this.colAcciones.Width = 125;
            // 
            // lblIngredientesTotales
            // 
            this.lblIngredientesTotales.AutoSize = true;
            this.lblIngredientesTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngredientesTotales.Location = new System.Drawing.Point(366, 385);
            this.lblIngredientesTotales.Name = "lblIngredientesTotales";
            this.lblIngredientesTotales.Size = new System.Drawing.Size(147, 16);
            this.lblIngredientesTotales.TabIndex = 12;
            this.lblIngredientesTotales.Text = "Total de Ingredientes: 0";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(230, 411);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 27);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(321, 411);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 27);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(634, 114);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // groupBoxDetalle
            // 
            this.groupBoxDetalle.Location = new System.Drawing.Point(12, 172);
            this.groupBoxDetalle.Name = "groupBoxDetalle";
            this.groupBoxDetalle.Size = new System.Drawing.Size(634, 54);
            this.groupBoxDetalle.TabIndex = 16;
            this.groupBoxDetalle.TabStop = false;
            // 
            // FrmAltaRecetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblIngredientesTotales);
            this.Controls.Add(this.dgvIngredientes);
            this.Controls.Add(this.NUPIngredientes);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cboIngredientes);
            this.Controls.Add(this.cboTiposRecetas);
            this.Controls.Add(this.txtCheff);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNroReceta);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxDetalle);
            this.Name = "FrmAltaRecetas";
            this.Text = "Alta de recetas";
            this.Load += new System.EventHandler(this.FrmAltaRecetas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUPIngredientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNroReceta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCheff;
        private System.Windows.Forms.ComboBox cboTiposRecetas;
        private System.Windows.Forms.ComboBox cboIngredientes;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.NumericUpDown NUPIngredientes;
        private System.Windows.Forms.DataGridView dgvIngredientes;
        private System.Windows.Forms.Label lblIngredientesTotales;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodIngrediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIngrediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewButtonColumn colAcciones;
    }
}