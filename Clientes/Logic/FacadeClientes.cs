using Clientes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Logic {
    public class FacadeClientes {
        IDAOClientes datos;

        public FacadeClientes() {
            datos = DatosClientes.Instance;
        }

        public ObservableCollection<Cliente> ListarClientes() {
            return datos.ListarClientes();
        }

        public bool AgregarCliente(Cliente c) {
            return datos.AgregarCliente(c);
        }

        public void EliminarCliente(Cliente c) {
            datos.EliminarCliente(c);
        }

		public void ModificarCliente(Cliente c) {
			datos.ModificarCliente(c); 
		}

        public bool AgregarVehiculo(Vehiculo v) {
            return datos.AgregarVehiculo(v);
        }

        public void EliminarVehiculo(Vehiculo v) {
            datos.EliminarVehiculo(v);
        }

		public void ModificarVehiculo(Vehiculo v) {
			datos.ModificarVehiculo(v); 
		}

        public ObservableCollection<Vehiculo> ListarVehiculos() {
            return datos.ListarVehiculos(); 
        }
    }
}
