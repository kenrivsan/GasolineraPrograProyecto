﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasolineraPrograProyecto
{
    internal class clsDatos
    {
        string nit;
        string nombre;
        DateTime fecha;
        string opcion;
        string tipogasolina;
        double cantidadServida;
        double cantidadPedida;

        public string Nit { get => nit; set => nit = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Opcion { get => opcion; set => opcion = value; }
        public string Tipogasolina { get => tipogasolina; set => tipogasolina = value; }
        public double CantidadServida { get => cantidadServida; set => cantidadServida = value; }
        public double CantidadPedida { get => cantidadPedida; set => cantidadPedida = value; }
    }
}
