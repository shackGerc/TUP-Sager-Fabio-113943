namespace Problema_1_Unidad_1.Presentacion
{
    partial class frmRptAsignaturas
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dSAsignaturas = new Problema_1_Unidad_1.Reportes.DSAsignaturas();
            this.paconsultarasignaturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pa_consultar_asignaturasTableAdapter = new Problema_1_Unidad_1.Reportes.DSAsignaturasTableAdapters.pa_consultar_asignaturasTableAdapter();
            this.dSAsignaturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paconsultarasignaturasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dSAsignaturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paconsultarasignaturasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSAsignaturasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paconsultarasignaturasBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.paconsultarasignaturasBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Problema_1_Unidad_1.Reportes.rptAsignaturas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(826, 462);
            this.reportViewer1.TabIndex = 0;
            // 
            // dSAsignaturas
            // 
            this.dSAsignaturas.DataSetName = "DSAsignaturas";
            this.dSAsignaturas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // paconsultarasignaturasBindingSource
            // 
            this.paconsultarasignaturasBindingSource.DataMember = "pa_consultar_asignaturas";
            this.paconsultarasignaturasBindingSource.DataSource = this.dSAsignaturas;
            // 
            // pa_consultar_asignaturasTableAdapter
            // 
            this.pa_consultar_asignaturasTableAdapter.ClearBeforeFill = true;
            // 
            // dSAsignaturasBindingSource
            // 
            this.dSAsignaturasBindingSource.DataSource = this.dSAsignaturas;
            this.dSAsignaturasBindingSource.Position = 0;
            // 
            // paconsultarasignaturasBindingSource1
            // 
            this.paconsultarasignaturasBindingSource1.DataMember = "pa_consultar_asignaturas";
            this.paconsultarasignaturasBindingSource1.DataSource = this.dSAsignaturas;
            // 
            // frmRptAsignaturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 462);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRptAsignaturas";
            this.Text = "frmRptAsignaturas";
            this.Load += new System.EventHandler(this.frmRptAsignaturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSAsignaturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paconsultarasignaturasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSAsignaturasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paconsultarasignaturasBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Reportes.DSAsignaturas dSAsignaturas;
        private System.Windows.Forms.BindingSource paconsultarasignaturasBindingSource;
        private Reportes.DSAsignaturasTableAdapters.pa_consultar_asignaturasTableAdapter pa_consultar_asignaturasTableAdapter;
        private System.Windows.Forms.BindingSource paconsultarasignaturasBindingSource1;
        private System.Windows.Forms.BindingSource dSAsignaturasBindingSource;
    }
}