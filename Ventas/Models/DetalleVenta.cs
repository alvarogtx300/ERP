using Framework;
using Repuestos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Models {
    public class DetalleVenta : ObservableObject {
        private Repuesto repuesto;
        private int cantidad;

        public Repuesto Repuesto {
            get { return repuesto; }
            set { SetProperty(ref repuesto, value, () => Repuesto); }
        }

        public int Cantidad {
            get { return cantidad; }
            set { SetProperty(ref cantidad, value, () => Cantidad); }
        }

        public double Suma {
            get { return cantidad * repuesto.Precio; }
        }
    }
}
