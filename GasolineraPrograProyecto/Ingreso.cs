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
using System.IO.Ports;

namespace GasolineraPrograProyecto
{   
    
    public partial class Ingreso : Form
    {
        List<clsDatos> datos = new List<clsDatos>();
        SerialPort serialPort;
        public Ingreso()
        {
            InitializeComponent();
          //  serialPort1.Open();
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
            if (rbDiesel.Checked)
            {
                dato.Opcion = "Diesel";
            }
            else if (rbSuper.Checked)
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
            EnviarDatosPorSerial(dato);
        }
        void GuardadoDatos()
        {
            string DatosGuardar = JsonConvert.SerializeObject(datos);
            string Archivo = @"C:\Users\Julian Vg\source\repos\GasolineraPrograProyecto\GasolineraPrograProyecto\bin\Debug\Datos.json";
            System.IO.File.WriteAllText(Archivo, DatosGuardar);
        }

        void EnviarDatosPorSerial(clsDatos dato)
        {
            try
            {
                serialPort1.Open();
                string jsonData = JsonConvert.SerializeObject(dato);
                serialPort1.WriteLine(jsonData);
                serialPort1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar datos: " + ex.Message);
            }

        }
        void limpieza()
        {
            txtNit.Text = string.Empty;
            txtNombre.Text = string.Empty;

            txtNit.Focus();
        }

        private void iconocerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconorestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconorestaurar.Visible = false;
            iconomaximizar.Visible = true;

        }

        private void iconominimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconomaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconorestaurar.Visible = true;
            iconomaximizar.Visible = false;
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {

        }
    }
}
