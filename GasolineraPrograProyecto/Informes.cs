using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasolineraPrograProyecto
{
    public partial class Informes : Form
    {
        List<clsDatos> Datoss = new List<clsDatos>();
        public Informes()
        {
            InitializeComponent();
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
            Form1 Menu = new Form1();
            Menu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ingreso FormIngreso = new Ingreso();
            FormIngreso.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileJSon = File.ReadAllText(@"C:\Users\user\source\repos\GasolineraPrograProyecto\GasolineraPrograProyecto\bin\Debug\Datos.json");
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(fileJSon,typeof(DataTable));
            dataGridView1.DataSource = dt;


        }


        void cargarClientes()
        {
            string archivo = "Datos.json";

            StreamReader jsonStream = File.OpenText(archivo);

            
            string json = jsonStream.ReadToEnd();

            jsonStream.Close();

            
            Datoss = JsonConvert.DeserializeObject<List<clsDatos>>(json);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cargarClientes();
            clsDatos tanquelleno = Datoss.FirstOrDefault(p => p.Opcion == tanquelleno.Opcion);

            if (Datoss != null)
            {
                clsDatos reporte = new clsDatos
                {
                    Nit = tanquelleno.Nit,
                    Nombre = tanquelleno.Nombre,
                    Fecha = tanquelleno.Fecha,
                    Opcion =tanquelleno.Opcion,
                    Tipogasolina = tanquelleno.Tipogasolina,

                };
                Datoss.Add(reporte);
            }

            dataGridView3.DataSource = null;
            dataGridView3.DataSource = Datoss;
            dataGridView3.Refresh();


        }


    }
    
}
