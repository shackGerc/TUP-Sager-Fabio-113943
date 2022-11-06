using ReportesNetFramework;
namespace ClienteCarreras.Presentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quiere salir de la aplicaci�n?",
                "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void consultarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmConsultar consultas = new frmConsultar();
            consultas.ShowDialog();
        }

        private void nuevoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmNuevaCarrera nuevaCarrera = new frmNuevaCarrera();
            nuevaCarrera.ShowDialog();
        }

        private void modificarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmModificar modificar = new frmModificar();
            modificar.ShowDialog();
        }

        private void asignaturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptAsignaturas asignaturas = new frmRptAsignaturas();
            asignaturas.ShowDialog();
        }

        private void asignaturasPorCarreraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmRptMateriasxCarrera().ShowDialog();
        }
    }
}