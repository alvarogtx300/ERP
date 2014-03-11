using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Models {
    class Vehiculo : ObservableObject {
        string modelo, matricula;
        Cliente relacionCliente; 

        public string Modelo {
            get { return modelo; }
            set { SetProperty(ref modelo, value, () => Modelo); } 
        }

        public string Matricula {
            get { return matricula; }
            set { SetProperty(ref matricula, value, () => Matricula); }
        }

        public Cliente RelacionCliente {
            get { return relacionCliente; }
            set { SetProperty(ref relacionCliente, value, () => RelacionCliente); }
        }

        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }

            return this.matricula == ((Vehiculo)obj).matricula;
        }
    }
}
