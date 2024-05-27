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
using Microsoft.VisualBasic;
using System.IO;

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
            if (rdDiesel.Checked)
            {
                dato.Opcion = "Diesel";
            }
            else if (rdSuper.Checked)
            {
                dato.Opcion = "Super";

            }
            if (rdbprepago.Checked)
            {
                dato.Tipogasolina = "Prepago";
                dato.CantidadPedida = decimal.Parse(Interaction.InputBox("Ingrese la cantidad en Q "));
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
            string Archivo = @"C:\Users\kenri\OneDrive\Desktop\Proyecto\GasolineraPrograProyecto\bin\Debug\Datos.json";
            System.IO.File.WriteAllText(Archivo, DatosGuardar);
        }
    }
}
