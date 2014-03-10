using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repuestos.Models {
    class Repuesto : ObservableObject{
        private int codigo;
        private string nombre;
        private string direccion;
        private double precio;
        private int numArticulos;

        public int Codigo {
            get { return codigo; }
            set { SetProperty(ref codigo, value, () => Codigo); }
        }

        public string Nombre {
            get { return nombre; }
            set { SetProperty(ref nombre, value, () => Nombre); }
        }

        public string Direccion {
            get { return direccion; }
            set { SetProperty(ref direccion, value, () => Direccion); }
        }

        public double Precio {
            get { return precio; }
            set { SetProperty(ref precio, value, () => Precio); }
        }

        public int NumArticulos {
            get { return numArticulos; }
            set { SetProperty(ref numArticulos, value, () => NumArticulos); }
        }
    }
}
