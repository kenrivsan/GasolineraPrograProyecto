using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GasolineraPrograProyecto
{   
    
    public partial class Ingreso : Form
    {
        List<clsDatos> datos = new List<clsDatos>();
        public Ingreso()
        {
            InitializeComponent();
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsDatos dato = new clsDatos();
            dato.Nit = txtNit.Text;
            dato.Nombre = txtNombre.Text;
            dato.Fecha = dateTimeHora.Value;
            dato.Tipogasolina = cmbGasolina.SelectedIndex.ToString();
            if (rdbprepago.Checked)
            {
                dato.Tipogasolina = "Prepago";
            }
            else if (rdbprepagolleno.Checked)
            {
                dato.Tipogasolina = "PrepagoLleno";
            }
            datos.Add(dato);
            GuardadoDatos();

        }
        void GuardadoDatos()
        {
            string DatosGuardar = JsonConvert.SerializeObject(datos);
            string Archivo = "Datos.json";
            System.IO.File.WriteAllText(Archivo, DatosGuardar);
        }
    }
}
