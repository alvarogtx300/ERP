using Clientes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Logic {
    interface IDAOClientes {
        ObservableCollection<Cliente> ListarClientes();
        bool AgregarCliente(Cliente c);
        void EliminarCliente(Cliente c);
        void ModificarCliente(Cliente c);

        ObservableCollection<Vehiculo> ListarVehiculos();
        bool AgregarVehiculo(Vehiculo c);
        void ModificarVehiculo(Vehiculo c);
        void EliminarVehiculo(Vehiculo c);
    }
}
