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
    public partial class FrmAltaRecetas : Form
    {
        private IServicio servicio;
        private Receta oReceta;
        private int cantidadIngredientes;
        public FrmAltaRecetas()
        {
            InitializeComponent();
            servicio = new ServicioReceta();
            oReceta = new Receta();
            cantidadIngredientes = 0;
        }

        private void CargarCboTiposRecetas()
        {
            // string[] tiposRecetas = {"Ensalada", "Mariscos", "China",
            // "Rapida", "Tradicional", "Pasta", "Carne", "Postre"};

            //cboTiposRecetas.DataSource = tiposRecetas;

            cboTiposRecetas.DataSource = servicio.ObtenerTiposRecetas();
            cboTiposRecetas.ValueMember = "id_tipo";
            cboTiposRecetas.DisplayMember = "tipo";
            cboTiposRecetas.SelectedIndex = -1;
        }

        private void CargarCboIngredientes()
        {
            cboIngredientes.DataSource = servicio.ObtenerIngredientes();
            cboIngredientes.ValueMember = "id_ingrediente";
            cboIngredientes.DisplayMember = "n_ingrediente";
            cboIngredientes.SelectedIndex = -1;
        }

        private void LimpiarCamposDeCarga()
        {
            txtNombre.Text =
                txtCheff.Text = "";

            cboTiposRecetas.SelectedIndex =
                cboIngredientes.SelectedIndex = -1;

            NUPIngredientes.Value = 1;

            dgvIngredientes.Rows.Clear();        
        }

        private void FrmAltaRecetas_Load(object sender, EventArgs e)
        {
            CargarCboTiposRecetas();
            CargarCboIngredientes();
            lblNroReceta.Text = lblNroReceta.Text + servicio.ObtenerIDproxReceta().ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(cboIngredientes.SelectedIndex == -1)
            {
                MessageBox.Show("Debe elegir un ingrediente antes de agregar", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach(DetalleReceta dr in oReceta.Detalles)
            {
                if (dr.Ingrediente.Nombre == cboIngredientes.Text)
                {
                    MessageBox.Show("Ese ingrediente ya existe en esta receta!",
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }
            }

            Ingrediente ingrediente = new Ingrediente();
            ingrediente.ID = Convert.ToInt32(cboIngredientes.SelectedValue);
            ingrediente.Nombre = cboIngredientes.Text;

            DetalleReceta detalle = new DetalleReceta(ingrediente, (int)NUPIngredientes.Value);

            oReceta.AgregarDetalle(detalle);

            dgvIngredientes.Rows.Add(ingrediente.ID, ingrediente.Nombre, (int)NUPIngredientes.Value);
            cantidadIngredientes += 1;
            lblIngredientesTotales.Text = "Total de Ingredientes: "  + cantidadIngredientes.ToString();
        }

        private void dgvIngredientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvIngredientes.CurrentCell.ColumnIndex == 3)
            {
                oReceta.QuitarDetalle(dgvIngredientes.CurrentCell.RowIndex);
                dgvIngredientes.Rows.Remove(dgvIngredientes.CurrentRow);
                cantidadIngredientes -= 1;
                lblIngredientesTotales.Text = "Total de Ingredientes: " + cantidadIngredientes.ToString();
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre de receta", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCheff.Text == "")
            {
                MessageBox.Show("Debe ingresar un Cheff", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboTiposRecetas.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de receta", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cantidadIngredientes < 3)
            {
                MessageBox.Show("Debe ingresar como minimo 3 ingredientes", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Ha olvidado ingredientes?", "ERROR", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                oReceta.Nombre = txtNombre.Text;
                oReceta.Cheff = txtCheff.Text;
                oReceta.TipoReceta = (int)cboTiposRecetas.SelectedValue;
                if (servicio.CargarReceta(oReceta))
                {
                    MessageBox.Show("La receta se almaceno con exito", "Carga", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    LimpiarCamposDeCarga();
                }
                else
                {
                    MessageBox.Show("No se puedo almacenar la receta", "Carga", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
