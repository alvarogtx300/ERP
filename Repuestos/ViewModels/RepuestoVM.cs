using Framework;
using Repuestos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repuestos.ViewModels {
	public class RepuestoVM : ViewModelBase<Repuesto>{

		public string Codigo {
			get { return Convert.ToString(Model.Codigo); }
			set { 
				int num;
				if (!String.IsNullOrWhiteSpace(value) && int.TryParse(value, out num))
					if (num > 0)
						Model.Codigo = num;
					else
						throw new ArgumentException("Debe ser un numero positivo");
				else
					throw new ArgumentException("Debe escribir un número");
			}
		}

		public string Nombre {
			get { return Model.Nombre; }
			set { Model.Nombre = value; }
		}

		public string Descripcion {
			get { return Model.Descripcion; }
			set { Model.Descripcion = value; }
		}

		public double Precio {
			get { return Model.Precio; }
			set { Model.Precio = value; }
		}

		public int NumArticulos {
			get { return Model.NumArticulos; }
			set { Model.NumArticulos = value; }
		}
	}
}
