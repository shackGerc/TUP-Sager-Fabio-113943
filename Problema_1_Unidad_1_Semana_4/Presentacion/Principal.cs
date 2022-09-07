using Problema_1_Unidad_1.Presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problema_1_Unidad_1
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Seguro que quiere salir de la aplicación?",
                "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuevaCarrera nuevaCarrera = new frmNuevaCarrera();
            nuevaCarrera.ShowDialog();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultar consultas = new frmConsultar();
            consultas.ShowDialog();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModificar modificar = new frmModificar();
            modificar.ShowDialog();
        }

        private void asignaturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptAsignaturas frmRptAsignaturas = new frmRptAsignaturas();
            frmRptAsignaturas.ShowDialog();
        }

        private void asignaturasPorCarreraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptMateriasPorCarrera frmRptMateriasPorCarrera = new frmRptMateriasPorCarrera();
            frmRptMateriasPorCarrera.ShowDialog();
        }
    }
}
