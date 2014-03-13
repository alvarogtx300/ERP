using Clientes.Models;
using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.ViewModels {
    public class ClienteVM : ViewModelBase<Cliente> {
        public string Nombre {
            get { return Model.Nombre; }
            set {
				if (string.IsNullOrWhiteSpace(value)) {
					Model.Nombre = value;
					OnPropertyChanged("IsClientOk");
					throw new ArgumentException("Debe escribir un nombre.");
				}
				else {
					Model.Nombre = value;
					OnPropertyChanged("IsClientOk");
				}
			}
        }

        public string Dni {
            get { return Model.Dni; }
			set {
				if (string.IsNullOrWhiteSpace(value)) {
					Model.Dni = value;
					OnPropertyChanged("IsClientOk");
					throw new ArgumentException("Debe escribir un dni.");
				}
				else {
					Model.Dni = value;
					OnPropertyChanged("IsClientOk");
				}
			}
        }

        public string Telefono {
			get { return Model.Telefono==0 ? "" : Convert.ToString(Model.Telefono); }
            set {
				long num=0;
				if (long.TryParse(value, out num))
					if (num > 0) {
						Model.Telefono = num;
						OnPropertyChanged("IsClientOk");
					}
					else {
						Model.Telefono = 0;
						OnPropertyChanged("IsClientOk");
						throw new ArgumentException("Telefono no valido.");
					}
				else {
					Model.Telefono = 0;
					OnPropertyChanged("IsClientOk");
					throw new ArgumentException("Debe escribir un número.");
				}
			}
        }

		public bool IsClientOk {
			get {
				return !string.IsNullOrWhiteSpace(Nombre) && !string.IsNullOrWhiteSpace(Dni) && !string.IsNullOrWhiteSpace(Telefono);
			}
		}
    }
}
