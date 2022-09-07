using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Problema_1_Unidad_1.AccesoDatos;

namespace Problema_1_Unidad_1.Presentacion
{
    public partial class frmRptMateriasPorCarrera : Form
    {
        public frmRptMateriasPorCarrera()
        {
            InitializeComponent();
        }

        private void frmRptMateriasPorCarrera_Load(object sender, EventArgs e)
        {
            AccesoBD AccesoBD = new AccesoBD();

            DataTable tabla = AccesoBD.HacerConsultaConSP("pa_consultar_cantidad_materias_x_carrera");

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", tabla));

            this.reportViewer1.RefreshReport();
        }
    }
}
