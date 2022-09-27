using RecetasSLN.dominio;
using RecetasSLN.Servicios.Implementaciones;
using RecetasSLN.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecetasSLN.presentación
{
    public partial class FrmConsultarRecetas : Form
    {
        private IServicio servicio;
        public FrmConsultarRecetas()
        {
            InitializeComponent();
            servicio = new ServicioReceta();
        }

        private void CargarCboTiposRecetas()
        {
            cboTiposRecetas.DataSource = servicio.ObtenerTiposRecetas();
            cboTiposRecetas.ValueMember = "id_tipo";
            cboTiposRecetas.DisplayMember = "tipo";
            cboTiposRecetas.SelectedIndex = -1;
        }

        private void FrmConsultarRecetas_Load(object sender, EventArgs e)
        {
            CargarCboTiposRecetas();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmAltaRecetas frmAltaRecetas = new FrmAltaRecetas();
            frmAltaRecetas.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            List<Receta> recetas = servicio.ObtenerRecetasConFiltros((int)cboTiposRecetas.SelectedValue, txtNombre.Text);
            dgvResultados.Rows.Clear();
            foreach (Receta r in recetas)
            {
                dgvResultados.Rows.Add(r.Nombre, r.TipoReceta, r.Cheff);
            }
            lblTotal.Text = "Total de recetas: " + recetas.Count.ToString();
        }

        private void dgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
