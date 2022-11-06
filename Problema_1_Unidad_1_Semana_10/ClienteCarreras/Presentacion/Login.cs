using ClienteCarreras.Cliente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace ClienteCarreras.Presentacion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:5225/usuario" +
                "?nombre=" + txtNombre.Text + "&contrasenia=" + txtContrasenia.Text;
            var resultado = await ClienteSingleton.ObtenerInstancia().GetAsync(url);

            if (JsonConvert.DeserializeObject<bool>(resultado))
            {
                frmPrincipal principal = new frmPrincipal();
                principal.ShowDialog();
            }
            else
                MessageBox.Show("Credenciales no encontradas", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
    }
}
