using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Models {
    class Vehiculo : ObservableObject {
        string modelo, matricula;
        Cliente relacionCliente

        public string Modelo {
            get { return modelo; }
            set { SetProperty(ref modelo, value, () => Modelo); } 
        }

        public string Matricula {
            get { return matricula; }
            set { SetProperty(ref matricula, value, () => Matricula); }
        }

        public Cliente RelacionCliente {
            get { return matricula; }
            set { SetProperty(ref matricula, value, () => Matricula); }
        }  
    }
}
