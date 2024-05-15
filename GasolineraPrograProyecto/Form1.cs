using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasolineraPrograProyecto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnslide_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 164)
            { 
                MenuVertical.Width = 57;
            
            }
            else
            {
                MenuVertical.Width = 164;
            }
        }

        private void iconocerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void iconorestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconorestaurar.Visible = false;
            iconomaximizar .Visible = true;
        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            Ingreso FormIngreso = new Ingreso();
            FormIngreso.Show();
            this.Hide();

        }

        private void btnInformes_Click(object sender, EventArgs e)
        {
            Informes FormInformes = new Informes();
            FormInformes.Show();
            this.Hide();
            
        }
    }
}
