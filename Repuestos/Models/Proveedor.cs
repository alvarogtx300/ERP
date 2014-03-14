using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repuestos.Models {
	public class Proveedor : ObservableObject{
		private string cif;
		private string nombre;
		private string descripcion;

		public string Cif { 
			get{ return cif; }
			set{ SetProperty(ref cif, value, () => Cif); }
		}

		public string Nombre {
			get { return nombre; }
			set { SetProperty(ref nombre, value, () => Nombre); }
		}

		public string Descripcion {
			get { return descripcion; }
			set { SetProperty(ref descripcion, value, () => Descripcion); }
		}

		public override bool Equals(object obj) {
			if (obj == null || GetType() != obj.GetType()) {
				return false;
			}
			
			return this.cif==((Proveedor)obj).cif;			
		}
	}
}
