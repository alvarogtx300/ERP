using Clientes.Models;
using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.ViewModels {
    public class VehiculoVM : ViewModelBase<Vehiculo> {
        public string Modelo {
            get { return Model.Modelo; }
            set {
				if (string.IsNullOrWhiteSpace(value)) {
					Model.Modelo = value;
					OnPropertyChanged("IsOk");
					throw new ArgumentException("Debe escribir un modelo.");
				}
				else {
					Model.Modelo = value;
					OnPropertyChanged("IsOk");
				}
			}
        }

        public string Matricula {
            get { return Model.Matricula; }
            set {
				if (string.IsNullOrWhiteSpace(value)) {
					Model.Matricula = value;
					OnPropertyChanged("IsOk");
					throw new ArgumentException("Debe escribir una matricula.");
				}
				else {
					Model.Matricula = value;
					OnPropertyChanged("IsOk");
				}
			}
        }

        public Cliente RelacionCliente {
            get { return Model.RelacionCliente; }
            set {
                Model.RelacionCliente = value;
                OnPropertyChanged("IsOk"); 
            }
        }

        public string DatosDuenio {
            get { return Model.RelacionCliente.Nombre + " " + Model.RelacionCliente.Apellidos; }
        }

		public bool IsOk {
			get {
				return !string.IsNullOrWhiteSpace(Modelo) && !string.IsNullOrWhiteSpace(Matricula) && Model.RelacionCliente!=null;
			}
		}
    }
}
