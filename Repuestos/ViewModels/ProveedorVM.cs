using Framework;
using Repuestos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repuestos.ViewModels {
	public class ProveedorVM : ViewModelBase<Proveedor>{

		public string Cif {
			get { return Model.Cif; }
			set { Model.Cif = value; }
		}

		public string Nombre {
			get { return Model.Nombre; }
			set { Model.Nombre = value; }
		}

		public string Descripccion {
			get { return Model.Descripccion; }
			set { Model.Descripccion = value; }
		}
	}
}
