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
            set { Model.Modelo=value; }
        }

        public string Matricula {
            get { return Model.Matricula; }
            set { Model.Matricula=value; }
        }  
    }
}
