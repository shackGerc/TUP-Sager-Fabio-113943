using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problema_1_Unidad_1.Presentacion
{
    public partial class frmRptAsignaturas : Form
    {
        public frmRptAsignaturas()
        {
            InitializeComponent();
        }

        private void frmRptAsignaturas_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSAsignaturas.pa_consultar_asignaturas' table. You can move, or remove it, as needed.
            this.pa_consultar_asignaturasTableAdapter.Fill(this.dSAsignaturas.pa_consultar_asignaturas);

            this.reportViewer1.RefreshReport();
        }
    }
}
