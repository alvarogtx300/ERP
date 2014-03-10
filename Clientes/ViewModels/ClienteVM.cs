using Clientes.Models;
using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.ViewModels {
    class ClienteVM : ViewModelBase<Cliente> {
        public string Nombre {
            get { return Model.Nombre; }
            set { Model.Nombre=value; }
        }

        public string Apellidos {
            get { return Model.Apellidos; }
            set { Model.Apellidos=value; }
        }

        public string Dni {
            get { return Model.Dni; }
            set { Model.Dni=value; }
        }

        public string Direccion {
            get { return Model.Direccion; }
            set { Model.Direccion=value; }
        }

        public long Telefono {
            get { return Model.Telefono; }
            set { Model.Telefono=value; }
        }
    }
}
