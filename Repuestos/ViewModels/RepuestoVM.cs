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
			get { return Model.Codigo==0 ? "" : Model.Codigo.ToString(); }
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
			set { 
				if(!string.IsNullOrWhiteSpace(value))
					Model.Nombre = value; 
				else
					throw new ArgumentException("Debe escribir un nombre");
			}
		}

		public string precio;
		public string Precio {
			get {
				precio = precio ?? Model.Precio.ToString("0.#0");
				return precio=="0,00" ? "" : precio;
			}
			set {
				double num;
				if (!String.IsNullOrWhiteSpace(value) && double.TryParse(value, out num)) {
					num = Convert.ToDouble(value);
					if (num > 0) {
						precio = value;
						Model.Precio = num;
					}
					else
						throw new ArgumentException("Debe ser un numero positivo");
				}
				else
					throw new ArgumentException("Debe escribir un número");
			}
		}

		public string NumArticulos {
			get { return Model.NumArticulos==0 ? "" : Model.NumArticulos.ToString(); }
			set {
				int num;
				if (!String.IsNullOrWhiteSpace(value) && int.TryParse(value, out num))
					if (num > 0)
						Model.NumArticulos = num;
					else
						throw new ArgumentException("Debe ser un numero positivo");
				else
					throw new ArgumentException("Debe escribir un número");
			}
		}
	}
}
