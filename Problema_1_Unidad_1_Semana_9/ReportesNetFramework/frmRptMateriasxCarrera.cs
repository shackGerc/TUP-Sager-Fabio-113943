using Microsoft.Reporting.WinForms;
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

namespace ReportesNetFramework
{
    public partial class frmRptMateriasxCarrera : Form
    {
        public frmRptMateriasxCarrera()
        {
            InitializeComponent();
        }

        private async void frmRptMateriasxCarrera_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            string url = "http://localhost:5225/GetMateriasXCarrera";
            var data = await ClienteSingleton.ObtenerInstancia().GetAsync(url);
            DataTable Table = JsonConvert.DeserializeObject<DataTable>(data);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet", Table));
            this.reportViewer1.RefreshReport();
        }
    }
}
