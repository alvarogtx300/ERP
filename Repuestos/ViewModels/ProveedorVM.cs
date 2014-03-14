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
			set {
				if (!string.IsNullOrWhiteSpace(value)) {
					Model.Cif = value;
					OnPropertyChanged("IsOK");
				}
				else {
					Model.Cif = value;
					OnPropertyChanged("IsOK");
					throw new ArgumentException("Debe escribir un CIF");
				}
			}
		}

		public string Nombre {
			get { return Model.Nombre; }
			set {
				if (!string.IsNullOrWhiteSpace(value)) {
					Model.Nombre = value;
					OnPropertyChanged("IsOK");
				}
				else {
					Model.Nombre = value;
					OnPropertyChanged("IsOK");
					throw new ArgumentException("Debe escribir un nombre");
				}
			}
		}

		public bool IsOK {
			get {
				return !string.IsNullOrWhiteSpace(Nombre) && !string.IsNullOrWhiteSpace(Cif);
			}
		}
	}
}
