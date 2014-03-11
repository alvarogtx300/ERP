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
		private string descripcion;
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

		public string Descripcion {
			get { return descripcion; }
			set { SetProperty(ref descripcion, value, () => Descripcion); }
		}

		public double Precio {
			get { return precio; }
			set { SetProperty(ref precio, value, () => Precio); }
		}

		public int NumArticulos {
			get { return numArticulos; }
			set { SetProperty(ref numArticulos, value, () => NumArticulos); }
		}

		public override bool Equals(object obj) {
			if (obj == null || GetType() != obj.GetType()) {
				return false;
			}

			return this.codigo == ((Repuesto)obj).codigo;
		}
	}
}
